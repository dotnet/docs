        ' Override the GetDesignTimeHtml method to add style to the control
        ' on the design surface.
        Public Overrides Function GetDesignTimeHtml() As String
            ' Cast the control to the Component property of the designer.
            simpleList = CType(Component, SimpleDataList)

            Dim designTimeHtml As String = Nothing

            ' Create variables to hold current property values.
            Dim oldBorderWidth As Unit = simpleList.BorderWidth
            Dim oldBorderColor As Color = simpleList.BorderColor

            ' Set the properties and generate the design-time HTML.
            If (simpleList.Enabled) Then
                Try
                    simpleList.BorderWidth = Unit.Point(5)
                    simpleList.BorderColor = Color.Purple
                    designTimeHtml = MyBase.GetDesignTimeHtml()

                    ' Call the GetErrorDesignTimeHtml method if an
                    ' exception occurs.
                Catch ex As Exception
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Return the properties to their original settings.
                Finally
                    simpleList.BorderWidth = oldBorderWidth
                    simpleList.BorderColor = oldBorderColor
                End Try
                ' If the list is not enabled, call the GetEmptyDesignTimeHtml
                ' method.
            Else
                designTimeHtml = GetEmptyDesignTimeHtml()
            End If

            Return designTimeHtml

        End Function