' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ShowToString()
      ShowComposite()
      ShowCompositeWithAlignment()
   End Sub
   
   Private Sub ShowToString()
      ' <Snippet10>
      Dim value As Decimal = 123.456d
      Console.WriteLine(value.ToString("C2"))         
      ' Displays $123.46
      ' </Snippet10>
   End Sub
   
   Private Sub ShowComposite()
      ' <Snippet11>   
      Dim value As Decimal = 123.456d
      Console.WriteLine("Your account balance is {0:C2}.", value)
      ' Displays "Your account balance is $123.46."
      ' </Snippet11>
   End Sub
   
   Private Sub ShowCompositeWithAlignment()
      ' <Snippet12>
      Dim amounts() As Decimal = { 16305.32d, 18794.16d }
      Console.WriteLine("   Beginning Balance           Ending Balance")
      Console.WriteLine("   {0,-28:C2}{1,14:C2}", amounts(0), amounts(1))
      ' Displays:
      '        Beginning Balance           Ending Balance
      '        $16,305.32                      $18,794.16      
      ' </Snippet12>
   End Sub
End Module


