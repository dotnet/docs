using System;
using System.Windows;
using System.Windows.Controls;
using SDKSample;

namespace SDKSample {

    public partial class LogicalOverrideApp {
        void AddLogicalElement(object sender, RoutedEventArgs e)        {
            Button mybutton = new Button();
            mybutton.Content = "Happy birthday! " + System.DateTime.Now.TimeOfDay.ToString();
            CustomElement.SetSingleChild(mybutton);
        }
    }
}
            

