Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Threading
Imports System.Windows.Media
Imports System.Windows.Markup
Imports System.Windows
Imports System.Windows.Controls

Namespace Microsoft.Samples.PerFrameAnimations

	''' <summary>
	''' This class is used internally to delegate it's rendering to the parent OverlayRenderDecorator.
	''' </summary>
	Friend Class OverlayRenderDecoratorOverlayVisual
		Inherits DrawingVisual
		Private _hitTestVisible As Boolean = False

		Friend Property IsHitTestVisible() As Boolean
			Get
				Return _hitTestVisible
			End Get
			Set(ByVal value As Boolean)
				_hitTestVisible = value
			End Set
		End Property

		'dont hit test, these are just overlay graphics
		Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As GeometryHitTestParameters) As GeometryHitTestResult
			If IsHitTestVisible Then
				Return MyBase.HitTestCore(hitTestParameters)
			Else
				Return Nothing
			End If
		End Function

		'dont hit test, these are just overlay graphics
		Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As PointHitTestParameters) As HitTestResult
			If IsHitTestVisible Then
				Return MyBase.HitTestCore(hitTestParameters)
			Else
				Return Nothing
			End If
		End Function
	End Class



	''' <summary>
	''' OverlayRenderDecorator provides a simple overlay graphics mechanism similar 
	''' to OnRender called OnOverlayRender
	''' </summary>
	<ContentProperty("Child")>
	Public Class OverlayRenderDecorator
		Inherits FrameworkElement
		'the only logical child
		Private _child As UIElement
		Private _vc As VisualCollection

		'this will be a visual child, but not a logical child.  as the last child, it can 'overlay' graphics
		' by calling back to us with OnOverlayRender
		Private _overlayVisual As OverlayRenderDecoratorOverlayVisual


		'-------------------------------------------------------------------
		'
		'  Constructors
		'
		'-------------------------------------------------------------------

		#Region "Constructors"

		''' <summary>
		'''     Default constructor
		''' </summary>
		Public Sub New()
			MyBase.New()
			_overlayVisual = New OverlayRenderDecoratorOverlayVisual()

			_vc = New VisualCollection(Me)

			'insert the overlay element into the visual tree
			_vc.Add(_overlayVisual)
		End Sub

		#End Region


		'-------------------------------------------------------------------
		'
		'  Public Properties
		'
		'-------------------------------------------------------------------

		#Region "Public Properties"

		''' <summary>
		''' Enables/Disables hit testing on the overlay visual
		''' </summary>
		Public Property IsOverlayHitTestVisible() As Boolean
			Get
				If _overlayVisual IsNot Nothing Then
					Return _overlayVisual.IsHitTestVisible
				Else
					Return False
				End If
			End Get
			Set(ByVal value As Boolean)
				If _overlayVisual IsNot Nothing Then
					_overlayVisual.IsHitTestVisible = value
				End If
			End Set
		End Property

		''' <summary>
		''' The single child of an <see cref="System.Windows.Media.Animation.OverlayRenderDecorator" />
		''' </summary>
'<SnippetAddRemoveLogicalChild>
        <System.ComponentModel.DefaultValue(GetType(Object), Nothing)>
        Public Overridable Property Child() As UIElement
            Get
                Return _child
            End Get
            Set(ByVal value As UIElement)
                If _child IsNot value Then
                    'need to remove old element from logical tree
                    If _child IsNot Nothing Then
                        OnDetachChild(_child)
                        RemoveLogicalChild(_child)
                    End If

                    _vc.Clear()

                    If value IsNot Nothing Then
                        'add to visual
                        _vc.Add(value)
                        'add to logical
                        AddLogicalChild(value)
                    End If

                    'always add the overlay child back into the visual tree if its set
                    If _overlayVisual IsNot Nothing Then
                        _vc.Add(_overlayVisual)
                    End If

                    'cache the new child
                    _child = value

                    'notify derived types of the new child
                    If value IsNot Nothing Then
                        OnAttachChild(_child)
                    End If

                    InvalidateMeasure()
                End If
            End Set
        End Property
'</SnippetAddRemoveLogicalChild>

		''' <summary> 
		''' Returns enumerator to logical children.
		''' </summary>
		Protected Overrides ReadOnly Property LogicalChildren() As IEnumerator
			Get
				If _child Is Nothing Then
					Return CType(New List(Of UIElement)().GetEnumerator(), IEnumerator)
				End If
				Dim l As New List(Of UIElement)()
				l.Add(_child)
				Return CType(l.GetEnumerator(), IEnumerator)
			End Get
		End Property


		#End Region

		'-------------------------------------------------------------------
		'
		'  Protected Methods
		'
		'-------------------------------------------------------------------

		#Region "Protected Methods"

		''' <summary>
		''' Updates DesiredSize of the OverlayRenderDecorator.  Called by parent UIElement.  This is the first pass of layout.
		''' </summary>
		''' <remarks>
		''' OverlayRenderDecorator determines a desired size it needs from the child's sizing properties, margin, and requested size.
		''' </remarks>
		''' <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
		''' <returns>The OverlayRenderDecorator's desired size.</returns>
		Protected Overrides Function MeasureOverride(ByVal constraint As System.Windows.Size) As System.Windows.Size
			Dim child As UIElement = Me.Child
			If child IsNot Nothing Then
				child.Measure(constraint)
				Return (child.DesiredSize)
			End If
			Return (New System.Windows.Size())
		End Function

		''' <summary>
		''' OverlayRenderDecorator computes the position of its single child inside child's Margin and calls Arrange
		''' on the child.
		''' </summary>
		''' <param name="arrangeSize">Size the OverlayRenderDecorator will assume.</param>
		Protected Overrides Function ArrangeOverride(ByVal arrangeSize As System.Windows.Size) As System.Windows.Size
			Dim child As UIElement = Me.Child
			If child IsNot Nothing Then
				child.Arrange(New Rect(arrangeSize))
			End If

			'Our OnRender gets called in Arrange, but
			'  we dont have access to that, so update the 
			'  overlay here.
			If _overlayVisual IsNot Nothing Then
				Using dc As DrawingContext = _overlayVisual.RenderOpen()
					'delegate to derived types
					OnOverlayRender(dc)
				End Using
			End If

			Return (arrangeSize)
		End Function

		''' <summary>
		''' render method for overlay graphics.
		''' </summary>
		''' <param name="dc"></param>
		Protected Overridable Sub OnOverlayRender(ByVal dc As DrawingContext)

		End Sub

		''' <summary>
		''' gives derives types a simple way to respond to a new child being added
		''' </summary>
		''' <param name="child"></param>
		Protected Overridable Sub OnAttachChild(ByVal child As UIElement)

		End Sub

		''' <summary>
		''' gives derives types a simple way to respond to a child being removed
		''' </summary>
		''' <param name="child"></param>
		Protected Overridable Sub OnDetachChild(ByVal child As UIElement)

		End Sub

		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return _vc.Count
			End Get
		End Property

		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			Return _vc(index)
		End Function

		#End Region


	End Class

End Namespace