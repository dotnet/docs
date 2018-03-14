Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Globalization

Namespace BindingGroupSnippets
	'<SnippetData>

	'<SnippetValidateObject>
	Public Class ValidateDateAndPrice
		Inherits ValidationRule
		' Ensure that an item over $100 is available for at least 7 days.
		Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
			Dim bg As BindingGroup = TryCast(value, BindingGroup)

			' Get the source object.
			Dim item As PurchaseItem = TryCast(bg.Items(0), PurchaseItem)

            Dim doubleValue As Object = Nothing
            Dim dateTimeValue As Object = Nothing

			' Get the proposed values for Price and OfferExpires.
			Dim priceResult As Boolean = bg.TryGetValue(item, "Price", doubleValue)
			Dim dateResult As Boolean = bg.TryGetValue(item, "OfferExpires", dateTimeValue)

			If (Not priceResult) OrElse (Not dateResult) Then
				Return New ValidationResult(False, "Properties not found")
			End If

			Dim price As Double = CDbl(doubleValue)
			Dim offerExpires As Date = CDate(dateTimeValue)

			' Check that an item over $100 is available for at least 7 days.
			If price > 100 Then
				If offerExpires < Date.Today + New TimeSpan(7, 0, 0, 0) Then
					Return New ValidationResult(False, "Items over $100 must be available for at least 7 days.")
				End If
			End If

			Return ValidationResult.ValidResult

		End Function
	End Class
	'</SnippetValidateObject>

	'Ensure that the price is positive.
	Public Class PriceIsAPositiveNumber
		Inherits ValidationRule
		Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
			Try
				Dim price As Double = Convert.ToDouble(value)

				If price < 0 Then
					Return New ValidationResult(False, "Price must be positive.")
				Else
					Return ValidationResult.ValidResult
				End If
			Catch e1 As Exception
				' Exception thrown by Conversion - value is not a number.
				Return New ValidationResult(False, "Price must be a number.")
			End Try

		End Function
	End Class

	' Ensure that the date is in the future.
	Friend Class FutureDateRule
		Inherits ValidationRule
		Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult

			Dim [date] As Date
			Try
				[date] = Date.Parse(value.ToString())
			Catch e1 As FormatException
				Return New ValidationResult(False, "Value is not a valid date.")
			End Try
			If Date.Now.Date > [date] Then
				Return New ValidationResult(False, "Please enter a date in the future.")
			Else
				Return ValidationResult.ValidResult
			End If
		End Function
	End Class

	' PurchaseItem implements INotifyPropertyChanged and IEditableObject
	' to support edit transactions, which enable users to cancel pending changes.
	Public Class PurchaseItem
		Implements INotifyPropertyChanged, IEditableObject
		Private Structure ItemData
			Friend Description As String
			Friend Price As Double
			Friend OfferExpires As Date

			Friend Shared Function NewItem() As ItemData
				Dim data As New ItemData()
				data.Description = "New item"
				data.Price = 0
				data.OfferExpires = Date.Now + New TimeSpan(7, 0, 0, 0)

				Return data
			End Function
		End Structure
		Private copyData As ItemData = ItemData.NewItem()
		Private currentData As ItemData = ItemData.NewItem()

		Public Sub New()

		End Sub

		Public Sub New(ByVal desc As String, ByVal price As Double, ByVal endDate As Date)
			Description = desc
			Me.Price = price
			OfferExpires = endDate
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("{0}, {1:c}, {2:D}", Description, Price, OfferExpires)
		End Function

		Public Property Description() As String
			Get
				Return currentData.Description
			End Get
			Set(ByVal value As String)
				If currentData.Description <> value Then
					currentData.Description = value
					NotifyPropertyChanged("Description")
				End If
			End Set
		End Property

		Public Property Price() As Double
			Get
				Return currentData.Price
			End Get
			Set(ByVal value As Double)
				If currentData.Price <> value Then
					currentData.Price = value
					NotifyPropertyChanged("Price")
				End If
			End Set
		End Property

		Public Property OfferExpires() As Date
			Get
				Return currentData.OfferExpires
			End Get
			Set(ByVal value As Date)
                If value <> currentData.OfferExpires Then
                    currentData.OfferExpires = value
                    NotifyPropertyChanged("OfferExpires")
                End If
			End Set
		End Property

		#Region "INotifyPropertyChanged Members"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private Sub NotifyPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub

		#End Region

		#Region "IEditableObject Members"

		Public Sub BeginEdit() Implements IEditableObject.BeginEdit
			copyData = currentData
		End Sub

		Public Sub CancelEdit() Implements IEditableObject.CancelEdit
			currentData = copyData
			NotifyPropertyChanged("")

		End Sub

		Public Sub EndEdit() Implements IEditableObject.EndEdit
			copyData = ItemData.NewItem()

		End Sub

		#End Region

	End Class
	'</SnippetData>

End Namespace
