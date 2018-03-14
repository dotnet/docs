Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.Windows.Automation.Provider


Namespace ElementProvider
	Friend Class CustomGridItem
		Implements IRawElementProviderFragment, IGridItemProvider
		Private myText As String
		Private ItemColumn As Integer ' pretend these are properties for the sake of snippets
		Private ItemRow As Integer
		Private ItemContainingGrid As IRawElementProviderSimple

		''' <summary>
		''' Constructor.
		''' </summary>
		Public Sub New(ByVal s As String, ByVal row As Integer, ByVal col As Integer, ByVal ownerGrid As IRawElementProviderSimple)
			myText = s
			ItemColumn = col
			ItemRow = row
			ItemContainingGrid = ownerGrid
		End Sub


		#Region "IGridItemProvider Members"

 ' <Snippet104> 
		Private ReadOnly Property Column() As Integer Implements IGridItemProvider.Column
			Get
				Return ItemColumn
			End Get
		End Property
' </Snippet104>

' <Snippet105> 
		Private ReadOnly Property Row() As Integer Implements IGridItemProvider.Row
			Get
				Return ItemRow
			End Get
		End Property
' </Snippet105>


		''' <summary>
		''' Gets the number of columns spanned by the item.
		''' </summary>
' <Snippet106> 
		Private ReadOnly Property ColumnSpan() As Integer Implements IGridItemProvider.ColumnSpan
			Get
				Return 1
			End Get
		End Property
' </Snippet106>

		''' <summary>
		''' Gets the number of rows spanned by the item.
		''' </summary>
' <Snippet107> 
		Private ReadOnly Property RowSpan() As Integer Implements IGridItemProvider.RowSpan
			Get
				Return 1
			End Get
		End Property
' </Snippet107>

' <Snippet108> 
		Private ReadOnly Property ContainingGrid() As IRawElementProviderSimple Implements IGridItemProvider.ContainingGrid
			Get
				Return ItemContainingGrid
			End Get
		End Property
' </Snippet108>

		#End Region

		#Region "IRawElementProviderSimple Members"

		Private Function GetPatternProvider(ByVal patternId As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			If patternId = GridItemPatternIdentifiers.Pattern.Id Then

				Return CType(Me, IGridItemProvider)
			End If
			Return Nothing
		End Function


		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			Return Nothing
		End Function

		Private ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
			Get
				Return Nothing
			End Get
		End Property

		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region

		#Region "IRawElementProviderFragment Members"

		Private ReadOnly Property BoundingRectangle() As System.Windows.Rect Implements IRawElementProviderFragment.BoundingRectangle
			Get
				Throw New Exception("The method or operation is not implemented.")
			End Get
		End Property

		Private ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot Implements IRawElementProviderFragment.FragmentRoot
			Get
				Return CType(ItemContainingGrid, IRawElementProviderFragmentRoot)
			End Get
		End Property

		Private Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
			Return Nothing
		End Function

		Private Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
			Return Nothing
		End Function

		Private Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment Implements IRawElementProviderFragment.Navigate
			If direction = NavigateDirection.Parent Then
				Return CType(ItemContainingGrid, IRawElementProviderFragment)
			Else
				Return Nothing
			End If
		End Function

		Private Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		#End Region
	End Class
End Namespace
