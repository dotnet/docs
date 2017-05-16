' This entire sample can go	in the TabRenderer overview. 
'  - Snippet2 can be excerpted in DrawTabPage, DrawTabItem,	and	IsSupported.
'  - Snippet2 could	also be	excerpted in the VisualStyles.TabItemState enum,
'	 if	necessary.

' The sample defines a simple custom Control that uses TabRenderer to
' simulate a basic (and	essentially	useless) TabControl. Might want
' to add a bit more	unique functionality, although the basic painting 
' functionality	of the class is	demonstrated.

' For simplicity, this sample doesn't handle runtime switching of visual styles.


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace TabRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Dim Tab1 As New CustomTabControl()
            Controls.Add(Tab1)
            Me.Size = New Size(500, 500)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' The call to EnableVisualStyles below does not affect whether 
            ' TabRenderer.IsSupported is true; as long as visual styles 
            ' are enabled by the operating system, IsSupported is true.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomTabControl
        Inherits Control

        Private tabPageRectangle As Rectangle
        Private tabItemRectangle1 As Rectangle
        Private tabItemRectangle2 As Rectangle
        Private tabHeight As Integer = 30
        Private tabWidth As Integer = 100
        Private tab1State As TabItemState = TabItemState.Selected
        Private tab2State As TabItemState = TabItemState.Normal
        Private tab1Text As String = "Tab 1"
        Private tab2Text As String = "Tab 2"
        Private tab1Focused As Boolean = True
        Private tab2Focused As Boolean = False

        Public Sub New()
            With Me
                .Size = New Size(300, 300)
                .Location = New Point(10, 10)
                .Font = SystemFonts.IconTitleFont
                .Text = "TabRenderer"
                .DoubleBuffered = True
            End With

            tabPageRectangle = New Rectangle(ClientRectangle.X, _
                ClientRectangle.Y + tabHeight, _
                ClientRectangle.Width, _
                ClientRectangle.Height - tabHeight)

            ' Extend the first tab rectangle down by 2 pixels, because
            ' it is selected by default.
            tabItemRectangle1 = New Rectangle(ClientRectangle.X, _
                ClientRectangle.Y, tabWidth, tabHeight + 2)

            tabItemRectangle2 = New Rectangle(ClientRectangle.Location.X + _
                tabWidth, ClientRectangle.Location.Y, tabWidth, tabHeight)
        End Sub

        '<Snippet2>
        ' Draw the tab page and the tab items.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not TabRenderer.IsSupported Then
                Me.Parent.Text = "CustomTabControl Disabled"
                Return
            End If

            TabRenderer.DrawTabPage(e.Graphics, tabPageRectangle)
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle1, _
                tab1Text, Me.Font, tab1Focused, tab1State)
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle2, _
                tab2Text, Me.Font, tab2Focused, tab2State)
            Me.Parent.Text = "CustomTabControl Enabled"
        End Sub

        '</Snippet2>
        ' Draw the selected tab item.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If Not TabRenderer.IsSupported Then
                Return
            End If

            ' The first tab is clicked. Note that the height of the 
            ' selected tab rectangle is raised by 2, so that it draws 
            ' over the border of the tab page.
            If tabItemRectangle1.Contains(e.Location) Then
                tab1State = TabItemState.Selected
                tab2State = TabItemState.Normal
                tabItemRectangle1.Height += 2
                tabItemRectangle2.Height -= 2
                tab1Focused = True
                tab2Focused = False
            End If

            ' The second tab is clicked.
            If tabItemRectangle2.Contains(e.Location) Then
                tab2State = TabItemState.Selected
                tab1State = TabItemState.Normal
                tabItemRectangle2.Height += 2
                tabItemRectangle1.Height -= 2
                tab2Focused = True
                tab1Focused = False
            End If

            Invalidate()
        End Sub

    End Class
End Namespace
'</Snippet0>