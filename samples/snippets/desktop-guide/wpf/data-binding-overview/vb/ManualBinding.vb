Imports bindings.SDKSample

Public Class ManualBinding

    Public myText As TextBox

    Public Sub BindTextBox()
        ' <CodeOnlyBinding>
        ' Make a New source
        Dim myDataObject As New MyData
        Dim myBinding As New Binding("ColorName")
        myBinding.Source = myDataObject

        ' Bind the data source to the TextBox control's Text dependency property
        myText.SetBinding(TextBlock.TextProperty, myBinding)
        ' </CodeOnlyBinding>
    End Sub

End Class
