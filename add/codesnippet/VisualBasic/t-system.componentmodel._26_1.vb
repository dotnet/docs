        <AmbientValue(GetType(Color), "Empty"), _
        Category("Appearance"), _
        DefaultValue(GetType(Color), "White"), _
        Description("The color used for painting alert text.")> _
        Public Property AlertForeColor() As Color
            Get
                If Me.alertForeColorValue = Color.Empty AndAlso (Me.Parent IsNot Nothing) Then
                    Return Parent.ForeColor
                End If

                Return Me.alertForeColorValue
            End Get

            Set(ByVal value As Color)
                Me.alertForeColorValue = value
            End Set
        End Property

        ' This method is used by designers to enable resetting the
        ' property to its default value.
        Public Sub ResetAlertForeColor()
            Me.AlertForeColor = AttributesDemoControl.defaultAlertForeColorValue
        End Sub

        ' This method indicates to designers whether the property
        ' value is different from the ambient value, in which case
        ' the designer should persist the value.
        Private Function ShouldSerializeAlertForeColor() As Boolean
            Return Me.alertForeColorValue <> AttributesDemoControl.ambientColorValue
        End Function