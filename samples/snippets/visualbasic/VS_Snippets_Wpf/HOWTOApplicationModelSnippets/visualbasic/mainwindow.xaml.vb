Namespace SDKSample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>

	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

			Application.Current.Properties("NumberOfAppSessions") = Integer.Parse(Application.Current.Properties("NumberOfAppSessions").ToString()) + 1
			Me.Title = "Number of app sessions: " & Application.Current.Properties("NumberOfAppSessions").ToString()
		End Sub

	End Class
End Namespace