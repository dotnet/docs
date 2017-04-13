Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region



    ' The following code example demonstrates using the IsMdiContainer
    ' property and changing the BackColor property of an MDI Form.


    '<snippet1>

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
    '</snippet1>

    Public Shared Sub main()
        Application.Run(New Form1)
    End Sub

End Class
