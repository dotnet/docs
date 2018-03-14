'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace IReferenceServiceExample

    ' This control displays the name and type of the primary selection 
    ' component in design mode, if there is one,
    ' and uses the IReferenceService interface to display the names of 
    ' any components of the type of the primary selected component.    
    ' This control uses the IComponentChangeService to monitor for 
    ' selection changed events.    
    Public Class IReferenceServiceControl
        Inherits System.Windows.Forms.UserControl
        ' Indicates the name of the type of the selected component, or "None selected."
        Private selected_typename As String
        ' Indicates the name of the base type of the selected component, or "None selected."
        Private selected_basetypename As String
        ' Indicates the name of the selected component.
        Private selected_componentname As String
        ' Contains the names of components of the type of the selected 
        ' component in design mode.
        Private typeComponents() As String
        ' Contains the names of components of the base type of the selected component in design mode.
        Private basetypeComponents() As String
        ' Reference to the IComponentChangeService for the current component.
        Private selectionService As ISelectionService

        Public Sub New()
            ' Initializes the control properties.
            Me.BackColor = Color.White
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.Name = "IReferenceServiceControl"
            Me.Size = New System.Drawing.Size(500, 250)
            ' Initializes the data properties.
            typeComponents = New String(0) {}
            basetypeComponents = New String(0) {}
            selected_typename = "None selected."
            selected_basetypename = "None selected."
            selected_componentname = "None selected."
            selectionService = Nothing
        End Sub

        ' Registers and unregisters design-mode services when 
        ' the component is sited and unsited.
        Public Overrides Property Site() As System.ComponentModel.ISite
            Get
                ' Returns the site for the control.
                Return MyBase.Site
            End Get
            Set(ByVal Value As System.ComponentModel.ISite)
                ' The site is set to null when a component is cut or 
                ' removed from a design-mode site.

                ' If an event handler has already been linked with 
                ' an ISelectionService, remove the handler.
                If (selectionService IsNot Nothing) Then
                    RemoveHandler selectionService.SelectionChanged, AddressOf Me.OnSelectionChanged
                End If

                ' Sites the control.
                MyBase.Site = Value

                ' Obtains an ISelectionService interface to register 
                ' the selection changed event handler with.
                selectionService = CType(Me.GetService(GetType(ISelectionService)), ISelectionService)
                If (selectionService IsNot Nothing) Then
                    AddHandler selectionService.SelectionChanged, AddressOf Me.OnSelectionChanged
                    ' Updates the display for the current selection, if any.
                    DisplayComponentsOfSelectedComponentType()
                End If
            End Set
        End Property

        ' Updates the display according to the primary selected component, 
        ' if any, and the names of design-mode components that the 
        ' IReferenceService returns references for when queried for 
        ' references to components of the primary selected component's 
        ' type and base type.
        Private Sub DisplayComponentsOfSelectedComponentType()
            ' If a component is selected...
            If (selectionService.PrimarySelection IsNot Nothing) Then
                ' Sets the selected type name and selected component name 
                ' to the type and name of the primary selected component.
                selected_typename = selectionService.PrimarySelection.GetType().FullName
                selected_basetypename = selectionService.PrimarySelection.GetType().BaseType.FullName
                selected_componentname = CType(selectionService.PrimarySelection, IComponent).Site.Name

                ' Obtain an IReferenceService and obtain references to 
                ' each component in the design-mode project.
                ' of the selected component's type and base type.
                Dim rs As IReferenceService = CType(Me.GetService(GetType(IReferenceService)), IReferenceService)
                If (rs IsNot Nothing) Then
                    ' Get references to design-mode components of the 
                    ' primary selected component's type.
                    Dim comps As Object() = CType(rs.GetReferences(selectionService.PrimarySelection.GetType()), Object())
                    typeComponents = New String(comps.Length) {}
                    Dim i As Integer
                    For i = 0 To comps.Length - 1
                        typeComponents(i) = CType(comps(i), IComponent).Site.Name
                    Next i
                    ' Get references to design-mode components with a base type 
                    ' of the primary selected component's base type.
                    comps = CType(rs.GetReferences(selectionService.PrimarySelection.GetType().BaseType), Object())
                    basetypeComponents = New String(comps.Length) {}               
                    For i = 0 To comps.Length - 1
                        basetypeComponents(i) = CType(comps(i), IComponent).Site.Name
                    Next i
                End If
            Else
                selected_typename = "None selected."
                selected_basetypename = "None selected."
                selected_componentname = "None selected."
                typeComponents = New String(0) {}
                basetypeComponents = New String(0) {}
            End If
            Me.Refresh()
        End Sub 'DisplayComponentsOfSelectedComponentType

        Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            DisplayComponentsOfSelectedComponentType()
        End Sub 'OnSelectionChanged

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            e.Graphics.DrawString("IReferenceService Example Control", New Font(FontFamily.GenericMonospace, 9), New SolidBrush(Color.Blue), 5, 5)

            e.Graphics.DrawString("Primary Selected Component from IComponentChangeService:", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Red), 5, 20)
            e.Graphics.DrawString("Name:      " + selected_componentname, New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 10, 32)
            e.Graphics.DrawString("Type:      " + selected_typename, New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 10, 44)
            e.Graphics.DrawString("Base Type: " + selected_basetypename, New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 10, 56)
            e.Graphics.DrawLine(New Pen(New SolidBrush(Color.Black), 1), 5, 77, Me.Width - 10, 77)

            e.Graphics.DrawString("Components of Type from IReferenceService:", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Red), 5, 85)
            If selected_typename <> "None selected." Then
                Dim i As Integer
                For i = 0 To typeComponents.Length - 1
                    e.Graphics.DrawString(typeComponents(i), New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 20, 97 + i * 12)
                Next i
            End If
            e.Graphics.DrawString("Components of Base Type from IReferenceService:", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Red), 5, 109 + typeComponents.Length * 12)
            If selected_typename <> "None selected." Then
                Dim i As Integer
                For i = 0 To basetypeComponents.Length - 1
                    e.Graphics.DrawString(basetypeComponents(i), New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Black), 20, 121 + typeComponents.Length * 12 + i * 12)
                Next i
            End If
        End Sub 'OnPaint

    End Class 'IReferenceServiceControl
End Namespace 'IReferenceServiceExample
'</Snippet1>