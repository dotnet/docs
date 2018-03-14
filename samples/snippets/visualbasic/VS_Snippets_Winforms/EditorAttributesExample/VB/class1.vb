Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Web.UI.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class Class1
    Inherits System.ComponentModel.Component

    ' System.ComponentModel.Design.CollectionEditor EditorAttribute example
    '<Snippet1>
   <EditorAttribute(GetType(System.ComponentModel.Design.CollectionEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testCollection() As ICollection
      Get
         Return Icollection
      End Get
      Set
         Icollection = value
      End Set
   End Property
   Private Icollection As ICollection
   '</Snippet1>

    ' System.Drawing.Design.FontEditor EditorAttribute example
   '<Snippet2>   
   <EditorAttribute(GetType(System.Drawing.Design.FontEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testFont() As Font
      Get
         Return font
      End Get
      Set
         font = value
      End Set
   End Property
   Private font As Font
    '</Snippet2>

   ' System.Drawing.Design.ImageEditor EditorAttribute example
   '<Snippet3>   
   <EditorAttribute(GetType(System.Drawing.Design.ImageEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testImage() As Image
      Get
         Return testImg
      End Get
      Set
         testImg = value
      End Set
   End Property
   Private testImg As Image
    '</Snippet3>

   ' System.Windows.Forms.Design.AnchorEditor EditorAttribute example
   '<Snippet4>   
   <EditorAttribute(GetType(System.Windows.Forms.Design.AnchorEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testAnchor() As System.Windows.Forms.AnchorStyles
      Get
         Return anchor
      End Get
      Set
         anchor = value
      End Set
   End Property
   Private anchor As AnchorStyles
    '</Snippet4>

   ' System.Windows.Forms.Design.FileNameEditor EditorAttribute example
   '<Snippet5>   
   <EditorAttribute(GetType(System.Windows.Forms.Design.FileNameEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testFilename() As String
      Get
         Return filename
      End Get
      Set
         filename = value
      End Set
   End Property
   Private filename As String   
    '</Snippet5>

   Public Sub New()
      ' Initialize collections for design-mode editor testing.
      Icollection = New Integer() {0, 2, 4, 6, 8, 12, 14}
      font = New Font("Arial", 8)
      testAnchor = AnchorStyles.None
      filename = String.Empty
    End Sub

End Class