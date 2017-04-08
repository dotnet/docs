Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Windows.Forms

Public Class UserControl1
    Inherits System.Windows.Forms.UserControl
    Private components As System.ComponentModel.Container = Nothing

    '<Snippet1>
    <EditorAttribute(GetType(System.Drawing.Design.BitmapEditor), _
        GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property testBitmap() As Bitmap
        Get
            Return testBmp
        End Get
        Set(ByVal Value As Bitmap)
            testBmp = Value
        End Set
    End Property

    Private testBmp As Bitmap
    '</Snippet1>

    Public Sub New()
    End Sub

End Class