
//<snippet1>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using System.Reflection;
using System.Globalization;
using System.Text;


namespace Reflection
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
           this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TypeInfo t = typeof(Calendar).GetTypeInfo();
            IEnumerable<PropertyInfo> pList = t.DeclaredProperties;
            IEnumerable<MethodInfo> mList = t.DeclaredMethods;

            StringBuilder sb = new StringBuilder();
           
            sb.Append("Properties:");
            foreach (PropertyInfo p in pList)
            {

                sb.Append("\n" + p.DeclaringType.Name + ": " + p.Name);
            }
            sb.Append("\nMethods:");
            foreach (MethodInfo m in mList)
            {
                sb.Append("\n" + m.DeclaringType.Name + ": " + m.Name);
            }
            
            textblock1.Text = sb.ToString();

        }
    }
}
//</snippet1>
