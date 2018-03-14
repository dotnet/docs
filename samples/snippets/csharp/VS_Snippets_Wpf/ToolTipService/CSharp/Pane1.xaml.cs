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

        void TimingSnippets(Ellipse ellipse1)
        {
            //set tooltip timing 
            //<SnippetToolTipServiceTimingCode>

            //<SnippetSetInitialShowDelay>
            ToolTipService.SetInitialShowDelay(ellipse1, 1000);
            //</SnippetSetInitialShowDelay>

            //<SnippetSetBetweenShowDelay>
            ToolTipService.SetBetweenShowDelay(ellipse1, 2000);
            //</SnippetSetBetweenShowDelay>

            //<SnippetSetShowDuration>
            ToolTipService.SetShowDuration(ellipse1, 7000);
            //</SnippetSetShowDuration>

            //</SnippetToolTipServiceTimingCode>

        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            
            //<SnippetToolTipCode>            
            //Create an ellipse that will have a 
            //ToolTip control. 
            Ellipse ellipse1 = new Ellipse();
            ellipse1.Height = 25;
            ellipse1.Width = 50;
            ellipse1.Fill = Brushes.Gray;
            ellipse1.HorizontalAlignment = HorizontalAlignment.Left;

            //Create a tooltip and set its position.
            //<SnippetToolTipControlPlacement>
            ToolTip tooltip = new ToolTip();
            tooltip.Placement = PlacementMode.Right;
            tooltip.PlacementRectangle = new Rect(50, 0, 0, 0);
            tooltip.HorizontalOffset = 10;
            tooltip.VerticalOffset = 20;
            //</SnippetToolTipControlPlacement>

            //Create BulletDecorator and set it
            //as the tooltip content.
            BulletDecorator bdec = new BulletDecorator();
            Ellipse littleEllipse = new Ellipse();
            littleEllipse.Height = 10;
            littleEllipse.Width = 20;
            littleEllipse.Fill = Brushes.Blue;
            bdec.Bullet = littleEllipse;
            TextBlock tipText = new TextBlock();
            tipText.Text = "Uses the ToolTip class";
            bdec.Child = tipText;
            tooltip.Content = bdec;

            //set tooltip on ellipse
            ellipse1.ToolTip = tooltip;
            //</SnippetToolTipCode>            
            
            
            stackPanel_1_1.Children.Add(ellipse1);
   
            //set event handlers for the Opened and Closed events
            //<SnippetToolTipEventHandlers>
            tooltip.Opened +=
              new RoutedEventHandler(whenToolTipOpens);
            tooltip.Closed +=
              new RoutedEventHandler(whenToolTipCloses);
            //</SnippetToolTipEventHandlers>

            //set drop shadow effect
            //<SnippetToolTipHasDropShadow>
            tooltip.HasDropShadow = false;
            //</SnippetToolTipHasDropShadow>


            ///////////////////////////////////////////////////////////////////////
            //<SnippetNoToolTipCode>            
            //Create and Ellipse with the BulletDecorator as 
            //the tooltip 
            Ellipse ellipse2 = new Ellipse();
            ellipse2.Name = "ellipse2";
            this.RegisterName(ellipse2.Name, ellipse2);
            ellipse2.Height = 25;
            ellipse2.Width = 50;
            ellipse2.Fill = Brushes.Gray;
            ellipse2.HorizontalAlignment = HorizontalAlignment.Left;

            //set tooltip timing
            ToolTipService.SetInitialShowDelay(ellipse2, 1000);
            ToolTipService.SetBetweenShowDelay(ellipse2, 2000);
            ToolTipService.SetShowDuration(ellipse2, 7000);

            //set tooltip placement
            //<SnippetNonToolTipControlPlacement>

            //<SnippetSetPlacement>
            ToolTipService.SetPlacement(ellipse2, PlacementMode.Right);
            //</SnippetSetPlacement>

            //<SnippetSetPlacementRectangle>
            ToolTipService.SetPlacementRectangle(ellipse2,
                new Rect(50, 0, 0, 0));
            //</SnippetSetPlacementRectangle>

            //<SnippetSetHorizontalOffset>
            ToolTipService.SetHorizontalOffset(ellipse2, 10.0);
            //</SnippetSetHorizontalOffset>

            //<SnippetSetVerticalOffset>
            ToolTipService.SetVerticalOffset(ellipse2, 20.0);
            //</SnippetSetVerticalOffset>

            //</SnippetNonToolTipControlPlacement>

            //<SnippetSetHasDropShadow>
            ToolTipService.SetHasDropShadow(ellipse2, false);
            //</SnippetSetHasDropShadow>

            //<SnippetSetIsEnabled>
            ToolTipService.SetIsEnabled(ellipse2, true);
            //</SnippetSetIsEnabled>

            //<SnippetSetShowOnDisabled>
            ToolTipService.SetShowOnDisabled(ellipse2, true);
            //</SnippetSetShowOnDisabled>

            //<SnippetToolTipServiceEventHandlers>
            ellipse2.AddHandler(ToolTipService.ToolTipOpeningEvent,
                new RoutedEventHandler(whenToolTipOpens));
            ellipse2.AddHandler(ToolTipService.ToolTipClosingEvent,
                new RoutedEventHandler(whenToolTipCloses));
            //</SnippetToolTipServiceEventHandlers>

            //define tooltip content
            //<SnippetSetToolTip>
            BulletDecorator bdec2 = new BulletDecorator();
            Ellipse littleEllipse2 = new Ellipse();
            littleEllipse2.Height = 10;
            littleEllipse2.Width = 20;
            littleEllipse2.Fill = Brushes.Blue;
            bdec2.Bullet = littleEllipse2;
            TextBlock tipText2 = new TextBlock();
            tipText2.Text = "Uses the ToolTipService class";
            bdec2.Child = tipText2;
            //<SnippetSetToolTip2>
            ToolTipService.SetToolTip(ellipse2, bdec2);
            //</SnippetSetToolTip2>
            stackPanel_1_2.Children.Add(ellipse2);
            //</SnippetSetToolTip>

            //</SnippetNoToolTipCode>            

        }

        //<SnippetToolTipOpenAndCloseHandler>

        //<SnippetToolTipOpeningHandler>
        void whenToolTipOpens(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            if (sender.GetType().FullName.Equals("System.Windows.Shapes.Ellipse"))
            {
                ell = (Ellipse)sender;
                ell.Fill = Brushes.Blue;
            }
            else if (sender.GetType().FullName.Equals(
                                     "System.Windows.Controls.ToolTip"))
            {
                ToolTip t = (ToolTip)sender;
                Popup p = (Popup)t.Parent;
                ell = (Ellipse)p.PlacementTarget;
                ell.Fill = Brushes.Blue;
            }
        }
        //</SnippetToolTipOpeningHandler>

        //<SnippetToolTipClosingHandler>
        void whenToolTipCloses(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            if (sender.GetType().FullName.Equals(
                              "System.Windows.Shapes.Ellipse"))
            {
                ell = (Ellipse)sender;
                ell.Fill = Brushes.Gray;
            }
            else if (sender.GetType().FullName.Equals(
                                   "System.Windows.Controls.ToolTip"))
            {
                ToolTip t = (ToolTip)sender;
                Popup p = (Popup)t.Parent;
                ell = (Ellipse)p.PlacementTarget;
                ell.Fill = Brushes.Gray;
            }
        }
        //</SnippetToolTipClosingHandler>

        //</SnippetToolTipOpenAndCloseHandler>

        private void showProperties(object sender, RoutedEventArgs e)
        {
            ttProperties.ClearValue(TextBlock.TextProperty);
            ttPropertyValues.ClearValue(TextBlock.TextProperty);
            //<SnippetGetBetweenShowDelay>
            int myInt = ToolTipService.GetBetweenShowDelay(
                         (DependencyObject)FindName("ellipse2"));
            //</SnippetGetBetweenShowDelay>
            AddTextString(ttProperties, ttPropertyValues, "BetweenShowDelay",
                          myInt.ToString());
            //<SnippetGetInitialShowDelay>
            myInt = ToolTipService.GetInitialShowDelay(
                         (DependencyObject)FindName("ellipse2"));
            //</SnippetGetInitialShowDelay>
            AddTextString(ttProperties, ttPropertyValues, "InitialShowDelay",
                          myInt.ToString());
            //<SnippetGetShowDuration>
            myInt = ToolTipService.GetShowDuration(
                          (DependencyObject)FindName("ellipse2"));
            //</SnippetGetShowDuration>
            AddTextString(ttProperties, ttPropertyValues, "ShowDuration",
                          myInt.ToString());
            //<SnippetGetHasDropShadow>
            bool myBool = ToolTipService.GetHasDropShadow(
                         (DependencyObject)FindName("ellipse2"));
            //</SnippetGetHasDropShadow>
            AddTextString(ttProperties, ttPropertyValues, "HasDropShadow",
                          myBool.ToString());
            //<SnippetGetHorizontalOffset>
            double myDouble = ToolTipService.GetHorizontalOffset(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetHorizontalOffset>
            AddTextString(ttProperties, ttPropertyValues, "HorizontalOffset",
                          myDouble.ToString());
            //<SnippetGetVerticalOffset>
            myDouble = ToolTipService.GetVerticalOffset(
                        (DependencyObject)FindName("ellipse2"));
            //</SnippetGetVerticalOffset>
            AddTextString(ttProperties, ttPropertyValues, "VerticalOffset",
                          myDouble.ToString());
            //<SnippetGetPlacement>
            PlacementMode myMode = ToolTipService.GetPlacement(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetPlacement>
            AddTextString(ttProperties, ttPropertyValues, "Placement",
                          myMode.ToString());
            //<SnippetGetPlacementRectangle>
            Rect myRect = ToolTipService.GetPlacementRectangle(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetPlacementRectangle>
            AddTextString(ttProperties, ttPropertyValues, "PlacementRectangle",
                          myRect.ToString());
            //<SnippetGetPlacementTarget>
            UIElement target = new UIElement();
            target = ToolTipService.GetPlacementTarget(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetPlacementTarget>
            if (target == null)
                AddTextString(ttProperties, ttPropertyValues, "PlacementTarget",
                          "null");
            else
                AddTextString(ttProperties, ttPropertyValues, "PlacementTarget",
                            target.ToString());
            //<SnippetGetIsDropShadow>
            myBool = ToolTipService.GetHasDropShadow(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetIsDropShadow>
            AddTextString(ttProperties, ttPropertyValues, "HasDropShadow",
                          myBool.ToString());
            //<SnippetGetIsEnabled>
            myBool = ToolTipService.GetIsEnabled(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetIsEnabled>
            AddTextString(ttProperties, ttPropertyValues, "IsEnabled",
                          myBool.ToString());
            //<SnippetGetIsOpen>
            myBool = ToolTipService.GetIsOpen(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetIsOpen>
            AddTextString(ttProperties, ttPropertyValues, "IsOpen",
                          myBool.ToString());
            //<SnippetGetShowOnDisabled>
            myBool = ToolTipService.GetShowOnDisabled(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetShowOnDisabled>
            AddTextString(ttProperties, ttPropertyValues, "ShowOnDisabled",
                          myBool.ToString());
            //<SnippetGetToolTip>
            target = (UIElement)ToolTipService.GetToolTip(
             (DependencyObject)FindName("ellipse2"));
            //</SnippetGetToolTip>
            AddTextString(ttProperties, ttPropertyValues, "ToolTip",
                          target.ToString());

        }

        private void AddTextString(TextBlock tBlock,
                                     string pName,
                                     string value)
        {
            tBlock.Text += pName + "\t" + value + "\n";
        }

        private void AddTextString(TextBlock tBlock, TextBlock vBlock,
                                     string pName,
                                     string value)
        {
            tBlock.Text += pName + "\n";
            vBlock.Text += value + "\n";
        }

    }
}