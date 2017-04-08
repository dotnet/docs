using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.ComponentModel;

namespace WPFAquariumObjects
{
  public class AquariumFilter
  {
      //<SnippetAECode>
      public static readonly RoutedEvent NeedsCleaningEvent = EventManager.RegisterRoutedEvent("NeedsCleaning", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AquariumFilter));
      public static void AddNeedsCleaningHandler(DependencyObject d, RoutedEventHandler handler)
      {
          UIElement uie = d as UIElement;
          if (uie != null)
          {
              uie.AddHandler(AquariumFilter.NeedsCleaningEvent, handler);
          }
      }
      public static void RemoveNeedsCleaningHandler(DependencyObject d, RoutedEventHandler handler)
      {
          UIElement uie = d as UIElement;
          if (uie != null)
          {
              uie.RemoveHandler(AquariumFilter.NeedsCleaningEvent, handler);
          }
      }
      //</SnippetAECode>
  }
  public class Aquarium : Canvas
  {
    public Aquarium()
      : base()
    {
      //do something
      this.Background = new SolidColorBrush(Colors.Aqua);
      PopulateAquarium();
      CalculateAquariumSize();
    }

    void PopulateAquarium()
    {
      Fish fish1 = new Fish();
      this.Children.Add(fish1);
    }
    //<SnippetRODP>
    internal static readonly DependencyPropertyKey AquariumSizeKey = DependencyProperty.RegisterReadOnly(
      "AquariumSize",
      typeof(double),
      typeof(Aquarium),
      new PropertyMetadata(double.NaN)
    );
    public static readonly DependencyProperty AquariumSizeProperty =
      AquariumSizeKey.DependencyProperty;
    public double AquariumSize
    {
      get { return (double)GetValue(AquariumSizeProperty); }
    }
    //</SnippetRODP>
    protected virtual void CalculateAquariumSize()
    {
      this.SetValue(AquariumSizeKey, this.Width * this.Height);
    }

    static object CoerceAquariumSize(DependencyObject d, Object baseValue)
    {
      return baseValue; //give more practical implementation that tracks Height and Width
    }

  }

  public class Fishbowl : Aquarium {
    public Fishbowl()
      : base()
    {

    }
//<SnippetRODPOverride> 
    static Fishbowl() {
      Aquarium.AquariumSizeKey.OverrideMetadata(
        typeof(Aquarium),
        new PropertyMetadata(
          double.NaN,
          null,
          new CoerceValueCallback(CoerceFishbowlAquariumSize)
        )
      );
    }

    static object CoerceFishbowlAquariumSize(DependencyObject d,Object baseValue)
    {
        //Aquarium is 2D, a Fishbowl is a round Aquarium, so the Size we return is the ellipse of that height/width rather than the rectangle
        Fishbowl fb = (Fishbowl)d;
        //other constraints assure that H,W are positive
        return Convert.ToInt32(Math.PI * (fb.Width / 2) * (fb.Height / 2));
    }
    //</SnippetRODPOverride> 
  }

  public abstract class AquariumObject : Shape{

    static AquariumObject()
    {
    }
    protected AquariumObject()
    {
      Uri checkUri = (Uri) GetValue(AquariumGraphicProperty);
      if (checkUri != null)
      {
        this.Fill = new ImageBrush(new BitmapImage(checkUri));
      }
    }
    protected AquariumObject(Uri startingGraphicUri) {
      
    }
//<SnippetRegisterAttachedBubbler>
    public static readonly DependencyProperty IsBubbleSourceProperty = DependencyProperty.RegisterAttached(
      "IsBubbleSource",
      typeof(Boolean),
      typeof(AquariumObject),
      new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender)
    );
    public static void SetIsBubbleSource(UIElement element, Boolean value)
    {
      element.SetValue(IsBubbleSourceProperty, value);
    }
    public static Boolean GetIsBubbleSource(UIElement element)
    {
      return (Boolean)element.GetValue(IsBubbleSourceProperty);
    }
//</SnippetRegisterAttachedBubbler>
//<SnippetAGWithWrapper>

//<SnippetRegisterAG>
    public static readonly DependencyProperty AquariumGraphicProperty = DependencyProperty.Register(
      "AquariumGraphic",
      typeof(Uri),
      typeof(AquariumObject),
      new FrameworkPropertyMetadata(null,
          FrameworkPropertyMetadataOptions.AffectsRender, 
          new PropertyChangedCallback(OnUriChanged)
      )
    );
//</SnippetRegisterAG>
    public Uri AquariumGraphic
    {
      get { return (Uri)GetValue(AquariumGraphicProperty); }
      set { SetValue(AquariumGraphicProperty, value); }
    }
//</SnippetAGWithWrapper>
//<SnippetAGPropertyChangedCallback>
    private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      Shape sh = (Shape) d;
      sh.Fill = new ImageBrush(new BitmapImage((Uri)e.NewValue));
    }
//</SnippetAGPropertyChangedCallback>
  }

  public sealed class Fish : AquariumObject
  {
    static Fish() {
      AquariumGraphicProperty.OverrideMetadata(typeof(Fish), new FrameworkPropertyMetadata(new System.Uri("fish.gif", UriKind.RelativeOrAbsolute), FrameworkPropertyMetadataOptions.AffectsRender));

    }
    public Fish() : base() {

    } 

    protected override Geometry DefiningGeometry
    {
      get { return new RectangleGeometry(new Rect(0.0, 0.0, 100.0, 100.0)); }
    }
  }
    public abstract class AquariumObject2 : Shape {
        //<SnippetRegisterAttachedBubbler2>
        public static readonly DependencyProperty IsBubbleSourceProperty = DependencyProperty.RegisterAttached(
          "IsBubbleSource",
          typeof(Boolean),
          typeof(AquariumObject2)
        );
        public static void SetIsBubbleSource(UIElement element, Boolean value)
        {
            element.SetValue(IsBubbleSourceProperty, value);
        }
        public static Boolean GetIsBubbleSource(UIElement element)
        {
            return (Boolean)element.GetValue(IsBubbleSourceProperty);
        }
        //</SnippetRegisterAttachedBubbler2>
    }
    //<SnippetDOMain>
    public abstract class AquariumObject3 : DependencyObject
    {
        //<SnippetRegisterAttached3>
        public enum Bouyancy
        {
            Floats,
            Sinks,
            Drifts
        }
        public static readonly DependencyProperty BouyancyProperty = DependencyProperty.RegisterAttached(
          "Bouyancy",
          typeof(Bouyancy),
          typeof(AquariumObject3),
          new FrameworkPropertyMetadata(Bouyancy.Floats, FrameworkPropertyMetadataOptions.AffectsArrange),
          new ValidateValueCallback(ValidateBouyancy)
        );
        public static void SetBouyancy(UIElement element, Bouyancy value)
        {
            element.SetValue(BouyancyProperty, value);
        }
        public static Bouyancy GetBouyancy(UIElement element)
        {
            return (Bouyancy)element.GetValue(BouyancyProperty);
        }
        private static bool ValidateBouyancy(object value)
        {
            Bouyancy bTest = (Bouyancy) value;
            return (bTest == Bouyancy.Floats || bTest == Bouyancy.Drifts || bTest==Bouyancy.Sinks);
        }
        //</SnippetRegisterAttached3>
        //<SnippetRegister3Param>
        public static readonly DependencyProperty IsDirtyProperty = DependencyProperty.Register(
          "IsDirty",
          typeof(Boolean),
          typeof(AquariumObject3)
        );
        //</SnippetRegister3Param>
    }
    //</SnippetDOMain>
}
