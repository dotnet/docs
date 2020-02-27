' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO

Module Module1

    Sub Main()
        Try
            ' Get a list of the files to use for the sorted set.
            Dim files1 As IEnumerable = _
                Directory.EnumerateFiles("\\archives\2007\media", "*", _
                                                          SearchOption.AllDirectories)
            ' <Snippet2>
            ' Create a sorted set using the ByFileExtension comparer.
            Dim mediaFiles1 As New SortedSet(Of String)(New ByFileExtension)
            ' </Snippet2>
        
            ' Note that there is a SortedSet constructor that takes an IEnumerable,
            ' but to remove the path information they must be added individually.
            ' <Snippet3>
            For Each f As String In files1
                mediaFiles1.Add(f.Substring((f.LastIndexOf("\") + 1)))
            Next
            ' </Snippet3>
            
            ' <Snippet4>
            ' Remove elements that have non-media extensions. See the 'IsDoc' method.
            Console.WriteLine("Remove docs from the set...")
            Console.WriteLine($"{vbTab}Count before: {mediaFiles1.Count}")
            mediaFiles1.RemoveWhere(AddressOf IsDoc)
            Console.WriteLine($"{vbTab}Count after: {mediaFiles1.Count}")
            ' </Snippet4>
        
            Console.WriteLine()
            
            ' <Snippet5>
            ' List all the avi files.
            Dim aviFiles As SortedSet(Of String) = mediaFiles1.GetViewBetween("avi", "avj")
            Console.WriteLine("AVI files:")
            For Each avi As String In aviFiles
                Console.WriteLine($"{vbTab}{avi}")
            Next
            ' </Snippet5>

            Console.WriteLine()

            ' Create another sorted set.
            Dim files2 As IEnumerable = _
                Directory.EnumerateFiles("\\archives\2008\media", "*", _
                                      SearchOption.AllDirectories)
            Dim mediaFiles2 As New SortedSet(Of String)(New ByFileExtension)
            For Each f As String In files2
                mediaFiles2.Add(f.Substring((f.LastIndexOf("\") + 1)))
            Next
            
            ' <Snippet6>
            ' Remove elements in mediaFiles1 that are also in mediaFiles2.
            Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...")
            Console.WriteLine($"{vbTab}Count before: {mediaFiles1.Count}")
            mediaFiles1.ExceptWith(mediaFiles2)
            Console.WriteLine($"{vbTab}Count after: {mediaFiles1.Count}")
        ' </Snippet6>

            Console.WriteLine()

            Console.WriteLine("List of mediaFiles1:")
            For Each f As String In mediaFiles1
                Console.WriteLine($"{vbTab}{f}")
            Next
            
            ' <Snippet7>
            ' Create a set of the sets.
            Dim comparer As IEqualityComparer(Of SortedSet(Of String)) = _
                SortedSet(Of String).CreateSetComparer()
            Dim allMedia As New HashSet(Of SortedSet(Of String))(comparer)
            allMedia.Add(mediaFiles1)
            allMedia.Add(mediaFiles2)
            ' </Snippet7>

        Catch ioEx As IOException
            Console.WriteLine(ioEx.Message)
        Catch AuthEx As UnauthorizedAccessException
            Console.WriteLine(AuthEx.Message)
        End Try


    End Sub

    ' <Snippet8>
    ' Defines a predicate delegate to use
    ' for the SortedSet.RemoveWhere method.
    Private Function IsDoc(s As String) As Boolean
        s = s.ToLower()
        Return s.EndsWith(".txt") OrElse 
    			s.EndsWith(".doc") OrElse 
    			s.EndsWith(".xls") OrElse
                s.EndsWith(".xlsx") OrElse
                s.EndsWith(".pdf") OrElse
                s.EndsWith(".doc") OrElse
                s.EndsWith(".docx")
    End Function
    ' </Snippet8>
    
    ' <Snippet9>
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
    ' </Snippet9>
End Module
' </Snippet1>
