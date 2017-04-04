Imports System.IO.Ports


Public Class Form
    '  Dim WithEvents SerialPort1 As New SerialPort

    Private parador As Boolean
    Dim file As System.IO.StreamWriter
    Dim startTime As DateTime
    Dim NumLeftPressed As Integer
    Dim NumRightPressed As Integer
    Dim NumSimLeftPressed As Integer
    Dim NumSimRightPressed As Integer
    Dim NumCorr As Integer
    Dim NumIncorr As Integer
    Dim NumMissed As Integer
    Dim RunType As Char


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        'Serial Port Configuration
        SerialPort1.Close()
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default

        TextBoxName.Text = 0

        TextBoxPump.Text = 1
        TextBoxTime.Text = 30
        TextBoxPrime.Text = 80
        TextBoxTrials.Text = 100        
        TextBoxInterPrime.Text = 10
        TextBoxInterCorr.Text = 10
        TextBoxInterIncorr.Text = 20
        TextBoxTrialMaxTime.Text = 100
        TextBoxBlackout.Text = 5
        TextBoxIncForced.Text = 2

        LabelNumLeftPressed.Text = 0
        LabelNumRightPressed.Text = 0
        LabelNumSimLeftPressed.Text = 0
        LabelNumSimRightPressed.Text = 0
        LabelNumCorr.Text = 0
        LabelNumIncorr.Text = 0
        LabelNumMissed.Text = 0

    End Sub
    Private Sub ComboBox1_DropDown(sender As System.Object, e As System.EventArgs) Handles ComboBoxPort.DropDown

        ComboBoxPort.Items.Clear()
        ' Show all available COM ports. 
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBoxPort.Items.Add(sp)
        Next

    End Sub
    Protected Overrides Sub Finalize()


        If (SerialPort1.IsOpen = True) Then

            SerialPort1.Close()
            SerialPort1.Write("t" & vbCr)
            Timer1.Stop()
            file.Close()

        End If

        MyBase.Finalize()

    End Sub

    Private Sub ComboBoxPort_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxPort.SelectedIndexChanged
        SerialPort1.PortName = ComboBoxPort.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        'Can only be avaiable if selected port is present

        Dim filename As String = Format(Date.Now(), "yyyyMMdd")
        Dim SessionType As String



        If OnlyCorrectBar.Checked = True Then
            RunType = "1"
            SessionType = OnlyCorrectBar.Name
        ElseIf BothLevers_RepeatAfterError.Checked = True Then
            RunType = "2"
            SessionType = BothLevers_RepeatAfterError.Name
        ElseIf BothBars.Checked = True Then
            RunType = "3"
            SessionType = BothBars.Name
        ElseIf OnlyLeftStim.Checked = True Then
            RunType = "4"
            SessionType = OnlyLeftStim.Name
        ElseIf RadioButtonOnlyRight.Checked = True Then
            RunType = "5"
            SessionType = RadioButtonOnlyRight.Name
        Else
            MsgBox("Choose the type of run")
            Exit Sub
        End If

        If ComboBoxPort.Text = "" Then
            MsgBox("Choose the port where arduino is connected")
            Exit Sub
        End If


        If IsNumeric(TextBoxPump.Text) = False Then
            MsgBox("Reward pump time is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxTime.Text) = False Then
            MsgBox("Session time is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxPrime.Text) = False Then
            MsgBox("Number of Primes is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxTrials.Text) = False Then
            MsgBox("Number of Trials is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxInterPrime.Text) = False Then
            MsgBox("Time between Prime trials is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxInterCorr.Text) = False Then
            MsgBox("Time between correct trials is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxInterIncorr.Text) = False Then
            MsgBox("Time between inorrect trials is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxTrialMaxTime.Text) = False Then
            MsgBox("Time before missing trial is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxBlackout.Text) = False Then
            MsgBox("Blackout Time is invalid")
            Exit Sub
        End If

        If IsNumeric(TextBoxIncForced.Text) = False Then
            MsgBox("Number of Incorrect Trials Allowed in Forced Sessions is invalid")
            Exit Sub
        End If

        If (ComboBoxPort.Text <> "") Then

            If (SerialPort1.IsOpen = False) Then


                SerialPort1.Open()
            End If

            SerialPort1.Write("c" & vbCr) 'clear serial

            SerialPort1.Write(TextBoxPump.Text * 1000)
            SerialPort1.Write("p" & vbCr)

            SerialPort1.Write(TextBoxTime.Text * 60 * 1000) 'Arduino wait for miliseconds time
            SerialPort1.Write("a" & vbCr)

            SerialPort1.Write(TextBoxPrime.Text)
            SerialPort1.Write("b" & vbCr)

            SerialPort1.Write(TextBoxTrials.Text)
            SerialPort1.Write("d" & vbCr)

            SerialPort1.Write(TextBoxInterPrime.Text * 1000)
            SerialPort1.Write("f" & vbCr)

            SerialPort1.Write(TextBoxInterCorr.Text * 1000) 'Arduino wait for miliseconds time
            SerialPort1.Write("g" & vbCr)

            SerialPort1.Write(TextBoxInterIncorr.Text * 1000) 'Arduino wait for miliseconds time
            SerialPort1.Write("h" & vbCr)

            SerialPort1.Write(TextBoxTrialMaxTime.Text * 1000) 'Arduino wait for miliseconds time            
            SerialPort1.Write("i" & vbCr)

            SerialPort1.Write(TextBoxBlackout.Text * 1000) 'Arduino wait for miliseconds time            
            SerialPort1.Write("m" & vbCr)

            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)


            SerialPort1.Write(TextBoxIncForced.Text)
            SerialPort1.Write("k" & vbCr)

            SerialPort1.Write("s" & vbCr)

            ButtonPump.Enabled = True
            ButtonInterIncorr.Enabled = True
            ButtonInterCorr.Enabled = True
            ButtonTrials.Enabled = True
            ButtonTime.Enabled = True
            ButtonInterPrime.Enabled = True
            ButtonSimRight.Enabled = True
            ButtonSimLeft.Enabled = True
            ButtonReward.Enabled = True
            ButtonPrime.Enabled = True
            ButtonTrialMaxTime.Enabled = True
            ButtonBlackout.Enabled = True
            ButtonIncForced.Enabled = True




            ButtonStop.Enabled = True




            ButtonStart.Enabled = False
            parador = False

            filename = My.Computer.FileSystem.CurrentDirectory + "\" + TextBoxName.Text + "_" + filename + ".csv"

            file = My.Computer.FileSystem.OpenTextFileWriter(filename, True)

            file.WriteLine("Start date:" + Format(Date.Now(), "yyyy/MM/dd"))
            file.WriteLine("Start time:" + Format(Date.Now(), "hh:mm:ss"))
            file.WriteLine("Session Type : " + SessionType)
            file.WriteLine("Type Stimulus;Stimulus File Name;Time When Stimulus Delivered;Type Trial (1 or 2 Bars presented);Lever Pressed (0-Missed,1-Left,2-Right,3-SimuledLeft,4-SimuledRIght) ;Time Lever Pressed;IsCorrect (0-NO,1-YES)")

            Timer1.Start()
            startTime = DateTime.Now()

            NumLeftPressed = 0
            NumRightPressed = 0
            NumSimLeftPressed = 0
            NumSimRightPressed = 0
            NumCorr = 0
            NumIncorr = 0
            NumMissed = 0

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim span As TimeSpan = DateTime.Now.Subtract(startTime)

        timerLabel.Text = span.ToString("hh\:mm\:ss")

        LabelNumLeftPressed.Text = NumLeftPressed
        LabelNumRightPressed.Text = NumRightPressed
        LabelNumSimLeftPressed.Text = NumSimLeftPressed
        LabelNumSimRightPressed.Text = NumSimRightPressed
        LabelNumCorr.Text = NumCorr
        LabelNumIncorr.Text = NumIncorr
        LabelNumMissed.Text = NumMissed

        If span.Minutes >= TextBoxTime.Text Then
            ButtonStop.PerformClick()
            MsgBox("Session Finished")
        End If

    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click

        SerialPort1.Write("t" & vbCr)
        SerialPort1.Close()
        ButtonStop.Enabled = False
        ButtonStart.Enabled = True
        ButtonReward.Enabled = False
        Timer1.Stop()
        file.Close()


        ButtonPump.Enabled = False
        ButtonInterIncorr.Enabled = False
        ButtonInterCorr.Enabled = False
        ButtonTrials.Enabled = False
        ButtonTime.Enabled = False
        ButtonInterPrime.Enabled = False
        ButtonSimRight.Enabled = False
        ButtonSimLeft.Enabled = False
        ButtonReward.Enabled = False
        ButtonPrime.Enabled = False
        ButtonTrialMaxTime.Enabled = False
        ButtonBlackout.Enabled = False
        ButtonIncForced.Enabled = False




    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Dim inChar(100) As Char
        Dim count As Integer


        Dim TypeTrial As Char

        inChar = SerialPort1.ReadLine()
        file.WriteLine(inChar)
        count = 0

        For i = 0 To Len(inChar) - 1

            If inChar(i) = ";" Then
                count = count + 1

                If count = 4 Then

                    TypeTrial = inChar(i - 1)

                End If

                If count = 5 Then

                    If inChar(i - 1) = "1" Then
                        NumLeftPressed = NumLeftPressed + 1
                    ElseIf inChar(i - 1) = "2" Then
                        NumRightPressed = NumRightPressed + 1
                    ElseIf inChar(i - 1) = "3" Then
                        NumSimLeftPressed = NumSimLeftPressed + 1
                    ElseIf inChar(i - 1) = "4" Then
                        NumSimRightPressed = NumSimRightPressed + 1
                    ElseIf inChar(i - 1) = "0" Then
                        NumMissed = NumMissed + 1
                    End If

                End If


                If count = 7 Then
                    If (TypeTrial = "2") Then
                        If inChar(i - 1) = "1" Then
                            NumCorr = NumCorr + 1
                        Else
                            NumIncorr = NumIncorr + 1
                        End If
                    End If


                End If


            End If

        Next

    End Sub


    Private Sub ButtonSimLeft_Click(sender As Object, e As EventArgs) Handles ButtonSimLeft.Click
        SerialPort1.Write("l" & vbCr)
    End Sub

    Private Sub ButtonSimRight_Click(sender As Object, e As EventArgs) Handles ButtonSimRight.Click
        SerialPort1.Write("r" & vbCr)
    End Sub

    Private Sub ButtonReward_Click(sender As Object, e As EventArgs) Handles ButtonReward.Click

        SerialPort1.Write("w" & vbCr)

    End Sub

    Private Sub ButtonPump_Click(sender As Object, e As EventArgs) Handles ButtonPump.Click

        If IsNumeric(TextBoxPump.Text) = False Then
            MsgBox("Reward pump time is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxPump.Text * 1000) 'Arduino wait for miliseconds time
        SerialPort1.Write("p" & vbCr)
    End Sub

    Private Sub ButtonTime_Click(sender As Object, e As EventArgs) Handles ButtonTime.Click

        If IsNumeric(TextBoxTime.Text) = False Then
            MsgBox("Session time is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxTime.Text * 60 * 1000) 'Arduino wait for miliseconds time
        SerialPort1.Write("a" & vbCr)
    End Sub

    Private Sub ButtonPrime_Click(sender As Object, e As EventArgs) Handles ButtonPrime.Click

        If IsNumeric(TextBoxPrime.Text) = False Then
            MsgBox("Number of Primes is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxPrime.Text)
        SerialPort1.Write("b" & vbCr)
    End Sub

    Private Sub ButtonTrials_Click(sender As Object, e As EventArgs) Handles ButtonTrials.Click

        If IsNumeric(TextBoxTrials.Text) = False Then
            MsgBox("Number of Trials is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxTrials.Text)
        SerialPort1.Write("d" & vbCr)
    End Sub

    Private Sub ButtonInterPrime_Click(sender As Object, e As EventArgs) Handles ButtonInterPrime.Click

        If IsNumeric(TextBoxInterPrime.Text) = False Then
            MsgBox("Time between Prime trials is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxInterPrime.Text * 1000)
        SerialPort1.Write("f" & vbCr)
    End Sub

    Private Sub ButtonInterCorr_Click(sender As Object, e As EventArgs) Handles ButtonInterCorr.Click

        If IsNumeric(TextBoxInterCorr.Text) = False Then
            MsgBox("Time between correct trials is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxInterCorr.Text * 1000)
        SerialPort1.Write("g" & vbCr)
    End Sub

    Private Sub ButtonInterIncorr_Click(sender As Object, e As EventArgs) Handles ButtonInterIncorr.Click

        If IsNumeric(TextBoxInterIncorr.Text) = False Then
            MsgBox("Time between inorrect trials is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxInterIncorr.Text * 1000)
        SerialPort1.Write("h" & vbCr)
    End Sub

    Private Sub ButtonTrialMaxTime_Click(sender As Object, e As EventArgs) Handles ButtonTrialMaxTime.Click

        If IsNumeric(TextBoxTrialMaxTime.Text) = False Then
            MsgBox(" Time before missing trial is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxTrialMaxTime.Text * 1000)
        SerialPort1.Write("i" & vbCr)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If SerialPort1.IsOpen = True Then
            If e.KeyCode = Keys.F1 Then
                SerialPort1.Write("l" & vbCr)
            ElseIf e.KeyCode = Keys.F2 Then
                SerialPort1.Write("r" & vbCr)
            ElseIf e.KeyCode = Keys.F3 Then
                SerialPort1.Write("w" & vbCr)
            End If
        End If
    End Sub

    Private Sub ButtonBlackout_Click(sender As Object, e As EventArgs) Handles ButtonBlackout.Click
        If IsNumeric(TextBoxBlackout.Text) = False Then
            MsgBox("Blackout Time Is invalid")
            Exit Sub
        End If
        SerialPort1.Write(TextBoxBlackout.Text * 1000)
        SerialPort1.Write("m" & vbCr)
    End Sub

    Private Sub ButtonIncForced_Click(sender As Object, e As EventArgs) Handles ButtonIncForced.Click
        If IsNumeric(TextBoxIncForced.Text) = False Then
            MsgBox("Number of Incorrect Trials Allowed in Forced Sessions is invalid")
            Exit Sub
        End If

        SerialPort1.Write(TextBoxIncForced.Text)
        SerialPort1.Write("k" & vbCr)
    End Sub

    Private Sub OnlyCorrectBar_CheckedChanged(sender As Object, e As EventArgs) Handles OnlyCorrectBar.CheckedChanged


        If ButtonStart.Enabled = False And OnlyCorrectBar.Checked = True Then
            RunType = "1"
            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)
        End If



    End Sub

    Private Sub BothLevers_RepeatAfterError_CheckedChanged(sender As Object, e As EventArgs) Handles BothLevers_RepeatAfterError.CheckedChanged


        If ButtonStart.Enabled = False And BothLevers_RepeatAfterError.Checked = True Then
            RunType = "2"
            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)
        End If


    End Sub

    Private Sub BothBars_CheckedChanged(sender As Object, e As EventArgs) Handles BothBars.CheckedChanged

        If ButtonStart.Enabled = False And BothBars.Checked = True Then
            RunType = "3"
            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)
        End If


    End Sub



    Private Sub OnlyLeftStim_CheckedChanged(sender As Object, e As EventArgs) Handles OnlyLeftStim.CheckedChanged

        If ButtonStart.Enabled = False And OnlyLeftStim.Checked = True Then
            RunType = "4"
            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)
        End If


    End Sub


    Private Sub RadioButtonOnlyRight_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOnlyRight.CheckedChanged

        If ButtonStart.Enabled = False And RadioButtonOnlyRight.Checked = True Then
            RunType = "5"
            SerialPort1.Write(RunType)
            SerialPort1.Write("j" & vbCr)
        End If

    End Sub
End Class