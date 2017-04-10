' Visual Basic .NET Document
Option Strict On

' <Snippet2>
<Flags> Public Enum DinnerItems As Integer
   None = 0
   Entree = 1
   Appetizer = 2
   Side = 4
   Dessert = 8
   Beverage = 16 
   BarBeverage = 32
End Enum

Module Example
   Public Sub Main()
      Dim myOrder As DinnerItems = DinnerItems.Appetizer Or DinnerItems.Entree Or
                                   DinnerItems.Beverage Or DinnerItems.Dessert
      Dim flagValue As DinnerItems = DinnerItems.Entree Or DinnerItems.Beverage
      Console.WriteLine("{0} includes {1}: {2}", 
                        myOrder, flagValue, myOrder.HasFlag(flagValue))
   End Sub
End Module
' The example displays the following output:
'    Entree, Appetizer, Dessert, Beverage includes Entree, Beverage: True
' </Snippet2>
