Public Class Form1
    Private Extensions As New List(Of String) From {".aiff", ".ape", ".flac", ".m4a", ".mp3", ".ogg", ".opus", ".wav"}
    Private Sub InputBrowseBtn_Click(sender As Object, e As EventArgs) Handles InputBrowseBtn.Click
        Dim InputBrowser As New FolderBrowserDialog With {
            .ShowNewFolderButton = False
        }
        Dim OkAction As MsgBoxResult = InputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            InputTxt.Text = InputBrowser.SelectedPath
        End If
    End Sub

    Private Sub OutputBrowseBtn_Click(sender As Object, e As EventArgs) Handles OutputBrowseBtn.Click
        Dim OutputBrowser As New FolderBrowserDialog With {
            .ShowNewFolderButton = True
        }
        Dim OkAction As MsgBoxResult = OutputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            OutputTxt.Text = OutputBrowser.SelectedPath
        End If
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        StartBtn.Enabled = False
        InputTxt.Enabled = False
        OutputTxt.Enabled = False
        InputBrowseBtn.Enabled = False
        OutputBrowseBtn.Enabled = False
        BitrateNumberBox.Enabled = False
        enableMultithreading.Enabled = False
        Dim StartTasks As New Threading.Thread(Sub() StartThreads())
        StartTasks.Start()
    End Sub
    Private Sub StartThreads()
        If Not String.IsNullOrEmpty(OutputTxt.Text) Then If Not My.Computer.FileSystem.DirectoryExists(OutputTxt.Text) Then My.Computer.FileSystem.CreateDirectory(OutputTxt.Text)
        Dim ItemsToProcess As List(Of String) = New List(Of String)
        Dim IgnoreFilesWithExtensions As String = String.Empty
        If My.Computer.FileSystem.FileExists("ignore.txt") Then IgnoreFilesWithExtensions = My.Computer.FileSystem.ReadAllText("ignore.txt")
        For Each File In IO.Directory.GetFiles(InputTxt.Text)
            If Extensions.Contains(IO.Path.GetExtension(File)) Then
                ItemsToProcess.Add(File)
            Else
                If Not String.IsNullOrEmpty(OutputTxt.Text) Then
                    If Not My.Computer.FileSystem.FileExists(OutputTxt.Text + "\" + My.Computer.FileSystem.GetName(File)) Then
                        If Not IgnoreFilesWithExtensions.Contains(IO.Path.GetExtension(File)) Then My.Computer.FileSystem.CopyFile(File, OutputTxt.Text + "\" + My.Computer.FileSystem.GetName(File))
                    End If
                End If
            End If
        Next
        ProgressBar1.BeginInvoke(Sub()
                                     ProgressBar1.Maximum = ItemsToProcess.Count
                                     ProgressBar1.Value = 0
                                 End Sub
        )
        Dim tasks = New List(Of Action)
        Dim outputPath As String = ""
        If enableMultithreading.Checked Then
            For Counter As Integer = 0 To ItemsToProcess.Count - 1
                If Not String.IsNullOrEmpty(OutputTxt.Text) Then
                    outputPath = OutputTxt.Text + "\" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".mp3"
                End If
                Dim args As Array = {ItemsToProcess(Counter), outputPath, My.Settings.Bitrate}
                tasks.Add(Function() run_ffmpeg(args))
            Next
            Parallel.Invoke(New ParallelOptions With {.MaxDegreeOfParallelism = Environment.ProcessorCount}, tasks.ToArray())
        Else
            For Counter As Integer = 0 To ItemsToProcess.Count - 1
                If Not String.IsNullOrEmpty(OutputTxt.Text) Then
                    outputPath = OutputTxt.Text + "\" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".mp3"
                End If
                Dim args As Array = {ItemsToProcess(Counter), outputPath, My.Settings.Bitrate}
                run_ffmpeg(args)
            Next
        End If
        StartBtn.BeginInvoke(Sub()
                                 StartBtn.Enabled = True
                                 BitrateNumberBox.Enabled = True
                                 enableMultithreading.Enabled = True
                                 InputTxt.Enabled = True
                                 OutputTxt.Enabled = True
                                 InputBrowseBtn.Enabled = True
                                 OutputBrowseBtn.Enabled = True
                             End Sub)
        MsgBox("Finished")
    End Sub
    Private Function run_ffmpeg(args As Array)
        Dim Input_File As String = args(0)
        Dim Output_File As String = args(1)
        Dim Bitrate As String = args(2)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        If My.Settings.libshine Then
            ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libshine -b:a " & Bitrate & "K  """ + Output_File + """"
        ElseIf My.Settings.libmp3lame Then
            If Not My.Settings.useVBR Then
                ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libmp3lame -b:a " & Bitrate & "K  """ + Output_File + """"
            Else
                ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libmp3lame -q " & My.Settings.q.ToString() & " -compression_level " & My.Settings.compression_level.ToString() & " """ + Output_File + """"
            End If
        End If
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        ProgressBar1.BeginInvoke(Sub() ProgressBar1.PerformStep())
        Return True
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BitrateNumberBox.Value = My.Settings.Bitrate
        enableMultithreading.Checked = My.Settings.Multithreading
        Try
            GetffmpegVersion()
        Catch
            MessageBox.Show("ffmpeg.exe was not found. Exiting...")
            Me.Close()
        End Try
        If libmp3lame.Enabled Then
            If My.Settings.libmp3lame Then
                libmp3lame.Checked = True
            Else
                libshine.Checked = True
            End If
        ElseIf libshine.Enabled Then
            If My.Settings.libshine Then
                libshine.Checked = True
            Else
                libmp3lame.Checked = True
            End If
        End If
        useVBR.Checked = My.Settings.useVBR
        q.Value = My.Settings.q
        compression_level.Value = My.Settings.compression_level
    End Sub


    Private Sub GetffmpegVersion()
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-version"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = True
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        ffmpegVersionLabel.Text = "ffmpeg version: " + ffmpegProcess.StandardOutput.ReadLine()
        While Not ffmpegProcess.StandardOutput.EndOfStream
            Dim line As String = ffmpegProcess.StandardOutput.ReadLine
            If line.Contains("--enable-libmp3lame") Then
                libmp3lame.Enabled = True
            End If
            If line.Contains("--enable-libshine") Then
                libshine.Enabled = True
            End If
        End While
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles BitrateNumberBox.ValueChanged
        My.Settings.Bitrate = BitrateNumberBox.Value
        My.Settings.Save()
    End Sub

    Private Sub EnableMultithreading_CheckedChanged(sender As Object, e As EventArgs) Handles enableMultithreading.CheckedChanged
        My.Settings.Multithreading = enableMultithreading.Checked
        My.Settings.Save()
    End Sub

    Private Sub q_ValueChanged(sender As Object, e As EventArgs) Handles q.ValueChanged
        If q.Value > 9 Then
            q.Value = 9
        ElseIf q.Value < 0 Then
            q.Value = 0
        End If
        My.Settings.q = q.Value
        My.Settings.Save()
    End Sub

    Private Sub compression_level_ValueChanged(sender As Object, e As EventArgs) Handles compression_level.ValueChanged
        If compression_level.Value > 9 Then
            compression_level.Value = 9
        ElseIf compression_level.Value < 0 Then
            compression_level.Value = 0
        End If
        My.Settings.compression_level = compression_level.Value
        My.Settings.Save()
    End Sub

    Private Sub useVBR_CheckedChanged(sender As Object, e As EventArgs) Handles useVBR.CheckedChanged
        My.Settings.useVBR = useVBR.Checked
        My.Settings.Save()
        If useVBR.Checked And useVBR.Enabled Then
            q.Enabled = True
            compression_level.Enabled = True
        Else
            q.Enabled = False
            compression_level.Enabled = False
        End If
    End Sub

    Private Sub libmp3lame_CheckedChanged(sender As Object, e As EventArgs) Handles libmp3lame.CheckedChanged
        My.Settings.libmp3lame = libmp3lame.Checked
        My.Settings.Save()
        If libmp3lame.Checked Then
            useVBR.Enabled = True
            If useVBR.Checked Then
                q.Enabled = True
                compression_level.Enabled = True
            End If
        Else
            useVBR.Enabled = False
            q.Enabled = False
            compression_level.Enabled = False
        End If
    End Sub

    Private Sub libshine_CheckedChanged(sender As Object, e As EventArgs) Handles libshine.CheckedChanged
        My.Settings.libshine = libshine.Checked
        My.Settings.Save()
    End Sub
End Class
