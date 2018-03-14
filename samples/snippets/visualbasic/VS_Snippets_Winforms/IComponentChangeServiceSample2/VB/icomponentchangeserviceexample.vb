 '<Snippet1>
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms

'  This sample illustrates how to use the IComponentChangeService interface 
'    to handle component change events.  The ComponentClass control attaches 
'    event handlers when it is sited in a document, and displays a message 
'    when notification that a component has been added, removed, or changed
'    is received from the IComponentChangeService.

'    To run this sample, add the ComponentClass control to a Form and
'    add, remove, or change components to see the behavior of the
'    component change event handlers. 

Namespace IComponentChangeServiceExample
    _
   Public Class ComponentClass
      Inherits System.Windows.Forms.UserControl
      Private components As System.ComponentModel.Container = Nothing
      Private listBox1 As System.Windows.Forms.ListBox
      Private m_changeService As IComponentChangeService    
      
      Public Sub New()
         InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.SuspendLayout()

            ' listBox1.
            Me.listBox1.Location = New System.Drawing.Point(24, 16)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.Size = New System.Drawing.Size(576, 277)
            Me.listBox1.TabIndex = 0

            ' ComponentClass.
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBox1})
            Me.Name = "ComponentClass"
            Me.Size = New System.Drawing.Size(624, 320)

            Me.ResumeLayout(False)
        End Sub

        ' This override allows the control to register event handlers for IComponentChangeService events
        ' at the time the control is sited, which happens only in design mode.
        Public Overrides Property Site() As ISite
            Get
                Return MyBase.Site
            End Get
            Set(ByVal Value As ISite)
                ' Clear any component change event handlers.
                ClearChangeNotifications()

                ' Set the new Site value.
                MyBase.Site = Value

                m_changeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)

                ' Register event handlers for component change events.
                RegisterChangeNotifications()
            End Set
        End Property

        Private Sub ClearChangeNotifications()
            ' The m_changeService value is null when not in design mode, 
            ' as the IComponentChangeService is only available at design time.	
            m_changeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)

            ' Clear our the component change events to prepare for re-siting.				
            If (m_changeService IsNot Nothing) Then
                RemoveHandler m_changeService.ComponentChanged, AddressOf OnComponentChanged
                RemoveHandler m_changeService.ComponentChanging, AddressOf OnComponentChanging
                RemoveHandler m_changeService.ComponentAdded, AddressOf OnComponentAdded
                RemoveHandler m_changeService.ComponentAdding, AddressOf OnComponentAdding
                RemoveHandler m_changeService.ComponentRemoved, AddressOf OnComponentRemoved
                RemoveHandler m_changeService.ComponentRemoving, AddressOf OnComponentRemoving
                RemoveHandler m_changeService.ComponentRename, AddressOf OnComponentRename
            End If
        End Sub

        Private Sub RegisterChangeNotifications()
            ' Register the event handlers for the IComponentChangeService events
            If (m_changeService IsNot Nothing) Then
                AddHandler m_changeService.ComponentChanged, AddressOf OnComponentChanged
                AddHandler m_changeService.ComponentChanging, AddressOf OnComponentChanging
                AddHandler m_changeService.ComponentAdded, AddressOf OnComponentAdded
                AddHandler m_changeService.ComponentAdding, AddressOf OnComponentAdding
                AddHandler m_changeService.ComponentRemoved, AddressOf OnComponentRemoved
                AddHandler m_changeService.ComponentRemoving, AddressOf OnComponentRemoving
                AddHandler m_changeService.ComponentRename, AddressOf OnComponentRename
            End If
        End Sub

        ' This method handles the OnComponentChanged event to display a notification. 
        Private Sub OnComponentChanged(ByVal sender As Object, ByVal ce As ComponentChangedEventArgs)
            If (ce.Component IsNot Nothing) And (CType(ce.Component, IComponent).Site IsNot Nothing) And (ce.Member IsNot Nothing) Then
                OnUserChange(("The " + ce.Member.Name + " member of the " + CType(ce.Component, IComponent).Site.Name + " component has been changed."))
            End If
        End Sub

        ' This method handles the OnComponentChanging event to display a notification. 
        Private Sub OnComponentChanging(ByVal sender As Object, ByVal ce As ComponentChangingEventArgs)
            If (ce.Component IsNot Nothing) And (CType(ce.Component, IComponent).Site IsNot Nothing) And (ce.Member IsNot Nothing) Then
                OnUserChange(("The " + ce.Member.Name + " member of the " + CType(ce.Component, IComponent).Site.Name + " component is being changed."))
            End If
        End Sub

        ' This method handles the OnComponentAdded event to display a notification. 
        Private Sub OnComponentAdded(ByVal sender As Object, ByVal ce As ComponentEventArgs)
            OnUserChange(("A component, " + ce.Component.Site.Name + ", has been added."))
        End Sub

        ' This method handles the OnComponentAdding event to display a notification. 
        Private Sub OnComponentAdding(ByVal sender As Object, ByVal ce As ComponentEventArgs)
            OnUserChange(("A component of type " + (CType(ce.Component, Component)).GetType().FullName + " is being added."))
        End Sub

        ' This method handles the OnComponentRemoved event to display a notification. 
        Private Sub OnComponentRemoved(ByVal sender As Object, ByVal ce As ComponentEventArgs)
            OnUserChange(("A component, " + ce.Component.Site.Name + ", has been removed."))
        End Sub

        ' This method handles the OnComponentRemoving event to display a notification. 
        Private Sub OnComponentRemoving(ByVal sender As Object, ByVal ce As ComponentEventArgs)
            OnUserChange(("A component, " + ce.Component.Site.Name + ", is being removed."))
        End Sub

        ' This method handles the OnComponentRename event to display a notification. 
        Private Sub OnComponentRename(ByVal sender As Object, ByVal ce As ComponentRenameEventArgs)
            OnUserChange(("A component, " + ce.OldName + ", was renamed to " + ce.NewName + "."))
        End Sub

        ' This method adds a specified notification message to the control's listbox.
        Private Sub OnUserChange(ByVal [text] As String)
            listBox1.Items.Add([text])
        End Sub

        ' Clean up any resources being used.
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                ClearChangeNotifications()

                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace
'</Snippet1>