'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.Design.Behavior

Namespace BehaviorServiceSample

    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private userControl As UserControl1
        Private components As System.ComponentModel.IContainer = Nothing

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        Private Sub InitializeComponent()
            Me.userControl = New UserControl1()
            Me.SuspendLayout()

            Me.userControl.Location = New System.Drawing.Point(12, 13)
            Me.userControl.Name = "userControl"
            Me.userControl.Size = New System.Drawing.Size(143, 110)
            Me.userControl.TabIndex = 0

            Me.ClientSize = New System.Drawing.Size(184, 153)
            Me.Controls.Add(userControl)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

    End Class

    <Designer(GetType(MyDesigner))> _
    Public Class UserControl1
        Inherits UserControl
        Private components As System.ComponentModel.IContainer = Nothing


        Public Sub New()
            InitializeComponent()
        End Sub


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        Private Sub InitializeComponent()
            Me.Name = "UserControl1"
            Me.Size = New System.Drawing.Size(170, 156)
        End Sub 'InitializeComponent
    End Class

    '<snippet2>
    Class MyDesigner
        Inherits ControlDesigner
        Private myAdorner As Adorner


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (myAdorner IsNot Nothing) Then
                Dim b As System.Windows.Forms.Design.Behavior.BehaviorService _
                    = BehaviorService
                If (b IsNot Nothing) Then
                    b.Adorners.Remove(myAdorner)
                End If
            End If

        End Sub


        Public Overrides Sub Initialize(ByVal component As IComponent)
            MyBase.Initialize(component)

            ' Add the custom set of glyphs using the BehaviorService.  
            ' Glyphs live on adornders.
            '<snippet4>
            '<snippet3>
            myAdorner = New Adorner()
            BehaviorService.Adorners.Add(myAdorner)
            '</snippet3>
            myAdorner.Glyphs.Add(New MyGlyph(BehaviorService, Control))
            '</snippet4>

        End Sub
    End Class
    '</snippet2>

    '<snippet5>
    Class MyGlyph
        Inherits Glyph
        Private control As Control
        Private behaviorSvc As _
            System.Windows.Forms.Design.Behavior.BehaviorService

        '<snippet7>
        Public Sub New(ByVal behaviorSvc As _
            System.Windows.Forms.Design.Behavior.BehaviorService, _
            ByVal control As Control)

            MyBase.New(New MyBehavior())
            Me.behaviorSvc = behaviorSvc
            Me.control = control
        End Sub
        '</snippet7>

        '<snippet8>
        Public Overrides ReadOnly Property Bounds() As Rectangle
            Get
                ' Create a glyph that is 10x10 and sitting
                ' in the middle of the control.  Glyph coordinates
                ' are in adorner window coordinates, so we must map
                ' using the behavior service.
                Dim edge As Point = behaviorSvc.ControlToAdornerWindow(control)
                Dim size As Size = control.Size
                Dim center As New Point(edge.X + size.Width / 2, edge.Y + _
                    size.Height / 2)

                Dim bounds1 As New Rectangle(center.X - 5, center.Y - 5, 10, 10)

                Return bounds1
            End Get
        End Property
        '</snippet8>

        '<snippet9>
        Public Overrides Function GetHitTest(ByVal p As Point) As Cursor
            ' GetHitTest is called to see if the point is
            ' within this glyph.  This gives us a chance to decide
            ' what cursor to show.  Returning null from here means
            ' the mouse pointer is not currently inside of the glyph.
            ' Returning a valid cursor here indicates the pointer is
            ' inside the glyph,and also enables our Behavior property
            ' as the active behavior.
            If Bounds.Contains(p) Then
                Return Cursors.Hand
            End If

            Return Nothing

        End Function
        '</snippet9>


        '<snippet10>
        Public Overrides Sub Paint(ByVal pe As PaintEventArgs)
            ' Draw our glyph.  It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds)

        End Sub
        '</snippet10>

        ' By providing our own behavior we can do something interesting
        ' when the user clicks or manipulates our glyph.

        '<snippet6>
        Class MyBehavior
            Inherits System.Windows.Forms.Design.Behavior.Behavior

            Public Overrides Function OnMouseUp(ByVal g As Glyph, _
                ByVal button As MouseButtons) As Boolean
                MessageBox.Show("Hey, you clicked the mouse here")
                Return True
                ' indicating we processed this event.
            End Function 'OnMouseUp
        End Class
        '</snippet6>

    End Class
    '</snippet5>

End Namespace
'</snippet1>
