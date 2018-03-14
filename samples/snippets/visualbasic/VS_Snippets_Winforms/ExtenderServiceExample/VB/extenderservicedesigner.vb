 '<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This designer adds a ComponentExtender extender provider, 
' and removes it when the designer is destroyed.
Public Class ExtenderServiceDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner

   ' A local reference to an obtained IExtenderProviderService.
   Private localExtenderServiceReference As IExtenderProviderService
   ' An IExtenderProvider that this designer supplies.
   Private extender As ComponentExtender   
   
   Public Sub New()
    End Sub

    Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)

        ' Attempts to obtain an IExtenderProviderService.
        Dim extenderService As IExtenderProviderService = CType(component.Site.GetService(GetType(IExtenderProviderService)), IExtenderProviderService)
        If (extenderService IsNot Nothing) Then
            ' If the service was obtained, adds a ComponentExtender 
            ' that adds an "ExtenderIndex" integer property to the 
            ' designer's component.
            extender = New ComponentExtender()
            extenderService.AddExtenderProvider(extender)
            localExtenderServiceReference = extenderService
        Else
            MessageBox.Show("Could not obtain an IExtenderProviderService.")
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        ' Removes any previously added extender provider.
        If (localExtenderServiceReference IsNot Nothing) Then
            localExtenderServiceReference.RemoveExtenderProvider(extender)
            localExtenderServiceReference = Nothing
        End If
    End Sub
End Class

' IExtenderProviderImplementation that adds an integer property 
' named "ExtenderIndex" to any design-mode document object.
<ProvidePropertyAttribute("ExtenderIndex", GetType(IComponent))> _
Public Class ComponentExtender
    Implements System.ComponentModel.IExtenderProvider

    ' Stores the value of the property to extend a component with.
    Public index As Integer = 0

    Public Sub New()
    End Sub

    ' Extends any type of object.
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements IExtenderProvider.CanExtend
        Return True
    End Function

    Public Function GetExtenderIndex(ByVal component As IComponent) As Integer
        Return index
    End Function

    Public Sub SetExtenderIndex(ByVal component As IComponent, ByVal index As Integer)
        Me.index = index
    End Sub
End Class

' Example UserControl associated with the ExtenderServiceDesigner.
<DesignerAttribute(GetType(ExtenderServiceDesigner))> _
Public Class ExtenderServiceTestControl
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
    End Sub
End Class
'</Snippet1>