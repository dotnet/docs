' Visual Basic .NET Document
Option Strict On
Option Infer On

Public Enum ArrivalStatus As Integer
   Unknown = -3
   Late = -1
   OnTime = 0
   Early = 1
End Enum

Module Example
   Public Sub Main()
      GetEnumByName()
      Console.WriteLine("-----")
      GetEnumByValue()
   End Sub
   
   Private Sub GetEnumByName()
      ' <Snippet11>     
      Dim names() As String = [Enum].GetNames(GetType(ArrivalStatus))
      Console.WriteLine("Members of {0}:", GetType(ArrivalStatus).Name)
      Array.Sort(names)
      For Each name In names
         Dim status As ArrivalStatus = CType([Enum].Parse(GetType(ArrivalStatus), name),
                                       ArrivalStatus)
         Console.WriteLine("   {0} ({0:D})", status)
      Next
      ' The example displays the following output:
      '       Members of ArrivalStatus:
      '          Early (1)
      '          Late (-1)
      '          OnTime (0)
      '          Unknown (-3)      
      ' </Snippet11>      
   End Sub
   
   Private Sub GetEnumByValue()
      ' <Snippet12>
      Dim values = [Enum].GetValues(GetType(ArrivalStatus))
      Console.WriteLine("Members of {0}:", GetType(ArrivalStatus).Name)
      For Each value In values
         Dim status As ArrivalStatus = CType([Enum].ToObject(GetType(ArrivalStatus), value),
                                             ArrivalStatus)
         Console.WriteLine("   {0} ({0:D})", status)
      Next                                       
      ' The example displays the following output:
      '       Members of ArrivalStatus:
      '          OnTime (0)
      '          Early (1)
      '          Unknown (-3)
      '          Late (-1)
      ' </Snippet12>
   End Sub
End Module

