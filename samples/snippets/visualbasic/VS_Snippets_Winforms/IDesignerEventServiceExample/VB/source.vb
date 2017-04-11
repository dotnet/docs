'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace DesignerEventServiceExample

    ' DesignerMonitor provides a display for designer event notifications.
    <Designer(GetType(DesignerMonitorDesigner))> _
    Public Class DesignerMonitor
        Inherits System.Windows.Forms.UserControl

        ' List to contain strings that describe designer events.
        Public updates As ArrayList
        Public monitoring_events As Boolean = False

        Public Sub New()
            updates = New ArrayList()
            Me.BackColor = Color.Beige
            Me.Size = New Size(450, 300)
        End Sub    

        ' Display the message for the current mode, and any event messages if monitoring events
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawString("IDesignerEventService DesignerMonitor control", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Red), 5, 4)
            Dim yoffset As Integer = 10
            If Not monitoring_events Then
                yoffset += 10
                e.Graphics.DrawString("Currently not monitoring designer events.", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Black), 5, yoffset + 10)
                e.Graphics.DrawString("Use the shortcut menu commands", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Black), 5, yoffset + 30)
                e.Graphics.DrawString("provided by an associated DesignerMonitorDesigner", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Black), 5, yoffset + 40)
                e.Graphics.DrawString("to start or stop monitoring.", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.Black), 5, yoffset + 50)
            Else
                e.Graphics.DrawString("Currently monitoring designer events.", New Font(FontFamily.GenericMonospace, 10), New SolidBrush(Color.DarkBlue), 5, yoffset + 10)
                e.Graphics.DrawString("Designer created, changed and disposed events:", New Font(FontFamily.GenericMonospace, 9), New SolidBrush(Color.Brown), 5, yoffset + 35)
                Dim i As Integer
                For i = 0 To updates.Count - 1
                    e.Graphics.DrawString(CStr(updates(i)), New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 5, yoffset + 55 + 10 * i)
                    yoffset += 10
                Next i
            End If
        End Sub 
    End Class   

    ' DesignerMonitorDesigner uses the IDesignerEventService to send event information 
    ' to an associated DesignerMonitor control's updates collection.
    Public Class DesignerMonitorDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner
        Private dm As DesignerMonitor = Nothing
        Private dvc As DesignerVerbCollection = Nothing
        Private eventcount As Integer = 0

        Public Sub New()
            ' Initializes the designer's shortcut menu with a "Start monitoring" command.
            dvc = New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Start monitoring", AddressOf Me.StartMonitoring)})
        End Sub  

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            Dim o As Object
            o = component
            
            If o.GetType() IsNot GetType(DesignerMonitor) Then
                Throw New Exception("This designer requires a DesignerMonitor control.")
            End If
            dm = CType(component, DesignerMonitor)
        End Sub   

        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                Return dvc
            End Get
        End Property

        Private Sub StopMonitoring(ByVal sender As Object, ByVal e As EventArgs)
            Dim des As IDesignerEventService = CType(Me.Control.Site.GetService(GetType(IDesignerEventService)), IDesignerEventService)
            If des Is Nothing Then
                Return
            End If
            ' Remove event handlers for event notification methods.
            RemoveHandler des.DesignerCreated, AddressOf Me.DesignerCreated
            RemoveHandler des.DesignerDisposed, AddressOf Me.DesignerDisposed
            RemoveHandler des.ActiveDesignerChanged, AddressOf Me.DesignerChanged
            RemoveHandler des.SelectionChanged, AddressOf Me.SelectionChanged

            dm.monitoring_events = False
            ' Rebuild menu with "Start monitoring" command.
            dvc = New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Start monitoring", AddressOf Me.StartMonitoring)})
            dm.Refresh()
        End Sub 

        Private Sub StartMonitoring(ByVal sender As Object, ByVal e As EventArgs)
            Dim des As IDesignerEventService = CType(Me.Control.Site.GetService(GetType(IDesignerEventService)), IDesignerEventService)
            If des Is Nothing Then
                Return
            End If
            ' Add event handlers for event notification methods.
            AddHandler des.DesignerCreated, AddressOf Me.DesignerCreated
            AddHandler des.DesignerDisposed, AddressOf Me.DesignerDisposed
            AddHandler des.ActiveDesignerChanged, AddressOf Me.DesignerChanged
            AddHandler des.SelectionChanged, AddressOf Me.SelectionChanged

            dm.monitoring_events = True
            ' Rebuild menu with "Stop monitoring" command.
            dvc = New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Stop monitoring", AddressOf Me.StopMonitoring)})
            dm.Refresh()
        End Sub      

        Private Sub DesignerCreated(ByVal sender As Object, ByVal e As DesignerEventArgs)
            UpdateStatus(("Designer for " + e.Designer.RootComponent.Site.Name + " was created."))
        End Sub     

        Private Sub DesignerDisposed(ByVal sender As Object, ByVal e As DesignerEventArgs)
            UpdateStatus(("Designer for " + e.Designer.RootComponent.Site.Name + " was disposed."))
        End Sub 

        Private Sub DesignerChanged(ByVal sender As Object, ByVal e As ActiveDesignerEventArgs)
            UpdateStatus(("Active designer moved from " + e.OldDesigner.RootComponent.Site.Name + " to " + e.NewDesigner.RootComponent.Site.Name + "."))
        End Sub    

        Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateStatus("A component selection was changed.")
        End Sub       

        ' Update message buffer on DesignerMonitor control.
        Private Sub UpdateStatus(ByVal newmsg As String)
            If dm.updates.Count > 10 Then
                dm.updates.RemoveAt(10)
            End If
            dm.updates.Insert(0, "Event #" + eventcount.ToString() + ": " + newmsg)
            eventcount += 1
            dm.Refresh()
        End Sub 

    End Class 
End Namespace 
'</Snippet1>