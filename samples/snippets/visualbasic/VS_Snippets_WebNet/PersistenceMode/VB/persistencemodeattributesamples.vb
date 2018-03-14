'  System.Web.UI.PersistenceMode.Attribute;System.Web.UI.PersistenceMode.InnerProperty;
'  System.Web.UI.PersistenceMode.InnerDefaultProperty;

'  The following example demonstrates the attribute 'PersistenceModeAttribute' and members 'Attribute','InnerProperty'
'  and 'InnerDefaultProperty' of enumeration PersistenceMode.
'  A simple Templated control 'MyTemplateControl' is created. Different persistence modes have been applied to it's 
'  properties.
'  'PersistenceMode.Attribute' is applied to property 'Author' which is of type string.
'  This is initialized as an attribute of the html tag. 
' 'PersistenceMode.InnerProperty' is applied to property 'MessageTemplate' which is of type 'ITemplate'. 
'  This is initialized as a nested tag in the html tag.
'  AND  
' 'PersistenceMode.InnerDefaultProperty' is applied to property 'Items' which is of type 'ListItemCollection'.
' This is initialized as inner content of the HTML tag as a child
 
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace PersistenceModeAttributeSamples

   ' The container control class to instantiate the template property 'MessageTemplate'
   Public Class TemplateItem
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      Private _author As [String] = Nothing
      
      Public Sub New(author As [String])
         _author = author
      End Sub 'New
      
      Public Property Author() As [String]
         Get
            Return _author
         End Get
         Set
            _author = value
         End Set
      End Property
   End Class 'TemplateItem
   <ParseChildren(True)> Public Class MyTemplateControl
      Inherits Control
      Implements INamingContainer 'ToDo: Add Implements Clauses for implementation methods of these interface(s)

      ' 'ParseChildren' Attribute ensures nested (child) elements correspond to properties of the control. 
      ' Other (nonproperty) elements and literal text between control tags will generate a parser error. 

      Private _messageTemplate As ITemplate = Nothing
      Private _author As String = Nothing
      Private myCollection As ListItemCollection = Nothing

 ' <Snippet1>    

      <PersistenceMode(PersistenceMode.Attribute)> Public Property Author() As String
         Get
            Return _author
         End Get
         Set(ByVal Value As String)
            _author = Value
         End Set
      End Property

' </Snippet1>

' <Snippet2>

      <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(TemplateItem))> Public Property MessageTemplate() As ITemplate
         Get
            Return _messageTemplate
         End Get
         Set(ByVal Value As ITemplate)
            _messageTemplate = Value
         End Set
      End Property

' </Snippet2>
' <Snippet3>

      <PersistenceMode(PersistenceMode.InnerDefaultProperty)> Public ReadOnly Property Items() As ListItemCollection
         Get
            If myCollection Is Nothing Then
               myCollection = New ListItemCollection()
               If IsTrackingViewState Then
                  CType(myCollection, IStateManager).TrackViewState()
               End If
            End If
            Return myCollection
         End Get
      End Property

' </Snippet3>

      ' When called on a server control, this method resolves all data-binding 
      ' expressions in the server control and in any of its child controls.
      Public Overrides Sub DataBind()
         EnsureChildControls()
         MyBase.DataBind()
      End Sub 'DataBind


      Protected Overrides Sub CreateChildControls()
         ' If a template has been specified, use it to create children.
         ' Otherwise, create a single literalcontrol with author value.
         If Not (MessageTemplate Is Nothing) Then
            Controls.Clear()
            Dim i As New TemplateItem(Me.Author)
            MessageTemplate.InstantiateIn(i)
            Controls.Add(i)
         Else
            Me.Controls.Add(New LiteralControl(Me.Author))
         End If
      End Sub 'CreateChildControls
   End Class 'MyTemplateControl
End Namespace 'PersistenceModeAttributeSamples
