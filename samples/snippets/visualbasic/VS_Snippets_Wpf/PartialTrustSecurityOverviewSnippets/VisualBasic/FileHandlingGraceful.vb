'<SnippetDetectPermsGracefulCODE1>

Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Security
Imports System.Security.Permissions
Imports System.Windows

Namespace SDKSample
	Public Class FileHandlingGraceful
		Public Sub Save()
			If IsPermissionGranted(New FileIOPermission(FileIOPermissionAccess.Write, "c:\newfile.txt")) Then
				' Write to local disk
				Using stream As FileStream = File.Create("c:\newfile.txt")
				Using writer As New StreamWriter(stream)
					writer.WriteLine("I can write to local disk.")
				End Using
				End Using
			Else
				' Persist application-scope property to 
				' isolated storage
				Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
				Using stream As New IsolatedStorageFileStream("newfile.txt", FileMode.Create, storage)
				Using writer As New StreamWriter(stream)
					writer.WriteLine("I can write to Isolated Storage")
				End Using
				End Using
			End If
		End Sub

		' Detect whether or not this application has the requested permission
		Private Function IsPermissionGranted(ByVal requestedPermission As CodeAccessPermission) As Boolean
			Try
				' Try and get this permission
				requestedPermission.Demand()
				Return True
			Catch
				Return False
			End Try
		End Function

		'</SnippetDetectPermsGracefulCODE1>
		'<SnippetDetectPermsGracefulCODE2>
	End Class
End Namespace
'</SnippetDetectPermsGracefulCODE2>