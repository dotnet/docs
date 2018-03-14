' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim scores() As Tuple(Of String, Nullable(Of Integer)) = 
                      { New Tuple(Of String, Nullable(Of Integer))("Dan", 90),
                        New Tuple(Of String, Nullable(Of Integer))("Ernie", Nothing),
                        New Tuple(Of String, Nullable(Of Integer))("Jill", 88),
                        New Tuple(Of String, Nullable(Of Integer))("Ernie", Nothing), 
                        New Tuple(Of String, Nullable(Of Integer))("Nancy", 88), 
                        New Tuple(Of String, Nullable(Of Integer))("Dan", 90) }

      ' Compare the Tuple objects
      For ctr As Integer = 0 To scores.Length - 1
         Dim currentTuple As Tuple(Of String, Nullable(Of Integer)) = scores(ctr)
         For innerCtr As Integer = ctr + 1 To scores.Length - 1
            Console.WriteLine("{0} = {1}: {2}", 
                              scores(ctr), scores(innerCtr), 
                              scores(ctr).Equals(scores(innerCtr)))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       (Dan, 90) = (Ernie, ): False
'       (Dan, 90) = (Jill, 88): False
'       (Dan, 90) = (Ernie, ): False
'       (Dan, 90) = (Nancy, 88): False
'       (Dan, 90) = (Dan, 90): True
'       
'       (Ernie, ) = (Jill, 88): False
'       (Ernie, ) = (Ernie, ): True
'       (Ernie, ) = (Nancy, 88): False
'       (Ernie, ) = (Dan, 90): False
'       
'       (Jill, 88) = (Ernie, ): False
'       (Jill, 88) = (Nancy, 88): False
'       (Jill, 88) = (Dan, 90): False
'       
'       (Ernie, ) = (Nancy, 88): False
'       (Ernie, ) = (Dan, 90): False
'       
'       (Nancy, 88) = (Dan, 90): False
' </Snippet1>
