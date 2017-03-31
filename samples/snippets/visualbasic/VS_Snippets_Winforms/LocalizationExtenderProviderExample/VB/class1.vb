 '<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This example demonstrates adding localization support to a component hierarchy from a 
' custom IRootDesigner using the LocalizationExtenderProvider class.

' RootViewDesignerComponent is a component associated with the SampleRootDesigner
' IRootDesigner that provides LocalizationExtenderProvider localization support.
' This derived class is included at the top of this example to enable 
' easy launching of designer view without having to put the class in its own file.
Public Class RootViewDesignerComponent
    Inherits RootDesignedComponent

    Public Sub New()
    End Sub
End Class

' The following attribute associates the RootDesignedComponent with the RootDesignedComponent component.
<Designer(GetType(SampleRootDesigner), GetType(IRootDesigner))> _
Public Class RootDesignedComponent
    Inherits Component

    Public Sub New()
    End Sub
End Class

' Example IRootDesigner implementation demonstrates LocalizationExtenderProvider support.
Friend Class SampleRootDesigner
    Implements IRootDesigner

    ' RootDesignerView Control provides a full region designer view for this root designer's associated component.
    Private m_view As RootDesignerView
    ' Stores reference to the LocalizationExtenderProvider this designer adds, in order to remove it on Dispose.
    Private extender As LocalizationExtenderProvider
    ' Internally stores the IDesigner's component reference
    Private component_ As IComponent

    ' Adds a LocalizationExtenderProvider for the component this designer is initialized to support.
    Public Sub Initialize(ByVal component As System.ComponentModel.IComponent) Implements IRootDesigner.Initialize
        Me.component_ = component

        ' If no extender from this designer is active...
        If extender Is Nothing Then
            '<Snippet2>
            ' Adds a LocalizationExtenderProvider that provides localization support properties to the specified component.
            extender = New LocalizationExtenderProvider(Me.component_.Site, Me.component_)
            '</Snippet2>
        End If
    End Sub

    ' Provides a RootDesignerView object that supports ViewTechnology.WindowsForms.
    Function GetView(ByVal technology As ViewTechnology) As Object Implements IRootDesigner.GetView

        If technology <> ViewTechnology.WindowsForms Then
            Throw New ArgumentException("Not a supported view technology", "technology")
        End If
        If m_view Is Nothing Then
            ' Create the view control. In this example, a Control of type RootDesignerView is used.
            ' A WindowsForms ViewTechnology view provider requires a class that inherits from Control.
            m_view = New RootDesignerView(Me, Me.Component)
        End If
        Return m_view

    End Function

    ' This designer supports the WindowsForms view technology.
    ReadOnly Property SupportedTechnologies() As ViewTechnology() Implements IRootDesigner.SupportedTechnologies
        Get
            Return New ViewTechnology() {ViewTechnology.WindowsForms}
        End Get
    End Property

    ' If a LocalizationExtenderProvider has been added, removes the extender provider.
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        ' If an extender has been added, remove it
        If (extender IsNot Nothing) Then
            ' Disposes of the extender provider.  The extender 
            ' provider removes itself from the extender provider
            ' service when it is disposed.
            extender.Dispose()
            extender = Nothing
        End If
    End Sub

    ' Empty IDesigner interface property and method implementations
    Public ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection Implements IDesigner.Verbs
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Component() As System.ComponentModel.IComponent Implements IRootDesigner.Component
        Get
            Return Me.component_
        End Get
    End Property

    Public Sub DoDefaultAction() Implements IDesigner.DoDefaultAction
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
    End Sub

    ' RootDesignerView is a simple control that will be displayed in the designer window.
    Private Class RootDesignerView
        Inherits Control
        Private m_designer As SampleRootDesigner
        Private comp As IComponent

        Public Sub New(ByVal designer As SampleRootDesigner, ByVal component As IComponent)
            m_designer = designer
            Me.comp = component
            BackColor = Color.Blue
            Font = New Font(FontFamily.GenericMonospace, 12)
        End Sub

        ' Displays the name of the component and the name of the assembly of the component 
        ' that this root designer is providing support for.
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            MyBase.OnPaint(pe)

            If (m_designer IsNot Nothing) AndAlso (comp IsNot Nothing) Then
                ' Draws the name of the component in large letters.
                pe.Graphics.DrawString("Root Designer View", Font, Brushes.Yellow, 8, 4)
                pe.Graphics.DrawString("Design Name  : " + comp.Site.Name, New Font("Arial", 10), Brushes.Yellow, 8, 28)
                
                ' Uses the site of the component to acquire an ISelectionService and sets the property grid focus to the component.
                Dim selectionService As ISelectionService = CType(comp.Site.GetService(GetType(ISelectionService)), ISelectionService)
                If (selectionService IsNot Nothing) Then
                    selectionService.SetSelectedComponents(New IComponent() {m_designer.Component})
                End If
            End If
        End Sub
    End Class

End Class
'</Snippet1>