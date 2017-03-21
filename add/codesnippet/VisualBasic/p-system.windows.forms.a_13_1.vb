        ' Inner Class ChartControlAccessibleObject represents accessible information 
        ' associated with the ChartControl.
        ' The ChartControlAccessibleObject is returned in the         ' ChartControl.CreateAccessibilityInstance override.
        Public Class ChartControlAccessibleObject
            Inherits Control.ControlAccessibleObject

            Private chartControl As ChartControl
            
            Public Sub New(ctrl As ChartControl)
                MyBase.New(ctrl)
                chartControl = ctrl
            End Sub 'New
            
            ' Get the role for the Chart. This is used by accessibility programs.            
            Public Overrides ReadOnly Property Role() As AccessibleRole
                Get
                    Return System.Windows.Forms.AccessibleRole.Chart
                End Get
            End Property
            
            ' Get the state for the Chart. This is used by accessibility programs.            
            Public Overrides ReadOnly Property State() As AccessibleStates
                Get
                    Return AccessibleStates.ReadOnly
                End Get
            End Property                        
            
            ' The CurveLegend objects are "child" controls in terms of accessibility so 
            ' return the number of ChartLengend objects.            
            Public Overrides Function GetChildCount() As Integer
                Return chartControl.Legends.Length
            End Function 
            
            ' Get the Accessibility object of the child CurveLegend idetified by index.
            Public Overrides Function GetChild(index As Integer) As AccessibleObject
                If index >= 0 And index < chartControl.Legends.Length Then
                    Return chartControl.Legends(index).AccessibilityObject
                End If
                Return Nothing
            End Function 
            
            ' Helper function that is used by the CurveLegend's accessibility object
            ' to navigate between sibiling controls. Specifically, this function is used in
            ' the CurveLegend.CurveLegendAccessibleObject.Navigate function.
            Friend Function NavigateFromChild(child As CurveLegend.CurveLegendAccessibleObject, _
                                            navdir As AccessibleNavigation) As AccessibleObject
                Select Case navdir
                    Case AccessibleNavigation.Down, AccessibleNavigation.Next
                            Return GetChild(child.ID + 1)
                    
                    Case AccessibleNavigation.Up, AccessibleNavigation.Previous
                            Return GetChild(child.ID - 1)
                End Select
                Return Nothing
            End Function            

            ' Helper function that is used by the CurveLegend's accessibility object
            ' to select a specific CurveLegend control. Specifically, this function is used 
            ' in the CurveLegend.CurveLegendAccessibleObject.Select function.            
            Friend Sub SelectChild(child As CurveLegend.CurveLegendAccessibleObject, selection As AccessibleSelection)
                Dim childID As Integer = child.ID
                
                ' Determine which selection action should occur, based on the
                ' AccessibleSelection value.
                If (selection And AccessibleSelection.TakeSelection) <> 0 Then
                    Dim i As Integer
                    For i = 0 To chartControl.Legends.Length - 1
                        If i = childID Then
                            chartControl.Legends(i).Selected = True
                        Else
                            chartControl.Legends(i).Selected = False
                        End If
                    Next i
                    
                    ' AccessibleSelection.AddSelection means that the CurveLegend will be selected.
                    If (selection And AccessibleSelection.AddSelection) <> 0 Then
                        chartControl.Legends(childID).Selected = True
                    End If

                    ' AccessibleSelection.AddSelection means that the CurveLegend will be unselected.                    
                    If (selection And AccessibleSelection.RemoveSelection) <> 0 Then
                        chartControl.Legends(childID).Selected = False
                    End If
                End If
            End Sub 'SelectChild
        End Class 'ChartControlAccessibleObject