<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ComboBoxPort = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OnlyCorrectBar = New System.Windows.Forms.RadioButton()
        Me.BothLevers_RepeatAfterError = New System.Windows.Forms.RadioButton()
        Me.BothBars = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxInterIncorr = New System.Windows.Forms.TextBox()
        Me.TextBoxInterCorr = New System.Windows.Forms.TextBox()
        Me.TextBoxInterPrime = New System.Windows.Forms.TextBox()
        Me.TextBoxTrials = New System.Windows.Forms.TextBox()
        Me.TextBoxPrime = New System.Windows.Forms.TextBox()
        Me.TextBoxTime = New System.Windows.Forms.TextBox()
        Me.TextBoxPump = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonSimRight = New System.Windows.Forms.Button()
        Me.ButtonSimLeft = New System.Windows.Forms.Button()
        Me.ButtonReward = New System.Windows.Forms.Button()
        Me.ButtonPump = New System.Windows.Forms.Button()
        Me.ButtonTime = New System.Windows.Forms.Button()
        Me.ButtonPrime = New System.Windows.Forms.Button()
        Me.ButtonInterPrime = New System.Windows.Forms.Button()
        Me.ButtonTrials = New System.Windows.Forms.Button()
        Me.ButtonInterIncorr = New System.Windows.Forms.Button()
        Me.ButtonInterCorr = New System.Windows.Forms.Button()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.timerLabel = New System.Windows.Forms.Label()
        Me.LabelLeftPressed = New System.Windows.Forms.Label()
        Me.LabelRightPressed = New System.Windows.Forms.Label()
        Me.LabelSimLeftPressed = New System.Windows.Forms.Label()
        Me.LabelSimRightPressed = New System.Windows.Forms.Label()
        Me.LabelNumSimLeftPressed = New System.Windows.Forms.Label()
        Me.LabelNumLeftPressed = New System.Windows.Forms.Label()
        Me.LabelNumRightPressed = New System.Windows.Forms.Label()
        Me.LabelNumSimRightPressed = New System.Windows.Forms.Label()
        Me.LabelCorr = New System.Windows.Forms.Label()
        Me.LabelIncorr = New System.Windows.Forms.Label()
        Me.LabelMissed = New System.Windows.Forms.Label()
        Me.LabelNumCorr = New System.Windows.Forms.Label()
        Me.LabelNumIncorr = New System.Windows.Forms.Label()
        Me.LabelNumMissed = New System.Windows.Forms.Label()
        Me.ButtonTrialMaxTime = New System.Windows.Forms.Button()
        Me.TextBoxTrialMaxTime = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.ButtonBlackout = New System.Windows.Forms.Button()
        Me.TextBoxBlackout = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonIncForced = New System.Windows.Forms.Button()
        Me.TextBoxIncForced = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RadioButtonOnlyRight = New System.Windows.Forms.RadioButton()
        Me.OnlyLeftStim = New System.Windows.Forms.RadioButton()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(118, 504)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 0
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ComboBoxPort
        '
        Me.ComboBoxPort.FormattingEnabled = True
        Me.ComboBoxPort.Location = New System.Drawing.Point(95, 12)
        Me.ComboBoxPort.Name = "ComboBoxPort"
        Me.ComboBoxPort.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Animal Name"
        '
        'ButtonStop
        '
        Me.ButtonStop.Enabled = False
        Me.ButtonStop.Location = New System.Drawing.Point(204, 504)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStop.TabIndex = 4
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Number Of Prime Trials"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(101, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Number Trials"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reward Pump Time(s)"
        '
        'OnlyCorrectBar
        '
        Me.OnlyCorrectBar.AutoSize = True
        Me.OnlyCorrectBar.Location = New System.Drawing.Point(27, 86)
        Me.OnlyCorrectBar.Name = "OnlyCorrectBar"
        Me.OnlyCorrectBar.Size = New System.Drawing.Size(102, 17)
        Me.OnlyCorrectBar.TabIndex = 9
        Me.OnlyCorrectBar.TabStop = True
        Me.OnlyCorrectBar.Text = "Only Correct Bar"
        Me.OnlyCorrectBar.UseVisualStyleBackColor = True
        '
        'BothLevers_RepeatAfterError
        '
        Me.BothLevers_RepeatAfterError.AutoSize = True
        Me.BothLevers_RepeatAfterError.Location = New System.Drawing.Point(147, 79)
        Me.BothLevers_RepeatAfterError.Name = "BothLevers_RepeatAfterError"
        Me.BothLevers_RepeatAfterError.Size = New System.Drawing.Size(129, 30)
        Me.BothLevers_RepeatAfterError.TabIndex = 10
        Me.BothLevers_RepeatAfterError.TabStop = True
        Me.BothLevers_RepeatAfterError.Text = "Both Bars with Stim" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Repeatition After Error"
        Me.BothLevers_RepeatAfterError.UseVisualStyleBackColor = True
        '
        'BothBars
        '
        Me.BothBars.AutoSize = True
        Me.BothBars.Location = New System.Drawing.Point(293, 86)
        Me.BothBars.Name = "BothBars"
        Me.BothBars.Size = New System.Drawing.Size(71, 17)
        Me.BothBars.TabIndex = 11
        Me.BothBars.TabStop = True
        Me.BothBars.Text = "Both Bars"
        Me.BothBars.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(91, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Total Time (min)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Time Between Prime (s)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Time Between Correct Trial (s)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(157, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Time Between Incorrect Trial (s)"
        '
        'TextBoxInterIncorr
        '
        Me.TextBoxInterIncorr.Location = New System.Drawing.Point(179, 333)
        Me.TextBoxInterIncorr.Name = "TextBoxInterIncorr"
        Me.TextBoxInterIncorr.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxInterIncorr.TabIndex = 17
        '
        'TextBoxInterCorr
        '
        Me.TextBoxInterCorr.Location = New System.Drawing.Point(179, 304)
        Me.TextBoxInterCorr.Name = "TextBoxInterCorr"
        Me.TextBoxInterCorr.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxInterCorr.TabIndex = 18
        '
        'TextBoxInterPrime
        '
        Me.TextBoxInterPrime.Location = New System.Drawing.Point(179, 278)
        Me.TextBoxInterPrime.Name = "TextBoxInterPrime"
        Me.TextBoxInterPrime.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxInterPrime.TabIndex = 19
        '
        'TextBoxTrials
        '
        Me.TextBoxTrials.Location = New System.Drawing.Point(179, 175)
        Me.TextBoxTrials.Name = "TextBoxTrials"
        Me.TextBoxTrials.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTrials.TabIndex = 21
        '
        'TextBoxPrime
        '
        Me.TextBoxPrime.Location = New System.Drawing.Point(178, 149)
        Me.TextBoxPrime.Name = "TextBoxPrime"
        Me.TextBoxPrime.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPrime.TabIndex = 22
        '
        'TextBoxTime
        '
        Me.TextBoxTime.Location = New System.Drawing.Point(179, 227)
        Me.TextBoxTime.Name = "TextBoxTime"
        Me.TextBoxTime.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTime.TabIndex = 23
        '
        'TextBoxPump
        '
        Me.TextBoxPump.Location = New System.Drawing.Point(179, 201)
        Me.TextBoxPump.Name = "TextBoxPump"
        Me.TextBoxPump.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxPump.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Port"
        '
        'ButtonSimRight
        '
        Me.ButtonSimRight.Enabled = False
        Me.ButtonSimRight.Location = New System.Drawing.Point(203, 446)
        Me.ButtonSimRight.Name = "ButtonSimRight"
        Me.ButtonSimRight.Size = New System.Drawing.Size(161, 23)
        Me.ButtonSimRight.TabIndex = 27
        Me.ButtonSimRight.Text = "Simulate Right Bar (F2)"
        Me.ButtonSimRight.UseVisualStyleBackColor = True
        '
        'ButtonSimLeft
        '
        Me.ButtonSimLeft.Enabled = False
        Me.ButtonSimLeft.Location = New System.Drawing.Point(34, 446)
        Me.ButtonSimLeft.Name = "ButtonSimLeft"
        Me.ButtonSimLeft.Size = New System.Drawing.Size(162, 23)
        Me.ButtonSimLeft.TabIndex = 26
        Me.ButtonSimLeft.Text = "Simulate Left Bar (F1)"
        Me.ButtonSimLeft.UseVisualStyleBackColor = True
        '
        'ButtonReward
        '
        Me.ButtonReward.Enabled = False
        Me.ButtonReward.Location = New System.Drawing.Point(118, 475)
        Me.ButtonReward.Name = "ButtonReward"
        Me.ButtonReward.Size = New System.Drawing.Size(161, 23)
        Me.ButtonReward.TabIndex = 28
        Me.ButtonReward.Text = "Deliver Extra Reward (F3)"
        Me.ButtonReward.UseVisualStyleBackColor = True
        '
        'ButtonPump
        '
        Me.ButtonPump.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonPump.Enabled = False
        Me.ButtonPump.Location = New System.Drawing.Point(285, 201)
        Me.ButtonPump.Name = "ButtonPump"
        Me.ButtonPump.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPump.TabIndex = 29
        Me.ButtonPump.Text = "Issue"
        Me.ButtonPump.UseVisualStyleBackColor = True
        '
        'ButtonTime
        '
        Me.ButtonTime.Enabled = False
        Me.ButtonTime.Location = New System.Drawing.Point(285, 225)
        Me.ButtonTime.Name = "ButtonTime"
        Me.ButtonTime.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTime.TabIndex = 30
        Me.ButtonTime.Text = "Issue"
        Me.ButtonTime.UseVisualStyleBackColor = True
        '
        'ButtonPrime
        '
        Me.ButtonPrime.Enabled = False
        Me.ButtonPrime.Location = New System.Drawing.Point(284, 147)
        Me.ButtonPrime.Name = "ButtonPrime"
        Me.ButtonPrime.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPrime.TabIndex = 31
        Me.ButtonPrime.Text = "Issue"
        Me.ButtonPrime.UseVisualStyleBackColor = True
        '
        'ButtonInterPrime
        '
        Me.ButtonInterPrime.Enabled = False
        Me.ButtonInterPrime.Location = New System.Drawing.Point(284, 276)
        Me.ButtonInterPrime.Name = "ButtonInterPrime"
        Me.ButtonInterPrime.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInterPrime.TabIndex = 34
        Me.ButtonInterPrime.Text = "Issue"
        Me.ButtonInterPrime.UseVisualStyleBackColor = True
        '
        'ButtonTrials
        '
        Me.ButtonTrials.Enabled = False
        Me.ButtonTrials.Location = New System.Drawing.Point(285, 173)
        Me.ButtonTrials.Name = "ButtonTrials"
        Me.ButtonTrials.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTrials.TabIndex = 32
        Me.ButtonTrials.Text = "Issue"
        Me.ButtonTrials.UseVisualStyleBackColor = True
        '
        'ButtonInterIncorr
        '
        Me.ButtonInterIncorr.Enabled = False
        Me.ButtonInterIncorr.Location = New System.Drawing.Point(284, 331)
        Me.ButtonInterIncorr.Name = "ButtonInterIncorr"
        Me.ButtonInterIncorr.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInterIncorr.TabIndex = 36
        Me.ButtonInterIncorr.Text = "Issue"
        Me.ButtonInterIncorr.UseVisualStyleBackColor = True
        '
        'ButtonInterCorr
        '
        Me.ButtonInterCorr.Enabled = False
        Me.ButtonInterCorr.Location = New System.Drawing.Point(284, 302)
        Me.ButtonInterCorr.Name = "ButtonInterCorr"
        Me.ButtonInterCorr.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInterCorr.TabIndex = 35
        Me.ButtonInterCorr.Text = "Issue"
        Me.ButtonInterCorr.UseVisualStyleBackColor = True
        '
        'TextBoxName
        '
        Me.TextBoxName.Location = New System.Drawing.Point(95, 43)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxName.TabIndex = 37
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(240, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Elapsed time"
        '
        'timerLabel
        '
        Me.timerLabel.AutoSize = True
        Me.timerLabel.Location = New System.Drawing.Point(309, 31)
        Me.timerLabel.Name = "timerLabel"
        Me.timerLabel.Size = New System.Drawing.Size(49, 13)
        Me.timerLabel.TabIndex = 39
        Me.timerLabel.Text = "00:00:00"
        '
        'LabelLeftPressed
        '
        Me.LabelLeftPressed.AutoSize = True
        Me.LabelLeftPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLeftPressed.Location = New System.Drawing.Point(71, 531)
        Me.LabelLeftPressed.Name = "LabelLeftPressed"
        Me.LabelLeftPressed.Size = New System.Drawing.Size(80, 16)
        Me.LabelLeftPressed.TabIndex = 40
        Me.LabelLeftPressed.Text = "LeftPressed"
        '
        'LabelRightPressed
        '
        Me.LabelRightPressed.AutoSize = True
        Me.LabelRightPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRightPressed.Location = New System.Drawing.Point(207, 531)
        Me.LabelRightPressed.Name = "LabelRightPressed"
        Me.LabelRightPressed.Size = New System.Drawing.Size(90, 16)
        Me.LabelRightPressed.TabIndex = 41
        Me.LabelRightPressed.Text = "RightPressed"
        '
        'LabelSimLeftPressed
        '
        Me.LabelSimLeftPressed.AutoSize = True
        Me.LabelSimLeftPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSimLeftPressed.Location = New System.Drawing.Point(45, 558)
        Me.LabelSimLeftPressed.Name = "LabelSimLeftPressed"
        Me.LabelSimLeftPressed.Size = New System.Drawing.Size(106, 16)
        Me.LabelSimLeftPressed.TabIndex = 42
        Me.LabelSimLeftPressed.Text = "Sim LeftPressed"
        '
        'LabelSimRightPressed
        '
        Me.LabelSimRightPressed.AutoSize = True
        Me.LabelSimRightPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSimRightPressed.Location = New System.Drawing.Point(183, 558)
        Me.LabelSimRightPressed.Name = "LabelSimRightPressed"
        Me.LabelSimRightPressed.Size = New System.Drawing.Size(116, 16)
        Me.LabelSimRightPressed.TabIndex = 43
        Me.LabelSimRightPressed.Text = "Sim RightPressed"
        '
        'LabelNumSimLeftPressed
        '
        Me.LabelNumSimLeftPressed.AutoSize = True
        Me.LabelNumSimLeftPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumSimLeftPressed.Location = New System.Drawing.Point(162, 558)
        Me.LabelNumSimLeftPressed.Name = "LabelNumSimLeftPressed"
        Me.LabelNumSimLeftPressed.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumSimLeftPressed.TabIndex = 44
        Me.LabelNumSimLeftPressed.Text = "0"
        '
        'LabelNumLeftPressed
        '
        Me.LabelNumLeftPressed.AutoSize = True
        Me.LabelNumLeftPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumLeftPressed.Location = New System.Drawing.Point(162, 531)
        Me.LabelNumLeftPressed.Name = "LabelNumLeftPressed"
        Me.LabelNumLeftPressed.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumLeftPressed.TabIndex = 45
        Me.LabelNumLeftPressed.Text = "0"
        '
        'LabelNumRightPressed
        '
        Me.LabelNumRightPressed.AutoSize = True
        Me.LabelNumRightPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumRightPressed.Location = New System.Drawing.Point(305, 531)
        Me.LabelNumRightPressed.Name = "LabelNumRightPressed"
        Me.LabelNumRightPressed.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumRightPressed.TabIndex = 46
        Me.LabelNumRightPressed.Text = "0"
        '
        'LabelNumSimRightPressed
        '
        Me.LabelNumSimRightPressed.AutoSize = True
        Me.LabelNumSimRightPressed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumSimRightPressed.Location = New System.Drawing.Point(305, 558)
        Me.LabelNumSimRightPressed.Name = "LabelNumSimRightPressed"
        Me.LabelNumSimRightPressed.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumSimRightPressed.TabIndex = 47
        Me.LabelNumSimRightPressed.Text = "0"
        '
        'LabelCorr
        '
        Me.LabelCorr.AutoSize = True
        Me.LabelCorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCorr.Location = New System.Drawing.Point(100, 582)
        Me.LabelCorr.Name = "LabelCorr"
        Me.LabelCorr.Size = New System.Drawing.Size(51, 16)
        Me.LabelCorr.TabIndex = 48
        Me.LabelCorr.Text = "Correct"
        '
        'LabelIncorr
        '
        Me.LabelIncorr.AutoSize = True
        Me.LabelIncorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIncorr.Location = New System.Drawing.Point(235, 582)
        Me.LabelIncorr.Name = "LabelIncorr"
        Me.LabelIncorr.Size = New System.Drawing.Size(59, 16)
        Me.LabelIncorr.TabIndex = 49
        Me.LabelIncorr.Text = "Incorrect"
        '
        'LabelMissed
        '
        Me.LabelMissed.AutoSize = True
        Me.LabelMissed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMissed.Location = New System.Drawing.Point(242, 606)
        Me.LabelMissed.Name = "LabelMissed"
        Me.LabelMissed.Size = New System.Drawing.Size(52, 16)
        Me.LabelMissed.TabIndex = 50
        Me.LabelMissed.Text = "Missed"
        '
        'LabelNumCorr
        '
        Me.LabelNumCorr.AutoSize = True
        Me.LabelNumCorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumCorr.Location = New System.Drawing.Point(161, 582)
        Me.LabelNumCorr.Name = "LabelNumCorr"
        Me.LabelNumCorr.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumCorr.TabIndex = 51
        Me.LabelNumCorr.Text = "0"
        '
        'LabelNumIncorr
        '
        Me.LabelNumIncorr.AutoSize = True
        Me.LabelNumIncorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumIncorr.Location = New System.Drawing.Point(305, 582)
        Me.LabelNumIncorr.Name = "LabelNumIncorr"
        Me.LabelNumIncorr.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumIncorr.TabIndex = 52
        Me.LabelNumIncorr.Text = "0"
        '
        'LabelNumMissed
        '
        Me.LabelNumMissed.AutoSize = True
        Me.LabelNumMissed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumMissed.Location = New System.Drawing.Point(305, 606)
        Me.LabelNumMissed.Name = "LabelNumMissed"
        Me.LabelNumMissed.Size = New System.Drawing.Size(15, 16)
        Me.LabelNumMissed.TabIndex = 53
        Me.LabelNumMissed.Text = "0"
        '
        'ButtonTrialMaxTime
        '
        Me.ButtonTrialMaxTime.Enabled = False
        Me.ButtonTrialMaxTime.Location = New System.Drawing.Point(285, 250)
        Me.ButtonTrialMaxTime.Name = "ButtonTrialMaxTime"
        Me.ButtonTrialMaxTime.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTrialMaxTime.TabIndex = 56
        Me.ButtonTrialMaxTime.Text = "Issue"
        Me.ButtonTrialMaxTime.UseVisualStyleBackColor = True
        '
        'TextBoxTrialMaxTime
        '
        Me.TextBoxTrialMaxTime.Location = New System.Drawing.Point(179, 252)
        Me.TextBoxTrialMaxTime.Name = "TextBoxTrialMaxTime"
        Me.TextBoxTrialMaxTime.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTrialMaxTime.TabIndex = 55
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(82, 255)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Trial Max Time (s)"
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'ButtonBlackout
        '
        Me.ButtonBlackout.Enabled = False
        Me.ButtonBlackout.Location = New System.Drawing.Point(284, 357)
        Me.ButtonBlackout.Name = "ButtonBlackout"
        Me.ButtonBlackout.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBlackout.TabIndex = 59
        Me.ButtonBlackout.Text = "Issue"
        Me.ButtonBlackout.UseVisualStyleBackColor = True
        '
        'TextBoxBlackout
        '
        Me.TextBoxBlackout.Location = New System.Drawing.Point(179, 359)
        Me.TextBoxBlackout.Name = "TextBoxBlackout"
        Me.TextBoxBlackout.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxBlackout.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 362)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Time Blackout after Inc. Trial (s)"
        '
        'ButtonIncForced
        '
        Me.ButtonIncForced.Enabled = False
        Me.ButtonIncForced.Location = New System.Drawing.Point(285, 386)
        Me.ButtonIncForced.Name = "ButtonIncForced"
        Me.ButtonIncForced.Size = New System.Drawing.Size(75, 23)
        Me.ButtonIncForced.TabIndex = 62
        Me.ButtonIncForced.Text = "Issue"
        Me.ButtonIncForced.UseVisualStyleBackColor = True
        '
        'TextBoxIncForced
        '
        Me.TextBoxIncForced.Location = New System.Drawing.Point(179, 386)
        Me.TextBoxIncForced.Name = "TextBoxIncForced"
        Me.TextBoxIncForced.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxIncForced.TabIndex = 61
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(61, 389)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Number of Repetitions"
        '
        'RadioButtonOnlyRight
        '
        Me.RadioButtonOnlyRight.AutoSize = True
        Me.RadioButtonOnlyRight.Location = New System.Drawing.Point(210, 115)
        Me.RadioButtonOnlyRight.Name = "RadioButtonOnlyRight"
        Me.RadioButtonOnlyRight.Size = New System.Drawing.Size(97, 17)
        Me.RadioButtonOnlyRight.TabIndex = 63
        Me.RadioButtonOnlyRight.TabStop = True
        Me.RadioButtonOnlyRight.Text = "Only Right Stim"
        Me.RadioButtonOnlyRight.UseVisualStyleBackColor = True
        '
        'OnlyLeftStim
        '
        Me.OnlyLeftStim.AutoSize = True
        Me.OnlyLeftStim.Location = New System.Drawing.Point(73, 115)
        Me.OnlyLeftStim.Name = "OnlyLeftStim"
        Me.OnlyLeftStim.Size = New System.Drawing.Size(90, 17)
        Me.OnlyLeftStim.TabIndex = 64
        Me.OnlyLeftStim.TabStop = True
        Me.OnlyLeftStim.Text = "Only Left Stim"
        Me.OnlyLeftStim.UseVisualStyleBackColor = True
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 629)
        Me.Controls.Add(Me.OnlyLeftStim)
        Me.Controls.Add(Me.RadioButtonOnlyRight)
        Me.Controls.Add(Me.ButtonIncForced)
        Me.Controls.Add(Me.TextBoxIncForced)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ButtonBlackout)
        Me.Controls.Add(Me.TextBoxBlackout)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ButtonTrialMaxTime)
        Me.Controls.Add(Me.TextBoxTrialMaxTime)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LabelNumMissed)
        Me.Controls.Add(Me.LabelNumIncorr)
        Me.Controls.Add(Me.LabelNumCorr)
        Me.Controls.Add(Me.LabelMissed)
        Me.Controls.Add(Me.LabelIncorr)
        Me.Controls.Add(Me.LabelCorr)
        Me.Controls.Add(Me.LabelNumSimRightPressed)
        Me.Controls.Add(Me.LabelNumRightPressed)
        Me.Controls.Add(Me.LabelNumLeftPressed)
        Me.Controls.Add(Me.LabelNumSimLeftPressed)
        Me.Controls.Add(Me.LabelSimRightPressed)
        Me.Controls.Add(Me.LabelSimLeftPressed)
        Me.Controls.Add(Me.LabelRightPressed)
        Me.Controls.Add(Me.LabelLeftPressed)
        Me.Controls.Add(Me.timerLabel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBoxName)
        Me.Controls.Add(Me.ButtonInterIncorr)
        Me.Controls.Add(Me.ButtonInterCorr)
        Me.Controls.Add(Me.ButtonInterPrime)
        Me.Controls.Add(Me.ButtonTrials)
        Me.Controls.Add(Me.ButtonPrime)
        Me.Controls.Add(Me.ButtonTime)
        Me.Controls.Add(Me.ButtonPump)
        Me.Controls.Add(Me.ButtonReward)
        Me.Controls.Add(Me.ButtonSimRight)
        Me.Controls.Add(Me.ButtonSimLeft)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBoxPump)
        Me.Controls.Add(Me.TextBoxTime)
        Me.Controls.Add(Me.TextBoxPrime)
        Me.Controls.Add(Me.TextBoxTrials)
        Me.Controls.Add(Me.TextBoxInterPrime)
        Me.Controls.Add(Me.TextBoxInterCorr)
        Me.Controls.Add(Me.TextBoxInterIncorr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BothBars)
        Me.Controls.Add(Me.BothLevers_RepeatAfterError)
        Me.Controls.Add(Me.OnlyCorrectBar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxPort)
        Me.Controls.Add(Me.ButtonStart)
        Me.Name = "Form"
        Me.Text = "Marmoset Operant Box GUI"
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ComboBoxPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OnlyCorrectBar As System.Windows.Forms.RadioButton
    Friend WithEvents BothLevers_RepeatAfterError As System.Windows.Forms.RadioButton
    Friend WithEvents BothBars As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxInterIncorr As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxInterCorr As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxInterPrime As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTrials As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPrime As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTime As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPump As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimRight As System.Windows.Forms.Button
    Friend WithEvents ButtonSimLeft As System.Windows.Forms.Button
    Friend WithEvents ButtonReward As System.Windows.Forms.Button
    Friend WithEvents ButtonPump As System.Windows.Forms.Button
    Friend WithEvents ButtonTime As System.Windows.Forms.Button
    Friend WithEvents ButtonPrime As System.Windows.Forms.Button
    Friend WithEvents ButtonInterPrime As System.Windows.Forms.Button
    Friend WithEvents ButtonTrials As System.Windows.Forms.Button
    Friend WithEvents ButtonInterIncorr As System.Windows.Forms.Button
    Friend WithEvents ButtonInterCorr As System.Windows.Forms.Button
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents timerLabel As System.Windows.Forms.Label
    Friend WithEvents LabelLeftPressed As System.Windows.Forms.Label
    Friend WithEvents LabelRightPressed As System.Windows.Forms.Label
    Friend WithEvents LabelSimLeftPressed As System.Windows.Forms.Label
    Friend WithEvents LabelSimRightPressed As System.Windows.Forms.Label
    Friend WithEvents LabelNumSimLeftPressed As System.Windows.Forms.Label
    Friend WithEvents LabelNumLeftPressed As System.Windows.Forms.Label
    Friend WithEvents LabelNumRightPressed As System.Windows.Forms.Label
    Friend WithEvents LabelNumSimRightPressed As System.Windows.Forms.Label
    Friend WithEvents LabelCorr As System.Windows.Forms.Label
    Friend WithEvents LabelIncorr As System.Windows.Forms.Label
    Friend WithEvents LabelMissed As System.Windows.Forms.Label
    Friend WithEvents LabelNumCorr As System.Windows.Forms.Label
    Friend WithEvents LabelNumIncorr As System.Windows.Forms.Label
    Friend WithEvents LabelNumMissed As System.Windows.Forms.Label
    Friend WithEvents ButtonTrialMaxTime As System.Windows.Forms.Button
    Friend WithEvents TextBoxTrialMaxTime As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents ButtonBlackout As System.Windows.Forms.Button
    Friend WithEvents TextBoxBlackout As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonIncForced As System.Windows.Forms.Button
    Friend WithEvents TextBoxIncForced As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OnlyLeftStim As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOnlyRight As System.Windows.Forms.RadioButton

End Class
