Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Interop


Namespace CorePseudocode
	Public Class Cache
		Inherits Object
		Friend Sub StoreInfoAboutChild(ByVal z As Object)
		End Sub
	End Class
	Public Class MyAssemblyResources
	End Class

	Public Class MakesAKey
'<SnippetCRKCode>
		Public Shared ViewBoxStyleKey As New ComponentResourceKey(GetType(MyAssemblyResources), "part_ViewBox")
'</SnippetCRKCode>
	End Class


	Public Class myElement
		Inherits UIElement
		Private _visualChildren As List(Of UIElement)
		Private _cache As Cache
		Private childX, childY, childWidth, childHeight As Double

		Private Function CalculateBasedOnCache(ByVal z As Object) As Size
			Return New Size()
		End Function

		Public Property VisualChildren() As List(Of UIElement)
		   Get
			   Return _visualChildren
		   End Get
			Set(ByVal value As List(Of UIElement))
				_visualChildren=value
			End Set
		End Property
		Shared Sub New()
'<SnippetUIElementShortOverride>
FocusableProperty.OverrideMetadata(GetType(myElement), New UIPropertyMetadata(True))
'</SnippetUIElementShortOverride>
		End Sub
'<SnippetUIElementArrangeOverride>
Protected Overrides Sub ArrangeCore(ByVal finalRect As Rect)
	 'Call base, it will set offset and RenderBounds to the finalRect:
	 MyBase.ArrangeCore(finalRect)
	 For Each child As UIElement In VisualChildren
		 child.Arrange(New Rect(childX, childY, childWidth, childHeight))
	 Next child
End Sub
'</SnippetUIElementArrangeOverride>

'<SnippetUIElementMeasureOverride>
Protected Overrides Function MeasureCore(ByVal availableSize As Size) As Size
	For Each child As UIElement In VisualChildren
		child.Measure(availableSize)
		' call some method on child that adjusts child size if needed
		_cache.StoreInfoAboutChild(child)
	Next child
	Dim desired As Size = CalculateBasedOnCache(_cache)
	Return desired
End Function
'</SnippetUIElementMeasureOverride>
	End Class
	Friend Class myFEElement
		Inherits FrameworkElement
		Private _visualChildren As List(Of UIElement)
		Public Property VisualChildren() As List(Of UIElement)
			Get
				Return _visualChildren
			End Get
			Set(ByVal value As List(Of UIElement))
				_visualChildren = value
			End Set
		End Property
	'<SnippetFEMeasureOverride>
Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
	Dim desiredSize As New Size()
	For Each child As UIElement In VisualChildren
		child.Measure(availableSize)
		' do something with child.DesiredSize, either sum them directly or apply whatever logic your element has for reinterpreting the child sizes
		' if greater than availableSize, must decide what to do and which size to return
	Next child
	' desiredSize = ... computed sum of children's DesiredSize ...
	' IMPORTANT: do not allow PositiveInfinity to be returned, that will raise an exception in the caller!
	' PositiveInfinity might be an availableSize input - this means that the parent does not care about sizing
	Return desiredSize
End Function
'</SnippetFEMeasureOverride>
	End Class


	Friend Class ClockwiseSpinEventManager
		Inherits WeakEventManager
		Protected Overrides Sub StartListening(ByVal source As Object)
			Throw New Exception("The method or operation is not implemented.")
		End Sub
		Protected Overrides Sub StopListening(ByVal source As Object)
			Throw New Exception("The method or operation is not implemented.")
		End Sub
	End Class
	Friend Class CounterclockwiseSpinEventManager
		Inherits WeakEventManager
		Protected Overrides Sub StartListening(ByVal source As Object)
			Throw New Exception("The method or operation is not implemented.")
		End Sub
		Protected Overrides Sub StopListening(ByVal source As Object)
			Throw New Exception("The method or operation is not implemented.")
		End Sub
	End Class
	Friend Class SpinEventArgs
		Inherits RoutedEventArgs
	End Class

	Friend Class SpinnerWeakEventManager
		Implements IWeakEventListener
'<SnippetIWeakEventListener>
Private Function ReceiveWeakEvent(ByVal managerType As Type, ByVal sender As Object, ByVal e As EventArgs) As Boolean Implements IWeakEventListener.ReceiveWeakEvent
	If managerType Is GetType(ClockwiseSpinEventManager) Then
		OnClockwiseSpin(sender, CType(e, SpinEventArgs))
	ElseIf managerType Is GetType(CounterclockwiseSpinEventManager) Then
		OnCounterclockwiseSpin(sender, CType(e, SpinEventArgs))
	Else
		Return False ' unrecognized event
	End If
	Return True
End Function
Private Sub OnClockwiseSpin(ByVal sender As Object, ByVal e As SpinEventArgs)
	'do something here...
End Sub
Private Sub OnCounterclockwiseSpin(ByVal sender As Object, ByVal e As SpinEventArgs)
	'do something here...
End Sub
'</SnippetIWeakEventListener>
	End Class

Public Delegate Sub MyRoutedEventHandler(ByVal sender As Object, ByVal e As MyRoutedEventArgs)
'<SnippetRoutedEventArgs>
Public Class MyRoutedEventArgs
	Inherits RoutedEventArgs
' other members omitted
	Protected Overrides Sub InvokeEventHandler(ByVal genericHandler As System.Delegate, ByVal genericTarget As Object)
		Dim handler As MyRoutedEventHandler = CType(genericHandler, MyRoutedEventHandler)
		handler(genericTarget, Me)
	End Sub
End Class
'</SnippetRoutedEventArgs>

	Friend Class InteropMonkey
		Private ownerHwnd As IntPtr
		Private myDialog As New Window()
		Private Sub Monkey()
			'<SnippetWindowInteropHelper>
			Dim wih As New WindowInteropHelper(myDialog)
			wih.Owner = ownerHwnd
			myDialog.ShowDialog()
			'</SnippetWindowInteropHelper>
		End Sub
	End Class
End Namespace










