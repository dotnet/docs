Option Strict On
Option Explicit On

Class Class1
    Public Sub testClock()
        '<snippet21>
        MsgBox("Current local time: " & My.Computer.Clock.LocalTime)
        '</snippet21>
        '<snippet22>
        MsgBox("Current GMT time: " & My.Computer.Clock.GmtTime)
        '</snippet22>
    End Sub
    '<snippet20>
    Public Sub LoopTask(ByVal secondsToRun As Integer)
        Dim startTicks As Integer = My.Computer.Clock.TickCount
        Do While IsTimeUp(startTicks, secondsToRun)
            ' Code to run for at least secondsToRun seconds goes here.
        Loop
    End Sub

    Private Function IsTimeUp( 
        ByVal startTicks As Integer, 
        ByVal seconds As Integer 
    ) As Boolean
        ' This function throws an overflow exception if the
        ' tick count difference is greater than 2,147,483,647,  
        ' about 24 days for My.Computer.Clock.TickCount.

        ' Use UInteger to simplify the code for roll over.
        Dim uStart As UInteger = 
            CUInt(CLng(startTicks) - Integer.MinValue)
        Dim uCurrent As UInteger = 
            CUInt(CLng(My.Computer.Clock.TickCount) - Integer.MinValue)

        ' Calculate the tick count difference.
        Dim tickCountDifference As UInteger
        If uStart <= uCurrent Then
            tickCountDifference = uCurrent - uStart
        Else
            ' Tick count rolled over.
            tickCountDifference = UInteger.MaxValue - (uStart - uCurrent)
        End If

        ' Convert seconds to milliseconds and compare.
        Return CInt(tickCountDifference) < (seconds * 1000)
    End Function
    '</snippet20>





    '<snippet17>
    Sub PlaySystemSound()
        My.Computer.Audio.PlaySystemSound( 
            System.Media.SystemSounds.Asterisk)
    End Sub
    '</snippet17>

    '<snippet16>
    Sub PlayBackgroundSoundResource()
        My.Computer.Audio.Play(My.Resources.Waterfall, 
            AudioPlayMode.WaitToComplete)
    End Sub
    '</snippet16>

    '<snippet15>
    Sub PlayBackgroundSoundFile()
        My.Computer.Audio.Play("C:\Waterfall.wav", 
            AudioPlayMode.WaitToComplete)
    End Sub
    '</snippet15>

    '<snippet14>
    Sub PlaySoundResource()
        My.Computer.Audio.Play(My.Resources.Waterfall, 
            AudioPlayMode.WaitToComplete)
    End Sub
    '</snippet14>

    '<snippet13>
    Sub PlaySoundFile()
        My.Computer.Audio.Play("C:\Waterfall.wav", 
            AudioPlayMode.WaitToComplete)
    End Sub
    '</snippet13>

    '<snippet12>
    Sub PlayLoopingBackgroundSoundResource()
        My.Computer.Audio.Play(My.Resources.Waterfall, 
              AudioPlayMode.BackgroundLoop)
    End Sub
    '</snippet12>

    '<snippet19>
    '<snippet11>
    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play("C:\Waterfall.wav", 
            AudioPlayMode.BackgroundLoop)
    End Sub
    '</snippet11>
    '<snippet18>
    Sub StopBackgroundSound()
        My.Computer.Audio.Stop()
    End Sub
    '</snippet18>
    '</snippet19>

    Class Class10
        Inherits Form
        '<snippet10>
        Private Sub EnlargeForm()
            Me.Size = My.Computer.Screen.WorkingArea.Size
            Me.Location = New System.Drawing.Point(0, 0)
        End Sub
        '</snippet10>
    End Class

    Public Sub testComputerInfo()
        '<snippet1>
        MsgBox("Computer name: " & My.Computer.Name)
        '</snippet1>
        '<snippet2>
        MsgBox("Computer's available physical memory: " & 
            My.Computer.Info.AvailablePhysicalMemory)
        '</snippet2>
        '<snippet3>
        MsgBox("Computer's available virtual memory: " & 
            My.Computer.Info.AvailableVirtualMemory)
        '</snippet3>
        '<snippet4>
        MsgBox("Computer's UI culture name: " & 
            My.Computer.Info.InstalledUICulture.DisplayName)
        '</snippet4>
        '<snippet5>
        MsgBox("Computer's operating system name: " & 
            My.Computer.Info.OSFullName)
        '</snippet5>
        '<snippet6>
        MsgBox("Computer's operating system platform: " & 
            My.Computer.Info.OSPlatform)
        '</snippet6>
        '<snippet7>
        MsgBox("Computer's operating system version: " & 
            My.Computer.Info.OSVersion)
        '</snippet7>
        '<snippet8>
        MsgBox("Computer's available physical memory: " & 
            My.Computer.Info.TotalPhysicalMemory)
        '</snippet8>
        '<snippet9>
        MsgBox("Computer's available virtual memory: " & 
            My.Computer.Info.TotalVirtualMemory)
        '</snippet9>

    End Sub

End Class
