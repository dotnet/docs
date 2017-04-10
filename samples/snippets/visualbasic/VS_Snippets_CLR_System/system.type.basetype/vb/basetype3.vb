' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Public Class Example
   Public Shared Sub Main()
      For Each t In GetType(Example).Assembly.GetTypes()
         Console.WriteLine("{0} derived from: ", t.FullName)
         Dim derived As Type = t
         Do 
            derived = derived.BaseType
            If derived IsNot Nothing Then 
               Console.WriteLine("   {0}", derived.FullName)
            End If   
         Loop While derived IsNot Nothing
         Console.WriteLine() 
      Next 
   End Sub
End Class

Public Class A 
End Class

Public Class B : Inherits A
End Class

Public Class C : Inherits B
End Class
' The example displays the following output:
'       Example derived from:
'          System.Object
'       
'       A derived from:
'          System.Object
'       
'       B derived from:
'          A
'          System.Object
'       
'       C derived from:
'          B
'          A
'          System.Object
' </Snippet2>
