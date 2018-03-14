Namespace SDKSample
    Public Class Gauge
        Inherits Control
        Public Sub New()
            MyBase.New()
        End Sub
        '<SnippetValidateValueCallback>
        Public Shared Function IsValidReading(ByVal value As Object) As Boolean
            Dim v As Double = CType(value, Double)
            Return ((Not v.Equals(Double.NegativeInfinity)) AndAlso
                    (Not v.Equals(Double.PositiveInfinity)))
        End Function
        '</SnippetValidateValueCallback>

        '<SnippetCurrentDefinitionWithWrapper>
        Public Shared ReadOnly CurrentReadingProperty As DependencyProperty =
            DependencyProperty.Register("CurrentReading",
                GetType(Double), GetType(Gauge),
                New FrameworkPropertyMetadata(Double.NaN,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    New PropertyChangedCallback(AddressOf OnCurrentReadingChanged),
                    New CoerceValueCallback(AddressOf CoerceCurrentReading)),
                New ValidateValueCallback(AddressOf IsValidReading))

        Public Property CurrentReading() As Double
            Get
                Return CDbl(GetValue(CurrentReadingProperty))
            End Get
            Set(ByVal value As Double)
                SetValue(CurrentReadingProperty, value)
            End Set
        End Property
        '</SnippetCurrentDefinitionWithWrapper>

        '<SnippetCoerceCurrent>
        Private Shared Function CoerceCurrentReading(ByVal d As DependencyObject, ByVal value As Object) As Object
            Dim g As Gauge = CType(d, Gauge)
            Dim current As Double = CDbl(value)
            If current < g.MinReading Then
                current = g.MinReading
            End If
            If current > g.MaxReading Then
                current = g.MaxReading
            End If
            Return current
        End Function
        '</SnippetCoerceCurrent>

        '<SnippetOnPCCurrent>
        Private Shared Sub OnCurrentReadingChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            d.CoerceValue(MinReadingProperty)
            d.CoerceValue(MaxReadingProperty)
        End Sub
        '</SnippetOnPCCurrent>

        '<SnippetMaxDefinitionWithWrapper>
        Public Shared ReadOnly MaxReadingProperty As DependencyProperty = DependencyProperty.Register("MaxReading", GetType(Double), GetType(Gauge), New FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, New PropertyChangedCallback(AddressOf OnMaxReadingChanged), New CoerceValueCallback(AddressOf CoerceMaxReading)), New ValidateValueCallback(AddressOf IsValidReading))
        Public Property MaxReading() As Double
            Get
                Return CDbl(GetValue(MaxReadingProperty))
            End Get
            Set(ByVal value As Double)
                SetValue(MaxReadingProperty, value)
            End Set
        End Property
        '</SnippetMaxDefinitionWithWrapper>

        '<SnippetOnPCMax>
        Private Shared Sub OnMaxReadingChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            d.CoerceValue(MinReadingProperty)
            d.CoerceValue(CurrentReadingProperty)
        End Sub
        '</SnippetOnPCMax>
        '<SnippetCoerceMax>
        Private Shared Function CoerceMaxReading(ByVal d As DependencyObject, ByVal value As Object) As Object
            Dim g As Gauge = CType(d, Gauge)
            Dim max As Double = CDbl(value)
            If max < g.MinReading Then
                max = g.MinReading
            End If
            Return max
        End Function
        '</SnippetCoerceMax>

        '<SnippetMinDefinitionWithWrapper>
        Public Shared ReadOnly MinReadingProperty As DependencyProperty = DependencyProperty.Register("MinReading", GetType(Double), GetType(Gauge), New FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, New PropertyChangedCallback(AddressOf OnMinReadingChanged), New CoerceValueCallback(AddressOf CoerceMinReading)), New ValidateValueCallback(AddressOf IsValidReading))

        Public Property MinReading() As Double
            Get
                Return CDbl(GetValue(MinReadingProperty))
            End Get
            Set(ByVal value As Double)
                SetValue(MinReadingProperty, value)
            End Set
        End Property
        '</SnippetMinDefinitionWithWrapper>

        '<SnippetOnPCMin>
        Private Shared Sub OnMinReadingChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            d.CoerceValue(MaxReadingProperty)
            d.CoerceValue(CurrentReadingProperty)
        End Sub
        '</SnippetOnPCMin>

        '<SnippetCoerceMin>
        Private Shared Function CoerceMinReading(ByVal d As DependencyObject, ByVal value As Object) As Object
            Dim g As Gauge = CType(d, Gauge)
            Dim min As Double = CDbl(value)
            If min > g.MaxReading Then
                min = g.MaxReading
            End If
            Return min
        End Function
        '</SnippetCoerceMin>
    End Class
End Namespace
