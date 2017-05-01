
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace SplitterEx
    _
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   Public Class Form1
      Inherits System.Windows.Forms.Form
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         
         CreateMySplitControls()
      End Sub 'New
       
      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      
      '<snippet1>
      Private Sub CreateMySplitControls()
         ' Create TreeView, ListView, and Splitter controls.
         Dim treeView1 As New TreeView()
         Dim listView1 As New ListView()
         Dim splitter1 As New Splitter()
         
         ' Set the TreeView control to dock to the left side of the form.
         treeView1.Dock = DockStyle.Left
         ' Set the Splitter to dock to the left side of the TreeView control.
         splitter1.Dock = DockStyle.Left
         ' Set the minimum size the ListView control can be sized to.
            splitter1.MinExtra = 100
         ' Set the minimum size the TreeView control can be sized to.
            splitter1.MinSize = 75
         ' Set the ListView control to fill the remaining space on the form.
            listView1.Dock = DockStyle.Fill

            ' Add a TreeView and a ListView item to identify the controls on the form.
            treeView1.Nodes.Add("TreeView Node")
            listView1.Items.Add("ListView Item")
         
         ' Add the controls in reverse order to the form to ensure proper location.
         Me.Controls.AddRange(New Control() {listView1, splitter1, treeView1})
      End Sub 'CreateMySplitControls
      
      '</snippet1>
      '/ <summary>
      '/ Clean up any resources being used.
      '/ </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        '
        'ToDo: Error processing original source shown below
        '
        '
        '-----^--- Pre-processor directives not translated
        '/ <summary>
        '
        'ToDo: Error processing original source shown below
        '
        '
        '--^--- Unexpected pre-processor directive
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            ' 
            ' Form1
            ' 
            Me.ClientSize = New System.Drawing.Size(384, 365)
            Me.Name = "Form1"
            Me.Text = "Form1"
        End Sub 'InitializeComponent

        '
        'ToDo: Error processing original source shown below
        '
        '
        '-----^--- Pre-processor directives not translated
        '
        'ToDo: Error processing original source shown below
        '
        '
        '--^--- Unexpected pre-processor directive
        '/ <summary>
        '/ The main entry point for the application.
        '/ </summary>
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main
    End Class 'Form1
End Namespace 'SplitterEx