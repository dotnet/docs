Imports System.Drawing
Imports System.Windows.Forms

Namespace SDKSample

	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub AddChildToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddCircleChildToolStripMenuItem.Click
			MyWindow.CreateShape(Me.Handle)
		End Sub

		Private Sub FillWithCirclesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FillWithCirclesToolStripMenuItem.Click
			MyWindow.FillWithCircles(Me.Handle)
		End Sub

		Private Sub SmallToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SmallToolStripMenuItem.Click
			MyShape.radius = 30.0R
			SmallToolStripMenuItem.Checked = True
			MediumToolStripMenuItem.Checked = False
			LargeToolStripMenuItem.Checked = False
			RandomToolStripMenuItem.Checked = False
		End Sub

		Private Sub MediumToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MediumToolStripMenuItem.Click
			MyShape.radius = 50.0R
			SmallToolStripMenuItem.Checked = False
			MediumToolStripMenuItem.Checked = True
			LargeToolStripMenuItem.Checked = False
			RandomToolStripMenuItem.Checked = False
		End Sub

		Private Sub LargeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LargeToolStripMenuItem.Click
			MyShape.radius = 100.0R
			SmallToolStripMenuItem.Checked = False
			MediumToolStripMenuItem.Checked = False
			LargeToolStripMenuItem.Checked = True
			RandomToolStripMenuItem.Checked = False
		End Sub

		Private Sub RandomToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomToolStripMenuItem.Click
			MyShape.radius = 0.0R
			SmallToolStripMenuItem.Checked = False
			MediumToolStripMenuItem.Checked = False
			LargeToolStripMenuItem.Checked = False
			RandomToolStripMenuItem.Checked = True
		End Sub

		Private Sub ThreeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ThreeToolStripMenuItem.Click
			MyShape.numberCircles = 3
			ThreeToolStripMenuItem.Checked = True
			FiveToolStripMenuItem.Checked = False
			EightToolStripMenuItem.Checked = False
		End Sub

		Private Sub FiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FiveToolStripMenuItem.Click
			MyShape.numberCircles = 5
			ThreeToolStripMenuItem.Checked = False
			FiveToolStripMenuItem.Checked = True
			EightToolStripMenuItem.Checked = False
		End Sub

		Private Sub EightToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EightToolStripMenuItem.Click
			MyShape.numberCircles = 8
			ThreeToolStripMenuItem.Checked = False
			FiveToolStripMenuItem.Checked = False
			EightToolStripMenuItem.Checked = True
		End Sub

		Private Sub TopmostLayerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TopmostLayerToolStripMenuItem.Click
			MyWindow.topmostLayer = True
			TopmostLayerToolStripMenuItem.Checked = True
			AllLayersToolStripMenuItem.Checked = False
		End Sub

		Private Sub AllLayersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AllLayersToolStripMenuItem.Click
			MyWindow.topmostLayer = False
			AllLayersToolStripMenuItem.Checked = True
			TopmostLayerToolStripMenuItem.Checked = False
		End Sub
	End Class
End Namespace