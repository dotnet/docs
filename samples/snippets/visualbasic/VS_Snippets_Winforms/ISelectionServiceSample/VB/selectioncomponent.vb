'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

'  This sample demonstrates using the ISelectionService
'  interface to receive notification of selection change events.  

'  The SelectionComponent control attempts to retrieve an instance 
'  of the ISelectionService when it is sited. If it can, it attaches 
'  event handlers for events provided by the service that display
'  a message when a component is selected or deselected.
'  To run this sample, add the SelectionComponent control to a Form and
'  then select or deselect components in design mode to see the behavior 
'  of the component change event handlers. 

Namespace ISelectionServiceExample

    Public Class SelectionComponent
        Inherits System.Windows.Forms.UserControl
        Private tbox1 As System.Windows.Forms.TextBox
        Private selectionService As ISelectionService        

        Public Sub New()
            ' Initialize control
            Me.SuspendLayout()
            Me.Name = "SelectionComponent"
            Me.Size = New System.Drawing.Size(608, 296)
            Me.tbox1 = New System.Windows.Forms.TextBox()
            Me.tbox1.Location = New System.Drawing.Point(24, 16)
            Me.tbox1.Name = "listBox1"
            Me.tbox1.Multiline = True
            Me.tbox1.Size = New System.Drawing.Size(560, 251)
            Me.tbox1.TabIndex = 0
            Me.Controls.Add(Me.tbox1)
            Me.ResumeLayout()
        End Sub 'New

        Public Overrides Property Site() As ISite
            Get
                Return MyBase.Site
            End Get
            Set(ByVal Value As ISite)
                ' The ISelectionService is available in design mode 
                ' only, and only after the component is sited.
                If (selectionService IsNot Nothing) Then
                    ' Because the selection service has been 
                    ' previously obtained, the component may be in 
                    ' the process of being resited. 
                    ' Detatch the previous selection change event 
                    ' handlers in case the new selection
                    ' service is a new service instance belonging to 
                    ' another design mode service host.
                    RemoveHandler selectionService.SelectionChanged, AddressOf OnSelectionChanged
                    RemoveHandler selectionService.SelectionChanging, AddressOf OnSelectionChanging
                End If

                ' Establish the new site for the component.
                MyBase.Site = Value

                If MyBase.Site Is Nothing Then
                    Return
                End If

                ' The selection service is not available outside of 
                ' design mode. A call requesting the service 
                ' using GetService while not in design mode will 
                ' return null.
                selectionService = Me.Site.GetService(GetType(ISelectionService))

                ' If an instance of the ISelectionService was obtained, 
                ' attach event handlers for the selection 
                ' changing and selection changed events.
                If (selectionService IsNot Nothing) Then
                    ' Add an event handler for the SelectionChanging and SelectionChanged events.
                    AddHandler selectionService.SelectionChanging, AddressOf OnSelectionChanging
                    AddHandler selectionService.SelectionChanged, AddressOf OnSelectionChanged
                End If
            End Set
        End Property

        Private Sub OnSelectionChanged(ByVal sender As Object, ByVal args As EventArgs)            
            tbox1.AppendText("The selected component was changed.  Selected components:" + Microsoft.VisualBasic.ControlChars.CrLf + "    " + GetSelectedComponents() + Microsoft.VisualBasic.ControlChars.CrLf)
        End Sub 'OnSelectionChanged

        Private Sub OnSelectionChanging(ByVal sender As Object, ByVal args As EventArgs)                        
            tbox1.AppendText("The selected component is changing.  Selected components:" + Microsoft.VisualBasic.ControlChars.CrLf + "    " + GetSelectedComponents() + Microsoft.VisualBasic.ControlChars.CrLf)
        End Sub 'OnSelectionChanging

        Private Function GetSelectedComponents() As String
            Dim selectedString As String = String.Empty
            Dim components(CType(selectionService.GetSelectedComponents(), ICollection).Count - 1) As Object
            CType(selectionService.GetSelectedComponents(), ICollection).CopyTo(components, 0)

            Dim i As Integer
            For i = 0 To components.Length - 1
                If i <> 0 Then
                    selectedString += "&& "
                End If
                If CType(selectionService.PrimarySelection, IComponent) Is CType(components(i), IComponent) Then
                    selectedString += "PrimarySelection:"
                End If
                selectedString += CType(components(i), IComponent).Site.Name + " "
            Next i

            Return selectedString
        End Function 'GetSelectedComponents

        ' Clean up any resources being used.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            ' Detatch the event handlers for the selection service.
            If (selectionService IsNot Nothing) Then
                RemoveHandler selectionService.SelectionChanging, AddressOf OnSelectionChanging
                RemoveHandler selectionService.SelectionChanged, AddressOf OnSelectionChanged
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose
    End Class 'SelectionComponent

End Namespace 'ISelectionServiceExample
'</Snippet1>