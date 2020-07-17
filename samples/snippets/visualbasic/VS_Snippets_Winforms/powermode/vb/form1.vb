Public Class Form1
    ' <snippet1>
    Public Sub New()
        InitializeComponent()
        AddHandler Microsoft.Win32.SystemEvents.PowerModeChanged, AddressOf PowerModeChanged
    End Sub

    Private Sub PowerModeChanged(ByVal Sender As System.Object, ByVal e As Microsoft.Win32.PowerModeChangedEventArgs)
        Select Case SystemInformation.PowerStatus.BatteryChargeStatus
            Case BatteryChargeStatus.Low
                MessageBox.Show("Battery is running low.", "Low Battery", MessageBoxButtons.OK, _
                                System.Windows.Forms.MessageBoxIcon.Exclamation)
            Case BatteryChargeStatus.Critical
                MessageBox.Show("Battery is critically low.", "Critical Battery", MessageBoxButtons.OK, _
                                System.Windows.Forms.MessageBoxIcon.Stop)
            Case Else
                ' Battery is okay.
                Exit Select
        End Select
    End Sub
    ' </snippet1>

    Private Sub Hibernate()
        ' <snippet2>
        If SystemInformation.PowerStatus.BatteryChargeStatus = System.Windows.Forms.BatteryChargeStatus.Critical Then
            Application.SetSuspendState(PowerState.Hibernate, False, False)
        End If
        ' </snippet2>
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub

End Class
