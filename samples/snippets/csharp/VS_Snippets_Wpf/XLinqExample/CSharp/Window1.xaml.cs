using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Xml.Linq;

namespace BindToResults
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        XDocument planetsDoc;
        public Window1()
        {
            InitializeComponent();

            Button_Click_LoadXMLFromFile(null, null) ;
        }

        private void CheckBox_Checked_Sort(object sender, RoutedEventArgs e)
        {
//<SnippetBindToResults>
            stacky.DataContext =
            from c in planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
            orderby Int32.Parse(c.Element("{http://planetsNS}DiameterKM").Value)
            select c;
//</snippetBindToResults>
        }

        private void CheckBox_Unchecked_NoSort(object sender, RoutedEventArgs e)
        {
            stacky.DataContext =
            from c in planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
            select c;
        }

        private void Button_Click_LoadXMLFromFile(object sender, RoutedEventArgs e)
        {
            //<SnippetLoadDCFromFile>
            planetsDoc = XDocument.Load("../../Planets.xml");
            stacky.DataContext = planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements();
            //</SnippetLoadDCFromFile>
            sortCheckBox.IsChecked = false;
        }

        private void Button_Click_LoadXMLFromXAML(object sender, RoutedEventArgs e)
        {
//<SnippetLoadDCFromXAML>
            planetsDoc = (XDocument)((ObjectDataProvider)Resources["justTwoPlanets"]).Data;
            stacky.DataContext = planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements();
//</SnippetLoadDCFromXAML>
            sortCheckBox.IsChecked = false;
        }
    }
}
