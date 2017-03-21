    ' Call this method from the Load method of your form.
    Private Sub OtherInitialize()
        ' Exchange commented line and note the difference.
        Me.isDataSaved = True
        'Me.isDataSaved = False
    End Sub 'OtherInitialize
    
    Private Sub Form1_Closing(sender As Object, e As _
       System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not isDataSaved Then
            e.Cancel = True
            MessageBox.Show("You must save first.")
        Else
            e.Cancel = False
            MessageBox.Show("Goodbye.")
        End If
    End Sub 'Form1_Closing