Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports UserControls

Namespace MyApplication    
    
    Public Class MyUserControlHost
        Inherits System.Windows.Forms.Form

        ' Create the controls.
        Private components As System.ComponentModel.IContainer
        Private panel1 As System.Windows.Forms.Panel
        Private myUserControl As UserControls.MyCustomerInfoUserControl
                
        ' Define the constructor.
        Public Sub New()
            Me.InitializeComponent()
        End Sub        
        
        <System.STAThreadAttribute()> _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New MyUserControlHost())
        End Sub        
        
        ' Add a Panel control to a Form and host the UserControl in the Panel.
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            panel1 = New System.Windows.Forms.Panel()
            myUserControl = New UserControls.MyCustomerInfoUserControl()
            ' Set the DockStyle of the UserControl to Fill.
            myUserControl.Dock = System.Windows.Forms.DockStyle.Fill
            
            ' Make the Panel the same size as the UserControl and give it a border.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            panel1.Size = myUserControl.Size
            panel1.Location = New System.Drawing.Point(5, 5)
            ' Add the user control to the Panel.
            panel1.Controls.Add(myUserControl)
            ' Size the Form to accommodate the Panel.
            Me.ClientSize = New System.Drawing.Size(panel1.Size.Width + 10, panel1.Size.Height + 10)
            Me.Text = "Please enter the information below..."
            ' Add the Panel to the Form.
            Me.Controls.Add(panel1)
        End Sub
    End Class
End Namespace