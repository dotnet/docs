using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

//<SnippetNSFrameDiffCODE1>
using System.Windows.Controls;
using System.Windows.Navigation;
//</SnippetNSFrameDiffCODE1>

namespace NSGNSvsFNSSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

//<SnippetNSFrameDiffCODE2>
// Get the NavigationService owned by the Frame
NavigationService frameNS = this.frame.NavigationService;

// Get the NavigationService for the navigation host that navigated
// to the content in which the Frame is hosted
NavigationService navigationHostNS = NavigationService.GetNavigationService(this.frame);
//</SnippetNSFrameDiffCODE2>
        }

    }
}