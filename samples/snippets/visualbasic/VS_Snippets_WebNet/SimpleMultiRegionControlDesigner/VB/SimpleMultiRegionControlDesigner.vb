'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace Samples.ASPNet.ControlDesigners_VB

    < _
        Designer(GetType(MyMultiRegionControlDesigner)), _
        ToolboxData("<{0}:MyMultiRegionControl runat=""server"" width=""200""></{0}:MyMultiRegionControl>") _
    > _
    Public Class MyMultiRegionControl
        Inherits CompositeControl

        ' Define the templates that represent 2 views on the control
        Private _view1 As ITemplate
        Private _view2 As ITemplate
        ' The current view on the control; 0 = view1, 1 = view2
        Private _currentView As Integer = 0

        ' Create persistable inner properties
        <PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(CType(Nothing, ITemplate))> _
        Public Overridable Property View1() As ITemplate
            Get
                Return _view1
            End Get
            Set(ByVal value As ITemplate)
                _view1 = value
            End Set
        End Property

        <PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(CType(Nothing, ITemplate))> _
        Public Overridable Property View2() As ITemplate
            Get
                Return _view2
            End Get
            Set(ByVal value As ITemplate)
                _view2 = value
            End Set
        End Property

        Public Property CurrentView() As Integer
            Get
                Return _currentView
            End Get
            Set(ByVal value As Integer)
                _currentView = value
            End Set
        End Property

        ' Create a simple table with a row of two clickable, 
        ' readonly headers and a row with a single column, which 
        ' is the 'container' to which we'll be adding controls.
        Protected Overrides Sub CreateChildControls()
            ' Start with a clean form
            Controls.Clear()

            ' Create a table
            Dim t As New Table()
            t.CellSpacing = 1
            t.BorderStyle = BorderStyle
            t.Width = Me.Width
            t.Height = Me.Height

            ' Create the header row
            Dim tr As New TableRow()
            tr.HorizontalAlign = HorizontalAlign.Center
            tr.BackColor = Color.LightBlue

            ' Create the first cell in the header row
            Dim tc As New TableCell()
            tc.Text = "View 1"
            tc.Width = New Unit("50%")
            tr.Cells.Add(tc)

            ' Create the second cell in the header row
            tc = New TableCell()
            tc.Text = "View 2"
            tc.Width = New Unit("50%")
            tr.Cells.Add(tc)

            t.Rows.Add(tr)

            ' Create the second row for content
            tr = New TableRow()
            tr.HorizontalAlign = HorizontalAlign.Center

            ' This cell represents our content 'container'
            tc = New TableCell()
            tc.ColumnSpan = 2

            ' Add the current view content to the cell 
            ' at run-time
            If Not DesignMode Then
                Dim containerControl As New Control()
                Select Case CurrentView
                    Case 0
                        If Not (View1 Is Nothing) Then
                            View1.InstantiateIn(containerControl)
                        End If
                    Case 1
                        If Not (View2 Is Nothing) Then
                            View2.InstantiateIn(containerControl)
                        End If
                End Select

                tc.Controls.Add(containerControl)
            End If

            tr.Cells.Add(tc)

            t.Rows.Add(tr)

            ' Add the finished table to the Controls collection
            Controls.Add(t)
        End Sub

    End Class

    ' Region-based control designer for the above web control. 
    ' This is derived from CompositeControlDesigner.
    Public Class MyMultiRegionControlDesigner
        Inherits CompositeControlDesigner

        Private myControl As MyMultiRegionControl

        Public Overrides Sub Initialize(ByVal component As IComponent)
            MyBase.Initialize(component)
            myControl = CType(component, MyMultiRegionControl)
        End Sub

        '<Snippet2>
        ' Make this control resizeable on the design surface
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                Return True
            End Get
        End Property
        '</Snippet2>

        '<Snippet3>
        ' Use the base to create child controls, then add region markers
        Protected Overrides Sub CreateChildControls()
            MyBase.CreateChildControls()

            ' Get a reference to the table, which is the first child control
            Dim t As Table
            t = CType(myControl.Controls(0), Table)

            ' Add design time markers for each of the three regions
            If Not IsNothing(t) Then
                ' View1
                t.Rows(0).Cells(0).Attributes(DesignerRegion.DesignerRegionAttributeName) = "0"
                ' View2
                t.Rows(0).Cells(1).Attributes(DesignerRegion.DesignerRegionAttributeName) = "1"
                ' Editable region
                t.Rows(1).Cells(0).Attributes(DesignerRegion.DesignerRegionAttributeName) = "2"
            End If
        End Sub
        '</Snippet3>

        '<Snippet4>
        ' Handler for the Click event, which provides the region in the arguments.
        Protected Overrides Sub OnClick(ByVal e As DesignerRegionMouseEventArgs)
            If IsNothing(e.Region) Then
                Return
            End If

            ' If the clicked region is not a header, return
            If e.Region.Name.IndexOf("Header") <> 0 Then
                Return
            End If

            ' Switch the current view if required
            If e.Region.Name.Substring(6, 1) <> myControl.CurrentView.ToString() Then
                myControl.CurrentView = Integer.Parse(e.Region.Name.Substring(6, 1))
                MyBase.UpdateDesignTimeHtml()
            End If
        End Sub
        '</Snippet4>

        '<Snippet5>
        ' Create the regions and design-time markup. Called by the designer host.
        Public Overrides Function GetDesignTimeHtml(ByVal regions As DesignerRegionCollection) As String
            ' Create 3 regions: 2 clickable headers and an editable row
            regions.Add(New DesignerRegion(Me, "Header0"))
            regions.Add(New DesignerRegion(Me, "Header1"))

            ' Create an editable region and add it to the regions
            Dim editableRegion As EditableDesignerRegion = _
                New EditableDesignerRegion(Me, _
                    "Content" & myControl.CurrentView, False)
            regions.Add(editableRegion)

            ' Set the highlight for the selected region
            regions(myControl.CurrentView).Highlight = True

            ' Use the base class to render the markup
            Return MyBase.GetDesignTimeHtml()
        End Function
        '</Snippet5>

        '<Snippet6>
        ' Get the content string for the selected region. Called by the designer host?
        Public Overrides Function GetEditableDesignerRegionContent(ByVal region As EditableDesignerRegion) As String
            ' Get a reference to the designer host
            Dim host As IDesignerHost = CType(Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)

            If Not IsNothing(host) Then
                Dim template As ITemplate = myControl.View1
                If region.Name = "Content1" Then
                    template = myControl.View2
                End If

                ' Persist the template in the design host
                If Not IsNothing(template) Then
                    Return ControlPersister.PersistTemplate(template, host)
                End If
            End If

            Return String.Empty
        End Function
        '</Snippet6>

        '<Snippet7>
        ' Create a template from the content string and put it 
        ' in the selected view. Called by the designer host?
        Public Overrides Sub SetEditableDesignerRegionContent(ByVal region As EditableDesignerRegion, ByVal content As String)
            If IsNothing(content) Then
                Return
            End If

            ' Get a reference to the designer host
            Dim host As IDesignerHost = CType(Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
            If Not IsNothing(host) Then
                ' Create a template from the content string
                Dim template As ITemplate = ControlParser.ParseTemplate(host, content)

                ' Determine which region should get the template
                If region.Name.EndsWith("0") Then
                    myControl.View1 = template
                ElseIf region.Name.EndsWith("1") Then
                    myControl.View2 = template
                End If

            End If
        End Sub
        '</Snippet7>
    End Class

End Namespace
'</Snippet1>