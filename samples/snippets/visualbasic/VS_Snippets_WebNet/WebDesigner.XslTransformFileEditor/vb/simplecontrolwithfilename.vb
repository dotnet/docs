' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls
Imports System.IO

Namespace ControlDesignerSamples.VB

    ' <Snippet2>

    ' Define a simple text control, derived from the 
    ' System.Web.UI.WebControls.Label class.

    <Designer(GetType(TextControlDesigner))> _
    Public Class SimpleTextControl
        Inherits Label

        ' Define a private member to store the file name value in the control.
        Private _filename As String = ""
        Private _internalText As String = ""

        ' Define the public XML transform file property.  Indicate that the
        ' property can be edited at design-time with the XslTransformFileEditor class.
        <EditorAttribute(GetType(System.Web.UI.Design.XslTransformFileEditor), _
                         GetType(System.Drawing.Design.UITypeEditor))> _
        Public Property TransformFileName() As String
            Get
                Return _filename
            End Get

            Set(ByVal value As String)
                _filename = value
            End Set
        End Property

        ' Define a property that returns the timestamp
        ' for the selected file.
        Public ReadOnly Property LastChanged() As String
            Get
                If Not _filename Is Nothing AndAlso _filename.Length > 0 Then
                    If File.Exists(_filename) Then
                        Dim lastChangedStamp As DateTime
                        lastChangedStamp = File.GetLastWriteTime(_filename)
                        Return lastChangedStamp.ToLongDateString()
                    End If
                End If

                Return String.Empty

            End Get

        End Property

        ' Override the control Text property, setting the default
        ' text to the LastChanged string value for the selected
        ' file name.  If the file name has not been set in the
        ' design view, then default to an empty string.
        Public Overrides Property Text() As String
            Get
                If _internalText.Length = 0 And LastChanged.Length > 0 Then
                    ' If the internally stored value hasn't been set,
                    ' and the file name property has been set,
                    ' return the last changed timestamp for the file.

                    _internalText = LastChanged
                End If
                Return _internalText
            End Get

            Set(ByVal value As String)
                If Not value Is Nothing AndAlso value.Length > 0 Then
                    _internalText = value
                Else
                    _internalText = String.Empty
                End If

            End Set
        End Property

    End Class
    ' </Snippet2>
End Namespace
' </Snippet1>
