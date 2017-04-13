Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Effects
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles
Imports System.Reflection
Imports System.Security.Permissions

Namespace RGBFilter
	Friend Class COMSafeHandle
		Inherits SafeHandleZeroOrMinusOneIsInvalid
		Friend Sub New()
			MyBase.New(True)
		End Sub

		Protected Overrides Function ReleaseHandle() As Boolean
			Marshal.Release(handle)
			Return True
		End Function
	End Class

	'
	Public Class Ole32Methods
		<DllImport("ole32.dll")>
		Friend Shared Function CoCreateInstance(ByRef clsid As Guid, ByVal inner As IntPtr, ByVal context As UInteger, ByRef uuid As Guid, <System.Runtime.InteropServices.Out()> ByRef ppEffect As COMSafeHandle) As UInteger ' HRESULT 
		End Function
	End Class

	'<SnippetBitmapEffectClass>
	Public Class RGBFilterBitmapEffect
		Inherits BitmapEffect

        '<SnippetCreateUnmanagedEffect>
		<SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Protected Overrides Function CreateUnmanagedEffect() As SafeHandle
			Const CLSCTX_INPROC_SERVER As UInteger = 1
			Dim IID_IUnknown As New Guid("00000000-0000-0000-C000-000000000046")
			Dim guidEffectCLSID As New Guid("84CF07CC-34C4-460f-B435-3184F5F2FF2A")
			Dim wrapper As SafeHandle = BitmapEffect.CreateBitmapEffectOuter()

			Dim unmanagedEffect As COMSafeHandle
			Dim hresult As UInteger = Ole32Methods.CoCreateInstance(guidEffectCLSID, wrapper.DangerousGetHandle(), CLSCTX_INPROC_SERVER, IID_IUnknown, unmanagedEffect)
			InitializeBitmapEffect(wrapper, unmanagedEffect)
			If 0 = hresult Then
				Return wrapper
			End If
			Throw New Exception("Cannot instantiate effect. HRESULT = " & hresult.ToString())
		End Function
		'</SnippetCreateUnmanagedEffect>


		#Region "Public Methods"

		Public Sub New()
		End Sub

		Public Shadows Function Clone() As RGBFilterBitmapEffect
			Return CType(MyBase.Clone(), RGBFilterBitmapEffect)
		End Function

		Public Shadows Function CloneCurrentValue() As RGBFilterBitmapEffect
			Return CType(MyBase.CloneCurrentValue(), RGBFilterBitmapEffect)
		End Function

		#End Region ' Public Methods

		#Region "Public Properties"
		Public Property Red() As Double
			Get
				Return CDbl(GetValue(RedProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(RedProperty, value)
			End Set
		End Property

		Public Property Green() As Double
			Get
				Return CDbl(GetValue(GreenProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(GreenProperty, value)
			End Set
		End Property

		Public Property Blue() As Double
			Get
				Return CDbl(GetValue(BlueProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(BlueProperty, value)
			End Set
		End Property

		Public Shared ReadOnly RedProperty As DependencyProperty = DependencyProperty.Register("Red", GetType(Double), GetType(RGBFilterBitmapEffect), New PropertyMetadata(defaultRed, AddressOf OnPropertyInvalidated))

		Public Shared ReadOnly GreenProperty As DependencyProperty = DependencyProperty.Register("Green", GetType(Double), GetType(RGBFilterBitmapEffect), New PropertyMetadata(defaultGreen, AddressOf OnPropertyInvalidated))

		Public Shared ReadOnly BlueProperty As DependencyProperty = DependencyProperty.Register("Blue", GetType(Double), GetType(RGBFilterBitmapEffect), New PropertyMetadata(defaultBlue, AddressOf OnPropertyInvalidated))


		#End Region ' Public Properties

		#Region "Protected Methods"

		Protected Overrides Sub UpdateUnmanagedPropertyState(ByVal unmanagedEffect As SafeHandle)
			BitmapEffect.SetValue(unmanagedEffect, "Red", Me.Red)
			BitmapEffect.SetValue(unmanagedEffect, "Green", Me.Green)
			BitmapEffect.SetValue(unmanagedEffect, "Blue", Me.Blue)
		End Sub

		Protected Overrides Function CreateInstanceCore() As Freezable
			Return New RGBFilterBitmapEffect()
		End Function

		Protected Overrides Sub CloneCore(ByVal sourceFreezable As Freezable)
			Dim cycle As RGBFilterBitmapEffect = CType(sourceFreezable, RGBFilterBitmapEffect)

			MyBase.CloneCore(sourceFreezable)
			Red = defaultRed
			Green = defaultGreen
			Blue = defaultBlue
		End Sub
		Protected Overrides Sub GetCurrentValueAsFrozenCore(ByVal sourceFreezable As Freezable)
			Dim cycle As RGBFilterBitmapEffect = CType(sourceFreezable, RGBFilterBitmapEffect)

			MyBase.GetCurrentValueAsFrozenCore(sourceFreezable)

			Red = defaultRed
			Green = defaultGreen
			Blue = defaultBlue
		End Sub

		Protected Overrides Sub CloneCurrentValueCore(ByVal sourceAnimatable As Freezable)
			Dim sourceRGBFilterBitmapEffect As RGBFilterBitmapEffect = CType(sourceAnimatable, RGBFilterBitmapEffect)

			sourceRGBFilterBitmapEffect = Me

			MyBase.CloneCurrentValueCore(sourceAnimatable)

			Red = sourceRGBFilterBitmapEffect.Red
			Green = sourceRGBFilterBitmapEffect.Green
			Blue = sourceRGBFilterBitmapEffect.Blue

		End Sub
		#End Region ' ProtectedMethods

		Private Shared Sub OnPropertyInvalidated(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			If (CDbl(e.NewValue)) > 1.0 OrElse (CDbl(e.NewValue)) < -1.0 Then
				Throw New ArgumentOutOfRangeException("Red","Property value must be between -1 and 1.")
			Else
				CType(d, RGBFilterBitmapEffect).OnChanged()
			End If
		End Sub

		#Region "Internal Fields"
		Friend Const defaultRed As Double = &H0
		Friend Const defaultGreen As Double = &H0
		Friend Const defaultBlue As Double = &H0
		#End Region ' Internal Fields
	End Class
	'</SnippetBitmapEffectClass>
End Namespace
