Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

' <SnippetCustomEasingFunction>
Namespace CustomEasingFunction
	Public Class CustomSeventhPowerEasingFunction
		Inherits EasingFunctionBase
		Public Sub New()
			MyBase.New()
		End Sub

		' Specify your own logic for the easing function by overriding
		' the EaseInCore method. Note that this logic applies to the "EaseIn"
		' mode of interpolation. 
		Protected Overrides Function EaseInCore(ByVal normalizedTime As Double) As Double
			' applies the formula of time to the seventh power.
			Return Math.Pow(normalizedTime, 7)
		End Function

		' Typical implementation of CreateInstanceCore
		Protected Overrides Function CreateInstanceCore() As Freezable

			Return New CustomSeventhPowerEasingFunction()
		End Function

	End Class
End Namespace
' </SnippetCustomEasingFunction>