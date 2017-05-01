Imports System.Web.DynamicData
Imports System.Web.Routing
' <Snippet2>
Imports System.ComponentModel.DataAnnotations

<ScaffoldTable(True)> _
Partial Public Class Product
End Class
' </Snippet2>

Public Class Registration

    Sub RegisterContext()
        Dim model As New MetaModel()
        ' <Snippet1>
        model.RegisterContext(GetType(AdventureWorksLTDataContext), _
                              New ContextConfiguration() With {.ScaffoldAllTables = True})
        ' </Snippet1>
    End Sub

    Sub RegisterListDetailsTemplate()
        Dim routes As RouteCollection = RouteTable.Routes
        Dim model As New MetaModel()

        ' <Snippet3>
        routes.Add(New DynamicDataRoute("{table}/ListDetails.aspx") With { _
          .Action = PageAction.List, _
          .ViewName = "ListDetails", _
          .Model = model})

        routes.Add(New DynamicDataRoute("{table}/ListDetails.aspx") With { _
          .Action = PageAction.Details, _
          .ViewName = "ListDetails", _
          .Model = model})
        ' </Snippet3>
    End Sub

    Sub RegisterSpecificRoute()
        Dim routes As RouteCollection = RouteTable.Routes
        Dim model As New MetaModel()

        ' <Snippet4>
        routes.Add(New DynamicDataRoute("Products/{action}.aspx") With { _
          .ViewName = "ListDetails", _
          .Table = "Products", _
          .Model = model})

        routes.Add(New DynamicDataRoute("{table}/{action}.aspx") With { _
          .Constraints = New RouteValueDictionary( _
            New With {.Action = "List|Details|Edit|Insert"}), _
          .Model = model})
        ' </Snippet4>

    End Sub
End Class 'Registration

Public Class AdventureWorksLTDataContext

End Class