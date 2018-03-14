' <Snippet1>
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Public Module App
   ' Excercise the Iterator and show that it's more performant.
   Public Sub Main()
      TestStreamReaderEnumerable()
      Console.WriteLine("---")
      TestReadingFile()
   End Sub

   Public Sub TestStreamReaderEnumerable()
		' Check the memory before the iterator is used.
		Dim memoryBefore As Long = GC.GetTotalMemory(true)
      Dim stringsFound As IEnumerable(Of String)
		' Open a file with the StreamReaderEnumerable and check for a string.
      Try
         stringsFound =
               from line in new StreamReaderEnumerable("c:\temp\tempFile.txt")
               where line.Contains("string to search for")
               select line
         Console.WriteLine("Found: {0}", stringsFound.Count())
      Catch e As FileNotFoundException
         Console.WriteLine("This example requires a file named C:\temp\tempFile.txt.")
         Return
      End Try

		' Check the memory after the iterator and output it to the console.
		Dim memoryAfter As Long = GC.GetTotalMemory(false)
		Console.WriteLine("Memory Used with Iterator = {1}{0} kb",
                        (memoryAfter - memoryBefore)\1000, vbTab)
   End Sub

   Public Sub TestReadingFile()
		Dim memoryBefore As Long = GC.GetTotalMemory(true)
      Dim sr As StreamReader
      Try
         sr = File.OpenText("c:\temp\tempFile.txt")
      Catch e As FileNotFoundException
         Console.WriteLine("This example requires a file named C:\temp\tempFile.txt.")
         Return
      End Try

        ' Add the file contents to a generic list of strings.
		Dim fileContents As New List(Of String)()
		Do While Not sr.EndOfStream
			fileContents.Add(sr.ReadLine())
      Loop

		' Check for the string.
		Dim stringsFound =
            from line in fileContents
            where line.Contains("string to search for")
            select line

      sr.Close()
      Console.WriteLine("Found: {0}", stringsFound.Count())

		' Check the memory after when the iterator is not used, and output it to the console.
		Dim memoryAfter As Long = GC.GetTotalMemory(False)
		Console.WriteLine("Memory Used without Iterator = {1}{0} kb",
                        (memoryAfter - memoryBefore)\1000, vbTab)
   End Sub
End Module

' A custom class that implements IEnumerable(T). When you implement IEnumerable(T), 
' you must also implement IEnumerable and IEnumerator(T).
Public Class StreamReaderEnumerable : Implements IEnumerable(Of String)
    Private _filePath As String
    
    Public Sub New(filePath As String)
        _filePath = filePath
    End Sub

    ' Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
    Public Function GetEnumerator() As IEnumerator(Of String) _
          Implements IEnumerable(Of String).GetEnumerator
        Return New StreamReaderEnumerator(_filePath)
    End Function

    ' Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    Private Function GetEnumerator1() As IEnumerator _
          Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator()
    End Function
End Class

' When you implement IEnumerable(T), you must also implement IEnumerator(T), 
' which will walk through the contents of the file one line at a time.
' Implementing IEnumerator(T) requires that you implement IEnumerator and IDisposable.
Public Class StreamReaderEnumerator : Implements IEnumerator(Of String)
    Private _sr As StreamReader
    
    Public Sub New(filePath As String)
        _sr = New StreamReader(filePath)
    End Sub

    Private _current As String

    ' Implement the IEnumerator(T).Current Publicly, but implement 
    ' IEnumerator.Current, which is also required, privately.
    Public ReadOnly Property Current As String _
          Implements IEnumerator(Of String).Current
        Get
            If _sr Is Nothing OrElse _current Is Nothing
                Throw New InvalidOperationException()
            End If

            Return _current
        End Get
    End Property

    Private ReadOnly Property Current1 As Object _
          Implements IEnumerator.Current
        Get
           Return Me.Current
        End Get
    End Property

    ' Implement MoveNext and Reset, which are required by IEnumerator.
    Public Function MoveNext() As Boolean _
          Implements IEnumerator.MoveNext
        _current = _sr.ReadLine()
        if _current Is Nothing Then Return False

        Return True
    End Function

    Public Sub Reset() _
          Implements IEnumerator.Reset
        _sr.DiscardBufferedData()
        _sr.BaseStream.Seek(0, SeekOrigin.Begin)
        _current = Nothing
    End Sub

    ' Implement IDisposable, which is also implemented by IEnumerator(T).
    Private disposedValue As Boolean = False
    Public Sub Dispose() _
          Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' Dispose of managed resources.
            End If

            _current = Nothing
            If _sr IsNot Nothing Then
               _sr.Close()
               _sr.Dispose()
            End If
        End If

        Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub
End Class
' This example displays output similar to the following:
'       Found: 2
'       Memory Used With Iterator =     33kb
'       ---
'       Found: 2
'       Memory Used Without Iterator =  206kb
'</snippet1>


