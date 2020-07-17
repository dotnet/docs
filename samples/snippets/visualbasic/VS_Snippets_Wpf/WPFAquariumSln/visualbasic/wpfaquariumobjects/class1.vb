Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.ComponentModel

Namespace WPFAquariumObjects
    Public Class AquariumFilter
        '<SnippetAECode>
        Public Shared ReadOnly NeedsCleaningEvent As RoutedEvent = EventManager.RegisterRoutedEvent("NeedsCleaning", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(AquariumFilter))
        Public Shared Sub AddNeedsCleaningHandler(ByVal d As DependencyObject, ByVal handler As RoutedEventHandler)
            Dim uie As UIElement = TryCast(d, UIElement)
            If uie IsNot Nothing Then
                uie.AddHandler(AquariumFilter.NeedsCleaningEvent, handler)
            End If
        End Sub
        Public Shared Sub RemoveNeedsCleaningHandler(ByVal d As DependencyObject, ByVal handler As RoutedEventHandler)
            Dim uie As UIElement = TryCast(d, UIElement)
            If uie IsNot Nothing Then
                uie.RemoveHandler(AquariumFilter.NeedsCleaningEvent, handler)
            End If
        End Sub
        '</SnippetAECode>
    End Class
    Public Class Aquarium
        Inherits Canvas
        Public Sub New()
            MyBase.New()
            'do something
            Me.Background = New SolidColorBrush(Colors.Aqua)
            PopulateAquarium()
            CalculateAquariumSize()
        End Sub

        Private Sub PopulateAquarium()
            Dim fish1 As New Fish()
            Me.Children.Add(fish1)
        End Sub
        '<SnippetRODP>
        Friend Shared ReadOnly AquariumSizeKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("AquariumSize", GetType(Double), GetType(Aquarium), New PropertyMetadata(Double.NaN))
        Public Shared ReadOnly AquariumSizeProperty As DependencyProperty = AquariumSizeKey.DependencyProperty
        Public ReadOnly Property AquariumSize() As Double
            Get
                Return CDbl(GetValue(AquariumSizeProperty))
            End Get
        End Property
        '</SnippetRODP>
        Protected Overridable Sub CalculateAquariumSize()
            Me.SetValue(AquariumSizeKey, Me.Width * Me.Height)
        End Sub

        Private Shared Function CoerceAquariumSize(ByVal d As DependencyObject, ByVal baseValue As Object) As Object
            Return baseValue 'give more practical implementation that tracks Height and Width
        End Function

    End Class

    Public Class Fishbowl
        Inherits Aquarium
        Public Sub New()
            MyBase.New()

        End Sub
        '<SnippetRODPOverride> 
        Shared Sub New()
            Aquarium.AquariumSizeKey.OverrideMetadata(GetType(Aquarium), New PropertyMetadata(Double.NaN, Nothing, New CoerceValueCallback(AddressOf CoerceFishbowlAquariumSize)))
        End Sub

        Private Shared Function CoerceFishbowlAquariumSize(ByVal d As DependencyObject, ByVal baseValue As Object) As Object
            'Aquarium is 2D, a Fishbowl is a round Aquarium, so the Size we return is the ellipse of that height/width rather than the rectangle
            Dim fb As Fishbowl = CType(d, Fishbowl)
            'other constraints assure that H,W are positive
            Return Convert.ToInt32(Math.PI * (fb.Width / 2) * (fb.Height / 2))
        End Function
        '</SnippetRODPOverride> 
    End Class

    Public MustInherit Class AquariumObject
        Inherits Shape

        Shared Sub New()
        End Sub
        Protected Sub New()
            Dim checkUri As Uri = CType(GetValue(AquariumGraphicProperty), Uri)
            If checkUri IsNot Nothing Then
                Me.Fill = New ImageBrush(New BitmapImage(checkUri))
            End If
        End Sub
        Protected Sub New(ByVal startingGraphicUri As Uri)

        End Sub
        '<SnippetRegisterAttachedBubbler>
        Public Shared ReadOnly IsBubbleSourceProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsBubbleSource", GetType(Boolean), GetType(AquariumObject), New FrameworkPropertyMetadata(False, FrameworkPropertyMetadataOptions.AffectsRender))
        Public Shared Sub SetIsBubbleSource(ByVal element As UIElement, ByVal value As Boolean)
            element.SetValue(IsBubbleSourceProperty, value)
        End Sub
        Public Shared Function GetIsBubbleSource(ByVal element As UIElement) As Boolean
            Return CType(element.GetValue(IsBubbleSourceProperty), Boolean)
        End Function
        '</SnippetRegisterAttachedBubbler>
        '<SnippetAGWithWrapper>

        '<SnippetRegisterAG>
        Public Shared ReadOnly AquariumGraphicProperty As DependencyProperty = DependencyProperty.Register("AquariumGraphic", GetType(Uri), GetType(AquariumObject), New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf OnUriChanged)))
        '</SnippetRegisterAG>
        Public Property AquariumGraphic() As Uri
            Get
                Return CType(GetValue(AquariumGraphicProperty), Uri)
            End Get
            Set(ByVal value As Uri)
                SetValue(AquariumGraphicProperty, value)
            End Set
        End Property
        '</SnippetAGWithWrapper>
        '<SnippetAGPropertyChangedCallback>
        Private Shared Sub OnUriChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            Dim sh As Shape = CType(d, Shape)
            sh.Fill = New ImageBrush(New BitmapImage(CType(e.NewValue, Uri)))
        End Sub
        '</SnippetAGPropertyChangedCallback>
    End Class

    Public NotInheritable Class Fish
        Inherits AquariumObject
        Shared Sub New()
            AquariumGraphicProperty.OverrideMetadata(GetType(Fish), New FrameworkPropertyMetadata(New System.Uri("fish.gif", UriKind.RelativeOrAbsolute), FrameworkPropertyMetadataOptions.AffectsRender))

        End Sub
        Public Sub New()
            MyBase.New()

        End Sub

        Protected Overrides ReadOnly Property DefiningGeometry() As Geometry
            Get
                Return New RectangleGeometry(New Rect(0.0, 0.0, 100.0, 100.0))
            End Get
        End Property
    End Class
    Public MustInherit Class AquariumObject2
        Inherits Shape
        '<SnippetRegisterAttachedBubbler2>
        Public Shared ReadOnly IsBubbleSourceProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsBubbleSource", GetType(Boolean), GetType(AquariumObject2))
        Public Shared Sub SetIsBubbleSource(ByVal element As UIElement, ByVal value As Boolean)
            element.SetValue(IsBubbleSourceProperty, value)
        End Sub
        Public Shared Function GetIsBubbleSource(ByVal element As UIElement) As Boolean
            Return CType(element.GetValue(IsBubbleSourceProperty), Boolean)
        End Function
        '</SnippetRegisterAttachedBubbler2>
    End Class
    '<SnippetDOMain>
    Public MustInherit Class AquariumObject3
        Inherits DependencyObject
        '<SnippetRegisterAttached3>
        Public Enum Bouyancy
            Floats
            Sinks
            Drifts
        End Enum
        Public Shared ReadOnly BouyancyProperty As DependencyProperty = DependencyProperty.RegisterAttached("Bouyancy", GetType(Bouyancy), GetType(AquariumObject3), New FrameworkPropertyMetadata(Bouyancy.Floats, FrameworkPropertyMetadataOptions.AffectsArrange), New ValidateValueCallback(AddressOf ValidateBouyancy))
        Public Shared Sub SetBouyancy(ByVal element As UIElement, ByVal value As Bouyancy)
            element.SetValue(BouyancyProperty, value)
        End Sub
        Public Shared Function GetBouyancy(ByVal element As UIElement) As Bouyancy
            Return CType(element.GetValue(BouyancyProperty), Bouyancy)
        End Function
        Private Shared Function ValidateBouyancy(ByVal value As Object) As Boolean
            Dim bTest As Bouyancy = CType(value, Bouyancy)
            Return (bTest = Bouyancy.Floats OrElse bTest = Bouyancy.Drifts OrElse bTest = Bouyancy.Sinks)
        End Function
        '</SnippetRegisterAttached3>
        '<SnippetRegister3Param>
        Public Shared ReadOnly IsDirtyProperty As DependencyProperty = DependencyProperty.Register("IsDirty", GetType(Boolean), GetType(AquariumObject3))
        '</SnippetRegister3Param>
    End Class
    '</SnippetDOMain>
End Namespace
