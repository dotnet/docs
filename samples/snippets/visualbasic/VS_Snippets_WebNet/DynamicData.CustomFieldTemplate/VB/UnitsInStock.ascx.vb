Imports System
' <Snippet2>
Imports System.Web.DynamicData

Partial Public Class DynamicData_FieldTemplates_UnitsInStock
    Inherits FieldTemplateUserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ' DataBinding event handler.
    Public Sub DataBindingHandler(ByVal sender As Object, _
                                  ByVal e As EventArgs)
        ' Define product understocked threshold.
        Dim underStockedThreshold As Short = 150

        ' Get the current number of items in stock.
        Dim currentValue As Short = DirectCast(FieldValue, Short)

        ' Check product stock. 
        If currentValue < underStockedThreshold Then
            ' The product is understocked, set its 
            ' foreground color to red.
            TextLabel1.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

End Class
' </Snippet2>

