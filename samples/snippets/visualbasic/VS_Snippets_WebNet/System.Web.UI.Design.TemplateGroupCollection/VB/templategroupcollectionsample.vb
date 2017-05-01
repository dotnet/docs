'<Snippet1>
Imports System
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace Examples.AspNet

    ' Define a simple control designer that adds a
    ' template group to the template group collection.
    Class DerivedControlDesigner
        Inherits System.Web.UI.Design.ControlDesigner

        Private Dim internalControl As DerivedControl = Nothing
    
        Private Const templateGroupName As String = "My template group"
        Private Const templateDefinitionName1 As String = "First"
        Private Const templateDefinitionName2 As String = "Second"
        Private Dim internalGroup As TemplateGroup = Nothing

        ' Override the read-only TemplateGroups property.
        ' Get the base group collection, and add a group 
        ' with two template definitions for the derived
        ' control designer.
        Public Overrides ReadOnly Property TemplateGroups As TemplateGroupCollection
            Get

                ' Start with the groups defined by the base designer class.
                Dim groups As TemplateGroupCollection  = MyBase.TemplateGroups

                If internalGroup Is Nothing

                    ' Define a new group with two template definitions.
                    internalGroup = New TemplateGroup(templateGroupName, _
                                                internalControl.ControlStyle)

                    Dim templateDef1 As TemplateDefinition = new TemplateDefinition(Me, _
                        templateDefinitionName1, internalControl, _
                        templateDefinitionName1, internalControl.ControlStyle)

                    Dim templateDef2 As TemplateDefinition = new TemplateDefinition(Me, _
                        templateDefinitionName2, internalControl, _
                        templateDefinitionName2, internalControl.ControlStyle)

                    internalGroup.AddTemplateDefinition(templateDef1)
                    internalGroup.AddTemplateDefinition(templateDef2)

                End If

                ' Add the new template group to the collection.
                groups.Add(internalGroup)

                return groups
            End Get
        End Property

    End Class

    ' Simple Web control, derived from the Web control class.
    <DesignerAttribute(GetType(DerivedControlDesigner), GetType(IDesigner))> _
    Public Class DerivedControl
        Inherits WebControl
        
        ' Define derived control behavior here.
    End Class

End Namespace
'</Snippet1>

Namespace Examples.AspNet

    Public Class TestClass
    
        Public Shared Sub Main()
        End Sub
    End Class
End Namespace
