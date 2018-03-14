//<SnippetAllCode>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace SDKSample
{
  public class MyEditContainer : ContentControl
  {
    public MyEditContainer() : base() { }
//<SnippetStaticAndRegisterClassHandler>
    static MyEditContainer()
    {
      EventManager.RegisterClassHandler(typeof(MyEditContainer), PreviewMouseRightButtonDownEvent, new RoutedEventHandler(LocalOnMouseRightButtonDown));
    }
    internal static void LocalOnMouseRightButtonDown(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("this is invoked before the On* class handler on UIElement");
      //e.Handled = true; //uncommenting this would cause ONLY the subclass' class handler to respond
    }
//</SnippetStaticAndRegisterClassHandler>
    public static readonly RoutedEvent EditStateChangedEvent = EventManager.RegisterRoutedEvent("EditStageChanged", RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventArgs<bool>), typeof(MyEditContainer));

    // Provide CLR accessors for the event
    public event RoutedEventHandler EditStateChanged
    {
        add { AddHandler(EditStateChangedEvent, value); }
        remove { RemoveHandler(EditStateChangedEvent, value); }
    }
    public Boolean EditState {
        get{return (Boolean) GetValue(EditStateProperty);}
        set{this.SetValue(EditStateProperty, value);}
    }
    public static readonly DependencyProperty EditStateProperty = DependencyProperty.Register(
      "EditState", typeof(Boolean), typeof(MyEditContainer), new PropertyMetadata(false, new PropertyChangedCallback(OnEditStateChanged)));
      static void OnEditStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
          MyEditContainer ec = (MyEditContainer)d;
          if (ec != null)
          {
              RoutedPropertyChangedEventArgs<bool> newEventArgs =
                  new RoutedPropertyChangedEventArgs<bool>((bool)e.OldValue, (bool)e.NewValue);
              newEventArgs.RoutedEvent = EditStateChangedEvent;
              ec.RaiseEvent(newEventArgs);
          }
      }
//<SnippetOnStarClassHandler>
    protected override void OnPreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventArgs e)
    {
        e.Handled = true; //suppress the click event and other leftmousebuttondown responders
        MyEditContainer ec = (MyEditContainer)e.Source;
        if (ec.EditState)
        { ec.EditState = false; }
        else
        { ec.EditState = true; }
        base.OnPreviewMouseRightButtonDown(e);
    }
//</SnippetOnStarClassHandler>
  }
    public class AnotherEditContainer : ContentControl
    {
        static AnotherEditContainer()
        {
            EventManager.RegisterClassHandler(typeof(AnotherEditContainer), PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(MyEditContainer.LocalOnMouseRightButtonDown));
        }
        //<SnippetRoutedEventAddOwner>
        public static readonly RoutedEvent EditStateChangedEvent  = MyEditContainer.EditStateChangedEvent.AddOwner(typeof(AnotherEditContainer));
        //</SnippetRoutedEventAddOwner>
        public static readonly DependencyProperty EditStateProperty = MyEditContainer.EditStateProperty.AddOwner(typeof(AnotherEditContainer));
        public Boolean EditState
        {
            get { return (Boolean)GetValue(EditStateProperty); }
            set { this.SetValue(EditStateProperty, value); }
        }
        protected override void OnPreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true; //suppress the click event and other leftmousebuttondown responders
            AnotherEditContainer ec = (AnotherEditContainer)e.Source;
            if (ec.EditState)
            { ec.EditState = false; }
            else
            { ec.EditState = true; }
            base.OnPreviewMouseLeftButtonDown(e);
        }
    }
}
//</SnippetAllCode>