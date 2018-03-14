using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;


namespace PropertyMetadataAPIs
{
  public class MyCustomPropertyMetadata : PropertyMetadata
  {
      public MyCustomPropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback, Boolean supportsMyFeature)
      : base()
      {
        _supportsMyFeature = supportsMyFeature;
      }
    //<SnippetMergeImpl>
      public Boolean SupportsMyFeature
      {
          get { return _supportsMyFeature; }
          set { if (this.IsSealed != true) _supportsMyFeature = value; } //else may want to raise exception 
      }
      protected override void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
      {
          base.Merge(baseMetadata, dp);
          MyCustomPropertyMetadata mcpm = baseMetadata as MyCustomPropertyMetadata;
          if (mcpm != null)
          {
              if (this.SupportsMyFeature == false)
              {//if not set, revert to base
                  this.SupportsMyFeature = mcpm.SupportsMyFeature;
              }
          }
      }
      //</SnippetMergeImpl>     
      protected override void OnApply(DependencyProperty dp, Type targetType)
      {
 	      base.OnApply(dp, targetType);
      }

      Boolean _supportsMyFeature;
  }
  public class MyFeatureControl : Control
  {
      public static readonly DependencyProperty SpecialProperty = DependencyProperty.Register(
          "Special",
          typeof(MyFeatureControl),
          typeof(String),
          new MyCustomPropertyMetadata("I am special",null,null,true)
      );
  }


  public class Gauge : Control
  {
    //<SnippetInitpm>
    static PropertyMetadata pm;
    //</SnippetInitpm>
    static Gauge()
    {
      //<SnippetPMCtor1param>
      pm = new PropertyMetadata(Double.NaN);
      //</SnippetPMCtor1param>
      //<SnippetPMCtor1paramcallback>
      pm = new PropertyMetadata(new PropertyChangedCallback(OnCurrentReadingChanged));
      //</SnippetPMCtor1paramcallback>
      //<SnippetPMCtor2param>
      pm = new PropertyMetadata(
          Double.NaN,
          new PropertyChangedCallback(OnCurrentReadingChanged)
      );
      //</SnippetPMCtor2param>
      //<SnippetPMCtor3param>
      pm = new PropertyMetadata(
          Double.NaN,
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading)
      );
      //</SnippetPMCtor3param>
    }
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
        pm,
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
      get { return (double)GetValue(MaxReadingProperty); }
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
      get { return (double)GetValue(MinReadingProperty); }
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
  public class FEGauge : Control
  {
    //<SnippetInitfpm>
    static FrameworkPropertyMetadata fpm;
    //</SnippetInitfpm>
    static FEGauge()
    {
      //<SnippetFPMCtor1param>
      fpm = new FrameworkPropertyMetadata(Double.NaN);
      //</SnippetFPMCtor1param>
      //<SnippetFPMCtor1paramcallback>
      fpm = new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCurrentReadingChanged));
      //</SnippetFPMCtor1paramcallback>
      //<SnippetFPMCtor2param>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          new PropertyChangedCallback(OnCurrentReadingChanged)
      );
      //</SnippetFPMCtor2param>
      //<SnippetFPMCtor3param>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading)
      );
      //</SnippetFPMCtor3param>
      //<SnippetFPMCtor_DV_FPMO>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          (FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
      );
      //</SnippetFPMCtor_DV_FPMO>
      //<SnippetFPMCtor_PCC_CVC>
      fpm = new FrameworkPropertyMetadata(
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading)
      );
      //</SnippetFPMCtor_PCC_CVC>
      //<SnippetFPMCtor_DV_FPMO_PCC>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          (FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault),
          new PropertyChangedCallback(OnCurrentReadingChanged)
      );
      //</SnippetFPMCtor_DV_FPMO_PCC>
      //<SnippetFPMCtor_DV_FPMO_PCC_CVC>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          (FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault),
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading)
      );
      //</SnippetFPMCtor_DV_FPMO_PCC_CVC>
      //<SnippetFPMCtor_DV_FPMO_PCC_CVC_IAP>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          (FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault),
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading),
          true //Animation prohibited
      );
      //</SnippetFPMCtor_DV_FPMO_PCC_CVC_IAP>
      //<SnippetFPMCtor_DV_FPMO_PCC_CVC_IAP_DUST>
      fpm = new FrameworkPropertyMetadata(
          Double.NaN,
          (FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault),
          new PropertyChangedCallback(OnCurrentReadingChanged),
          new CoerceValueCallback(CoerceCurrentReading),
          true //Animation prohibited
          , UpdateSourceTrigger.PropertyChanged
      );
      //</SnippetFPMCtor_DV_FPMO_PCC_CVC_IAP_DUST>
    }
    public static bool IsValidReading(object value)
    {
      Double v = (Double)value;
      return (!v.Equals(Double.NegativeInfinity) && !v.Equals(Double.PositiveInfinity));
    }
    //<SnippetFPMCurrentDefinitionWithWrapper>
    public static readonly DependencyProperty CurrentReadingProperty = DependencyProperty.Register(
        "CurrentReading",
        typeof(double),
        typeof(FEGauge),
        fpm,
        new ValidateValueCallback(IsValidReading)
    );
    public double CurrentReading
    {
      get { return (double)GetValue(CurrentReadingProperty); }
      set { SetValue(CurrentReadingProperty, value); }
    }
    //</SnippetFPMCurrentDefinitionWithWrapper>
    //<SnippetFPMCoerceCurrent>
    private static object CoerceCurrentReading(DependencyObject d, object value)
    {
      FEGauge g = (FEGauge)d;
      double current = (double)value;
      if (current < g.MinReading) current = g.MinReading;
      if (current > g.MaxReading) current = g.MaxReading;
      return current;
    }
    //</SnippetFPMCoerceCurrent>
    //<SnippetFPMOnPCCurrent>
    private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MinReadingProperty);
      d.CoerceValue(MaxReadingProperty);
    }
    //</SnippetFPMOnPCCurrent>
    //<SnippetFPMMaxDefinitionWithWrapper>
    public static readonly DependencyProperty MaxReadingProperty = DependencyProperty.Register(
        "MaxReading",
        typeof(double),
        typeof(FEGauge),
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
      get { return (double)GetValue(MaxReadingProperty); }
      set { SetValue(MaxReadingProperty, value); }
    }
    //</SnippetFPMMaxDefinitionWithWrapper>
    //<SnippetFPMOnPCMax>
    private static void OnMaxReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MinReadingProperty);
      d.CoerceValue(CurrentReadingProperty);
    }
    //</SnippetFPMOnPCMax>
    //<SnippetFPMCoerceMax>
    private static object CoerceMaxReading(DependencyObject d, object value)
    {
      FEGauge g = (FEGauge)d;
      double max = (double)value;
      if (max < g.MinReading) max = g.MinReading;
      return max;
    }
    //</SnippetFPMCoerceMax>
    //<SnippetFPMMinDefinitionWithWrapper>
    public static readonly DependencyProperty MinReadingProperty = DependencyProperty.Register(
    "MinReading",
    typeof(double),
    typeof(FEGauge),
    new FrameworkPropertyMetadata(
        double.NaN,
        FrameworkPropertyMetadataOptions.AffectsMeasure,
        new PropertyChangedCallback(OnMinReadingChanged),
        new CoerceValueCallback(CoerceMinReading)
    ),
    new ValidateValueCallback(IsValidReading));

    public double MinReading
    {
      get { return (double)GetValue(MinReadingProperty); }
      set { SetValue(MinReadingProperty, value); }
    }
    //</SnippetFPMMinDefinitionWithWrapper>
    //<SnippetFPMOnPCMin>
    private static void OnMinReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      d.CoerceValue(MaxReadingProperty);
      d.CoerceValue(CurrentReadingProperty);
    }
    //</SnippetFPMOnPCMin>
    //<SnippetFPMCoerceMin>
    private static object CoerceMinReading(DependencyObject d, object value)
    {
      FEGauge g = (FEGauge)d;
      double min = (double)value;
      if (min > g.MaxReading) min = g.MaxReading;
      return min;
    }
    //</SnippetFPMCoerceMin>
  }
}
