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
using System.Windows.Input.Manipulations;

namespace ManipulationAPI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ManipulationItem manipulationItem;
        public Window1()
        {
            InitializeComponent();

            CheckTranslate.Checked += ManipulationChanged;
            CheckTranslate.Unchecked += ManipulationChanged;

            CheckRotate.Checked += ManipulationChanged;
            CheckRotate.Unchecked += ManipulationChanged;

            CheckScale.Checked += ManipulationChanged;
            CheckScale.Unchecked += ManipulationChanged;

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            manipulationItem = new ManipulationItem();
            manipulationItem.SupportedManipulations = GetSupportedManipulations();
            manipulationItem.Container = MainCanvas;
            MainCanvas.Children.Add(manipulationItem);

        }

        private void ManipulationChanged(object sender, RoutedEventArgs e)
        {
            manipulationItem.SupportedManipulations = GetSupportedManipulations();
        }

        private Manipulations2D GetSupportedManipulations()
        {
            Manipulations2D manipulations = Manipulations2D.None;
            if (CheckTranslate.IsChecked.Value)
            {
                manipulations = manipulations | Manipulations2D.Translate;
            }
            if (CheckRotate.IsChecked.Value)
            {
                manipulations = manipulations | Manipulations2D.Rotate;
            }
            if (CheckScale.IsChecked.Value)
            {
                manipulations = manipulations | Manipulations2D.Scale;
            }
            return manipulations;
        }
    }
}
