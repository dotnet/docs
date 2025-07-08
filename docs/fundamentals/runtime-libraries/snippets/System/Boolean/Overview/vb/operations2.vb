' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Module Example6
    Public Sub Main()
        Dim hasServiceCharges() As Boolean = {True, False}
        Dim subtotal As Decimal = 120.62D
        Dim shippingCharge As Decimal = 2.5D
        Dim serviceCharge As Decimal = 5D

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
