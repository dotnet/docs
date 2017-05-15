' <snippet1>
' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.Design.Behavior
' </snippet2>

Public Class Form1
   Inherits Form
   Private demoControl1 As DemoControl
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub
   
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub
   
   #Region "Windows Form Designer generated code"
   
   
   Private Sub InitializeComponent()
        Me.demoControl1 = New DemoControl
        Me.SuspendLayout()
        '
        'demoControl1
        '
        Me.demoControl1.Location = New System.Drawing.Point(53, 54)
        Me.demoControl1.Name = "demoControl1"
        Me.demoControl1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(492, 482)
        Me.Controls.Add(Me.demoControl1)
        Me.Name = "Form1"
        Me.Text = "r"
        Me.ResumeLayout(False)

    End Sub
   
   #End Region

End Class

' <snippet20>
' This control is derived from UserContro, with no additional logic.
' The design-related code is implemented in DemoControlDesigner.

' <snippet21>
<DesignerAttribute(GetType(DemoControlDesigner)), _
ToolboxItem(GetType(DemoControl.DemoToolboxItem))> _
Public Class DemoControl
    Inherits Label
    ' </snippet21>

    Private components As System.ComponentModel.IContainer = Nothing


    Public Sub New()
        InitializeComponent()

        MessageBox.Show("DemoControl", "Constructor")
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Private Sub InitializeComponent()
    End Sub


    ' <snippet22>
    ' Toolbox items must be serializable.
    <Serializable(), _
    System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name:="FullTrust"), _
    System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name:="FullTrust")> _
    Class DemoToolboxItem
        Inherits ToolboxItem

        ' The add components dialog in VS looks for a public
        ' ctor that takes a type.
        Public Sub New(ByVal toolType As Type)
            MyBase.New(toolType)
        End Sub 'New


        ' And you must provide this special constructor for serialization.
        ' If you add additional data to MyToolboxItem that you
        ' want to serialize, you may override Deserialize and
        ' Serialize methods to add that data.  
        Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            Deserialize(info, context)
        End Sub 'New


        ' This implementation sets the new control's Text and 
        ' AutoSize properties.
        Protected Overrides Function CreateComponentsCore(ByVal host As IDesignerHost, ByVal defaultValues As IDictionary) As IComponent()

            Dim comps As IComponent() = MyBase.CreateComponentsCore(host, defaultValues)

            ' The returned IComponent array contains a single 
            ' component, which is an instance of DemoControl.
            CType(comps(0), DemoControl).Text = "This text was set by CreateComponentsCore."
            CType(comps(0), DemoControl).AutoSize = True

            Return comps
        End Function
    End Class
    ' </snippet22>

End Class
' </snippet20>



' This class demonstrates a designer that attaches to various 
' services and changes the properties exposed by the control
' being designed.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class DemoControlDesigner
    Inherits ControlDesigner

    ' This member backs the Locked property.
    Private lockedValue As Boolean = False

    ' This is the collection of DesignerActionLists that
    ' defines the smart tags offered on the control. 
    Private actionListsValue As DesignerActionListCollection = Nothing

    ' This Timer is created when you select the Create Timer
    ' smart tag item.
    Private createdTimer As Timer = Nothing

    ' <snippet3>
    ' These are the services which DemoControlDesigner will use.
    Private actionService As DesignerActionService = Nothing
    Private actionUiService As DesignerActionUIService = Nothing
    Private changeService As IComponentChangeService = Nothing
    Private eventService As IDesignerEventService = Nothing
    Private host As IDesignerHost = Nothing
    Private optionService As IDesignerOptionService = Nothing
    Private eventBindingService As IEventBindingService = Nothing
    Private listService As IExtenderListService = Nothing
    Private referenceService As IReferenceService = Nothing
    Private selectionService As ISelectionService = Nothing
    Private typeResService As ITypeResolutionService = Nothing
    Private componentDiscoveryService As IComponentDiscoveryService = Nothing
    Private toolboxService As IToolboxService = Nothing
    Private undoEng As UndoEngine = Nothing
    ' </snippet3>

    Public Sub New()
        MessageBox.Show("DemoControlDesigner", "Constructor")
    End Sub

    ' <snippet4>
    ' The Dispose method override is implemented so event handlers
    ' can be removed. This prevents objects from lingering in 
    ' memory beyond the desired lifespan.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then
            If (Me.changeService IsNot Nothing) Then
                ' Unhook event handlers.
                RemoveHandler Me.changeService.ComponentChanged, AddressOf ChangeService_ComponentChanged

                RemoveHandler Me.changeService.ComponentAdded, AddressOf ChangeService_ComponentAdded

                RemoveHandler Me.changeService.ComponentRemoved, AddressOf changeService_ComponentRemoved
            End If

            If (Me.eventService IsNot Nothing) Then
                RemoveHandler Me.eventService.ActiveDesignerChanged, AddressOf eventService_ActiveDesignerChanged
            End If

            If (Me.selectionService IsNot Nothing) Then
                RemoveHandler Me.selectionService.SelectionChanged, AddressOf selectionService_SelectionChanged
            End If
        End If


        MyBase.Dispose(disposing)

    End Sub
    ' </snippet4>

    ' <snippet5>
    ' This method initializes the designer.
    Public Overrides Sub Initialize(ByVal component As IComponent)

        MyBase.Initialize(component)

        ' Connect to various designer services.
        InitializeServices()

        ' Set up the BackColor value that will be serialized.
        ' This is the shadowed property on the designer.
        Me.BackColor = Color.Chartreuse

        ' Set up the BackColor value that will be displayed.
        Me.Control.BackColor = Color.AliceBlue

    End Sub 'Initialize 
    ' </snippet5>

    ' <snippet6>
    ' This method creates the DesignerActionList on demand, causing
    ' smart tags to appear on the control being designed.

    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            If actionListsValue Is Nothing Then
                actionListsValue = New DesignerActionListCollection()
                actionListsValue.Add(New DemoActionList(Me.Component))
            End If

            Return actionListsValue
        End Get
    End Property
    ' </snippet6>

    ' <snippet7>
    ' This utility method connects the designer to various
    ' services it will use. 
    Private Sub InitializeServices()

        ' Acquire a reference to DesignerActionService.
        Me.actionService = GetService(GetType(DesignerActionService))

        ' Acquire a reference to DesignerActionUIService.
        Me.actionUiService = GetService(GetType(DesignerActionUIService))

        ' Acquire a reference to IComponentChangeService.
        Me.changeService = GetService(GetType(IComponentChangeService))

        ' <snippet14>
        ' Hook the IComponentChangeService events.
        If (Me.changeService IsNot Nothing) Then
            AddHandler Me.changeService.ComponentChanged, AddressOf ChangeService_ComponentChanged

            AddHandler Me.changeService.ComponentAdded, AddressOf ChangeService_ComponentAdded

            AddHandler Me.changeService.ComponentRemoved, AddressOf changeService_ComponentRemoved
        End If
        ' </snippet14>

        ' Acquire a reference to ISelectionService.
        Me.selectionService = GetService(GetType(ISelectionService))

        ' Hook the SelectionChanged event.
        If (Me.selectionService IsNot Nothing) Then
            AddHandler Me.selectionService.SelectionChanged, AddressOf selectionService_SelectionChanged
        End If

        ' Acquire a reference to IDesignerEventService.
        Me.eventService = GetService(GetType(IDesignerEventService))

        If (Me.eventService IsNot Nothing) Then
            AddHandler Me.eventService.ActiveDesignerChanged, AddressOf eventService_ActiveDesignerChanged
        End If

        ' Acquire a reference to IDesignerHost.
        Me.host = GetService(GetType(IDesignerHost))

        ' Acquire a reference to IDesignerOptionService.
        Me.optionService = GetService(GetType(IDesignerOptionService))

        ' Acquire a reference to IEventBindingService.
        Me.eventBindingService = GetService(GetType(IEventBindingService))

        ' Acquire a reference to IExtenderListService.
        Me.listService = GetService(GetType(IExtenderListService))

        ' Acquire a reference to IReferenceService.
        Me.referenceService = GetService(GetType(IReferenceService))

        ' Acquire a reference to ITypeResolutionService.
        Me.typeResService = GetService(GetType(ITypeResolutionService))

        ' Acquire a reference to IComponentDiscoveryService.
        Me.componentDiscoveryService = GetService(GetType(IComponentDiscoveryService))

        ' Acquire a reference to IToolboxService.
        Me.toolboxService = GetService(GetType(IToolboxService))

        ' Acquire a reference to UndoEngine.
        Me.undoEng = GetService(GetType(UndoEngine))

        If (Me.undoEng IsNot Nothing) Then
            MessageBox.Show("UndoEngine")
        End If
    End Sub
    ' </snippet7>

    ' <snippet8>
    ' This is the shadowed property on the designer.
    ' This value will be serialized instead of the 
    ' value of the control's property.

    Public Property BackColor() As Color
        Get
            Return CType(ShadowProperties("BackColor"), Color)
        End Get
        Set(ByVal value As Color)
            If (Me.changeService IsNot Nothing) Then
                Dim backColorDesc As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Control)("BackColor")

                Me.changeService.OnComponentChanging(Me.Control, backColorDesc)

                Me.ShadowProperties("BackColor") = value

                Me.changeService.OnComponentChanged(Me.Control, backColorDesc, Nothing, Nothing)
            End If
        End Set
    End Property
    ' </snippet8>

    ' <snippet9>
    ' This is the property added by the designer in the
    ' PreFilterProperties method.

    Private Property Locked() As Boolean
        Get
            Return lockedValue
        End Get
        Set(ByVal value As Boolean)
            lockedValue = value
        End Set
    End Property
    ' </snippet9>

    ' <snippet10>
    ' The PreFilterProperties method is where you can add or remove
    ' properties from the component being designed. 
    '
    ' In this implementation, the Visible property is removed,
    ' the BackColor property is shadowed by the designer, and
    ' the a new property, called Locked, is added.
    Protected Overrides Sub PreFilterProperties(ByVal properties As IDictionary)

        ' Always call the base PreFilterProperties implementation 
        ' before you modify the properties collection.
        MyBase.PreFilterProperties(properties)

        ' Remove the visible property.
        properties.Remove("Visible")

        ' Shadow the BackColor property.
        Dim propertyDesc As PropertyDescriptor = TypeDescriptor.CreateProperty(GetType(DemoControlDesigner), CType(properties("BackColor"), PropertyDescriptor), New Attribute(-1) {})
        properties("BackColor") = propertyDesc

        ' Create the Locked property.
        properties("Locked") = TypeDescriptor.CreateProperty(GetType(DemoControlDesigner), "Locked", GetType(Boolean), CategoryAttribute.Design, DesignOnlyAttribute.Yes)

    End Sub
    ' </snippet10>

    ' <snippet11>
    ' The PostFilterProperties method is where you modify existing
    ' properties. You must only use this method to modify existing 
    ' items. Do not add or remove items here. Also, be sure to 
    ' call base.PostFilterProperties(properties) after your filtering
    ' logic.
    '
    ' In this implementation, the Enabled property is hidden from
    ' any PropertyGrid or Properties window. This is done by 
    ' creating a copy of the existing PropertyDescriptor and
    ' attaching two new Attributes: Browsable and EditorBrowsable.
    Protected Overrides Sub PostFilterProperties(ByVal properties As IDictionary)
        Dim pd As PropertyDescriptor = properties("Enabled")

        pd = TypeDescriptor.CreateProperty(pd.ComponentType, pd, New Attribute(1) {New BrowsableAttribute(False), New EditorBrowsableAttribute(EditorBrowsableState.Never)})

        properties(pd.Name) = pd

        ' Always call the base PostFilterProperties implementation 
        ' after you modify the properties collection.
        MyBase.PostFilterProperties(properties)

    End Sub
    ' </snippet11>

#Region "Event Handlers"

    ' <snippet12>
    Private Sub eventService_ActiveDesignerChanged(ByVal sender As Object, ByVal e As ActiveDesignerEventArgs)
        If (e.NewDesigner IsNot Nothing) Then
            Dim o As Object = e.NewDesigner
            MessageBox.Show(o.ToString(), "ActiveDesignerChanged")
        End If
    End Sub

    ' <snippet15>
    Private Sub ChangeService_ComponentChanged(ByVal sender As Object, ByVal e As ComponentChangedEventArgs)
        Dim msg As String = String.Format("{0}, {1}", e.Component, e.Member)

        MessageBox.Show(msg, "ComponentChanged")
    End Sub


    Private Sub ChangeService_ComponentAdded(ByVal sender As Object, ByVal e As ComponentEventArgs)
        MessageBox.Show(e.ToString(), "ComponentAdded")
    End Sub


    Private Sub changeService_ComponentRemoved(ByVal sender As Object, ByVal e As ComponentEventArgs)
        Dim o As Object = e.Component
        MessageBox.Show(o.ToString(), "ComponentRemoved")
    End Sub
    ' </snippet15>

    Private Sub selectionService_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.selectionService IsNot Nothing) Then
            If Me.selectionService.PrimarySelection Is Me.Control Then
                MessageBox.Show(Me.Control.ToString(), "SelectionChanged")
            End If
        End If
    End Sub
    ' </snippet12>

#End Region

    ' <snippet13>
    ' This class defines the smart tags that appear on the control
    ' that is being designed.

    Friend Class DemoActionList
        Inherits System.ComponentModel.Design.DesignerActionList
        ' Cache a reference to the designer host.
        Private host As IDesignerHost = Nothing

        ' Cache a reference to the control.
        Private relatedControl As DemoControl = Nothing

        ' Cache a reference to the designer.
        Private relatedDesigner As DemoControlDesigner = Nothing

        'The constructor associates the control 
        'with the smart tag list.
        Public Sub New(ByVal component As IComponent)
            MyBase.New(component)
            Me.relatedControl = component '

            Me.host = Me.Component.Site.GetService(GetType(IDesignerHost))

            Dim dcd As IDesigner = host.GetDesigner(Me.Component)
            Me.relatedDesigner = dcd

        End Sub

        ' This method creates and populates the 
        ' DesignerActionItemCollection which is used to 
        ' display smart tag items.
        Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            ' If the Timer component has not been created, show the
            ' "Create Timer" DesignerAction item.
            '
            ' If the Timer component exists, show the timer-related
            ' options.
            If Me.relatedDesigner.createdTimer Is Nothing Then
                items.Add(New DesignerActionMethodItem(Me, "CreateTimer", "Create Timer", True))
            Else
                items.Add(New DesignerActionMethodItem(Me, "ShowEventHandlerCode", "Show Event Handler Code", True))

                items.Add(New DesignerActionMethodItem(Me, "RemoveTimer", "Remove Timer", True))
            End If

            items.Add(New DesignerActionMethodItem(Me, "GetExtenderProviders", "Get Extender Providers", True))

            items.Add(New DesignerActionMethodItem(Me, "GetDemoControlReferences", "Get DemoControl References", True))

            items.Add(New DesignerActionMethodItem(Me, "GetPathOfAssembly", "Get Path of Executing Assembly", True))

            items.Add(New DesignerActionMethodItem(Me, "GetComponentTypes", "Get ScrollableControl Types", True))

            items.Add(New DesignerActionMethodItem(Me, "GetToolboxCategories", "Get Toolbox Categories", True))

            items.Add(New DesignerActionMethodItem(Me, "SetBackColor", "Set Back Color", True))

            Return items
        End Function

        ' <snippet17>
        ' This method creates a Timer component using the 
        ' IDesignerHost.CreateComponent method. It also 
        ' creates an event handler for the Timer component's
        ' tick event.
        Private Sub CreateTimer()
            If (Me.host IsNot Nothing) Then
                If Me.relatedDesigner.createdTimer Is Nothing Then
                    ' Create and configure the Timer object.
                    Me.relatedDesigner.createdTimer = Me.host.CreateComponent(GetType(Timer))

                    Dim t As Timer = Me.relatedDesigner.createdTimer
                    t.Interval = 1000
                    t.Enabled = True

                    Dim eventColl As EventDescriptorCollection = TypeDescriptor.GetEvents(t, New Attribute(-1) {})

                    If (eventColl IsNot Nothing) Then
                        Dim ed As EventDescriptor = eventColl("Tick")

                        If (ed IsNot Nothing) Then
                            Dim epd As PropertyDescriptor = Me.relatedDesigner.eventBindingService.GetEventProperty(ed)

                            epd.SetValue(t, "timer_Tick")
                        End If
                    End If

                    Me.relatedDesigner.actionUiService.Refresh(Me.relatedControl)
                End If
            End If
        End Sub
        ' </snippet17>

        ' <snippet18>
        ' This method uses the IEventBindingService.ShowCode
        ' method to start the Code Editor. It places the caret
        ' in the timer_tick method created by the CreateTimer method.
        Private Sub ShowEventHandlerCode()
            Dim t As Timer = Me.relatedDesigner.createdTimer

            If (t IsNot Nothing) Then
                Dim eventColl As EventDescriptorCollection = TypeDescriptor.GetEvents(t, New Attribute(-1) {})
                If (eventColl IsNot Nothing) Then
                    Dim ed As EventDescriptor = eventColl("Tick")

                    If (ed IsNot Nothing) Then
                        Me.relatedDesigner.eventBindingService.ShowCode(t, ed)
                    End If
                End If
            End If
        End Sub
        ' </snippet18>

        ' <snippet19>
        ' This method uses the IDesignerHost.DestroyComponent method
        ' to remove the Timer component from the design environment.
        Private Sub RemoveTimer()
            If (Me.host IsNot Nothing) Then
                If (Me.relatedDesigner.createdTimer IsNot Nothing) Then
                    Me.host.DestroyComponent(Me.relatedDesigner.createdTimer)

                    Me.relatedDesigner.createdTimer = Nothing

                    Me.relatedDesigner.actionUiService.Refresh(Me.relatedControl)
                End If
            End If
        End Sub
        ' </snippet19>

        ' <snippet16>
        ' This method uses IExtenderListService.GetExtenderProviders
        ' to enumerate all the extender providers and display them 
        ' in a MessageBox.
        Private Sub GetExtenderProviders()
            If (Me.relatedDesigner.listService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim providers As IExtenderProvider() = Me.relatedDesigner.listService.GetExtenderProviders()

                Dim i As Integer
                For i = 0 To providers.Length - 1
                    Dim o As Object = providers(i)
                    sb.Append(o.ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next i

                MessageBox.Show(sb.ToString(), "Extender Providers")
            End If
        End Sub
        ' </snippet16>

        ' This method uses the IReferenceService.GetReferences method
        ' to enumerate all the instances of DemoControl on the 
        ' design surface.
        Private Sub GetDemoControlReferences()
            If (Me.relatedDesigner.referenceService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim refs As Object() = Me.relatedDesigner.referenceService.GetReferences(GetType(DemoControl))

                Dim i As Integer
                For i = 0 To refs.Length - 1
                    sb.Append(refs(i).ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next i

                MessageBox.Show(sb.ToString(), "DemoControl References")
            End If
        End Sub

        ' This method uses the ITypeResolutionService.GetPathOfAssembly
        ' method to display the path of the executing assembly.
        Private Sub GetPathOfAssembly()
            If (Me.relatedDesigner.typeResService IsNot Nothing) Then
                Dim name As System.Reflection.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName()

                MessageBox.Show(Me.relatedDesigner.typeResService.GetPathOfAssembly(name), "Path of executing assembly")
            End If
        End Sub


        ' This method uses the IComponentDiscoveryService.GetComponentTypes 
        ' method to find all the types that derive from 
        ' ScrollableControl.
        Private Sub GetComponentTypes()
            If (Me.relatedDesigner.componentDiscoveryService IsNot Nothing) Then
                Dim components As ICollection = Me.relatedDesigner.componentDiscoveryService.GetComponentTypes(host, GetType(ScrollableControl))

                If (components IsNot Nothing) Then
                    If components.Count > 0 Then
                        Dim sb As New StringBuilder()

                        Dim e As IEnumerator = components.GetEnumerator()

                        While e.MoveNext()
                            sb.Append(e.Current.ToString())
                            sb.Append(ControlChars.Cr + ControlChars.Lf)
                        End While

                        MessageBox.Show(sb.ToString(), "Controls derived from ScrollableControl")
                    End If
                End If
            End If
        End Sub


        ' This method uses the IToolboxService.CategoryNames
        ' method to enumerate all the categories that appear
        ' in the Toolbox.
        Private Sub GetToolboxCategories()
            If (Me.relatedDesigner.toolboxService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim names As CategoryNameCollection = Me.relatedDesigner.toolboxService.CategoryNames

                Dim name As String
                For Each name In names
                    sb.Append(name.ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next name

                MessageBox.Show(sb.ToString(), "Toolbox Categories")
            End If
        End Sub


        ' This method sets the shadowed BackColor property on the 
        ' designer. This is the value that is serialized by the 
        ' design environment.
        Private Sub SetBackColor()
            Dim d As New ColorDialog()
            If d.ShowDialog() = DialogResult.OK Then
                Me.relatedDesigner.BackColor = d.Color
            End If
        End Sub
    End Class
    ' </snippet13>
End Class
' </snippet1>