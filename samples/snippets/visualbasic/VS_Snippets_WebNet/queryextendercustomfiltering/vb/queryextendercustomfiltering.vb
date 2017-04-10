'<Snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.Expressions
Imports System.Data.Linq

Partial Class CustomVB
    Inherits System.Web.UI.Page

    Protected Sub FilterProducts(ByVal sender As Object, ByVal e As CustomExpressionEventArgs)
        e.Query = From p In e.Query.Cast(Of Product)() _
            Where p.ListPrice >= 3500 _
            Select p
    End Sub




'</Snippet2>

