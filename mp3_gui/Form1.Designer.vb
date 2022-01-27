<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InputTxt = New System.Windows.Forms.TextBox()
        Me.OutputTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.InputBrowseBtn = New System.Windows.Forms.Button()
        Me.OutputBrowseBtn = New System.Windows.Forms.Button()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ffmpegVersionLabel = New System.Windows.Forms.Label()
        Me.BitrateNumberBox = New System.Windows.Forms.NumericUpDown()
        Me.enableMultithreading = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.libshine = New System.Windows.Forms.RadioButton()
        Me.libmp3lame = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Help = New System.Windows.Forms.LinkLabel()
        Me.compression_level = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.q = New System.Windows.Forms.NumericUpDown()
        Me.useVBR = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.overwrite = New System.Windows.Forms.CheckBox()
        CType(Me.BitrateNumberBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.compression_level, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.q, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1: Browse for Input folder with ffmpeg-compatible music Files:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Step 2: Browse for output folder for encoded MP3 files:"
        '
        'InputTxt
        '
        Me.InputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InputTxt.Location = New System.Drawing.Point(15, 26)
        Me.InputTxt.Name = "InputTxt"
        Me.InputTxt.Size = New System.Drawing.Size(415, 20)
        Me.InputTxt.TabIndex = 2
        '
        'OutputTxt
        '
        Me.OutputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputTxt.Location = New System.Drawing.Point(15, 68)
        Me.OutputTxt.Name = "OutputTxt"
        Me.OutputTxt.Size = New System.Drawing.Size(415, 20)
        Me.OutputTxt.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bitrate:"
        '
        'InputBrowseBtn
        '
        Me.InputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InputBrowseBtn.Location = New System.Drawing.Point(436, 24)
        Me.InputBrowseBtn.Name = "InputBrowseBtn"
        Me.InputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.InputBrowseBtn.TabIndex = 5
        Me.InputBrowseBtn.Text = "Browse"
        Me.InputBrowseBtn.UseVisualStyleBackColor = True
        '
        'OutputBrowseBtn
        '
        Me.OutputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputBrowseBtn.Location = New System.Drawing.Point(436, 68)
        Me.OutputBrowseBtn.Name = "OutputBrowseBtn"
        Me.OutputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.OutputBrowseBtn.TabIndex = 6
        Me.OutputBrowseBtn.Text = "Browse"
        Me.OutputBrowseBtn.UseVisualStyleBackColor = True
        '
        'StartBtn
        '
        Me.StartBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartBtn.Location = New System.Drawing.Point(294, 213)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(204, 37)
        Me.StartBtn.TabIndex = 8
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Progress:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 271)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(496, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "GUI by Moises Cardona"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(483, 327)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "v1.0"
        '
        'ffmpegVersionLabel
        '
        Me.ffmpegVersionLabel.AutoSize = True
        Me.ffmpegVersionLabel.Location = New System.Drawing.Point(12, 305)
        Me.ffmpegVersionLabel.Name = "ffmpegVersionLabel"
        Me.ffmpegVersionLabel.Size = New System.Drawing.Size(79, 13)
        Me.ffmpegVersionLabel.TabIndex = 14
        Me.ffmpegVersionLabel.Text = "ffmpeg version:"
        '
        'BitrateNumberBox
        '
        Me.BitrateNumberBox.Location = New System.Drawing.Point(15, 191)
        Me.BitrateNumberBox.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.BitrateNumberBox.Name = "BitrateNumberBox"
        Me.BitrateNumberBox.Size = New System.Drawing.Size(159, 20)
        Me.BitrateNumberBox.TabIndex = 15
        '
        'enableMultithreading
        '
        Me.enableMultithreading.AutoSize = True
        Me.enableMultithreading.Location = New System.Drawing.Point(15, 217)
        Me.enableMultithreading.Name = "enableMultithreading"
        Me.enableMultithreading.Size = New System.Drawing.Size(121, 17)
        Me.enableMultithreading.TabIndex = 16
        Me.enableMultithreading.Text = "Use Multi-Threading"
        Me.enableMultithreading.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.libshine)
        Me.GroupBox1.Controls.Add(Me.libmp3lame)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 65)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MP3 Encoder Library"
        '
        'libshine
        '
        Me.libshine.AutoSize = True
        Me.libshine.Enabled = False
        Me.libshine.Location = New System.Drawing.Point(6, 43)
        Me.libshine.Name = "libshine"
        Me.libshine.Size = New System.Drawing.Size(98, 17)
        Me.libshine.TabIndex = 1
        Me.libshine.TabStop = True
        Me.libshine.Text = "libshine (Faster)"
        Me.libshine.UseVisualStyleBackColor = True
        '
        'libmp3lame
        '
        Me.libmp3lame.AutoSize = True
        Me.libmp3lame.Enabled = False
        Me.libmp3lame.Location = New System.Drawing.Point(6, 19)
        Me.libmp3lame.Name = "libmp3lame"
        Me.libmp3lame.Size = New System.Drawing.Size(107, 17)
        Me.libmp3lame.TabIndex = 0
        Me.libmp3lame.TabStop = True
        Me.libmp3lame.Text = "libmp3lame (Best)"
        Me.libmp3lame.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Help)
        Me.GroupBox2.Controls.Add(Me.compression_level)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.q)
        Me.GroupBox2.Controls.Add(Me.useVBR)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(294, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(204, 110)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "libmp3lame options"
        '
        'Help
        '
        Me.Help.AutoSize = True
        Me.Help.Location = New System.Drawing.Point(169, 94)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(29, 13)
        Me.Help.TabIndex = 5
        Me.Help.TabStop = True
        Me.Help.Text = "Help"
        '
        'compression_level
        '
        Me.compression_level.Enabled = False
        Me.compression_level.Location = New System.Drawing.Point(108, 70)
        Me.compression_level.Name = "compression_level"
        Me.compression_level.Size = New System.Drawing.Size(53, 20)
        Me.compression_level.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Compression Level:"
        '
        'q
        '
        Me.q.Enabled = False
        Me.q.Location = New System.Drawing.Point(108, 42)
        Me.q.Name = "q"
        Me.q.Size = New System.Drawing.Size(53, 20)
        Me.q.TabIndex = 2
        '
        'useVBR
        '
        Me.useVBR.AutoSize = True
        Me.useVBR.Enabled = False
        Me.useVBR.Location = New System.Drawing.Point(6, 19)
        Me.useVBR.Name = "useVBR"
        Me.useVBR.Size = New System.Drawing.Size(119, 17)
        Me.useVBR.TabIndex = 1
        Me.useVBR.Text = "Use Variable Bitrate"
        Me.useVBR.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(60, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Quality:"
        '
        'overwrite
        '
        Me.overwrite.AutoSize = True
        Me.overwrite.Location = New System.Drawing.Point(15, 234)
        Me.overwrite.Name = "overwrite"
        Me.overwrite.Size = New System.Drawing.Size(130, 17)
        Me.overwrite.TabIndex = 19
        Me.overwrite.Text = "Overwrite existing files"
        Me.overwrite.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 358)
        Me.Controls.Add(Me.overwrite)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.enableMultithreading)
        Me.Controls.Add(Me.BitrateNumberBox)
        Me.Controls.Add(Me.ffmpegVersionLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StartBtn)
        Me.Controls.Add(Me.OutputBrowseBtn)
        Me.Controls.Add(Me.InputBrowseBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.OutputTxt)
        Me.Controls.Add(Me.InputTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "MP3 GUI"
        CType(Me.BitrateNumberBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.compression_level, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.q, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents InputTxt As TextBox
    Friend WithEvents OutputTxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents InputBrowseBtn As Button
    Friend WithEvents OutputBrowseBtn As Button
    Friend WithEvents StartBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ffmpegVersionLabel As Label
    Friend WithEvents BitrateNumberBox As NumericUpDown
    Friend WithEvents enableMultithreading As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents libshine As RadioButton
    Friend WithEvents libmp3lame As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents compression_level As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents q As NumericUpDown
    Friend WithEvents useVBR As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Help As LinkLabel
    Friend WithEvents overwrite As CheckBox
End Class
