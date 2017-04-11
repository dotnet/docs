'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This sample contains a Form class that is configured to demonstrate 
' the behavior of a network of linked service containers.   

' Notes regarding this IServiceContainer and IServiceProvider implementation:
'
' When implementing the IServiceContainer interface, you may want to 
' implement support for a linked service container system
' which enables access to and sharing of services throughout a 
' container tree or network.
'
' To effectively share a service, a GetService, AddService or 
' RemoveService method must be able to locate a service 
' that has been added to a shared service container tree or network.
'        
' One simple approach to sharing services, suitable for container networks 
' where each container has one parent and the tree has
' one parentless container, is to store services only at the top node 
' (the root or grandparent) of a tree.
'
' To store services in the root node of a tree, two types of 
' consistencies must be maintained in the implementation:        
'
'   >   The GetService, AddService and RemoveService implementations 
'       must access the root through some mechanism.
'         The ServiceContainerControl's implementations of these 
'         standard IServiceContainer methods call 
'         the same method of a parent container, if the container 
'         has been parented, to route methods to the root.  
'
'   >   The services must be maintained at the root of the tree; 
'       therefore any new child's services should be copied to the root.                

' ServiceContainerControl provides an example user control implmentation 
' of the IServiceContainer interface. This implementation of 
' IServiceContainer supports a root-node linked service distribution, 
' access and removal architecture.
Public Class ServiceContainerControl
    Inherits System.Windows.Forms.UserControl
    Implements IServiceContainer

    ' List of service instances sorted by key of service type's full name.
    Private localServices As SortedList
    ' List contains the Type for each service sorted by each service type's full name.
    Private localServiceTypes As SortedList

    ' The parent IServiceContainer, or null.
    Private parentServiceContainer As IServiceContainer

    Public Property serviceParent() As IServiceContainer
        Get
            Return parentServiceContainer
        End Get
        Set(ByVal Value As IServiceContainer)
            parentServiceContainer = Value
            ' Move any services to parent.
            Dim i As Integer
            For i = 0 To localServices.Count - 1
                parentServiceContainer.AddService( _
                    CType(localServiceTypes.GetByIndex(i), Type), _
                    localServices.GetByIndex(i))
            Next i
            localServices.Clear()
            localServiceTypes.Clear()
        End Set
    End Property

    ' The current state of the control, reflecting whether it has 
    ' obtained or provided a text service.
    Private state_ As TextServiceState

    Public Property state() As TextServiceState
        Get
            Return state_
        End Get
        Set(ByVal Value As TextServiceState)
            If CType(Value, TextServiceState) = _
                    TextServiceState.ServiceProvided Then
                Me.BackColor = Color.LightGreen
            ElseIf CType(Value, TextServiceState) = _
                    TextServiceState.ServiceNotObtained Then
                Me.BackColor = Color.White
            ElseIf CType(Value, TextServiceState) = _
                    TextServiceState.ServiceObtained Then
                Me.BackColor = Color.LightBlue
            ElseIf CType(Value, TextServiceState) = _
                    TextServiceState.ServiceNotFound Then
                Me.BackColor = Color.SeaShell
            End If
            state_ = Value
        End Set
    End Property

    ' Parent form reference for main program function access.
    Private Shadows parent As ServiceForm
    ' String for label displayed on the control to indicate 
    ' the control's current service-related configuration state.
    Public label As String

    Public Sub New(ByVal size As Size, ByVal location As Point, _
                    ByVal parent As ServiceForm)
        MyClass.New(Nothing, size, location, parent)
    End Sub

    Public Sub New(ByVal ParentServiceContainer As IServiceContainer, _
        ByVal size As Size, ByVal location As Point, ByVal parent As ServiceForm)

        Me.state_ = TextServiceState.ServiceNotObtained
        localServices = New SortedList()
        localServiceTypes = New SortedList()

        Me.BackColor = Color.Beige
        Me.label = String.Empty
        Me.Size = size
        Me.Location = location
        Me.parent = parent
        Me.serviceParent = ParentServiceContainer

        ' If a parent is specified, set the parent property of this 
        ' linkable IServiceContainer implementation.
        If (ParentServiceContainer IsNot Nothing) Then
            serviceParent = ParentServiceContainer
        End If
    End Sub

    ' IServiceProvider.GetService implementation for a linked 
    ' service container architecture.
    Public Shadows Function GetService(ByVal serviceType As System.Type) As Object Implements IServiceProvider.GetService
        If (parentServiceContainer IsNot Nothing) Then
            Return parentServiceContainer.GetService(serviceType)
        End If
        Dim serviceInstance As Object = localServices(serviceType.FullName)
        If serviceInstance Is Nothing Then
            Return Nothing
        ElseIf serviceInstance.GetType() Is GetType(ServiceCreatorCallback) Then
            ' If service instance is a ServiceCreatorCallback, invoke it to create the service
            Return CType(serviceInstance, ServiceCreatorCallback)(Me, serviceType)
        End If
        Return serviceInstance
    End Function

    ' IServiceContainer.AddService implementation for a linked 
    ' service container architecture.
    Public Overloads Sub AddService(ByVal serviceType As System.Type, ByVal callback As System.ComponentModel.Design.ServiceCreatorCallback, ByVal promote As Boolean) Implements IServiceContainer.AddService
        If promote AndAlso (parentServiceContainer IsNot Nothing) Then
            parentServiceContainer.AddService(serviceType, callback, True)
        Else
            localServiceTypes(serviceType.FullName) = serviceType
            localServices(serviceType.FullName) = callback
        End If
    End Sub

    ' IServiceContainer.AddService implementation for a linked 
    ' service container architecture.
    Public Overloads Sub AddService(ByVal serviceType As System.Type, _
        ByVal callback As System.ComponentModel.Design.ServiceCreatorCallback) _
        Implements IServiceContainer.AddService
        AddService(serviceType, callback, True)
    End Sub

    ' IServiceContainer.AddService implementation for a linked 
    ' service container architecture.
    Public Overloads Sub AddService(ByVal serviceType As System.Type, _
        ByVal serviceInstance As Object, ByVal promote As Boolean) _
        Implements IServiceContainer.AddService
        If promote AndAlso (parentServiceContainer IsNot Nothing) Then
            parentServiceContainer.AddService(serviceType, serviceInstance, True)
        Else
            localServiceTypes(serviceType.FullName) = serviceType
            localServices(serviceType.FullName) = serviceInstance
        End If
    End Sub

    ' IServiceContainer.AddService (defaults to promote service addition).
    Public Overloads Sub AddService(ByVal serviceType As System.Type, _
        ByVal serviceInstance As Object) Implements IServiceContainer.AddService
        AddService(serviceType, serviceInstance, True)
    End Sub

    ' IServiceContainer.RemoveService implementation for a linked 
    ' service container architecture.
    Public Overloads Sub RemoveService(ByVal serviceType As System.Type, _
        ByVal promote As Boolean) Implements IServiceContainer.RemoveService
        If (localServices(serviceType.FullName) IsNot Nothing) Then
            localServices.Remove(serviceType.FullName)
            localServiceTypes.Remove(serviceType.FullName)
        End If
        If promote Then
            If (parentServiceContainer IsNot Nothing) Then
                parentServiceContainer.RemoveService(serviceType)
            End If
        End If
    End Sub

    ' IServiceContainer.RemoveService (defaults to promote service removal)
    Public Overloads Sub RemoveService(ByVal serviceType As System.Type) _
        Implements IServiceContainer.RemoveService
        RemoveService(serviceType, True)
    End Sub

    ' Paint method override draws the label string on the control.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString(label, New Font("Arial", 8), New SolidBrush(Color.Black), 5, 5)
    End Sub

    ' Process mouse-down behavior for click.
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)

        '  This example control responds to mouse clicks as follows:
        '
        '      Left click - control attempts to obtain a text service 
        '      and sets its label text to the text provided by the service
        '      Right click - if the control has already provided a text 
        '      service, this control does nothing. Otherwise, the control 
        '      shows a dialog to specify text to provide as a new text 
        '      service, after clearing the tree's services.

        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If state_ <> TextServiceState.ServiceProvided Then
                ' Attempt to update text from the service, and set 
                ' color state accordingly.
                Dim ts As TextService = CType(GetService(GetType(TextService)), TextService)
                If (ts IsNot Nothing) Then
                    Me.label = ts.text
                    state = TextServiceState.ServiceObtained
                Else
                    Me.label = "Service Not Found"
                    state = TextServiceState.ServiceNotFound
                End If
            End If
        End If
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If state_ = TextServiceState.ServiceProvided Then
                ' Remove the service the if the container provided it.
                If (GetService(GetType(TextService)) IsNot Nothing) Then
                    RemoveService(GetType(TextService), True)
                    state = TextServiceState.ServiceNotObtained
                    Me.label = "Service Removed"
                End If
            Else
                ' Obtain string and provide text service.
                Using form As New StringInputDialog("Test String")
                    form.StartPosition = FormStartPosition.CenterParent
                    If form.ShowDialog() = DialogResult.OK Then
                        If (GetService(GetType(TextService)) IsNot Nothing) Then
                            RemoveService(GetType(TextService), True)
                        End If
                        parent.ResetServiceTree(Me, New EventArgs())

                        AddService(GetType(TextService), _
                            New TextService(form.inputTextBox.Text), True)

                        ' The following commented method uses a service creator callback.
                        ' AddService(typeof(TextService), 
                        '   new ServiceCreatorCallback(this.CreateTextService));                                                
                        state = TextServiceState.ServiceProvided
                        Me.label = "Provided Text: " + form.inputTextBox.Text
                    End If
                End Using
            End If
        End If
        parent.UpdateServiceCoverage()
    End Sub

    ' Method accesses the TextService to test the visibility of the service 
    ' from the control, and sets the UI state accordingly.
    Public Sub ReflectServiceVisibility()
        If state_ = TextServiceState.ServiceObtained Then
            If GetService(GetType(TextService)) Is Nothing Then
                Me.BackColor = Color.CadetBlue
            End If
        ElseIf state_ <> TextServiceState.ServiceProvided Then
            If GetService(GetType(TextService)) Is Nothing Then
                Me.BackColor = Color.White
                Return
            End If

            ' Service available.    
            If state_ = TextServiceState.ServiceNotFound Then
                Me.BackColor = Color.Khaki
            ElseIf state_ = TextServiceState.ServiceNotObtained _
                AndAlso label <> "Service Removed" Then
                Me.BackColor = Color.Khaki
            End If
        End If
    End Sub

    ' ServiceCreatorCallback method creates a text service.
    Private Function CreateTextService(ByVal container As IServiceContainer, _
        ByVal serviceType As System.Type) As Object
        Return New TextService("Test Callback")
    End Function
End Class

' Example form provides UI for demonstrating service sharing behavior 
' of a network of IServiceContainer/IServiceProvider controls.
Public Class ServiceForm
    Inherits System.Windows.Forms.Form
    
    ' Root service container control for tree.
    Private root As ServiceContainerControl  
    ' Button for clearing any provided services and resetting tree states.
    Private WithEvents reset_button As System.Windows.Forms.Button 
    ' Color list used to color code controls.
    Private colorkeys() As Color
    Private keystrings() As String
    ' Strings used to reflect text service 
    Public Sub New()
        InitializeComponent()
        colorkeys = New Color() {Color.Beige, Color.SeaShell, _
            Color.LightGreen, Color.LightBlue, Color.Khaki, Color.CadetBlue}
        keystrings = New String() {"No service use", "Service not accessible", _
            "Service provided", "Service obtained", "Service accessible", _
            "No further access"}
        CreateServiceControlTree()
    End Sub

    Private Sub CreateServiceControlTree()
        ' Create root service control
        Dim control1 As New ServiceContainerControl(Nothing, New Size(300, 40), New Point(10, 80), Me)
        root = control1
        ' Create first tier - pass parent with service object control 1.
        Dim control2 As New ServiceContainerControl(control1, New Size(200, 30), New Point(50, 160), Me)
        Dim control3 As New ServiceContainerControl(control1, New Size(200, 30), New Point(50, 240), Me)
        ' Create second tier A - pass parent with service object control 2.
        Dim control4 As New ServiceContainerControl(control2, New Size(180, 20), New Point(300, 145), Me)
        Dim control5 As New ServiceContainerControl(control2, New Size(180, 20), New Point(300, 185), Me)
        ' Create second tier B - pass parent with service object control 3.
        Dim control6 As New ServiceContainerControl(control3, New Size(180, 20), New Point(300, 225), Me)
        Dim control7 As New ServiceContainerControl(control3, New Size(180, 20), New Point(300, 265), Me)
        ' Add controls
        Me.Controls.AddRange(New Control() {control1, control2, control3, control4, control5, control6, control7})
    End Sub

    Friend Sub ResetServiceTree(ByVal sender As Object, ByVal e As EventArgs) Handles reset_button.Click
        ' Remove the service from the service tree.
        If (root.GetService(GetType(TextService)) IsNot Nothing) Then
            root.RemoveService(GetType(TextService), True)
        End If
        ' Set all controls to "not obtained" and clear their labels.
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            If Not Controls(i).Equals(reset_button) Then
                CType(Controls(i), ServiceContainerControl).state = TextServiceState.ServiceNotObtained
                CType(Controls(i), ServiceContainerControl).label = String.Empty
                CType(Controls(i), ServiceContainerControl).BackColor = Color.Beige
            End If
        Next i
    End Sub

    Public Sub UpdateServiceCoverage()
        ' Have each control set state to reflect service availability.
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            If Not Controls(i).Equals(reset_button) Then
                CType(Controls(i), ServiceContainerControl).ReflectServiceVisibility()
            End If
        Next i
    End Sub

    Private Sub InitializeComponent()
        Me.reset_button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' reset_button
        ' 
        Me.reset_button.Location = New System.Drawing.Point(392, 88)
        Me.reset_button.Name = "reset_button"
        Me.reset_button.TabIndex = 0
        Me.reset_button.TabStop = False
        Me.reset_button.Text = "Reset"
        ' 
        ' ServiceForm
        ' 
        Me.ClientSize = New System.Drawing.Size(512, 373)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.reset_button})
        Me.MinimumSize = New System.Drawing.Size(520, 400)
        Me.Name = "ServiceForm"
        Me.Text = "Service Container Architecture Example"
        Me.ResumeLayout(False)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New ServiceForm())
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString("The following tree diagram represents a hierarchy of linked service containers in controls.", New Font("Arial", 9), New SolidBrush(Color.Black), 4, 4)
        e.Graphics.DrawString("This example demonstrates the propagation behavior of services through a linked service object tree.", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 26)
        e.Graphics.DrawString("Right-click a component to add or replace a text service, or to remove it if the component provided it.", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 38)
        e.Graphics.DrawString("Left-click a component to update text from the text service if available.", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 50)

        ' Draw lines to represent tree branches.
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 20, 125, 20, 258)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 21, 175, 45, 175)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 21, 258, 45, 258)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 255, 175, 285, 175)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 255, 258, 285, 258)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 155, 285, 195)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 238, 285, 278)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 155, 290, 155)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 195, 290, 195)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 238, 290, 238)
        e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 285, 278, 290, 278)

        ' Draw color key.
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), 20, 305, 410, 60)
        Dim y As Integer = 0
        Dim i As Integer
        For i = 0 To 2
            e.Graphics.FillRectangle(New SolidBrush(colorkeys(y)), _
                25 + i * 140, 310, 20, 20)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), _
                25 + i * 140, 310, 20, 20)
            e.Graphics.DrawString(keystrings(y), New Font("Arial", 8), _
                New SolidBrush(Color.Black), 50 + i * 140, 315)
            y += 1
            e.Graphics.FillRectangle(New SolidBrush(colorkeys(y)), _
                25 + i * 140, 340, 20, 20)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), _
                25 + i * 140, 340, 20, 20)
            e.Graphics.DrawString(keystrings(y), New Font("Arial", 8), _
                New SolidBrush(Color.Black), 50 + i * 140, 345)
            y += 1
        Next i
    End Sub
End Class

' Example service type contains a text string, sufficient to 
' demonstrate service sharing.
Public Class TextService
    Public [text] As String

    Public Sub New()
        MyClass.New(String.Empty)
    End Sub

    Public Sub New(ByVal [text] As String)
        Me.text = [text]
    End Sub
End Class

Public Enum TextServiceState
    ServiceNotObtained
    ServiceObtained
    ServiceProvided
    ServiceNotFound
End Enum

' Example Form for entering a string.
Friend Class StringInputDialog
    Inherits System.Windows.Forms.Form
    Private ok_button As System.Windows.Forms.Button
    Private cancel_button As System.Windows.Forms.Button
    Public inputTextBox As System.Windows.Forms.TextBox

    Public Sub New(ByVal [text] As String)
        InitializeComponent()
        inputTextBox.Text = [text]
    End Sub

    Private Sub InitializeComponent()
        Me.ok_button = New System.Windows.Forms.Button()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.inputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        Me.ok_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom _
            Or System.Windows.Forms.AnchorStyles.Right
        Me.ok_button.Location = New System.Drawing.Point(180, 43)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.TabIndex = 1
        Me.ok_button.Text = "OK"
        Me.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom _
            Or System.Windows.Forms.AnchorStyles.Right
        Me.cancel_button.Location = New System.Drawing.Point(260, 43)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.TabIndex = 2
        Me.cancel_button.Text = "Cancel"
        Me.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.inputTextBox.Location = New System.Drawing.Point(6, 9)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(327, 20)
        Me.inputTextBox.TabIndex = 0
        Me.inputTextBox.Text = ""
        Me.inputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Left Or _
            System.Windows.Forms.AnchorStyles.Right
        Me.ClientSize = New System.Drawing.Size(342, 73)
        Me.Controls.AddRange(New System.Windows.Forms.Control() _
            {Me.inputTextBox, Me.cancel_button, Me.ok_button})
        Me.MinimumSize = New System.Drawing.Size(350, 100)
        Me.Name = "StringInputDialog"
        Me.Text = "Text Service Provide String Dialog"
        Me.ResumeLayout(False)
    End Sub
End Class
'</Snippet1>