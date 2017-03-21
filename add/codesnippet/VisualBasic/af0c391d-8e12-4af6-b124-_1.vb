            ' Gets or sets the location for the curve legend.            
            Public Property Location() As Point
                Get
                    Return m_location
                End Get
                Set
                    m_location = value
                    chart.Invalidate()

                    ' Notifies the chart of the location change. This is used for
                    ' the accessibility information. AccessibleEvents.LocationChange
                    ' tells the chart the reason for the notification.
                    chart.ExposeAccessibilityNotifyClients(AccessibleEvents.LocationChange, _
                            CType(AccessibilityObject, CurveLegendAccessibleObject).ID)
                End Set
            End Property
            
            ' Gets or sets the Name for the curve legend.            
            Public Property Name() As String
                Get
                    Return m_name
                End Get
                Set
                    If m_name <> value Then
                        m_name = value
                        chart.Invalidate()

                        ' Notifies the chart of the name change. This is used for
                        ' the accessibility information. AccessibleEvents.NameChange
                        ' tells the chart the reason for the notification. 
                        chart.ExposeAccessibilityNotifyClients(AccessibleEvents.NameChange, _
                                CType(AccessibilityObject, CurveLegendAccessibleObject).ID)
                    End If
                End Set
            End Property
            
            ' Gets or sets the Selected state for the curve legend.            
            Public Property Selected() As Boolean
                Get
                    Return m_selected
                End Get
                Set
                    If m_selected <> value Then
                        m_selected = value
                        chart.Invalidate()

                        ' Notifies the chart of the selection value change. This is used for
                        ' the accessibility information. The AccessibleEvents value varies
                        ' on whether the selection is true (AccessibleEvents.SelectionAdd) or 
                        ' false (AccessibleEvents.SelectionRemove). 
                        If m_selected Then
                            chart.ExposeAccessibilityNotifyClients(AccessibleEvents.SelectionAdd, _
                                    CType(AccessibilityObject, CurveLegendAccessibleObject).ID) 
                        Else
                            chart.ExposeAccessibilityNotifyClients(AccessibleEvents.SelectionRemove, _
                                    CType(AccessibilityObject, CurveLegendAccessibleObject).ID) 
                        End If
                    End If
                End Set
            End Property