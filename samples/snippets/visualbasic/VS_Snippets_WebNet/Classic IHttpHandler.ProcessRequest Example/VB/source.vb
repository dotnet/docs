' <Snippet1>
' Name this Visual Basic file HandlerTest.vb and compile it with the
' command line: vbc /target:library /r:System.Web.dll HandlerTest.vb.
' Copy HandlerTest.dll to your \bin directory.
Imports System.Web

Namespace HandlerExample
    
    Public Class MyHttpHandler
        Implements IHttpHandler
        
        ' Override the ProcessRequest method.
        Public Sub ProcessRequest(context As HttpContext) _
        Implements IHttpHandler.ProcessRequest
        
            context.Response.Write("<H1>This is an HttpHandler Test.</H1>")
            context.Response.Write("<p>Your Browser:</p>")
            context.Response.Write("Type: " & context.Request.Browser.Type & "<br>")
            context.Response.Write("Version: " & context.Request.Browser.Version)
        End Sub
        
        ' Override the IsReusable property.        
        Public ReadOnly Property IsReusable() As Boolean _
        Implements IHttpHandler.IsReusable
        
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace

'______________________________________________________________
'
' To use this handler, include the following lines in a
' Web.config file (be sure to remove the comment markers).
'
'<configuration>
'   <system.web>
'      <httpHandlers>
'         <add verb="*" path="handler.aspx" type="HandlerExample.MyHttpHandler,HandlerTest"/>
'      </httpHandlers>
'   </system.web>
'</configuration>

' </Snippet1>
