    ' This is the shadowed property on the designer.
    ' This value will be serialized instead of the 
    ' value of the control's property.

    Public Property BackColor() As Color
        Get
            Return CType(ShadowProperties("BackColor"), Color)
        End Get
        Set(ByVal value As Color)
            If (Me.changeService IsNot Nothing) Then
                Dim backColorDesc As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Control)("BackColor")

                Me.changeService.OnComponentChanging(Me.Control, backColorDesc)

                Me.ShadowProperties("BackColor") = value

                Me.changeService.OnComponentChanged(Me.Control, backColorDesc, Nothing, Nothing)
            End If
        End Set
    End Property