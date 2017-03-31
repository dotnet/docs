Imports Microsoft.VisualBasic
Imports System.Web.Routing

Public Class CategoryRouteHandler
    Implements System.Web.Routing.IRouteHandler

    Function GetHttpHandler(ByVal requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
        Return Nothing
    End Function
End Class

Public Class ReportRouteHandler
    Implements System.Web.Routing.IRouteHandler

    Function GetHttpHandler(ByVal requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
        Return Nothing
    End Function
End Class