Imports System
Imports System.ComponentModel.Design
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design


Namespace FreeformActivityDesignerSnippets

    '<snippet0>
    Class ProcessActvityDesigner
        Inherits System.Workflow.ComponentModel.Design.FreeformActivityDesigner


        Function GetConnectionPoint(ByVal activity As Activity, ByVal connectorIndex As Int32, ByVal edge As DesignerEdges) As ConnectionPoint

            Dim designer As ActivityDesigner = Nothing

            If Activity IsNot Nothing And Activity.Site IsNot Nothing Then

                Dim designerHost As IDesignerHost = activity.Site.GetService(GetType(IDesignerHost))
                If designerHost IsNot Nothing Then
                    designer = CType(designerHost.GetDesigner(activity), ActivityDesigner)
                End If
            End If

            Return New ConnectionPoint(designer, edge, connectorIndex)
        End Function


        Protected Overrides Sub OnLayoutPosition(ByVal e As ActivityDesignerLayoutEventArgs)

            MyBase.OnLayoutPosition(e)

            ' Draw a connector between the first and second activities contained in 
            ' the sequence activity used by me designer
            If Me.IsRootDesigner Then

                Dim parentActivity As CompositeActivity = CType(Me.Activity, CompositeActivity)
                Dim sourcePoint As ConnectionPoint = GetConnectionPoint(parentActivity.Activities(0), 1, DesignerEdges.Bottom)
                Dim targetPoint As ConnectionPoint = GetConnectionPoint(parentActivity.Activities(1), 0, DesignerEdges.Top)

                Me.AddConnector(sourcePoint, targetPoint)
            End If
        End Sub

    End Class
    '</snippet0>
End Namespace
