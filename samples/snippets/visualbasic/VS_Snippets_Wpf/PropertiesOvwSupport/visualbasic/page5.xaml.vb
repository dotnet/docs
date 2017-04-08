Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Collections.Generic


Namespace MyAquarium

  Partial Public Class MyCode
	  Inherits Page
	  Private Sub UpdateFish(ByVal sender As Object, ByVal e As EventArgs)
		  Dim f As Fish = CType(aq.AquariumContents(0), Fish)
		  f.Species = "Guppy"
	  End Sub
  End Class

  Public Class Fish
	  Inherits FrameworkElement
	  Public Shared ReadOnly SpeciesProperty As DependencyProperty = DependencyProperty.Register("Species", GetType(String), GetType(Fish), New FrameworkPropertyMetadata("Default"))
	  Public Property Species() As String
		  Get
			  Return CStr(GetValue(SpeciesProperty))
		  End Get
		  Set(ByVal value As String)
			  SetValue(SpeciesProperty,CStr(value))
		  End Set
	  End Property
  End Class
  Public Class Aquarium
	  Inherits Canvas
	Private Shared ReadOnly AquariumContentsProperty As DependencyProperty = DependencyProperty.Register("AquariumContents", GetType(FreezableCollection(Of FrameworkElement)), GetType(Aquarium), New FrameworkPropertyMetadata(New FreezableCollection(Of FrameworkElement)()))
	Public ReadOnly Property AquariumContents() As FreezableCollection(Of FrameworkElement)
	  Get
		  Return CType(GetValue(AquariumContentsProperty), FreezableCollection(Of FrameworkElement))
	  End Get
	End Property
	Public Sub New()
		MyBase.New()
	  SetValue(AquariumContentsProperty, New FreezableCollection(Of FrameworkElement)())
	End Sub
  End Class
End Namespace

