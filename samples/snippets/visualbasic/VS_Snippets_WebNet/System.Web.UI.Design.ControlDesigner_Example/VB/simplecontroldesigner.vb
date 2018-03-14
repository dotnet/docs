' <snippet1>
' Create a designer class for a custom class,
' named Simple.
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports AspNet.Samples

Namespace AspNet.Samples

   Public NotInheritable Class SimpleDesigner
      Inherits System.Web.UI.Design.ControlDesigner
      ' Declare a reference to the Simple class
      Private simpleControl As Simple
  
' <snippet2>      
      ' Create a constructor for the designer class
      ' When an instance of the designer is created,
      ' the Text property of the instance of a Simple control
      ' is set to the designer's ID property.
      ' the designer is called.
      Public Sub New()
        simpleControl = CType(Component, Simple)      
        simpleControl.Text = Me.ID
      End Sub
 ' </snippet2>

      ' Override the Initialize method to ensure
      ' that the designer is always working with
      ' an instance of the Simple class.
      Overrides Public Sub Initialize( _
       ByVal component As IComponent _
      )
      
        If Not (component Is simpleControl)
                throw new ArgumentException( _
                 "The component must be an instance of the Simple class.", _
                 "component")
        End If

        MyBase.Initialize(component)
      
      End Sub
      
      Overrides Public ReadOnly Property AllowResize As Boolean
        Get
          Return True
        End Get
      End Property
      
'<snippet5>
      Public Overrides Function GetDesignTimeHtml() As String
         ' Component is the instance of the component or control that
         ' this designer object is associated with. This property is 
         ' inherited from System.ComponentModel.ComponentDesigner.
         simpleControl = CType(Component, Simple)
         
         If simpleControl.Text.Length > 0 Then
            Dim sw As New StringWriter()
            Dim tw As New HtmlTextWriter(sw)
            
            Dim placeholderLink As New HyperLink()
            
            ' Put simpleControl.Text into the link's Text.
            placeholderLink.Text = simpleControl.Text
            placeholderLink.NavigateUrl = simpleControl.Text
            placeholderLink.RenderControl(tw)
            
            Return sw.ToString()
         Else
            Return GetEmptyDesignTimeHtml()
         End If
      End Function
'</snippet5>

' <snippet3>
      ' Override the OnControlResize method to
      ' set the IsDirty property to true and
      ' call the UpdateDesignTimeHtml method.      
      Overrides Protected Sub OnControlResize()
        Me.IsDirty = True
        Me.UpdateDesignTimeHtml
      End Sub
' </snippet3>
      
   End Class
End Namespace
' </snippet1>

' <snippet4>
' Create a custom class, named Simple, that renders
' its Text property. Use the DesignerAttribute to
' associate it with its custom designer class, named
' SimpleDesigner.
Namespace AspNet.Samples

    <Designer(GetType(AspNet.Samples.SimpleDesigner))> _
   Public NotInheritable Class Simple
        Inherits WebControl

        Private _text As String

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            writer.Write(Text)
        End Sub
    End Class
End Namespace

' </snippet4>
