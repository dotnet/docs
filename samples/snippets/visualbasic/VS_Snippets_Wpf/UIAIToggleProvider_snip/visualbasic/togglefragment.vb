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


Namespace UIAIToggleProvider_snip
    Public Class ToggleProvider
        Implements IRawElementProviderSimple, IToggleProvider
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
            If patternId = TogglePatternIdentifiers.Pattern.Id Then
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

#Region "IToggleProvider Members"

        ' <SnippetToggleState>
        ''' <summary>
        ''' Retrieves the toggle state of the control.
        ''' </summary>
        ''' <remarks>
        ''' For this custom control the toggle state is reflected by the color 
        ''' of the control. This is analogous to the CheckBox IsChecked property.
        ''' Green   - ToggleState.On
        ''' Red     - ToggleState.Off
        ''' Yellow  - ToggleState.Indeterminate
        ''' </remarks>
        Private ReadOnly Property IToggleProvider_ToggleState() As ToggleState Implements IToggleProvider.ToggleState
            Get
                Return customControl.toggleStateColor(customControl.controlColor)

            End Get
        End Property
        ' </SnippetToggleState>

        ' <SnippetToggle>
        ''' <summary>
        ''' Toggles the control.
        ''' </summary>
        ''' <remarks>
        ''' For this custom control the toggle state is reflected by the color 
        ''' of the control. This is analogous to the CheckBox IsChecked property.
        ''' Green   - ToggleState.On
        ''' Red     - ToggleState.Off
        ''' Yellow  - ToggleState.Indeterminate
        ''' </remarks>
        Private Sub Toggle() Implements IToggleProvider.Toggle
            Dim toggleState As ToggleState = customControl.toggleStateColor(customControl.controlColor)
            ' Invoke control method on separate thread to avoid clashing with UI.
            ' Use anonymous method for simplicity.
            Me.customControl.Invoke(New MethodInvoker(Sub()
                                                          If toggleState = Windows.Automation.ToggleState.On Then
                                                              customControl.controlColor = Color.Red
                                                          ElseIf toggleState = Windows.Automation.ToggleState.Off Then
                                                              customControl.controlColor = Color.Yellow
                                                          ElseIf toggleState = Windows.Automation.ToggleState.Indeterminate Then
                                                              customControl.controlColor = Color.Green
                                                          End If
                                                          customControl.Refresh()
                                                      End Sub))
        End Sub
        ' </SnippetToggle>


#End Region ' IToggleProvider Members

    End Class
End Namespace
