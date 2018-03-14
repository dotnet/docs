using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SDKSample
{
//<SnippetMyStateControl>
  public class MyStateControl : ButtonBase
  {
    public MyStateControl() : base() { }
    public Boolean State
    {
      get { return (Boolean)this.GetValue(StateProperty); }
      set { this.SetValue(StateProperty, value); } 
    }
    public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
      "State", typeof(Boolean), typeof(MyStateControl),new PropertyMetadata(false));
  }
  //</SnippetMyStateControl>

  //<SnippetUnrelatedStateControl>
  public class UnrelatedStateControl : Control
  {
    public UnrelatedStateControl() { }
    public static readonly DependencyProperty StateProperty = MyStateControl.StateProperty.AddOwner(typeof(UnrelatedStateControl), new PropertyMetadata(true));
    public Boolean State
    {
      get { return (Boolean)this.GetValue(StateProperty); }
      set { this.SetValue(StateProperty, value); }
    }
  }
  //</SnippetUnrelatedStateControl>

  //<SnippetMyAdvancedStateControl>
  public class MyAdvancedStateControl : MyStateControl
  {
    public MyAdvancedStateControl() : base() { }
    static MyAdvancedStateControl()
    {
      MyStateControl.StateProperty.OverrideMetadata(typeof(MyAdvancedStateControl), new PropertyMetadata(true));
    }
  }
  //</SnippetMyAdvancedStateControl>
    public class AreaButton : Button
    {
  //<SnippetInvalidateProperty>
        static AreaButton()
        {
            WidthProperty.OverrideMetadata(typeof(AreaButton), new FrameworkPropertyMetadata(new PropertyChangedCallback(InvalidateAreaProperty)));
            HeightProperty.OverrideMetadata(typeof(AreaButton), new FrameworkPropertyMetadata(new PropertyChangedCallback(InvalidateAreaProperty)));
        }
        static void InvalidateAreaProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.InvalidateProperty(AreaProperty);
        }
   //</SnippetInvalidateProperty>
        public double Area
        {
            get { return (double)this.GetValue(AreaProperty); }
        }
        private static readonly DependencyPropertyKey AreaPropertyKey = DependencyProperty.RegisterReadOnly(
            "Area",
            typeof(double),
            typeof(AreaButton),
            new PropertyMetadata(0.0,null,new CoerceValueCallback(CalculateArea))
        );
        private static object CalculateArea(object d, object previousValue) {
            FrameworkElement fe = d as FrameworkElement;
            if (fe != null)
            {
                return(fe.ActualWidth * fe.ActualHeight);
            }
            else return null;
        }

        public static readonly DependencyProperty AreaProperty = AreaPropertyKey.DependencyProperty;
        protected override void OnClick()
        {
            this.Width += 1;
            this.Height += 1;
            base.OnClick();
            this.Content = GetValue(AreaProperty).ToString();
        }
    }
}
