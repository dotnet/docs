        ' Overridden to return the custom AccessibleObject 
        ' for the entire chart.
        Protected Overrides Function CreateAccessibilityInstance() As AccessibleObject
            Return New ChartControlAccessibleObject(Me)
        End Function 