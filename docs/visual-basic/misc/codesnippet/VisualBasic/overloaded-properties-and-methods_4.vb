    Public Class TaxClass
        Overloads Function TaxAmount(ByVal decPrice As Decimal, 
             ByVal TaxRate As Single) As String
            TaxAmount = "Price is a Decimal. Tax is $" & 
               (CStr(decPrice * TaxRate))
        End Function

        Overloads Function TaxAmount(ByVal strPrice As String, 
              ByVal TaxRate As Single) As String
            TaxAmount = "Price is a String. Tax is $" & 
               CStr((CDec(strPrice) * TaxRate))
        End Function
    End Class