'<snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Data

'   This sample illustrates how to use the ISelectionService
'   interface to handle selection change events.  The ComponentClass
'   control attaches event handlers when it is sited in a document
'   that displays a message when a component is selected or deselected.

'   To run this sample, add the ComponentClass control to a Form and
'   then select and deselect the component to see the behavior of the
'   selection change event handlers. 

Namespace ISelectionServiceExample
   Public Class ComponentClass
      Inherits System.Windows.Forms.UserControl
      Private components As System.ComponentModel.Container = Nothing
      Private WithEvents listBox1 As System.Windows.Forms.ListBox
      Private m_selectionService As ISelectionService

      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Private Sub InitializeComponent()
         Me.listBox1 = New System.Windows.Forms.ListBox()
         Me.SuspendLayout()

         ' listBox1
         Me.listBox1.Location = New System.Drawing.Point(24, 16)
         Me.listBox1.Name = "listBox1"
         Me.listBox1.Size = New System.Drawing.Size(560, 251)
         Me.listBox1.TabIndex = 0

         ' ComponentClass
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBox1})
         Me.Name = "ComponentClass"
         Me.Size = New System.Drawing.Size(608, 296)
         Me.ResumeLayout(False)
      End Sub ' InitializeComponent

      Public Overrides Property Site() As ISite
         Get
            Return MyBase.Site
         End Get
         Set(ByVal Value As ISite)
            ' This value will always be null when not in design mode
            m_selectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)

            ' The Selection Service works in design mode only, and only after the component is sited.
            '  So add our services at this time 
            If (m_selectionService IsNot Nothing) Then
               ' We are about to be re-sited.  Clear our old selection change events.
               RemoveHandler m_selectionService.SelectionChanged, AddressOf OnSelectionChanged
               RemoveHandler m_selectionService.SelectionChanging, AddressOf OnSelectionChanging
            End If

            MyBase.Site = Value
            ' This value will always be null when not in design mode
            m_selectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)

            ' The Selection Service works in design mode only, and only after the component is sited.
            '  So add our services at this time 
            If (m_selectionService IsNot Nothing) Then
'<snippet2>
               ' Add SelectionChanged event handler to event
               AddHandler m_selectionService.SelectionChanged, AddressOf OnSelectionChanged
'</snippet2>
'<snippet4>
               ' Add SelectionChanging event handler to event
               AddHandler m_selectionService.SelectionChanging, AddressOf OnSelectionChanging
'</snippet4>
            End If
         End Set
      End Property ' End Site

      ' Clean up any resources being used.
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

'<snippet3> 
      ' This is the OnSelectionChanged handler method.  This method calls
      '  OnUserChange to display a message that indicates the name of the
      '  handler that made the call and the type of the event argument. 
      Private Sub OnSelectionChanged(ByVal sender As Object, ByVal args As EventArgs)
         OnUserChange("OnSelectionChanged", args.ToString())
      End Sub 'OnSelectionChanged

'</snippet3>
'<snippet5>
     ' This is the OnSelectionChanging handler method.  This method calls
     '   OnUserChange to display a message that indicates the name of the
     '   handler that made the call and the type of the event argument. 
      Private Sub OnSelectionChanging(ByVal sender As Object, ByVal args As EventArgs)
         OnUserChange("OnSelectionChanging", args.ToString())
      End Sub 'OnSelectionChanging
'</snippet5>

      ' In this sample, all event handlers call this method
      Private Sub OnUserChange(ByVal text1 As String, ByVal text2 As String)
         listBox1.Items.Add(("Called " + text1 + " using " + text2 + "."))
      End Sub 'OnUserChange

      Private Sub ComponentClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      End Sub 'ComponentClass_Load

      Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles listBox1.SelectedIndexChanged
      End Sub 'listBox1_SelectedIndexChanged
   End Class 'ComponentClass 
End Namespace 'ISelectionServiceExample
'</snippet1>
