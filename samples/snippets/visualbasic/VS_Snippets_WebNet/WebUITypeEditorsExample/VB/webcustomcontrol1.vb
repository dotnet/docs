
Imports System
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design


'[DesignerAttribute(typeof(WebControlDesignerExample), typeof(IDesigner))]
<DefaultProperty("Text"), ToolboxData("<{0}:WebCustomControl1 runat=server></{0}:WebCustomControl1>")>  _
Public Class WebCustomControl1
   Inherits System.Web.UI.WebControls.WebControl
   Private [text] As String
   
   '<Snippet1>   
   <EditorAttribute(GetType(System.Web.UI.Design.UrlEditor), GetType(UITypeEditor))>  _
   Public Property URL() As String
      Get
         Return http_url
      End Get
      Set
         http_url = value
      End Set
   End Property
   
   Private http_url As String
   '</Snippet1>

    '<Snippet2>   
   <EditorAttribute(GetType(System.Web.UI.Design.XmlFileEditor), GetType(UITypeEditor))>  _
   Public Property XmlFile() As String
      Get
         Return xml_
      End Get
      Set
         xml_ = value
      End Set
   End Property
   
   Private xml_ As String
   '</Snippet2>

    '<Snippet3>   
    <EditorAttribute(GetType(System.Web.UI.Design.XmlUrlEditor), GetType(UITypeEditor))> _
    Public Property XmlFileURL() As String
        Get
            Return xmlURL
        End Get
        Set(ByVal Value As String)
            xmlURL = Value
        End Set
    End Property

    Private xmlURL As String
    '</Snippet3>

    '<Snippet4>
    <EditorAttribute(GetType(System.Web.UI.Design.XslUrlEditor), GetType(UITypeEditor))> _
    Public Property XslFileURL() As String
        Get
            Return xslURL
        End Get
        Set(ByVal Value As String)
            xslURL = Value
        End Set
    End Property

    Private xslURL As String
    '</Snippet4>

    '<Snippet5>
    <EditorAttribute(GetType(System.Web.UI.Design.ImageUrlEditor), GetType(UITypeEditor))> _
    Public Property imageURL() As String
        Get
            Return imgURL
        End Get
        Set(ByVal Value As String)
            imgURL = Value
        End Set
    End Property

    Private imgURL As String
    '</Snippet5>

    '<Snippet6>
    <EditorAttribute(GetType(System.Web.UI.Design.DataBindingCollectionEditor), GetType(UITypeEditor))> _
    Public Property TestDataBindings() As DataBindingCollection
        Get
            Return testBindings
        End Get
        Set(ByVal Value As DataBindingCollection)
            testBindings = Value
        End Set
    End Property

    Private testBindings As DataBindingCollection
    '</Snippet6>

    <Bindable(True), Category("Appearance"), DefaultValue("")> _
    Public Property [Text_]() As String
        Get
            Return [text]
        End Get

        Set(ByVal Value As String)
            [text] = Value
        End Set
    End Property


    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        output.Write([text])
    End Sub 'Render
End Class 'WebCustomControl1