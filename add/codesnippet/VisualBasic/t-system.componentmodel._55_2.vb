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