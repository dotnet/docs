Class Program
   
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Shared Sub Main(args() As String)
      Dim root As New SampleObject()
      
      Dim currentObject As SampleObject = root
      
      Dim i As Integer
      For i = 0 To 9
         Dim o As New SampleObject()
         
         currentObject.Child = o
         
         currentObject = o
      Next i
   End Sub 
End Class