Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Runtime.InteropServices
Imports MS.Win32
Imports System.Collections


Namespace UIAITransformProvider_snip
	Public Class TransformProvider
		Implements IRawElementProviderSimple, ITransformProvider
		' The custom control.
		Private customControl As CustomControl
		' Window handle of the control.
		Private windowHandle As IntPtr

		''' <summary>
		''' Constructor
		''' </summary>
		''' <param name="control">
		''' The control for which this object is providing UI Automation functionality.
		''' </param>
		Public Sub New(ByVal control As CustomControl)
			customControl = control
			windowHandle = control.Handle
		End Sub

		#Region "IRawElementProviderSimple Members"

		''' <summary>
		''' Retrieves the object that supports the specified control pattern.
		''' </summary>
		''' <param name="patternId">The pattern identifier</param>
		''' <returns>
		''' The supporting object, or null if the pattern is not supported.
		''' </returns>
		Private Function GetPatternProvider(ByVal patternId As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			If patternId = TransformPatternIdentifiers.Pattern.Id Then
				Return Me
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Gets provider property values.
		''' </summary>
		''' <param name="propertyId">The property identifier.</param>
		''' <returns>The value of the property.</returns>
		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			If propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
				Return ControlType.Window.Id
			' It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
			'  because this value cannot be discovered by the HWND host provider. This is not 
			'  necessary for a Win32 provider.
			ElseIf propertyId = AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id Then
				Return False
			ElseIf propertyId = AutomationElementIdentifiers.FrameworkIdProperty.Id Then
				Return "Custom"
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Gets the host provider.
		''' </summary>
		''' <remarks>
		''' Fragment roots return their window providers; most others return null.
		''' </remarks>
		Private ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
			Get
				Return AutomationInteropProvider.HostProviderFromHandle(windowHandle)
			End Get
		End Property

		''' <summary>
		''' Gets provider options.
		''' </summary>
		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region ' IRawElementProviderSimple Members

		#Region "IRawElementProviderFragment Members"

		''' <summary>
		''' Gets the bounding rectangle.
		''' </summary>
		''' <remarks>
		''' Fragment roots should return an empty rectangle. UI Automation will get the rectangle
		''' from the host control (the HWND in this case).
		''' </remarks>
		'System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
		'{
		'    get
		'    {
		'        return System.Windows.Rect.Empty;
		'    }
		'}

		''' <summary>
		''' Gets the root of this fragment.
		''' </summary>
		'IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
		'{
		'    get
		'    {
		'        return this;
		'    }
		'}

		''' <summary>
		''' Gets any fragment roots that are embedded in this fragment.
		''' </summary>
		''' <returns>Null in this case.</returns>
		'IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
		'{
		'    return null;
		'}

		''' <summary>
		''' Gets the runtime identifier of the UI Automation element.
		''' </summary>
		''' <returns>Fragment roots return null.</returns>
		'int[] IRawElementProviderFragment.GetRuntimeId()
		'{
		'    return null;
		'}

		''' <summary>
		''' Navigates to adjacent elements in the UI Automation tree.
		''' </summary>
		''' <param name="direction">Direction of navigation.</param>
		''' <returns>The element in that direction, or null.</returns>
		''' <remarks>
		''' The provider only returns directions that it is responsible for.  
		''' In this case, none.
		'''</remarks>
		'IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
		'{
		'    return null;
		'}

		''' <summary>
		''' Responds to a client request to set the focus to this control.
		''' </summary>
		''' <remarks>Setting focus to the control is handled by the parent window.</remarks>
		'void IRawElementProviderFragment.SetFocus()
		'{
		'    throw new Exception("The method is not implemented.");
		'}

		#End Region ' IRawElementProviderFragment Members

		#Region "IRawElementProviderFragmentRoot"

		''' <summary>
		''' Gets the element at the specified point.
		''' </summary>
		''' <param name="x">Distance from the left of the application window.</param>
		''' <param name="y">Distance from the top of the application window.</param>
		''' <returns>The provider for the element at that point.</returns>
		'IRawElementProviderFragment
		'    IRawElementProviderFragmentRoot.ElementProviderFromPoint(double x, double y)
		'{
		'    System.Drawing.Point clientPoint = new System.Drawing.Point((int)x, (int)y);

		'    if (!this.OwnerTransformControl.DisplayRectangle.Contains(clientPoint))
		'    {
		'        return null;
		'    }
		'    return (IRawElementProviderFragment)this.OwnerTransformControl.Provider;
		'}

		''' <summary>
		''' Returns the element that gets focus.
		''' </summary>
		''' <returns>The selected item.</returns>
		'IRawElementProviderFragment IRawElementProviderFragmentRoot.GetFocus()
		'{
		'    return (IRawElementProviderFragment)this.OwnerTransformControl.Provider;
		'}

		#End Region ' IRawElementProviderFragmentRoot

		#Region "ITransformProvider Members"

		' <SnippetCanMove>
		''' <summary>
		''' Specifies whether moving is supported.
		''' </summary>
		Private ReadOnly Property CanMove() As Boolean Implements ITransformProvider.CanMove
			Get
				Return True
			End Get
		End Property
		' </SnippetCanMove>

		' <SnippetCanResize>
		''' <summary>
		''' Specifies whether resizing is supported.
		''' </summary>
		Private ReadOnly Property CanResize() As Boolean Implements ITransformProvider.CanResize
			Get
				Return True
			End Get
		End Property
		' </SnippetCanResize>

		'<SnippetCanRotate>
		''' <summary>
		''' Specifies whether rotating is supported.
		''' </summary>
		Private ReadOnly Property CanRotate() As Boolean Implements ITransformProvider.CanRotate
			Get
				Return False
			End Get
		End Property
		'</SnippetCanRotate>

		' <SnippetMove>
		''' <summary>
		''' Moves the provider to the specified position.
		''' </summary>
		''' <param name="x">The specified X screen coordinate.</param>
		''' <param name="y">The specified Y screen coordinate</param>
		Private Sub Move(ByVal x As Double, ByVal y As Double) Implements ITransformProvider.Move
            Dim leftInt As Integer = CInt(x)
            Dim topInt As Integer = CInt(y)

			If Not(CType(Me, ITransformProvider)).CanMove Then
				Throw New InvalidOperationException("Operation cannot be performed.")
			End If

			' Move should never be allowed to place a control outside the 
			' bounds of its container; the control should always be accessible 
			' using the keyboard or mouse.
			' Use the bounds of the parent window to limit the placement 
			' of the custom control.
			Dim maxLeft As Integer = 10
			Dim maxTop As Integer = 10
			Dim maxRight As Integer = Me.customControl.formWidth - Me.customControl.Width - 10
			Dim maxBottom As Integer = Me.customControl.formHeight - Me.customControl.Height - 10

			If leftInt < maxLeft Then
				leftInt = 0
			End If
			If topInt < maxTop Then
				topInt = 0
			End If
			If leftInt > maxRight Then
				leftInt = maxRight
			End If
			If topInt > maxBottom Then
				topInt = maxBottom
			End If

			' Invoke control method on separate thread to avoid clashing with UI.
			' Use anonymous method for simplicity.
			Me.customControl.Invoke(New MethodInvoker(Sub()
				Me.customControl.Left = leftInt
				Me.customControl.Top = topInt
			End Sub))
		End Sub
		' </SnippetMove>

		' <SnippetResize>
		''' <summary>
		''' Resizes the provider to the specified height and width.
		''' </summary>
		''' <param name="height">The specified height.</param>
		''' <param name="width">The specified width.</param>
		Private Sub Resize(ByVal width As Double, ByVal height As Double) Implements ITransformProvider.Resize
			If Not(CType(Me, ITransformProvider)).CanResize Then
				Throw New InvalidOperationException("Operation cannot be performed.")
			End If

			If width <= 0 Or height <= 0 Then
				Throw New InvalidOperationException("Operation cannot be performed.")
			End If

            Dim widthInt As Integer = CInt(width)
            Dim heightInt As Integer = CInt(height)

			' Resize should never be allowed to place a control outside the 
			' bounds of its container; the control should always be accessible 
			' using the keyboard or mouse.
			' Use the bounds of the parent window to limit the placement 
			' of the custom control.
			Dim MaxSize As New Size(Me.customControl.formWidth - 20, Me.customControl.formHeight - 20)
			Dim MinSize As New Size(10, 10)

			If widthInt > MaxSize.Width Then
				widthInt = MaxSize.Width
			End If
			If heightInt > MaxSize.Height Then
				heightInt = MaxSize.Height
			End If
			If widthInt < MinSize.Width Then
				widthInt = MinSize.Width
			End If
			If heightInt < MinSize.Height Then
				heightInt = MinSize.Height
			End If

			' Invoke control method on separate thread to avoid clashing with UI.
            ' Use anonymous method for simplicity.
			Me.customControl.Invoke(New MethodInvoker(Sub() Me.customControl.Size = New Size(widthInt, heightInt)))
		End Sub
		' </SnippetResize>

		' <SnippetRotate>
		''' <summary>
		''' Rotates the provider the specified number of degrees.
		''' </summary>
		Private Sub Rotate(ByVal degreesToRotate As Double) Implements ITransformProvider.Rotate
			Throw New InvalidOperationException("Operation cannot be performed.")
		End Sub
		' </SnippetRotate>


		#End Region ' ITransformProvider Members

		#Region "Helper methods"

		#End Region ' Helper methods
	End Class
End Namespace
