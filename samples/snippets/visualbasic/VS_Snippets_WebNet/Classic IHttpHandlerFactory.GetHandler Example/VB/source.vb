' <Snippet1>
' Name this Visual Basic file HandlerFactoryTest.vb and compile it with 
' the command line: vbc /t:Library /r:System.Web.dll HandlerFactoryTest.vb.
' Copy HandlerFactoryTest.dll to your \bin directory.
Imports System
Imports System.Web

Namespace test    
    
    ' Factory class that creates a handler object based on a request 
    ' for either abc.aspx or xyz.aspx as specified in the Web.config file.
    Public Class MyFactory
        Implements IHttpHandlerFactory
        
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Public Overridable Function GetHandler(context As HttpContext, _
        requestType As String, url As String, pathTranslated As String) _
        As IHttpHandler _
        Implements IHttpHandlerFactory.GetHandler
        
            Dim fname As String = url.Substring(url.LastIndexOf("/"c) + 1)
            Dim cname As String = fname.Substring(0, fname.IndexOf("."c))
            Dim className As String = "test." & cname
            
            Dim h As Object = Nothing
            
            Try ' to create the handler object.
                ' Create by calling class abc or class xyz.
                h = Activator.CreateInstance(Type.GetType(className))
            Catch e As Exception
                Throw New HttpException("Factory couldn't create instance " & _
                    "of type " & className, e)
            End Try
            Return CType(h, IHttpHandler)
        End Function
        
        
        ' This is a must override method.
        Public Overridable Sub ReleaseHandler(handler As IHttpHandler) _
        Implements IHttpHandlerFactory.ReleaseHandler
        
        End Sub
        
    End Class
    
    
    ' Class definition for abc.aspx handler.
    Public Class abc
        Implements IHttpHandler
        
        Public Overridable Sub ProcessRequest(context As HttpContext) _
        Implements IHttpHandler.ProcessRequest
        
            context.Response.Write("<html><body>")
            context.Response.Write("<p>ABC Handler</p>" & _
                Microsoft.VisualBasic.ControlChars.CrLf)
            context.Response.Write("</body></html>")
        End Sub        
        
        Public Overridable ReadOnly Property IsReusable() As Boolean _
        Implements IHttpHandler.IsReusable
        
            Get
                Return True
            End Get
        End Property
    End Class
     
    ' Class definition for xyz.aspx handler.
    Public Class xyz
        Implements IHttpHandler
        
        Public Overridable Sub ProcessRequest(context As HttpContext) _
        Implements IHttpHandler.ProcessRequest
        
            context.Response.Write("<html><body>")
            context.Response.Write("<p>XYZ Handler</p>" & _
                Microsoft.VisualBasic.ControlChars.CrLf)
            context.Response.Write("</body></html>")
        End Sub
        
        
        Public Overridable ReadOnly Property IsReusable() As Boolean _
        Implements IHttpHandler.IsReusable
        
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace

'______________________________________________________________
'
'To use the handler factory, use the following lines in a
'Web.config file. (be sure to remove the comment markers)
'
'<configuration>
'   <system.web>
'      <httpHandlers>
'         <add verb="*" path="abc.aspx" type="test.MyFactory,HandlerFactoryTest" />
'         <add verb="*" path="xyz.aspx" type="test.MyFactory,HandlerFactoryTest" />
'      </httpHandlers>
'   </system.web>
'</configuration>


' </Snippet1>
