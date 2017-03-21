        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get a reference to the control or a copy of the control.
            Dim myHF As MyHiddenField = CType(ViewControl, MyHiddenField)

            Dim markup As String = _
                CreatePlaceHolderDesignTimeHtml( _
                    "Value: """ & myHF.Value.ToString() & """" )

            Return markup

        End Function ' GetDesignTimeHtml