Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Xml

Namespace SDKSample
	Public Class CoolView
		Inherits ViewBase
		Protected Overrides ReadOnly Property DefaultStyleKey() As Object
		  Get
			Return New ComponentResourceKey(Me.GetType(), "MyViewDSK")
		  End Get
		End Property

		Protected Overrides ReadOnly Property ItemContainerDefaultStyleKey() As Object
		  Get
			Return New ComponentResourceKey(Me.GetType(), "MyViewItemDSK")
		  End Get
		End Property
	End Class
End Namespace