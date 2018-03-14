'<Snippet1>
Option Explicit

Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace ChartControlNameSpace
    
    Public Class Form1 
        Inherits System.Windows.Forms.Form

        ' Test out the Chart Control.
        Private chart1 As ChartControl

        <System.STAThread()> _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Form1())
        End Sub 'Main

        Public Sub New() 
            ' Create a chart control and add it to the form.
            Me.chart1 = New ChartControl()
            Me.ClientSize = New System.Drawing.Size(920, 566)

            Me.chart1.Location = New System.Drawing.Point(47, 16)
            Me.chart1.Size = New System.Drawing.Size(600, 400)

            Me.Controls.Add(Me.chart1)
        End Sub
    End Class

    ' Declares a chart control that demonstrates Accessibility in Windows Forms.
    Public Class ChartControl
        Inherits System.Windows.Forms.UserControl

        Private legend1 As CurveLegend
        Private legend2 As CurveLegend
        
        Public Sub New()
            ' The ChartControl draws the chart in the OnPaint override.
            SetStyle(ControlStyles.ResizeRedraw, True)
            SetStyle(ControlStyles.DoubleBuffer, True)
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            
            Me.BackColor = System.Drawing.Color.White
            Me.Name = "ChartControl"

            ' The CurveLengend is not Control-based, it just
            ' represent the parts of the legend.
            legend1 = New CurveLegend(Me, "A")
            legend1.Location = New Point(20, 30)
            legend2 = New CurveLegend(Me, "B")
            legend2.Location = New Point(20, 50)
        End Sub 'New
              
        '<Snippet2>
        ' Overridden to return the custom AccessibleObject 
        ' for the entire chart.
        Protected Overrides Function CreateAccessibilityInstance() As AccessibleObject
            Return New ChartControlAccessibleObject(Me)
        End Function 
        '</Snippet2>

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            ' The ChartControl draws the chart in the OnPaint override.
            MyBase.OnPaint(e)
            
            Dim bounds As Rectangle = Me.ClientRectangle
            Dim border As Integer = 5
            
            ' Draw the legends first.
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            
            If (legend1 IsNot Nothing) Then
                If legend1.Selected Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.Blue), legend1.Bounds)
                Else
                    e.Graphics.DrawRectangle(Pens.Blue, legend1.Bounds)
                End If
                e.Graphics.DrawString(legend1.Name, Me.Font, Brushes.Black, RectangleF.op_Implicit(legend1.Bounds), format)
            End If
            If (legend2 IsNot Nothing) Then
                If legend2.Selected Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.Red), legend2.Bounds)
                Else
                    e.Graphics.DrawRectangle(Pens.Red, legend2.Bounds)
                End If
                e.Graphics.DrawString(legend2.Name, Me.Font, Brushes.Black, RectangleF.op_Implicit(legend2.Bounds), format)
            End If
            
            ' Chart out the actual curves that represent data in the Chart.
            bounds.Inflate(-border, -border)
            Dim curve1() As Point = {New Point(bounds.Left, bounds.Bottom), _
                                     New Point(bounds.Left + bounds.Width / 3, bounds.Top + bounds.Height / 5), _
                                     New Point(bounds.Right - bounds.Width / 3,(bounds.Top + bounds.Bottom) / 2), _
                                     New Point(bounds.Right, bounds.Top)}

            Dim curve2() As Point = {New Point(bounds.Left, bounds.Bottom - bounds.Height / 3), _
                                     New Point(bounds.Left + bounds.Width / 3, bounds.Top + bounds.Height / 5), _
                                     New Point(bounds.Right - bounds.Width / 3,(bounds.Top + bounds.Bottom) / 2), _
                                     New Point(bounds.Right, bounds.Top + bounds.Height / 2)}
            
            ' Draw the actual curve only if it is selected.
            If legend1.Selected Then
                e.Graphics.DrawCurve(Pens.Blue, curve1)
            End If
            If legend2.Selected Then
                e.Graphics.DrawCurve(Pens.Red, curve2)
            End If 
            e.Graphics.DrawRectangle(Pens.Blue, bounds)
        End Sub 'OnPaint
        
        '<Snippet3>
        ' Handle the QueryAccessibilityHelp event.
        Private Sub ChartControl_QueryAccessibilityHelp(sender As Object, _
                           e As System.Windows.Forms.QueryAccessibilityHelpEventArgs) Handles MyBase.QueryAccessibilityHelp
            e.HelpString = "Displays chart data"
        End Sub 
        '</Snippet3>

        ' Handle the Click event for the chart. 
        ' Toggle the selection of whatever legend was clicked.     
        Private Sub ChartControl_Click(sender As Object, e As System.EventArgs) Handles MyBase.Click

            Dim pt As Point = Me.PointToClient(Control.MousePosition)
            If legend1.Bounds.Contains(pt) Then
                legend1.Selected = Not legend1.Selected
            Else
                If legend2.Bounds.Contains(pt) Then
                    legend2.Selected = Not legend2.Selected
                End If
            End If
        End Sub 'ChartControl_Click

        ' Get an array of the CurveLengends used in the Chart.
        Public ReadOnly Property Legends() As CurveLegend()
            Get
                Return New CurveLegend() {legend1, legend2}
            End Get
        End Property
        
        Protected Sub ExposeAccessibilityNotifyClients(ByVal accEvent As AccessibleEvents, ByVal childID As Integer)
            AccessibilityNotifyClients(accEvent, childID) 
        End Sub

        '<Snippet4>
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
        '</Snippet4>

        ' Inner Class that represents a legend for a curve in the chart.
        Public Class CurveLegend
            Private m_name As String
            Private chart As ChartControl
            Private accObj As CurveLegendAccessibleObject
            Private m_selected As Boolean = True
            Private m_location As Point
            
            Public Sub New(chart As ChartControl, name As String)
                Me.chart = chart
                Me.m_name = name
            End Sub 'New

            ' Gets the accessibility object for the curve legend.            
            Public ReadOnly Property AccessibilityObject() As AccessibleObject
                Get
                    If accObj Is Nothing Then
                        accObj = New CurveLegendAccessibleObject(Me)
                    End If
                    Return accObj
                End Get
            End Property
            
            ' Gets the bounds for the curve legend.            
            Public ReadOnly Property Bounds() As Rectangle
                Get
                    Return New Rectangle(Location, Size)
                End Get
            End Property

            '<Snippet5>            
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
            '</Snippet5>
            
            ' Gets the Size for the curve legend.            
            Public ReadOnly Property Size() As Size
                Get
                    Dim legendHeight As Integer = chart.Font.Height + 4
                    Dim g As Graphics = chart.CreateGraphics()
                    Dim legendWidth As Integer = CInt(g.MeasureString(Name, chart.Font).Width) + 4
                    
                    Return New Size(legendWidth, legendHeight)
                End Get
            End Property
            
            
            '<Snippet6>
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
            '</Snippet6>

        End Class 'CurveLegend

    End Class 'ChartControl

End Namespace 'ChartControlNameSpace
'</Snippet1>