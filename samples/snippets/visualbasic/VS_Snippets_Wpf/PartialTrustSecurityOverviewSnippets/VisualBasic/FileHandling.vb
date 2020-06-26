'<SnippetDetectPermsCODE1>

Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Security
Imports System.Security.Permissions
Imports System.Windows

Namespace SDKSample
	Public Class FileHandling
		Public Sub Save()
			If IsPermissionGranted(New FileIOPermission(FileIOPermissionAccess.Write, "c:\newfile.txt")) Then
				' Write to local disk
				Using stream As FileStream = File.Create("c:\newfile.txt")
				Using writer As New StreamWriter(stream)
					writer.WriteLine("I can write to local disk.")
				End Using
				End Using
			Else
				MessageBox.Show("I can't write to local disk.")
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

		'</SnippetDetectPermsCODE1>
		'<SnippetDetectPermsCODE2>
	End Class
End Namespace
'</SnippetDetectPermsCODE2>