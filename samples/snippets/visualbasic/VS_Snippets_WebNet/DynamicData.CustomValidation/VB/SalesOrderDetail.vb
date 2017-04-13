' <Snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations

Partial Public Class SalesOrderDetail
    Private Sub OnOrderQtyChanging(ByVal value As Short)
        If value < 100 Then
            Throw New ValidationException( _
               "Quantity is less than the allowed minimum of 100.")
        End If
    End Sub
End Class

' </Snippet2>
