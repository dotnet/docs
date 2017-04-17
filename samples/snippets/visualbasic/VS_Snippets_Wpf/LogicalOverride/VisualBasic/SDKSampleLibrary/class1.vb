Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Collections


Namespace SDKSample
'<SnippetSingletonPanel>
	Public Class SingletonPanel
		Inherits StackPanel
        'Private _children As UIElementCollection 
		Private _child As FrameworkElement

		Public Sub New()

		End Sub

		Public Property SingleChild() As FrameworkElement

			Get
				Return _child
			End Get
			Set(ByVal value As FrameworkElement)
				If value Is Nothing Then
					 RemoveLogicalChild(_child)
				Else
					 If _child Is Nothing Then
						 _child = value
					 Else
						 ' raise an exception?
						 MessageBox.Show("Needs to be a single element")
					 End If
				End If
			End Set
		End Property
		Public Sub SetSingleChild(ByVal child As Object)
			Me.AddLogicalChild(child)
		End Sub

		Public Shadows Sub AddLogicalChild(ByVal child As Object)
			_child = CType(child, FrameworkElement)
			If Me.Children.Count = 1 Then
				Me.RemoveLogicalChild(Me.Children(0))
				Me.Children.Add(CType(child, UIElement))
			Else
				Me.Children.Add(CType(child, UIElement))
			End If
		End Sub

		Public Shadows Sub RemoveLogicalChild(ByVal child As Object)

			_child = Nothing
			Me.Children.Clear()
		End Sub
		Protected Overrides ReadOnly Property LogicalChildren() As IEnumerator
		   Get
		   ' cheat, make a list with one member and return the enumerator
		   Dim _list As New ArrayList()
		   _list.Add(_child)
		   Return CType(_list.GetEnumerator(), IEnumerator)
		   End Get
		End Property
	End Class
'</SnippetSingletonPanel>
End Namespace

