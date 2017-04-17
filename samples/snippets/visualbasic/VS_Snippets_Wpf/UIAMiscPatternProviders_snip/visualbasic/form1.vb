Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace ElementProvider
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim grid As New CustomGrid(Me, New Rectangle(5, 5, 50, 200))
			Me.Controls.Add(grid)

		End Sub
	End Class
End Namespace

