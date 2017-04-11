using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SDKSample
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //<SnippetDelegateDefinition>
            popup1.CustomPopupPlacementCallback =
                new CustomPopupPlacementCallback(placePopup);
            //</SnippetDelegateDefinition> 
        }


        private void onClick(object sender, RoutedEventArgs args)
        {
            popup1.IsOpen = !popup1.IsOpen;

        }

        //<SnippetDelegateInstance>
        public CustomPopupPlacement[] placePopup(Size popupSize,
                                                   Size targetSize,
                                                   Point offset)
        {
            CustomPopupPlacement placement1 =
               new CustomPopupPlacement(new Point(-50, 100), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement placement2 =
                new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);

            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { placement1, placement2 };
            return ttplaces;
        }
        //</SnippetDelegateInstance>


    }
  
}