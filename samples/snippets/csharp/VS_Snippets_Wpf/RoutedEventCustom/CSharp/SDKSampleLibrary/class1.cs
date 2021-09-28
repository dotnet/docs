using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
//<SnippetCustomClass>
    public class MyButtonSimple: Button
    {
        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
//<SnippetAddRemoveHandler>
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
            "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyButtonSimple));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Tap
        {
                add { AddHandler(TapEvent, value); }
                remove { RemoveHandler(TapEvent, value); }
        }
//</SnippetAddRemoveHandler>

        // This method raises the Tap event
//<SnippetRaiseEvent>
        void RaiseTapEvent()
        {
                RoutedEventArgs newEventArgs = new RoutedEventArgs(MyButtonSimple.TapEvent);
                RaiseEvent(newEventArgs);
        }
//</SnippetRaiseEvent>
        // For demonstration purposes we raise the event when the MyButtonSimple is clicked
        protected override void OnClick()
        {
            RaiseTapEvent();
        }
    }
//</SnippetCustomClass>
}
