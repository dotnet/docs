' System.Web.UI.Control.CreateControlCollection; 
' System.Web.UI.Control.ChildControlsCreated;
' System.Web.UI.Control.RenderControl; System.Web.UI.Control.RenderChildren;

' The following example demontrates implementation of methods 'RenderControl',
' 'RenderChildren' and 'CreateControlCollection' with property 
' 'ChildControlsCreated' of 'System.Web.UI.Control' class.    

' This program creates a custom control 'ParentControl' by inheriting from 
' 'Control' Class. Method 'CreateChildControls' is overridden to create new child 
' controls. "Render" method is overridden to write the rendered content to client. 
' 'RenderChildren' method is overridden for custom implementation of displaying 
' controls in reverse order. 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace RenderChildrenSample

   Public Class ParentControl
      Inherits Control
      Private _message As String = "Parent Control"
            
      Public Property Message() As String
         Get
            Return _message
         End Get
         Set
            _message = value
         End Set
      End Property

' <Snippet1>
' <Snippet2>
      Protected Overrides Sub CreateChildControls()
         ' Creates a new ControlCollection. 
         Me.CreateControlCollection()
         
         ' Create child controls.
         Dim firstControl As New ChildControl()
         firstControl.Message = "FirstChildControl"
         
         Dim secondControl As New ChildControl()
         secondControl.Message = "SecondChildControl"
         
         Controls.Add(firstControl)
         Controls.Add(secondControl)
         
         ' Prevent child controls from being created again.
         ChildControlsCreated = True
      End Sub 'CreateChildControls
      
      
' </Snippet2>
' </Snippet1>

' <Snippet3>
' <Snippet4>
' Override default implementation to Render children according to needs. 
      Protected Overrides Sub RenderChildren(output As HtmlTextWriter)
         If HasControls() Then
            ' Render Children in reverse order.
            Dim i As Integer

            For i = Controls.Count - 1 To 0 Step -1
               Controls(i).RenderControl(output)
            Next

         End If
      End Sub 'RenderChildren
      
      
      Protected Overrides Sub Render(output As HtmlTextWriter)
         output.Write(("<br>Message from Control : " + Message))
         output.Write(("Showing Custom controls created in reverse" + "order"))
         ' Render Controls.
         RenderChildren(output)
      End Sub
   End Class

' </Snippet4>
' </Snippet3>
   
   Public Class ChildControl
      Inherits Control

      Private _message As String = "Child Control"
      
      Public Property Message() As String
         Get
            Return _message
         End Get
         Set
            _message = value
         End Set
      End Property
      
      
      Protected Overrides Sub Render(output As HtmlTextWriter)
         output.Write(("<br>Message from Control : " + Message))
      End Sub 
   End Class 
End Namespace 