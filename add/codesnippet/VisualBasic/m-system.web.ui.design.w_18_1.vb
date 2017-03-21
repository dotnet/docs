        Public Overrides Function GetDesignTimeHtml() As String
            Dim designTimeHtml As String = String.Empty

            simpleGView = CType(Component, SimpleGridView)

            ' Check the control's BorderStyle property to  
            ' conditionally render design-time HTML.
            If (simpleGView.BorderStyle = BorderStyle.NotSet) Then
                ' Save the current property settings in variables.
                Dim oldCellPadding As Integer = simpleGView.CellPadding
                Dim oldBorderWidth As Unit = simpleGView.BorderWidth
                Dim oldBorderColor As Color = simpleGView.BorderColor

                ' Set properties and generate the design-time HTML.
                Try
                    simpleGView.Caption = "SimpleGridView"
                    simpleGView.CellPadding = 1
                    simpleGView.BorderWidth = Unit.Pixel(3)
                    simpleGView.BorderColor = Color.Red

                    designTimeHtml = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    ' Get HTML from the GetErrorDesignTimeHtml 
                    ' method if an exception occurs.
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Return the properties to their original values.
                Finally
                    simpleGView.CellPadding = oldCellPadding
                    simpleGView.BorderWidth = oldBorderWidth
                    simpleGView.BorderColor = oldBorderColor
                End Try

            Else
                designTimeHtml = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeHtml
        End Function

        Protected Overrides Function _
            GetErrorDesignTimeHtml(ByVal exc As Exception) As String

            Return CreatePlaceHolderDesignTimeHtml( _
                "ASPNET.Examples: An error occurred while rendering the GridView.")

        End Function