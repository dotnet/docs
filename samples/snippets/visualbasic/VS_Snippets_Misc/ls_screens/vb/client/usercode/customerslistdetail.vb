
Namespace LightSwitchApplication

    Public Class CustomersListDetail

        '<Snippet1>
        Private Sub CityCode_Validate(results As ScreenValidationResultsBuilder)
            If Me.CityCode.Length < 3 Then
                results.AddPropertyError("This string must have at least 3 letters.")
            End If
        End Sub
        '</Snippet1>
        '<Snippet3>
        Private Sub Button_Execute()
            Application.ShowCustomersByCity(CityName)
        End Sub
        '</Snippet3>
        '<Snippet4>
        Private Sub FindControlInList()
            Dim index As Integer = 0

            For Each cust As Customer In Customers

                If cust.CompanyName = "Great Lakes Food Market" Then
                    With FindControlInCollection("CompanyName", Customers(index))
                        .IsVisible = False
                        .IsReadOnly = True
                    End With

                End If
                index = index + 1
            Next
        End Sub
        '</Snippet4>
        '<Snippet5>
        Private Sub Customers_SelectionChanged()
            FindControl("Customers_DeleteSelected").IsEnabled = True

            If Me.Customers.SelectedItem.CompanyName = "Great Lakes Food Market" Then

                FindControl("CompanyName1").IsVisible = False
                FindControl("Customers_DeleteSelected").IsEnabled = False

            End If

        End Sub
        '</Snippet5>
        '<Snippet6>
        Private Sub CustomersListDetail_Activated()
            Me.FindControl("Customers").SetBinding( _
                System.Windows.Controls.ListBox.ItemsSourceProperty, _
                        "Value", System.Windows.Data.BindingMode.TwoWay)
        End Sub
        '</Snippet6>
    End Class

End Namespace
