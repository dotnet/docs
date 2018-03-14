' <Snippet1>
Class Sample
   Public Shared Sub Main() 
      ' Define a string array with the following three "I" characters:
      '      U+0069, U+0131, and U+0049.  
      Dim threeIs() As String = { "i", "ı", "I" }
      ' Define Type object representing StringComparison type.
      Dim scType As Type = GetType(StringComparison)  
      
      ' Show the current culture (for culture-sensitive string comparisons).
      Console.WriteLine("The current culture is {0}." & vbCrLf, _
                        System.Globalization.CultureInfo.CurrentCulture.Name)
        
      ' Perform comparisons using each StringComparison member. 
      For Each scName As String In [Enum].GetNames(scType)
         Dim sc As StringComparison = [Enum].Parse(scType, scName)
         Console.WriteLine("Comparisons using {0}:", sc)
         ' Compare each character in character array.
         For ctr As Integer = 0 To 1
            Dim instanceChar As String = threeIs(ctr)
            For innerCtr As Integer = ctr + 1 To threeIs.GetUpperBound(0)
               Dim otherChar As STring = threeIs(innerCtr)
               Console.WriteLine("{0} (U+{1}) = {2} (U+{3}): {4}", _
                                 instanceChar, Convert.ToInt16(Char.Parse(instanceChar)).ToString("X4"), _
                                 otherChar, Convert.ToInt16(Char.Parse(otherChar)).ToString("X4"), _
                                 instanceChar.Equals(otherChar, sc))
            Next
            Console.WriteLine()
         Next
      Next              
   End Sub
End Class
' The example displays the following output:
'       The current culture is en-US.
'       
'       Comparisons using CurrentCulture:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): False
'       
'       i (U+0131) = I (U+0049): False
'       
'       Comparisons using CurrentCultureIgnoreCase:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): True
'       
'       i (U+0131) = I (U+0049): False
'       
'       Comparisons using InvariantCulture:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): False
'       
'       i (U+0131) = I (U+0049): False
'       
'       Comparisons using InvariantCultureIgnoreCase:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): True
'       
'       i (U+0131) = I (U+0049): False
'       
'       Comparisons using Ordinal:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): False
'       
'       i (U+0131) = I (U+0049): False
'       
'       Comparisons using OrdinalIgnoreCase:
'       i (U+0069) = i (U+0131): False
'       i (U+0069) = I (U+0049): True
'       
'       i (U+0131) = I (U+0049): False
' </Snippet1>
' 114 lines
