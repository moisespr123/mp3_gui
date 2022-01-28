Public Class Form1
    Private Extensions As New List(Of String) From {".aiff", ".ape", ".flac", ".m4a", ".mp3", ".ogg", ".opus", ".wav"}
    Private hasmp3lame As Boolean = False
    Private haslibshine As Boolean = False
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
        If String.IsNullOrEmpty(InputTxt.Text) Then
            MessageBox.Show("The input path is empty.")
            Return
        End If
        If String.IsNullOrEmpty(OutputTxt.Text) Then
            MessageBox.Show("The output path is empty.")
            Return
        End If
        StartBtn.Enabled = False
        InputTxt.Enabled = False
        OutputTxt.Enabled = False
        InputBrowseBtn.Enabled = False
        OutputBrowseBtn.Enabled = False
        BitrateNumberBox.Enabled = False
        enableMultithreading.Enabled = False
        overwrite.Enabled = False
        mp3encoders.Enabled = False
        libmp3lameOptions.Enabled = False
        Dim StartTasks As New Threading.Thread(Sub() StartThreads())
        StartTasks.Start()
    End Sub

    Private Function Log(item As String, Optional action As Integer = 3) As String
        Dim logLine As String = Now.ToString() + " || " + IO.Path.GetFileName(item)
        If action = 1 Then
            Return logLine + " encoded."
        ElseIf action = 2 Then
            Return logLine + " copied."
        Else
            Return logLine + " already exist. Not overwriting."
        End If
    End Function
    Private Sub StartThreads()
        Dim logItems As New List(Of String)
        If Not IO.Directory.Exists(OutputTxt.Text) Then IO.Directory.CreateDirectory(OutputTxt.Text)
        Dim ItemsToProcess As List(Of String) = New List(Of String)
        Dim IgnoreFilesWithExtensions As String = String.Empty
        If IO.File.Exists("ignore.txt") Then IgnoreFilesWithExtensions = My.Computer.FileSystem.ReadAllText("ignore.txt")
        For Each File In IO.Directory.GetFiles(InputTxt.Text)
            If Extensions.Contains(IO.Path.GetExtension(File)) Then
                ItemsToProcess.Add(File)
            Else
                If Not IO.File.Exists(OutputTxt.Text + "\" + IO.Path.GetFileName(File)) Or overwrite.Checked Then
                    If Not IgnoreFilesWithExtensions.Contains(IO.Path.GetExtension(File)) Then IO.File.Copy(File, OutputTxt.Text + "\" + My.Computer.FileSystem.GetName(File), True)
                    logItems.Add(Log(File, 2))
                Else
                    logItems.Add(Log(File))
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
                outputPath = OutputTxt.Text + "\" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".mp3"
                If Not IO.File.Exists(outputPath) Or overwrite.Checked Then
                    Dim args As Array = {ItemsToProcess(Counter), outputPath, My.Settings.Bitrate}
                    tasks.Add(Sub() logItems.Add(run_ffmpeg(args)))
                Else
                    logItems.Add(Log(IO.Path.GetFileName(ItemsToProcess(Counter))))
                End If
            Next
            Parallel.Invoke(New ParallelOptions With {.MaxDegreeOfParallelism = Environment.ProcessorCount}, tasks.ToArray())
        Else
            For Counter As Integer = 0 To ItemsToProcess.Count - 1
                outputPath = OutputTxt.Text + "\" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".mp3"
                If Not IO.File.Exists(outputPath) Or overwrite.Checked Then
                    logItems.Add(run_ffmpeg({ItemsToProcess(Counter), outputPath, My.Settings.Bitrate}))
                Else
                    logItems.Add(Log(IO.Path.GetFileName(ItemsToProcess(Counter))))
                End If
            Next
        End If
        StartBtn.BeginInvoke(Sub()
                                 StartBtn.Enabled = True
                                 BitrateNumberBox.Enabled = True
                                 enableMultithreading.Enabled = True
                                 overwrite.Enabled = True
                                 InputTxt.Enabled = True
                                 OutputTxt.Enabled = True
                                 mp3encoders.Enabled = True
                                 libmp3lameOptions.Enabled = True
                                 InputBrowseBtn.Enabled = True
                                 OutputBrowseBtn.Enabled = True
                             End Sub)
        ResultsForm.ListBox1.DataSource = logItems
        ResultsForm.ShowDialog()
    End Sub
    Private Function run_ffmpeg(args As Array)
        Dim Input_File As String = args(0)
        Dim Output_File As String = args(1)
        Dim Bitrate As String = args(2)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        If My.Settings.libshine Then
            ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libshine -b:a " & Bitrate & "K  """ + Output_File + """ -y"
        ElseIf My.Settings.libmp3lame Then
            If Not My.Settings.useVBR Then
                ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libmp3lame -compression_level " + My.Settings.compression_level.ToString() + " -b:a " + Bitrate + "K """ + Output_File + """ -y"
            Else
                ffmpegProcessInfo.Arguments = "-i """ + Input_File + """ -c:a libmp3lame -q " + My.Settings.q.ToString() + " -compression_level " & My.Settings.compression_level.ToString() & " """ + Output_File + """ -y"
            End If
        End If
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        ProgressBar1.BeginInvoke(Sub() ProgressBar1.PerformStep())
        Return Log(IO.Path.GetFileName(Output_File), 1)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BitrateNumberBox.Value = My.Settings.Bitrate
        enableMultithreading.Checked = My.Settings.Multithreading
        overwrite.Checked = My.Settings.overwrite
        Try
            GetffmpegVersion()
        Catch
            MessageBox.Show("ffmpeg.exe was not found. Please download ffmpeg.")
            Process.Start("https://moisescardona.me/downloading-ffmpeg-for-use-with-my-media-tools-updated-guide/")
            Me.Close()
        End Try
        If hasmp3lame Then
            If My.Settings.libmp3lame Then
                libmp3lame.Checked = True
            Else
                libshine.Checked = True
            End If
        ElseIf haslibshine Then
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
                hasmp3lame = True
            End If
            If line.Contains("--enable-libshine") Then
                libshine.Enabled = True
                haslibshine = True
            End If
        End While
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        InputTxt.Text = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
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
        Else
            q.Enabled = False
        End If
    End Sub

    Private Sub libmp3lame_CheckedChanged(sender As Object, e As EventArgs) Handles libmp3lame.CheckedChanged
        My.Settings.libmp3lame = libmp3lame.Checked
        libmp3lameOptions.Enabled = libmp3lame.Checked
        My.Settings.Save()
    End Sub

    Private Sub libshine_CheckedChanged(sender As Object, e As EventArgs) Handles libshine.CheckedChanged
        My.Settings.libshine = libshine.Checked
        My.Settings.Save()
    End Sub

    Private Sub overwrite_CheckedChanged(sender As Object, e As EventArgs) Handles overwrite.CheckedChanged
        My.Settings.overwrite = overwrite.Checked
        My.Settings.Save()
    End Sub

    Private Sub Help_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Help.LinkClicked
        Process.Start("https://moisescardona.me/mp3-gui-help/")
    End Sub

End Class
