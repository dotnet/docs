   Public Shared Sub Main()
      Dim lines() As String = {"Public Module HelloWorld", _
                               "   Public Sub Main()", _
                               "      ' This code displays a simple greeting", _
                               "      ' to the console.", _
                               "      Console.WriteLine(""Hello, World."")", _
                               "   End Sub", _
                               " End Module"}
      Console.WriteLine("Code before call to StripComments:")
      For Each line As String In lines
         Console.WriteLine("   {0}", line)                         
      Next                            
      
      Dim strippedLines() As String = StripComments(lines) 
      Console.WriteLine("Code after call to StripComments:")
      For Each line As String In strippedLines
         Console.WriteLine("   {0}", line)                         
      Next                            
   End Sub
   ' This code produces the following output to the console:
   '    Code before call to StripComments:
   '       Public Module HelloWorld
   '          Public Sub Main()
   '             ' This code displays a simple greeting
   '             ' to the console.
   '             Console.WriteLine("Hello, World.")
   '          End Sub
   '       End Module
   '    Code after call to StripComments:
   '       This code displays a simple greeting
   '       to the console.   