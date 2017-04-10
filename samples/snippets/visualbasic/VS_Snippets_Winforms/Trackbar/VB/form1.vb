'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

namespace TrackBar
 
	' <summary>
	' Summary description for Form1.
	' </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private panel1 As System.Windows.Forms.Panel
        Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
        Private WithEvents trackBar2 As System.Windows.Forms.TrackBar
        Private WithEvents trackBar3 As System.Windows.Forms.TrackBar
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private Components As System.ComponentModel.Container
        Public Sub New()
            MyBase.New()

            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            '
            ' TODO: Add any constructor code after InitializeComponent call
            '
            '<Snippet2>
            trackBar2.Orientation = Orientation.Vertical
            trackBar3.Orientation = Orientation.Vertical
            trackBar1.Maximum = 255
            trackBar2.Maximum = 255
            trackBar3.Maximum = 255
            trackBar1.Width = 400
            trackBar2.Height = 400
            trackBar3.Height = 400
            trackBar1.LargeChange = 16
            trackBar2.LargeChange = 16
            trackBar3.LargeChange = 16
            '</Snippet2>
        End Sub

        ' <summary>
        ' Clean up any resources being used.
        ' </summary>

        '#region Windows Form Designer generated code
        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of Me method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.trackBar1 = New System.Windows.Forms.TrackBar()
            Me.trackBar2 = New System.Windows.Forms.TrackBar()
            Me.trackBar3 = New System.Windows.Forms.TrackBar()
            Me.panel1 = New System.Windows.Forms.Panel()
            '<Snippet4>
            CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.trackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.trackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'trackBar1
            '
            Me.trackBar1.Location = New System.Drawing.Point(160, 400)
            Me.trackBar1.Name = "trackBar1"
            Me.trackBar1.TabIndex = 1
            '
            'trackBar2
            '
            Me.trackBar2.Location = New System.Drawing.Point(608, 40)
            Me.trackBar2.Name = "trackBar2"
            Me.trackBar2.TabIndex = 2
            '
            'trackBar3
            '
            Me.trackBar3.Location = New System.Drawing.Point(56, 40)
            Me.trackBar3.Name = "trackBar3"
            Me.trackBar3.TabIndex = 3
            CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.trackBar2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.trackBar3, System.ComponentModel.ISupportInitialize).EndInit()
            '</Snippet4>
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(288, 448)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 4
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(8, 16)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(120, 16)
            Me.label2.TabIndex = 5
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(600, 16)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(120, 16)
            Me.label3.TabIndex = 6
            '
            'panel1
            '
            Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panel1.Location = New System.Drawing.Point(128, 32)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(464, 352)
            Me.panel1.TabIndex = 0
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(728, 477)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label3, Me.label2, Me.label1, Me.trackBar2, Me.trackBar3, Me.trackBar1, Me.panel1})
            AddHandler Me.Load, AddressOf Me.Form1_Load
            Me.Name = "Form1"
            Me.Text = "Color builder"
            Me.ResumeLayout(False)

        End Sub

        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        ' [STAThread]
        ' static void Main() 
        ' 
        '	Application.Run(new Form1())
        ' }

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            showColorValueLabels()
        End Sub

        '<Snippet3>   
        Private Sub showColorValueLabels()
            label1.Text = "Red value is : " & trackBar1.Value.ToString()
            label3.Text = "Green Value is : " & trackBar2.Value.ToString()
            label2.Text = "Blue Value is : " & trackBar3.Value.ToString()
        End Sub

        Private Sub trackBar_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackBar1.Scroll, trackBar2.Scroll, trackBar3.Scroll
            Dim myTB As System.Windows.Forms.TrackBar
            myTB = sender
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value)
            myTB.Text = "Value is " & myTB.Value.ToString()
            showColorValueLabels()
        End Sub
        '</Snippet3>

      Public Shared Sub Main()
         Application.Run(new Form1())
      End Sub
      
    End Class
End Namespace
'</Snippet1>
