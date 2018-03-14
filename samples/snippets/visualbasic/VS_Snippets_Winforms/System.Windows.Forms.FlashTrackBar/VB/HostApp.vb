' <snippet30>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Samples.WinForms.VB.FlashTrackBar


Namespace Microsoft.Samples.WinForms.VB.HostApp

    Public Class HostApp
        Inherits System.Windows.Forms.Form

        Public Sub New()

            MyBase.New()

            HostApp = Me

            'This call is required by the Windows Forms Designer.
            InitializeComponent()

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



#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container
        Private WithEvents flashTrackBar1 As Microsoft.Samples.WinForms.VB.FlashTrackBar.FlashTrackBar

        Private WithEvents HostApp As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.
        'Do not modify it using the code editor.
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.flashTrackBar1 = New Microsoft.Samples.WinForms.VB.FlashTrackBar.FlashTrackBar()

            flashTrackBar1.Dock = System.Windows.Forms.DockStyle.Fill
            flashTrackBar1.ForeColor = System.Drawing.Color.White
            flashTrackBar1.BackColor = System.Drawing.Color.Black
            flashTrackBar1.Size = New System.Drawing.Size(600, 450)
            flashTrackBar1.TabIndex = 0
            flashTrackBar1.Value = 73
            flashTrackBar1.Text = "Drag the Mouse and say Wow!"

            Me.Text = "Control Example"
            Me.ClientSize = New System.Drawing.Size(528, 325)

            Me.Controls.Add(flashTrackBar1)

        End Sub

#End Region

        'The main entry point for the application
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New HostApp())
        End Sub

    End Class

End Namespace

' </snippet30>