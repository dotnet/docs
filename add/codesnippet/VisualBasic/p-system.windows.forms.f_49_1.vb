
    ' Create a new form.
    Dim mdiChildForm As New Form

    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set the IsMdiContainer property to true.
        IsMdiContainer = True

        ' Set the child form's MdiParent property to 
        ' the current form.
        mdiChildForm.MdiParent = Me

        'Call the method that changes the background color.
        SetBackGroundColorOfMDIForm()
    End Sub

    Private Sub SetBackGroundColorOfMDIForm()
        Dim ctl As Control

        ' Loop through controls,  
        ' looking for controls of MdiClient type. 
        For Each ctl In Me.Controls
            If TypeOf (ctl) Is MdiClient Then

                ' If the control is the correct type,
                ' change the color.
                ctl.BackColor = System.Drawing.Color.PaleGreen
            End If
        Next

    End Sub