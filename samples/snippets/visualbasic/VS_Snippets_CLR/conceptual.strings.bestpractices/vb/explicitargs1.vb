' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CompareWithDefaults()
      CompareExplicit()
   End Sub
   
   Private Sub CompareWithDefaults()
      Dim url As New Uri("http://msdn.microsoft.com")
      ' <Snippet1> 
      Dim protocol As String = GetProtocol(url)       
      If String.Equals(protocol, "http") Then
         ' ...Code to handle HTTP protocol.
      Else
         Throw New InvalidOperationException()
      End If   
      ' </Snippet1>
   End Sub
   
   Private Sub CompareExplicit()
      Dim url As New Uri("http://msdn.microsoft.com")
      ' <Snippet2> 
      Dim protocol As String = GetProtocol(url)       
      If String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase) Then
         ' ...Code to handle HTTP protocol.
      Else
         Throw New InvalidOperationException()
      End If   
      ' </Snippet2>
   End Sub

   Private Function GetProtocol(url As Uri) As String
      Return url.Scheme
   End Function
End Module


' if (String.Compare(protocol, "ftp", StringComparsion.Ordinal) != 0)
' {
'    throw new InvalidOperationException();
