    ' Defines a comparer to create a sorted set
    ' that is sorted by the file extensions.
    Public Class ByFileExtension
        Implements IComparer(Of String)
        Dim xExt, yExt As String

        Dim caseiComp As CaseInsensitiveComparer = _
        					New CaseInsensitiveComparer
		Public Function Compare(x As String, y As String) _
            As Integer Implements IComparer(Of String).Compare
   			' Parse the extension from the file name.
			xExt = x.Substring(x.LastIndexOf(".") + 1)
			yExt = y.Substring(y.LastIndexOf(".") + 1)

			' Compare the file extensions.
			Dim vExt As Integer = caseiComp.Compare(xExt, yExt)
			If vExt <> 0 Then
				Return vExt
			Else
				' The extension is the same, 
				' so compare the filenames. 
				Return caseiComp.Compare(x, y)
			End If
		End Function        
        
    End Class