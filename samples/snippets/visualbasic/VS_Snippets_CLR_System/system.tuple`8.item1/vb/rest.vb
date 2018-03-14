'Option Strict On
Option Infer On

' <Snippet2>
Imports System.Reflection

Module Example
    Sub Main()
        Dim from1980 As Tuple(Of Integer, Integer, Integer) =
            Tuple.Create(1203339, 1027974, 951270)
        Dim from1910 As New Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, _
            Tuple(Of Integer, Integer, Integer)) _
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980)
        Dim population As New Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer, _ 
            Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, Tuple(Of Integer, Integer, Integer))) _
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910)
      
        ShowComponentCount(population)
   End Sub
   
   Private Sub ShowComponentCount(tuple As Object) 
      Static ctr As Integer = 0
      Static totalComponents As Integer = 0
      Dim components As Integer = 0
      
      ctr += 1
      Dim name As String = tuple.GetType().Name
      components += Int32.Parse(name.Substring(name.IndexOf("`") + 1))
      If components = 8 Then
         totalComponents += 7
         Console.WriteLine("The tuple at level {0} has 7 components.", ctr)
         ShowComponentCount(tuple.Rest)
      Else
         totalComponents += components
         Console.WriteLine("The tuple at level {0} has {1} components.", 
                           ctr, components)
         Console.WriteLine("Total components in tuple: {0}", totalComponents)
      End If      
   End Sub        
End Module
' The example displays the following output:
'       The tuple at level 1 has 7 components.
'       The tuple at level 2 has 7 components.
'       The tuple at level 3 has 3 components.
'       Total components in tuple: 17
' </Snippet2>
