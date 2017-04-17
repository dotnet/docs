Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Runtime.InteropServices
Imports System.Collections

Namespace UIAIValueProvider_snip
	Public Class ValueProvider
		Implements IRawElementProviderSimple, IRawElementProviderFragmentRoot, IValueProvider
		' The custom control.
		Private customControl As CustomControl
		' Window handle of the control.
		Private windowHandle As IntPtr
		' Default value for control
		Private controlValue As String

		  ''' <summary>
		''' Constructor
		''' </summary>
		''' <param name="control">
		''' The control for which this object is providing UI Automation functionality.
		''' </param>
		Public Sub New(ByVal control As CustomControl)
			customControl = control
			windowHandle = control.Handle
			controlValue = "x"
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
			If patternId = ValuePatternIdentifiers.Pattern.Id Then
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
				Return True
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

		#Region "IValueProvider members"

		' <SnippetIsReadOnly>
		''' <summary>
		''' Specifies whether the custom control is read only.
		''' </summary>
		Private ReadOnly Property IsReadOnly() As Boolean Implements IValueProvider.IsReadOnly
			Get
				Return False
			End Get
		End Property
		' </SnippetIsReadOnly>

		' <SnippetValue>
		''' <summary>
		''' Retrieves the value of the custom control.
		''' </summary>
		Private ReadOnly Property Value() As String Implements IValueProvider.Value
			Get
				Return controlValue
			End Get
		End Property
		' </SnippetValue>

		' <SnippetSetValue>
		''' <summary>
		''' Sets the value of the control.
		''' </summary>
		''' <param name="value">
		''' The new value.
		''' </param>
		Private Sub SetValue(ByVal value As String) Implements IValueProvider.SetValue
			If (CType(Me, IValueProvider)).IsReadOnly Then
				Throw New InvalidOperationException("Operation cannot be performed.")
			End If
			' Arbitrary string length limit.
			If value.Length > 5 Then
				Throw New ArgumentOutOfRangeException("String is greater than five characters in length.")
			End If
			controlValue = value
		End Sub
		' </SnippetSetValue>



		#End Region ' IValueProvider members

		#Region "IRawElementProviderFragment Members"

		''' <summary>
		''' Gets the bounding rectangle.
		''' </summary>
		''' <remarks>
		''' Fragment roots should return an empty rectangle. UI Automation will get the rectangle
		''' from the host control (the HWND in this case).
		''' </remarks>
		Private ReadOnly Property BoundingRectangle() As System.Windows.Rect Implements IRawElementProviderFragment.BoundingRectangle
			Get
				Return System.Windows.Rect.Empty
			End Get
		End Property

		''' <summary>
		''' Gets the root of this fragment.
		Private ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot Implements IRawElementProviderFragment.FragmentRoot
			Get
				Return Me
			End Get
		End Property

		''' <summary>
		''' Gets any fragment roots that are embedded in this fragment.
		''' </summary>
		''' <returns>Null in this case.</returns>
		Private Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
			Return Nothing
		End Function

		''' <summary>
		''' Gets the runtime identifier of the UI Automation element.
		''' </summary>
		''' <returns>Fragment roots return null.</returns>
		Private Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
			Return Nothing
		End Function

		''' <summary>
		''' Navigates to adjacent elements in the UI Automation tree.
		''' </summary>
		''' <param name="direction">Direction of navigation.</param>
		''' <returns>The element in that direction, or null.</returns>
		''' <remarks>The provider only returns directions that it is responsible for.  
		''' UI Automation knows how to navigate between HWNDs, so only the custom item 
		''' navigation needs to be provided.
		'''</remarks>
		Private Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment Implements IRawElementProviderFragment.Navigate
			Select Case direction
				Case NavigateDirection.Parent
					Return Nothing

				Case NavigateDirection.NextSibling
					Return Nothing

				Case NavigateDirection.PreviousSibling
					Return Nothing

				Case NavigateDirection.FirstChild
					Return Nothing

				Case NavigateDirection.LastChild
					Return Nothing
				Case Else
					Return Nothing
			End Select
		End Function

		''' <summary>
		''' Responds to a client request to set the focus to this control.
		''' </summary>
		''' <remarks>Setting focus to the control is handled by the parent window.</remarks>
		Private Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
			Throw New Exception("The method is not implemented.")
		End Sub

		#End Region ' IRawElementProviderFragment Members

		#Region "IRawElementProviderFragmentRoot Members"

		Public Function ElementProviderFromPoint(ByVal x As Double, ByVal y As Double) As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.ElementProviderFromPoint
			Return CType(Me.customControl.Provider, IRawElementProviderFragment)
		End Function

		Public Function GetFocus() As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.GetFocus
			Return CType(Me.customControl.Provider, IRawElementProviderFragment)
		End Function

		#End Region
	End Class
End Namespace
