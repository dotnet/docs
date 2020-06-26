Imports System.IO
Imports System.IO.IsolatedStorage

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private filename As String = "App.txt"

		Public Sub New()
			' Initialize application-scope property
			Me.Properties("NumberOfAppSessions") = 0
		End Sub

		Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			' Restore application-scope property from isolated storage
			Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain()
			Try
				Using stream As New IsolatedStorageFileStream(filename, FileMode.Open, storage)
				Using reader As New StreamReader(stream)
					' Restore each application-scope property individually
					Do While Not reader.EndOfStream
						Dim keyValue() As String = reader.ReadLine().Split(New Char() {","c})
						Me.Properties(keyValue(0)) = keyValue(1)
					Loop
				End Using
				End Using
			Catch ex As FileNotFoundException
				' Handle when file is not found in isolated storage:
				' * When the first application session
				' * When file has been deleted
			End Try
		End Sub

		Private Sub App_Exit(ByVal sender As Object, ByVal e As ExitEventArgs)
			' Persist application-scope property to isolated storage
			Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain()
			Using stream As New IsolatedStorageFileStream(filename, FileMode.Create, storage)
			Using writer As New StreamWriter(stream)
				' Persist each application-scope property individually
				For Each key As String In Me.Properties.Keys
					writer.WriteLine("{0},{1}", key, Me.Properties(key))
				Next key
			End Using
			End Using
		End Sub
	End Class
End Namespace