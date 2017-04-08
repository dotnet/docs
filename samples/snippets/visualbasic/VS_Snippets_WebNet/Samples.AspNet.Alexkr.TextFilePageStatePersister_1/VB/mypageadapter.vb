' <snippet5>
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyPageAdapter
       Inherits System.Web.UI.Adapters.PageAdapter


       Public Overrides Function GetStatePersister() As PageStatePersister
          Return New Samples.AspNet.VB.StreamPageStatePersister(Page)
       End Function 'GetStatePersister

    End Class 'MyPageAdapter

End Namespace
' </snippet5>

' <snippet6>
' C:\>vbc /t:library /out:C:\inetpub\wwwroot\bin\Samples.AspNet.VB.dll MyPageAdapter.vb TextFilePageStatePersister.vb
'
' </snippet6>