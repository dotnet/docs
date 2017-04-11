' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Module Example
   Public Sub Main()
      Dim hasServiceCharges() As Boolean = { True, False }
      Dim subtotal As Decimal = 120.62d
      Dim shippingCharge As Decimal = 2.50d
      Dim serviceCharge As Decimal = 5.00d
      
      For Each hasServiceCharge In hasServiceCharges
         Dim total As Decimal = subtotal + shippingCharge + 
                                If(hasServiceCharge, serviceCharge, 0)
         Console.WriteLine("hasServiceCharge = {1}: The total is {0:C2}.", 
                           total, hasServiceCharge)                       
      Next
   End Sub
End Module
' The example displays output like the following:
'       hasServiceCharge = True: The total is $128.12.
'       hasServiceCharge = False: The total is $123.12.
' </Snippet13>
