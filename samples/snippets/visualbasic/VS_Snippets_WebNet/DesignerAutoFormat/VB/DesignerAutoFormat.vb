'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace CustomControls.Design

    ' A custom Label control whose contents can be indented
    <Designer(GetType(IndentLabelDesigner)), _
        ToolboxData("<{0}:IndentLabel Runat=""server""></{0}:IndentLabel>")> _
    Public Class IndentLabel
        Inherits System.Web.UI.WebControls.Label

        Dim _indent As Integer = 0

        <Category("Appearance"), DefaultValue(0), _
            PersistenceMode(PersistenceMode.Attribute)> _
        Property Indent() As Integer
            Get
                Return _indent
            End Get
            Set(ByVal Value As Integer)
                _indent = Value

                ' Get the number of pixels to indent
                Dim ind As Integer = _indent * 8

                ' Add the indent style to the control
                If ind > 0 Then
                    Me.Style.Add(HtmlTextWriterStyle.MarginLeft, ind.ToString() & "px")
                Else
                    Me.Style.Remove(HtmlTextWriterStyle.MarginLeft)
                End If
            End Set
        End Property

    End Class

    ' A design-time ControlDesigner for the IndentLabel control
    Public Class IndentLabelDesigner
        Inherits LabelDesigner

        Private _autoFormats As DesignerAutoFormatCollection = Nothing
        '<Snippet2>
        ' The collection of AutoFormat objects for the IndentLabel object
        Public Overrides ReadOnly Property AutoFormats() As DesignerAutoFormatCollection
            Get
                If _autoFormats Is Nothing Then
                    ' Create the collection
                    _autoFormats = New DesignerAutoFormatCollection()

                    ' Create and add each AutoFormat object
                    _autoFormats.Add(New IndentLabelAutoFormat("MyClassic"))
                    _autoFormats.Add(New IndentLabelAutoFormat("MyBright"))
                    _autoFormats.Add(New IndentLabelAutoFormat("Default"))
                End If

                Return _autoFormats
            End Get
        End Property
        '</Snippet2>

        ' An AutoFormat object for the IndentLabel control
        Public Class IndentLabelAutoFormat
            Inherits DesignerAutoFormat

            Public Sub New(ByVal name As String)
                MyBase.New(name)
            End Sub

            '<Snippet3>
            ' Applies styles based on the Name of the AutoFormat
            Public Overrides Sub Apply(ByVal inLabel As Control)
                If TypeOf inLabel Is IndentLabel Then
                    Dim ctl As IndentLabel = CType(inLabel, IndentLabel)

                    ' Apply formatting according to the Name
                    If Me.Name.Equals("MyClassic") Then
                        ' For MyClassic, apply style elements directly to the control
                        ctl.ForeColor = Color.Gray
                        ctl.BackColor = Color.LightGray
                        ctl.Font.Size = FontUnit.XSmall
                        ctl.Font.Name = "Verdana,Geneva,Sans-Serif"
                    ElseIf Me.Name.Equals("MyBright") Then
                        ' For MyBright, apply style elements to the Style object
                        Me.Style.ForeColor = Color.Maroon
                        Me.Style.BackColor = Color.Yellow
                        Me.Style.Font.Size = FontUnit.Medium

                        ' Merge the AutoFormat style with the control's style
                        ctl.MergeStyle(Me.Style)
                    Else
                        ' For the Default format, apply style elements to the control
                        ctl.ForeColor = Color.Black
                        ctl.BackColor = Color.Empty
                        ctl.Font.Size = FontUnit.XSmall
                    End If
                End If
            End Sub
            '</Snippet3>
        End Class
    End Class

End Namespace
'</Snippet1>