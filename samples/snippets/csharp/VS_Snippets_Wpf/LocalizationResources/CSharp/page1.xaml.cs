namespace MySampleApp     // Namespace must be the same as what you set in project file
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows.Resources;

    public partial class MyPage
    {
        //<Snippet2>
        void OnClick(object sender, RoutedEventArgs e)
        {
            ResourceManager rm = new ResourceManager("MySampleApp.data.stringtable",
                 Assembly.GetExecutingAssembly());
            Text1.Text = rm.GetString("Message");
        }
        //</Snippet2>
    }
}
