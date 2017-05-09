' <snippet2>
Partial Class WizardClassvb_aspx
    Inherits System.Web.UI.Page

   Protected Sub OnFinishButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick

        ' The OnFinishButtonClick method is a good place to collect all
        ' the data from the completed pages and persist it to the data store. 

        ' For this example, write a confirmation message to the Complete page
        ' of the Wizard control.
        Dim tempLabel As Label = CType(Wizard1.FindControl("CompleteMessageLabel"), Label)
        If Not tempLabel Is Nothing Then

            Dim tempEmailAddress As String = "your e-mail address"
            If EmailAddress.Text.Length <> 0 Then
                tempEmailAddress = EmailAddress.Text
            End If

            tempLabel.Text = "Your order has been placed. An e-mail confirmation will be sent to " & _
                tempEmailAddress & "."

        End If
    End Sub

    Protected Sub OnGoBackButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles GoBackButton.Click

        ' The GoBackButtonClick event is raised when the GoBackButton
        ' is clicked on the Finish page of the Wizard.  

        ' Check the value of Step1's AllowReturn property.
        If Step1.AllowReturn Then
            ' Return to Step1.
            Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(Me.Step1)
        Else
            ' Step1 is not a valid step to return to; go to Step2 instead.
            Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(Me.Step2)
            Response.Write("ActiveStep is set to Step2 because Step1 has AllowReturn set to false.")
        End If
    End Sub

    Protected Sub OnActiveStepChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Wizard1.ActiveStepChanged

        ' If the ActiveStep is changing to Step3, check to see whether the 
        ' SeparateShippingCheckBox is selected.  If it is not, skip to the
        ' Finish step.

        If (Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(Me.Step3)) Then

            If (Me.SeparateShippingCheckBox.Checked) Then
                Wizard1.MoveTo(Me.Step3)
            Else
                Wizard1.MoveTo(Me.Finish)
            End If

        End If
    End Sub

End Class
' </snippet2>
