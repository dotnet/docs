using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//<SnippetNumbersCSharp>
namespace BidiTest
{
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            string currentLanguage =
                System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag;

            text1.Language = System.Windows.Markup.XmlLanguage.GetLanguage(currentLanguage);

            if (currentLanguage.ToLower().StartsWith("ar"))
            {
                text1.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                text1.FlowDirection = FlowDirection.LeftToRight;
            }
        }
    }
}
//</SnippetNumbersCSharp>