using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
  public class Gauge : Control
  {
    public Gauge() :base() {}
    //<SnippetValidateValueCallback>
    public static bool IsValidReading(object value)
    {
        Double v = (Double)value;
        return (!v.Equals(Double.NegativeInfinity) && !v.Equals(Double.PositiveInfinity));
    }
    //</SnippetValidateValueCallback>

    //<SnippetCurrentDefinitionWithWrapper>
    public static readonly DependencyProperty CurrentReadingProperty = DependencyProperty.Register(
        "CurrentReading",
        typeof(double),
        typeof(Gauge),
        new FrameworkPropertyMetadata(
            Double.NaN,
            FrameworkPropertyMetadataOptions.AffectsMeasure,
            new PropertyChangedCallback(OnCurrentReadingChanged),
            new CoerceValueCallback(CoerceCurrentReading)
        ),
        new ValidateValueCallback(IsValidReading)
    );
    public double CurrentReading
    {
      get { return (double)GetValue(CurrentReadingProperty); }
      set { SetValue(CurrentReadingProperty, value); }
    }
    //</SnippetCurrentDefinitionWithWrapper>

    //<SnippetCoerceCurrent>
    private static object CoerceCurrentReading(DependencyObject d, object value)
    {
      Gauge g = (Gauge)d;
      double current = (double)value;
      if (current < g.MinReading) current = g.MinReading;
      if (current > g.MaxReading) current = g.MaxReading;
      return current;
    }
    //</SnippetCoerceCurrent>

    //<SnippetOnPCCurrent>
    private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MinReadingProperty);
      d.CoerceValue(MaxReadingProperty);
    }
    //</SnippetOnPCCurrent>

    //<SnippetMaxDefinitionWithWrapper>
    public static readonly DependencyProperty MaxReadingProperty = DependencyProperty.Register(
        "MaxReading",
        typeof(double),
        typeof(Gauge),
        new FrameworkPropertyMetadata(
            double.NaN,
            FrameworkPropertyMetadataOptions.AffectsMeasure,
            new PropertyChangedCallback(OnMaxReadingChanged),
            new CoerceValueCallback(CoerceMaxReading)
        ),
        new ValidateValueCallback(IsValidReading)
    );
    public double MaxReading
    {
      get { return (double) GetValue(MaxReadingProperty); }
      set { SetValue(MaxReadingProperty, value); }
    }
    //</SnippetMaxDefinitionWithWrapper>

    //<SnippetOnPCMax>
    private static void OnMaxReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MinReadingProperty);
      d.CoerceValue(CurrentReadingProperty);
    }
    //</SnippetOnPCMax>
    //<SnippetCoerceMax>
    private static object CoerceMaxReading(DependencyObject d, object value)
    {
      Gauge g = (Gauge)d;
      double max = (double)value;
      if (max < g.MinReading) max = g.MinReading;
      return max;
    }
    //</SnippetCoerceMax>

    //<SnippetMinDefinitionWithWrapper>
    public static readonly DependencyProperty MinReadingProperty = DependencyProperty.Register(
    "MinReading",
    typeof(double),
    typeof(Gauge),
    new FrameworkPropertyMetadata(
        double.NaN,
        FrameworkPropertyMetadataOptions.AffectsMeasure,
        new PropertyChangedCallback(OnMinReadingChanged),
        new CoerceValueCallback(CoerceMinReading)
    ),
    new ValidateValueCallback(IsValidReading));

    public double MinReading
    {
      get { return (double) GetValue(MinReadingProperty); }
      set { SetValue(MinReadingProperty, value); }
    }
    //</SnippetMinDefinitionWithWrapper>

    //<SnippetOnPCMin>
    private static void OnMinReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MaxReadingProperty);
      d.CoerceValue(CurrentReadingProperty);
    }
    //</SnippetOnPCMin>

    //<SnippetCoerceMin>
    private static object CoerceMinReading(DependencyObject d, object value)
    {
      Gauge g = (Gauge)d;
      double min = (double)value;
      if (min > g.MaxReading) min = g.MaxReading;
      return min;
    }
    //</SnippetCoerceMin>
  }
}
