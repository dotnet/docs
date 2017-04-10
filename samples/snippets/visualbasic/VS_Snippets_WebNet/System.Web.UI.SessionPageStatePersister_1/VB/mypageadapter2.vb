' <snippet1>
Imports System.Web.UI

Namespace Samples.AspNet.VB

    Public Class MyPageAdapter
       Inherits System.Web.UI.Adapters.PageAdapter


       Public Overrides Function GetStatePersister() As PageStatePersister
          Return New SessionPageStatePersister(Page)
       End Function 'GetStatePersister

    End Class 'MyPageAdapter

End Namespace
' </snippet1>
