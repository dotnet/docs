//---------------------------------------------------------------------------
// <copyright file="RibbonWindow1.xaml.cs">
//     This WPF-based sample source code demonstrates using a WPF-based Microsoft Office 
//     Fluent User Interface (the "Fluent UI") and is provided only as referential material.  
//     License terms to copy, use or distribute the Fluent UI are available separately.  
//    
//     To learn more about our Fluent UI licensing program, 
//     please visit http://msdn.microsoft.com/officeui.
// </copyright>
//---------------------------------------------------------------------------

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
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using System.Collections.ObjectModel;

namespace WpfRibbonApplication1
{
    /// <summary>
    /// Interaction logic for RibbonWindow1.xaml
    /// </summary>
    public partial class RibbonWindow1 : RibbonWindow
    {
        public RibbonWindow1()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
    }

    public class MostRecentFiles : ObservableCollection<string>
    {
        public MostRecentFiles()
        {
            Add("Read Me.txt");
            Add("Document 1.txt");
        }
    }
}
