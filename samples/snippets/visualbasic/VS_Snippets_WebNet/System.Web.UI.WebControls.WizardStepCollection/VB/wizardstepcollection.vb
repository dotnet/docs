' <snippet2>
Partial Class WizardStepCollectionvb_aspx
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' Programmatically create a wizard control.
        Dim Wizard1 As Wizard = New Wizard()

        ' Create steps for the wizard control and insert them
        ' into the WizardStepCollection collection.
        For i As Integer = 0 To 5
            Dim newStep As WizardStepBase = New WizardStep()
            newStep.ID = "Step" + (i + 1).ToString()
            newStep.Title = "Step " + (i + 1).ToString()
            Wizard1.WizardSteps.Add(newStep)
        Next

        ' Display the wizard control on the Web page.
        PlaceHolder1.Controls.Add(Wizard1)

    End Sub

End Class
' </snippet2> 
