using System;
using System.Windows;
using System.Windows.Controls;
using SDKSample;

namespace SDKSample
{

    public partial class LogicalOverrideApp
    {
        void AddLogicalElement(object sender, RoutedEventArgs e)
        {
            Button myButton = new Button();
            myButton.Content = "Happy birthday! " + System.DateTime.Now.TimeOfDay.ToString();
            CustomElement.SetSingleChild(myButton);
        }
    }
}
