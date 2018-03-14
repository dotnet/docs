Imports System.Diagnostics

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
            If Not (components Is Nothing) Then
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
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <snippet1>
        Dim PC As New PerformanceCounter()
        PC.CategoryName = "Process"
        PC.CounterName = "Private Bytes"
        PC.InstanceName = "Explorer"
        MessageBox.Show(PC.NextValue().ToString())
        ' </snippet1>

	' <snippet2>
        Dim PerfCat As Array
        Dim PCat As New PerformanceCounterCategory()
        PerfCat = PCat.GetCategories()
        MessageBox.Show("The number of performance counter categories in the local machine is " & PerfCat.Length.ToString())
        ' </snippet2>
    End Sub
End Class
