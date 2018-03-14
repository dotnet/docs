' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim strings(,) As String = { {"ABCdef", "abc" },                    
                                   {"ABCdef", "abc" },  
                                   {"œil","oe" },
                                   { "læring}", "lae" } }
      For ctr1 As Integer = strings.GetLowerBound(0) To strings.GetUpperBound(0)
            For Each cmpName As String In [Enum].GetNames(GetType(StringComparison)) 
               Dim strCmp As StringComparison = CType([Enum].Parse(GetType(StringComparison), 
                                                      cmpName), StringComparison)
               Dim instance As String = strings(ctr1, 0)
               Dim value As String = strings(ctr1, 1)
               Console.WriteLine("{0} starts with {1}: {2} ({3} comparison)", 
                                 instance, value, 
                                 instance.StartsWith(value, strCmp), 
                                 strCmp) 
            Next
            Console.WriteLine()   
      Next   
   End Sub
End Module
' The example displays the following output:
'       ABCdef starts with abc: False (CurrentCulture comparison)
'       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
'       ABCdef starts with abc: False (InvariantCulture comparison)
'       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
'       ABCdef starts with abc: False (Ordinal comparison)
'       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
'       
'       ABCdef starts with abc: False (CurrentCulture comparison)
'       ABCdef starts with abc: True (CurrentCultureIgnoreCase comparison)
'       ABCdef starts with abc: False (InvariantCulture comparison)
'       ABCdef starts with abc: True (InvariantCultureIgnoreCase comparison)
'       ABCdef starts with abc: False (Ordinal comparison)
'       ABCdef starts with abc: True (OrdinalIgnoreCase comparison)
'       
'       œil starts with oe: True (CurrentCulture comparison)
'       œil starts with oe: True (CurrentCultureIgnoreCase comparison)
'       œil starts with oe: True (InvariantCulture comparison)
'       œil starts with oe: True (InvariantCultureIgnoreCase comparison)
'       œil starts with oe: False (Ordinal comparison)
'       œil starts with oe: False (OrdinalIgnoreCase comparison)
'       
'       læring} starts with lae: True (CurrentCulture comparison)
'       læring} starts with lae: True (CurrentCultureIgnoreCase comparison)
'       læring} starts with lae: True (InvariantCulture comparison)
'       læring} starts with lae: True (InvariantCultureIgnoreCase comparison)
'       læring} starts with lae: False (Ordinal comparison)
'       læring} starts with lae: False (OrdinalIgnoreCase comparison)
' </Snippet1>
