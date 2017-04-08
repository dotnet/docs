' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Private Const MAX_RECURSIVE_CALLS As Integer = 1000
   Dim ctr As Integer = 0

   Public Sub Main()
      Execute()
      Console.WriteLine()
      Console.WriteLine("The call counter: {0}", ctr)
   End Sub

   Private Sub Execute()
      ctr += 1
      If ctr Mod 50 = 0 Then
         Console.WriteLine("Call number {0} to the Execute method", ctr)
      End If
      
      If ctr <= MAX_RECURSIVE_CALLS Then
         Execute()
      End If

      ctr -= 1
   End Sub
End Module
' The example displays the following output:
'       Call number 50 to the Execute method
'       Call number 100 to the Execute method
'       Call number 150 to the Execute method
'       Call number 200 to the Execute method
'       Call number 250 to the Execute method
'       Call number 300 to the Execute method
'       Call number 350 to the Execute method
'       Call number 400 to the Execute method
'       Call number 450 to the Execute method
'       Call number 500 to the Execute method
'       Call number 550 to the Execute method
'       Call number 600 to the Execute method
'       Call number 650 to the Execute method
'       Call number 700 to the Execute method
'       Call number 750 to the Execute method
'       Call number 800 to the Execute method
'       Call number 850 to the Execute method
'       Call number 900 to the Execute method
'       Call number 950 to the Execute method
'       Call number 1000 to the Execute method
'
'       The call counter: 0
' </Snippet1>
