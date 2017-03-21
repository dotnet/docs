            ' Inner class CurveLegendAccessibleObject represents accessible information 
            ' associated with the CurveLegend object.
            Public Class CurveLegendAccessibleObject
                Inherits AccessibleObject

                Private curveLegend As CurveLegend
                
                Public Sub New(curveLegend As CurveLegend)
                    Me.curveLegend = curveLegend
                End Sub 'New
                
                ' Private property that helps get the reference to the parent ChartControl.                
                Private ReadOnly Property ChartControl() As ChartControlAccessibleObject
                    Get
                        Return CType(Parent, ChartControlAccessibleObject)
                    End Get
                End Property

                ' Friend helper function that returns the ID for this CurveLegend.                
                Friend ReadOnly Property ID() As Integer
                    Get
                        Dim i As Integer
                        For i = 0 To (ChartControl.GetChildCount()) - 1
                            If ChartControl.GetChild(i) Is Me Then
                                Return i
                            End If
                        Next i
                        Return - 1
                    End Get
                End Property
                
                ' Gets the Bounds for the CurveLegend. This is used by accessibility programs.
                Public Overrides ReadOnly Property Bounds() As Rectangle
                    Get
                        ' The bounds is in screen coordinates.
                        Dim loc As Point = curveLegend.Location
                        Return New Rectangle(curveLegend.chart.PointToScreen(loc), curveLegend.Size)
                    End Get
                End Property

                ' Gets or sets the Name for the CurveLegend. This is used by accessibility programs.                
                Public Overrides Property Name() As String
                    Get
                        Return curveLegend.Name
                    End Get
                    Set
                        curveLegend.Name = value
                    End Set
                End Property
                
                ' Gets the Curve Legend Parent's Accessible object.
                ' This is used by accessibility programs.                
                Public Overrides ReadOnly Property Parent() As AccessibleObject
                    Get
                        Return curveLegend.chart.AccessibilityObject
                    End Get
                End Property
                
                ' Gets the role for the CurveLegend. This is used by accessibility programs.                
                Public Overrides ReadOnly Property Role() As AccessibleRole
                    Get
                        Return System.Windows.Forms.AccessibleRole.StaticText
                    End Get
                End Property

                ' Gets the state based on the selection for the CurveLegend. 
                ' This is used by accessibility programs.                
                Public Overrides ReadOnly Property State() As AccessibleStates
                    Get
                        Dim stateTemp As AccessibleStates = AccessibleStates.Selectable
                        If curveLegend.Selected Then
                            stateTemp = stateTemp Or AccessibleStates.Selected
                        End If
                        Return stateTemp
                    End Get
                End Property
                
                ' Navigates through siblings of this CurveLegend. This is used by accessibility programs.                
                Public Overrides Function Navigate(navdir As AccessibleNavigation) As AccessibleObject
                    ' Use the Friend NavigateFromChild helper function that exists
                    ' on ChartControlAccessibleObject.
                    Return ChartControl.NavigateFromChild(Me, navdir)
                End Function
                
                ' Selects or unselects this CurveLegend. This is used by accessibility programs.
                Public Overrides Sub [Select](selection As AccessibleSelection)

                    ' Use the internal SelectChild helper function that exists
                    ' on ChartControlAccessibleObject.
                    ChartControl.SelectChild(Me, selection)
                End Sub

            End Class 'CurveLegendAccessibleObject