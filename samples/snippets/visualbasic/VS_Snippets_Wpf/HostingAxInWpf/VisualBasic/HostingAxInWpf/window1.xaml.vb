'<snippet10>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub


    '<snippet11>
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Create the interop host control.
        Dim host As New System.Windows.Forms.Integration.WindowsFormsHost()

        ' Create the ActiveX control.
        Dim axWmp As New AxWMPLib.AxWindowsMediaPlayer()

        ' Assign the ActiveX control as the host control's child.
        host.Child = axWmp

        ' Add the interop host control to the Grid
        ' control's collection of child controls.
        Me.grid1.Children.Add(host)

        ' Play a .wav file with the ActiveX control.
        axWmp.URL = "C:\Windows\Media\tada.wav"

    End Sub
    '</snippet11>

End Class
'</snippet10>