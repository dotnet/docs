Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel

Namespace BindingGroupSnippets
	''' <summary>
	''' Interaction logic for Window2.xaml
	''' </summary>
	Partial Public Class Window2
		Inherits Window
		Private customerData As Customers
		Private bindingGroupInError As BindingGroup = Nothing

		Public Sub New()
			InitializeComponent()

			customerData = New Customers()
			customerList.DataContext = customerData

		End Sub

		Private Sub AddCustomer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

			If bindingGroupInError Is Nothing Then
				customerData.Add(New Customer())
			Else
				MessageBox.Show("Please correct the data in error before adding a new customer.")
			End If
		End Sub

		'<SnippetUpdateSources>
		Private Sub saveCustomer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim btn As Button = TryCast(sender, Button)
			Dim container As FrameworkElement = CType(customerList.ContainerFromElement(btn), FrameworkElement)

			' If the user is trying to change an items, when another item has an error,
			' display a message and cancel the currently edited item.
			If bindingGroupInError IsNot Nothing AndAlso bindingGroupInError IsNot container.BindingGroup Then
				MessageBox.Show("Please correct the data in error before changing another customer")
				container.BindingGroup.CancelEdit()
				Return
			End If

			If container.BindingGroup.UpdateSources() Then
				bindingGroupInError = Nothing
				MessageBox.Show("Item Saved")
			Else
				bindingGroupInError = container.BindingGroup
			End If

		End Sub
		'</SnippetUpdateSources>
	End Class


	Public Class Customers
		Inherits ObservableCollection(Of Customer)
		Public Sub New()
			Add(New Customer())
		End Sub
	End Class

	Public Enum Region
		Africa
		Antartica
		Australia
		Asia
		Europe
		NorthAmerica
		SouthAmerica
	End Enum

	Public Class Customer
		Public Property Name() As String
		Public Property ServiceRepresentative() As ServiceRep
		Public Property Location() As Region
	End Class

	Public Class ServiceRep
		Public Property Name() As String
		Public Property Area() As Region

		Public Sub New()
		End Sub

		Public Sub New(ByVal name As String, ByVal area As Region)
			Me.Name = name
			Me.Area = area
		End Sub

		Public Overrides Function ToString() As String
			Return Name & " - " & Area.ToString()
		End Function
	End Class

	Public Class Representantives
		Inherits ObservableCollection(Of ServiceRep)
		Public Sub New()
			Add(New ServiceRep("Haluk Kocak", Region.Africa))
			Add(New ServiceRep("Reed Koch", Region.Antartica))
			Add(New ServiceRep("Christine Koch", Region.Asia))
			Add(New ServiceRep("Alisa Lawyer", Region.Australia))
			Add(New ServiceRep("Petr Lazecky", Region.Europe))
			Add(New ServiceRep("Karina Leal", Region.NorthAmerica))
			Add(New ServiceRep("Kelley LeBeau", Region.SouthAmerica))
			Add(New ServiceRep("Yoichiro Okada", Region.Africa))
			Add(New ServiceRep("Tülin Oktay", Region.Antartica))
			Add(New ServiceRep("Preeda Ola", Region.Asia))
			Add(New ServiceRep("Carole Poland", Region.Australia))
			Add(New ServiceRep("Idan Plonsky", Region.Europe))
			Add(New ServiceRep("Josh Pollock", Region.NorthAmerica))
			Add(New ServiceRep("Daphna Porath", Region.SouthAmerica))
		End Sub
	End Class

	'<SnippetItemBindGroupValidationRule>
	Public Class AreasMatch
		Inherits ValidationRule
		Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As System.Globalization.CultureInfo) As ValidationResult
			Dim bg As BindingGroup = TryCast(value, BindingGroup)
			Dim cust As Customer = TryCast(bg.Items(0), Customer)

			If cust Is Nothing Then
				Return New ValidationResult(False, "Customer is not the source object")
			End If

			Dim region As Region = CType(bg.GetValue(cust, "Location"), Region)
			Dim rep As ServiceRep = TryCast(bg.GetValue(cust, "ServiceRepresentative"), ServiceRep)
			Dim customerName As String = TryCast(bg.GetValue(cust, "Name"), String)

			If region = rep.Area Then
				Return ValidationResult.ValidResult
			Else

				Dim sb As New StringBuilder()
				sb.AppendFormat("{0} must be assigned a sales representative that serves the {1} region. " & vbLf & " ", customerName, region)
				Return New ValidationResult(False, sb.ToString())
			End If
		End Function
	End Class
	'</SnippetItemBindGroupValidationRule>
End Namespace
