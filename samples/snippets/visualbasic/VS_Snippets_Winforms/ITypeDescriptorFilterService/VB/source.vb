'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Reflection
Imports System.Timers
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace ITypeDescriptorFilterSample

    ' Component to host the ButtonDesignerFilterComponentDesigner that loads the 
    ' ButtonDesignerFilterService ITypeDescriptorFilterService.
    <Designer(GetType(ButtonDesignerFilterComponentDesigner))> _
    Public Class ButtonDesignerFilterComponent
        Inherits System.ComponentModel.Component

        Public Sub New(ByVal container As System.ComponentModel.IContainer)
            container.Add(Me)
        End Sub 'New

        Public Sub New()
        End Sub 'New
    End Class 'ButtonDesignerFilterComponent

    ' Provides a designer that can add a ColorCycleButtonDesigner to each 
    ' button in a design time project using the ButtonDesignerFilterService 
    ' ITypeDescriptorFilterService.
    Public Class ButtonDesignerFilterComponentDesigner
        Inherits System.ComponentModel.Design.ComponentDesigner

        ' Indicates whether the service has been loaded.
        Private serviceloaded As Boolean = False
        ' Stores any old ITypeDescriptorFilterService to restore later.
        Private oldservice As ITypeDescriptorFilterService = Nothing

        Public Sub New()
        End Sub

        ' Loads the new ITypeDescriptorFilterService and reloads the 
        ' designers for each Button.
        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)

            MyBase.Initialize(component)

            ' Loads the custom service if it has not been loaded already.
            LoadService()

            ' Build list of buttons from Container.Components.
            Dim buttons As New ArrayList()
            Dim c As IComponent
            For Each c In Me.Component.Site.Container.Components
                If TypeOf c Is System.Windows.Forms.Button Then
                    buttons.Add(CType(c, System.Windows.Forms.Button))
                End If
            Next c
            If buttons.Count > 0 Then
                ' Tests each Button for an existing 
                ' ColorCycleButtonDesigner;
		' if it has no designer of type 
                ' ColorCycleButtonDesigner, adds a designer.
                Dim b As System.Windows.Forms.Button
                For Each b In buttons
                    Dim loaddesigner As Boolean = True
                    ' Gets the attributes for each button.
                    Dim ac As AttributeCollection = TypeDescriptor.GetAttributes(b)
                    Dim i As Integer
                    For i = 0 To ac.Count - 1
                        ' If designer attribute is not for a 
                        ' ColorCycleButtonDesigner, adds a new 
                        ' ColorCycleButtonDesigner.
                        If TypeOf ac(i) Is DesignerAttribute Then
                            Dim da As DesignerAttribute = CType(ac(i), DesignerAttribute)
                            If da.DesignerTypeName.Substring((da.DesignerTypeName.LastIndexOf(".") + 1)) = "ColorCycleButtonDesigner" Then
                                loaddesigner = False
                            End If
                        End If
                    Next i
                    If loaddesigner Then
                        ' Saves the button location so that it 
                        ' can be repositioned.
                        Dim p As Point = b.Location

                        ' Gets an IMenuCommandService to cut and 
                        ' paste control in order to register with 
                        ' selection and movement interface after 
                        ' designer is changed without reloading.
                        Dim imcs As IMenuCommandService = CType(Me.GetService(GetType(IMenuCommandService)), IMenuCommandService)
                        If imcs Is Nothing Then
                            Throw New Exception("Could not obtain IMenuCommandService interface.")
                        End If 

                        ' Gets an ISelectionService to select the 
                        ' button so that it can be cut and pasted.
                        Dim iss As ISelectionService = CType(Me.GetService(GetType(ISelectionService)), ISelectionService)
                        If iss Is Nothing Then
                            Throw New Exception("Could not obtain ISelectionService interface.")
                        End If
                        iss.SetSelectedComponents(New IComponent() {b}, SelectionTypes.Auto)

                        ' Invoke Cut and Paste.
                        imcs.GlobalInvoke(StandardCommands.Cut)
                        imcs.GlobalInvoke(StandardCommands.Paste)

                        ' Regains reference to button from 
                        ' selection service.
                        Dim b2 As System.Windows.Forms.Button = CType(iss.PrimarySelection, System.Windows.Forms.Button)
                        iss.SetSelectedComponents(Nothing)

                        ' Refreshes TypeDescriptor properties of 
                        ' button to load new attributes from 
                        ' ButtonDesignerFilterService.
                        TypeDescriptor.Refresh(b2)
                        b2.Location = p
                        b2.Focus()
                    End If
                Next b
            End If
        End Sub 

        ' Loads a ButtonDesignerFilterService ITypeDescriptorFilterService 
        ' to add ColorCycleButtonDesigner designers to each button.
        Private Sub LoadService()
            ' If no custom ITypeDescriptorFilterService is loaded, 
            ' loads it now.
            If Not serviceloaded Then
                ' Stores the current ITypeDescriptorFilterService 
                ' to restore later.
                Dim tdfs As ITypeDescriptorFilterService = CType(Me.Component.Site.GetService(GetType(ITypeDescriptorFilterService)), ITypeDescriptorFilterService)
                If (tdfs IsNot Nothing) Then
                    oldservice = tdfs
                End If 
                
                ' Retrieves an IDesignerHost interface to use to 
                ' remove and add services.
                Dim dh As IDesignerHost = CType(Me.Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
                If dh Is Nothing Then
                    Throw New Exception("Could not obtain IDesignerHost interface.")
                End If 

                ' Removes the standard ITypeDescriptorFilterService.
                dh.RemoveService(GetType(ITypeDescriptorFilterService))
                ' Adds the new custom ITypeDescriptorFilterService.
                dh.AddService(GetType(ITypeDescriptorFilterService), New ButtonDesignerFilterService())
                serviceloaded = True
            End If
        End Sub

        ' Removes the custom service and reloads any stored, 
        ' preexisting service.
        Private Sub RemoveService()
            Dim dh As IDesignerHost = CType(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
            If dh Is Nothing Then
                Throw New Exception("Could not obtain IDesignerHost interface.")
            End If
            dh.RemoveService(GetType(ITypeDescriptorFilterService))
            If (oldservice IsNot Nothing) Then
                dh.AddService(GetType(ITypeDescriptorFilterService), oldservice)
            End If
            serviceloaded = False
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If serviceloaded Then
                RemoveService()
            End If
        End Sub

    End Class

    ' Provides a TypeDescriptorFilterService to add the 
    ' ColorCycleButtonDesigner using a DesignerAttribute.
    Public Class ButtonDesignerFilterService
        Implements System.ComponentModel.Design.ITypeDescriptorFilterService

        Public oldService As ITypeDescriptorFilterService = Nothing

        Public Sub New()
        End Sub 

        Public Sub New(ByVal oldService_ As ITypeDescriptorFilterService)
            ' Stores any previous ITypeDescriptorFilterService to implement service chaining.
            Me.oldService = oldService_
        End Sub 

        Public Function FilterAttributes(ByVal component As System.ComponentModel.IComponent, ByVal attributes As System.Collections.IDictionary) As Boolean Implements ITypeDescriptorFilterService.FilterAttributes
            If (oldService IsNot Nothing) Then
                oldService.FilterAttributes(component, attributes)
            End If
            ' Creates a designer attribute to compare its TypeID with the TypeID of existing attributes of the component.
            Dim da As New DesignerAttribute(GetType(ColorCycleButtonDesigner))
            ' Adds the designer attribute if the attribute collection does not contain a DesignerAttribute of the same TypeID.
            If TypeOf component Is System.Windows.Forms.Button And attributes.Contains(da.TypeId) Then
                attributes(da.TypeId) = da
            End If
            Return True
        End Function 

        Public Function FilterEvents(ByVal component As System.ComponentModel.IComponent, ByVal events As System.Collections.IDictionary) As Boolean Implements ITypeDescriptorFilterService.FilterEvents
            If (oldService IsNot Nothing) Then
                oldService.FilterEvents(component, events)
            End If
            Return True
        End Function 

        Public Function FilterProperties(ByVal component As System.ComponentModel.IComponent, ByVal properties As System.Collections.IDictionary) As Boolean Implements ITypeDescriptorFilterService.FilterProperties
            If (oldService IsNot Nothing) Then
                oldService.FilterProperties(component, properties)
            End If
            Return True
        End Function 

    End Class   

    ' Designer for a Button control which cycles the background color.
    Public Class ColorCycleButtonDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Private timer1 As System.Windows.Forms.Timer
        Private initial_bcolor, initial_fcolor As Color
        Private r, g, b As Integer
        Private ru, gu, bu, continue_ As Boolean

        Public Sub New()
            timer1 = New System.Windows.Forms.Timer()
            timer1.Interval = 50
            AddHandler timer1.Tick, AddressOf Me.Elapsed
            ru = True
            gu = False
            bu = True
            continue_ = False
            timer1.Start()
        End Sub 

        Private Sub Elapsed(ByVal sender As Object, ByVal e As EventArgs)
            Me.Control.BackColor = Color.FromArgb(r Mod 255, g Mod 255, b Mod 255)
            Me.Control.Refresh()

            ' Updates color.			
            If ru Then
                r += 10
            Else
                If r > 10 Then
                    r -= 10
                End If
            End If
            If gu Then
                g += 10
            Else
                If g > 10 Then
                    g -= 10
                End If
            End If
            If bu Then
                b += 10
            Else
                If b > 10 Then
                    b -= 10
                End If
            End If 

            ' Randomly switches direction of color component values.
            Dim rand As New Random()
            Dim i As Integer
            For i = 0 To 3
                Select Case rand.Next(0, 2)
                    Case 0
                        If ru Then
                            ru = False
                        Else
                            ru = True
                        End If
                    Case 1
                        If gu Then
                            gu = False
                        Else
                            gu = True
                        End If
                    Case 2
                        If bu Then
                            bu = False
                        Else
                            bu = True
                        End If
                End Select
            Next i
            Me.Control.ForeColor = Color.FromArgb((Me.Control.BackColor.R + 128) Mod 255, (Me.Control.BackColor.G + 128) Mod 255, (Me.Control.BackColor.B + 128) Mod 255)
        End Sub 

        Protected Overrides Sub OnMouseEnter()
            If Not timer1.Enabled Then
                initial_bcolor = Me.Control.BackColor
                initial_fcolor = Me.Control.ForeColor
                r = initial_bcolor.R
                g = initial_bcolor.G
                b = initial_bcolor.B
                timer1.Start()
            End If
        End Sub 

        Protected Overrides Sub OnMouseLeave()
            If Not continue_ Then
                continue_ = True
                timer1.Stop()
            Else
                continue_ = False
            End If
            Me.Control.BackColor = initial_bcolor
            Me.Control.ForeColor = initial_fcolor
        End Sub 

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            timer1.Stop()
            Me.Control.BackColor = initial_bcolor
            Me.Control.ForeColor = initial_fcolor
            MyBase.Dispose(disposing)
        End Sub 

    End Class 

    ' System.Windows.Forms.Button associated with the ColorCycleButtonDesigner.
    <Designer(GetType(ColorCycleButtonDesigner))> _
    Public Class ColorCycleButton
        Inherits System.Windows.Forms.Button

        Public Sub New()
        End Sub 
    End Class 

End Namespace 
'</Snippet1>