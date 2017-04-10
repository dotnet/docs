Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Xps.Packaging

Namespace SDKSample
	''' <summary>
	''' A Dialog that diplays and allows editing of the properties
	''' of an Xps Document
	''' </summary>
	Partial Public Class PropertiesDialog
		Inherits Form
		Public Sub New(ByVal xpsDocument As XpsDocument)
			_xpsDocument = xpsDocument
			_propertyUtility = New PropertiesUtility()
			InitializeComponent()
			_propertyUtility.ReadProperties(_xpsDocument, Me)
		End Sub
		Private _xpsDocument As XpsDocument

		Private Sub Ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok.Click
			_propertyUtility.WriteProperties(_xpsDocument, Me)
		End Sub

		Private _propertyUtility As PropertiesUtility
	End Class
End Namespace