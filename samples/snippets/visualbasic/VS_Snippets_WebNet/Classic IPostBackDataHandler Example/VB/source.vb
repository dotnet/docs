' <Snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports System.Collections.Specialized

Namespace CustomWebFormsControls
    
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> Public Class MyTextBox
        Inherits Control
        Implements IPostBackDataHandler
        
        
        Public Property Text() As String
            Get
                Return CType(Me.ViewState("Text"), String)
            End Get
            
            Set
                Me.ViewState("Text") = value
            End Set
        End Property
        
        
        Public Event TextChanged As EventHandler
        
        
        Public Overridable Shadows Function LoadPostData( _
        postDataKey As String, _
        postCollection As System.Collections.Specialized.NameValueCollection) _
        As Boolean Implements IPostBackDataHandler.LoadPostData
            
            Dim presentValue As String = Text
            Dim postedValue As String = postCollection(postDataKey)
            
            If presentValue Is Nothing Or Not presentValue.Equals(postedValue) Then
                Text = postedValue
                Return True
            End If
            
            Return False
        End Function
        
        
        Public Overridable Shadows Sub RaisePostDataChangedEvent() _
        Implements IPostBackDataHandler.RaisePostDataChangedEvent
        
            OnTextChanged(EventArgs.Empty)
        End Sub
        
        
        Protected Overridable Sub OnTextChanged(e As EventArgs)
            RaiseEvent TextChanged(Me, e)
        End Sub
        
        
        Protected Overrides Sub Render(output As HtmlTextWriter)
            output.Write("<INPUT type= text name = " & Me.UniqueID & _
                " value = " & Me.Text & " >")
        End Sub
        
    End Class
    
End Namespace

' </Snippet1>
