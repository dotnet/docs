            // Inner class CurveLegendAccessibleObject represents accessible information 
            // associated with the CurveLegend object.
            public class CurveLegendAccessibleObject : AccessibleObject
            {
                private CurveLegend curveLegend;

                public CurveLegendAccessibleObject(CurveLegend curveLegend) : base() 
                {
                    this.curveLegend = curveLegend;                    
                }                

                // Private property that helps get the reference to the parent ChartControl.
                private ChartControlAccessibleObject ChartControl
                {   
                    get {
                        return Parent as ChartControlAccessibleObject;
                    }
                }

                // Internal helper function that returns the ID for this CurveLegend.
                internal int ID
                {
                    get {
                        for(int i = 0; i < ChartControl.GetChildCount(); i++) {
                            if (ChartControl.GetChild(i) == this) {
                                return i;
                            }
                        }
                        return -1;
                    }
                }

                // Gets the Bounds for the CurveLegend. This is used by accessibility programs.
                public override Rectangle Bounds
                {
                    get {                        
                        // The bounds is in screen coordinates.
                        Point loc = curveLegend.Location;
                        return new Rectangle(curveLegend.chart.PointToScreen(loc), curveLegend.Size);
                    }
                }

                // Gets or sets the Name for the CurveLegend. This is used by accessibility programs.
                public override string Name
                {
                    get {
                        return curveLegend.Name;
                    }
                    set {
                        curveLegend.Name = value;                        
                    }
                }

                // Gets the Curve Legend Parent's Accessible object.
                // This is used by accessibility programs.
                public override AccessibleObject Parent
                {
                    get {
                        return curveLegend.chart.AccessibilityObject;
                    }
                }

                // Gets the role for the CurveLegend. This is used by accessibility programs.
                public override AccessibleRole Role 
                {
                    get {
                        return AccessibleRole.StaticText;
                    }
                }

                // Gets the state based on the selection for the CurveLegend. 
                // This is used by accessibility programs.
                public override AccessibleStates State 
                {
                    get {
                        AccessibleStates state = AccessibleStates.Selectable;
                        if (curveLegend.Selected) 
                        {
                            state |= AccessibleStates.Selected;
                        }
                        return state;
                    }
                }

                // Navigates through siblings of this CurveLegend. This is used by accessibility programs.
                public override AccessibleObject Navigate(AccessibleNavigation navdir) 
                {
                    // Uses the internal NavigateFromChild helper function that exists
                    // on ChartControlAccessibleObject.
                    return ChartControl.NavigateFromChild(this, navdir);
                }

                // Selects or unselects this CurveLegend. This is used by accessibility programs.
                public override void Select(AccessibleSelection selection) 
                {
                    // Uses the internal SelectChild helper function that exists
                    // on ChartControlAccessibleObject.
                    ChartControl.SelectChild(this, selection);
                }
            }