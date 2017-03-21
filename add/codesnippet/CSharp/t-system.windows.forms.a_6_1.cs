            // Gets or sets the location for the curve legend.
            public Point Location
            {   
                get {
                    return location;
                }
                set {
                    location = value;
                    chart.Invalidate();

                    // Notifies the chart of the location change. This is used for
                    // the accessibility information. AccessibleEvents.LocationChange
                    // tells the chart the reason for the notification.

                    chart.AccessibilityNotifyClients(AccessibleEvents.LocationChange, 
                        ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                }
            }            
        
            // Gets or sets the Name for the curve legend.
            public string Name
            {   
                get {
                    return name;
                }
                set {
                    if (name != value) 
                    {
                        name = value;
                        chart.Invalidate();

                        // Notifies the chart of the name change. This is used for
                        // the accessibility information. AccessibleEvents.NameChange
                        // tells the chart the reason for the notification.

                        chart.AccessibilityNotifyClients(AccessibleEvents.NameChange, 
                            ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                    }
                }
            }

            // Gets or sets the Selected state for the curve legend.
            public bool Selected
            {   
                get {
                    return selected;
                }
                set {
                    if (selected != value) 
                    {
                        selected = value;
                        chart.Invalidate();

                        // Notifies the chart of the selection value change. This is used for
                        // the accessibility information. The AccessibleEvents value depends upon
                        // if the selection is true (AccessibleEvents.SelectionAdd) or 
                        // false (AccessibleEvents.SelectionRemove).
                        chart.AccessibilityNotifyClients(
                            selected ? AccessibleEvents.SelectionAdd : AccessibleEvents.SelectionRemove, 
                            ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                    }
                }
            }