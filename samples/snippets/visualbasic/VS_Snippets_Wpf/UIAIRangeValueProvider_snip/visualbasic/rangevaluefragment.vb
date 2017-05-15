Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Windows.Forms
Imports System.Drawing

Namespace UIAIRangeValueProvider_snip
	Friend Class RangeValueProvider
		Implements IRangeValueProvider, IRawElementProviderSimple
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

	   #Region "IRangeValueProvider Members"

		' <SnippetIsReadOnly>
		''' <summary>
		''' Specifies whether the control is read-only.
		''' </summary>
		Public ReadOnly Property IsReadOnly() As Boolean Implements IRangeValueProvider.IsReadOnly
			Get
				Return Not(Me.customControl.Enabled)
			End Get
		End Property
		' </SnippetIsReadOnly>

		' <SnippetLargeChange>
		''' <summary>
		''' Specifies the large change value.
		''' </summary>
		Public ReadOnly Property LargeChange() As Double Implements IRangeValueProvider.LargeChange
			Get
				Return 5.0
			End Get
		End Property
		' </SnippetLargeChange>

		' <SnippetMaximum>
		''' <summary>
		''' Specifies the maximum value of the range.
		''' </summary>
		Public ReadOnly Property Maximum() As Double Implements IRangeValueProvider.Maximum
			Get
				Return 255.0
			End Get
		End Property
		' </SnippetMaximum>

		' <SnippetMinimum>
		''' <summary>
		''' Specifies the minimum value of the range.
		''' </summary>
		Public ReadOnly Property Minimum() As Double Implements IRangeValueProvider.Minimum
			Get
				Return 0.0
			End Get
		End Property
		' </SnippetMinimum>

		' <SnippetSetValue>
		''' <summary>
		''' Sets the value of the control.
		''' </summary>
		''' <param name="value">
		''' The value to set the control to.
		''' </param>
		''' <remarks>
		''' For the purposes of this sample, the custom control displays 
		''' its value through the alpha setting of its base color.
		''' </remarks>
		Public Sub SetValue(ByVal value As Double) Implements IRangeValueProvider.SetValue
			If value < Minimum Or value > Maximum Then
				Throw New ArgumentOutOfRangeException()
			Else
				Dim color As Color = customControl.controlColor
				' Invoke control method on separate thread to avoid 
				' clashing with UI.
				' Use anonymous method for simplicity.
				Me.customControl.Invoke(New MethodInvoker(Sub()
					customControl.controlColor = Color.FromArgb(CInt(Fix(value)), color)
					customControl.Refresh()
				End Sub))
			End If
		End Sub
		' </SnippetSetValue>

		' <SnippetSmallChange>
		''' <summary>
		''' Specifies the small change value.
		''' </summary>
		Public ReadOnly Property SmallChange() As Double Implements IRangeValueProvider.SmallChange
			Get
				Return 1.0
			End Get
		End Property
		' </SnippetSmallChange>

		' <SnippetValue>
		''' <summary>
		''' Specifies the current value of the control.
		''' </summary>
		''' <remarks>
		''' For the purposes of this sample, the custom control displays 
		''' its value through the alpha setting of the base color.
		''' </remarks>
		Public ReadOnly Property Value() As Double Implements IRangeValueProvider.Value
			Get
				Return customControl.colorAlpha
			End Get
		End Property
		' </SnippetValue>

		#End Region

		#Region "IRawElementProviderSimple Members"

		''' <summary>
		''' Retrieves the object that supports the specified control pattern.
		''' </summary>
		''' <param name="patternId">The pattern identifier</param>
		''' <returns>
		''' The supporting object, or null if the pattern is not supported.
		''' </returns>
		Private Function GetPatternProvider(ByVal patternId As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			If patternId = RangeValuePatternIdentifiers.Pattern.Id Then
				Return Me
			End If
			Return Nothing
		End Function

		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			If propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
				Return ControlType.Window.Id
			' It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
			' because this value cannot be discovered by the HWND host provider. This is not 
			' necessary for a Win32 provider.
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

		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region
	End Class
End Namespace
