//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SDKSample
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

    public partial class Pane1 : Window
    {

        void OnLoad(object sender, RoutedEventArgs e)
        {
            //<SnippetSetPlacementTarget>
            //create the button that displays the tooltip
            Button targetButton = new Button();
            targetButton.Content = "tooltip Placement Target";
         
            //create a button that owns the tooltip
            Button tooltipOwner = new Button();
            tooltipOwner.Content = "tooltip owner";
            tooltipOwner.ToolTip = "The ToolTip";
            ToolTipService.SetPlacement(tooltipOwner,PlacementMode.Top);
            ToolTipService.SetPlacementTarget(tooltipOwner,targetButton);
            //</SnippetSetPlacementTarget>
            
            targetButton.Margin = new Thickness(0, 20, 0, 0);
            targetButton.Width = 150;
            tooltipOwner.Margin = new Thickness(0, 20, 0, 0);
            tooltipOwner.Width = 150;
            
            Stack11.Children.Add(targetButton);
            Stack11.Children.Add(tooltipOwner);
        }
          
        public CustomPopupPlacement[] placeToolTip(Size popupSize,
	                                               Size targetSize,
	                                               Point offset)
        {
             CustomPopupPlacement[] ttplaces =
                new CustomPopupPlacement[] { new CustomPopupPlacement() };
             ttplaces[0].Point = new Point(0,80);
             ttplaces[0].PrimaryAxis = PopupPrimaryAxis.Horizontal;
             return ttplaces;
        }
    }
}