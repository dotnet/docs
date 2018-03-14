 ' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class DemoControl
    Inherits UserControl

    Private borderAppearanceValue As New BorderAppearance()
    Private components As System.ComponentModel.IContainer = Nothing


    Public Sub New()
        InitializeComponent()

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If

        MyBase.Dispose(disposing)

    End Sub

    ' <snippet2>
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("Demo"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Border() As BorderAppearance

        Get
            Return Me.borderAppearanceValue
        End Get

        Set(ByVal value As BorderAppearance)
            Me.borderAppearanceValue = value
        End Set

    End Property
    ' </snippet2>

    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font

    End Sub
End Class

' <snippet3>
<TypeConverter(GetType(BorderAppearanceConverter))>  _
Public Class BorderAppearance
    Private borderSizeValue As Integer = 1
    Private borderColorValue As Color = Color.Empty
    
    
    <Browsable(True), NotifyParentProperty(True), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(1)>  _
    Public Property BorderSize() As Integer 
        Get
            Return borderSizeValue
        End Get
        Set
            If value < 0 Then
                Throw New ArgumentOutOfRangeException("BorderSize", value, "must be >= 0")
            End If
            
            If borderSizeValue <> value Then
                borderSizeValue = value
            End If
        End Set
    End Property
    
    
    <Browsable(True), NotifyParentProperty(True), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(GetType(Color), "")>  _
    Public Property BorderColor() As Color 
        Get
            Return borderColorValue
        End Get
        Set
            If value.Equals(Color.Transparent) Then
                Throw New NotSupportedException("Transparent colors are not supported.")
            End If
            
            If borderColorValue <> value Then
                borderColorValue = value
            End If
        End Set
    End Property
End Class
' </snippet3>

' <snippet4>
Public Class BorderAppearanceConverter
    Inherits ExpandableObjectConverter
    
    ' This override prevents the PropertyGrid from 
    ' displaying the full type name in the value cell.
    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object

        If destinationType Is GetType(String) Then
            Return ""
        End If

        Return MyBase.ConvertTo(context, culture, value, destinationType)

    End Function
End Class
' </snippet4>
' </snippet1>