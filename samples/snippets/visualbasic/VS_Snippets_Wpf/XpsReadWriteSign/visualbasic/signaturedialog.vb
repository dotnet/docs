Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace XpsApiSdk
	Partial Public Class SignatureDialog
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim columnHeaderFont As Font = New System.Drawing.Font(Font, System.Drawing.FontStyle.Bold)
			Dim columnMargin As New Padding(0, 3, 0, 0)
			Dim columnPadding As New Padding(10, 0, 0, 0)
			Dim nameHeader As New Label()
			nameHeader.Text = "Name"
			nameHeader.Font = columnHeaderFont
			nameHeader.MinimumSize = New Size(16 + 100, 0)
			nameHeader.Margin = columnMargin
			nameHeader.Padding = columnPadding

			Dim intentHeader As New Label()
			intentHeader.Text ="Intent"
			intentHeader.Font = columnHeaderFont
			intentHeader.MinimumSize = New Size(100, 0)
			intentHeader.Margin = columnMargin
			intentHeader.Padding = columnPadding

			Dim locationHeader As New Label()
			locationHeader.Text = "Locale"
			locationHeader.Font = columnHeaderFont
			locationHeader.MinimumSize = New Size(100, 0)
			locationHeader.Margin = columnMargin
			locationHeader.Padding = columnPadding

			Dim signByHeader As New Label()
			signByHeader.Text = "Sign By"
			signByHeader.Font = columnHeaderFont
			signByHeader.MinimumSize = New Size(100, 0)
			signByHeader.Margin = columnMargin
			signByHeader.Padding = columnPadding

			ColumnHeader.Controls.Add(nameHeader)
			ColumnHeader.Controls.Add(intentHeader)
			ColumnHeader.Controls.Add(locationHeader)
			ColumnHeader.Controls.Add(signByHeader)
		End Sub
	End Class
End Namespace