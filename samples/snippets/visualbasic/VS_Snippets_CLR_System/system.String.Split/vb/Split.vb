' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim source As String = "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]"
      Dim stringSeparators() As String = {"[stop]"}
      Dim result() As String
      
      ' Display the original string and delimiter string.
      Console.WriteLine("Splitting the string:{0}   '{1}'.", vbCrLf, source)
      Console.WriteLine()
      Console.WriteLine("Using the delimiter string:{0}   '{1}'.", _
                        vbCrLf, stringSeparators(0))
      Console.WriteLine()                          
         
      ' Split a string delimited by another string and return all elements.
      result = source.Split(stringSeparators, StringSplitOptions.None)
      Console.WriteLine("Result including all elements ({0} elements):", _ 
                        result.Length)
      Console.Write("   ")
      For Each s As String In result
         Console.Write("'{0}' ", IIf(String.IsNullOrEmpty(s), "<>", s))                   
      Next
      Console.WriteLine()
      Console.WriteLine()

      ' Split delimited by another string and return all non-empty elements.
      result = source.Split(stringSeparators, _ 
                            StringSplitOptions.RemoveEmptyEntries)
      Console.WriteLine("Result including non-empty elements ({0} elements):", _ 
                        result.Length)
      Console.Write("   ")
      For Each s As String In result
         Console.Write("'{0}' ", IIf(String.IsNullOrEmpty(s), "<>", s))                   
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    Splitting the string:
'       "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
'    
'    Using the delimiter string:
'       "[stop]"
'    
'    Result including all elements (9 elements):
'       '<>' 'ONE' '<>' 'TWO' '<>' '<>' 'THREE' '<>' '<>'
'    
'    Result including non-empty elements (3 elements):
'       'ONE' 'TWO' 'THREE'
' </Snippet1>