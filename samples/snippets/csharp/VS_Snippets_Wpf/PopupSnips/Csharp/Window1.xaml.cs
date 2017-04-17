using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace PopupSnips
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }



    private void PopupAdjust(object sender, EventArgs e)
    {
      //<SnippetIsOpen>
        myPopupIsOpen.IsOpen = true;
        //</SnippetIsOpen>
  
        //<SnippetPopupPosition>
        Popup myPopup = new Popup();
        myPopup.PlacementTarget = myEllipse;
        myPopup.PlacementRectangle = new Rect(0, 0, 30, 50);
        myPopup.VerticalOffset = 20;
        myPopup.HorizontalOffset = 20;
        myPopup.Placement = PlacementMode.Bottom;
        myPopup.PopupAnimation = PopupAnimation.Fade;
        myPopup.AllowsTransparency = true;
        TextBlock popupText = new TextBlock();
        popupText.Background = Brushes.Beige;
        popupText.FontSize = 12;
        popupText.Width = 75;
        popupText.TextWrapping = TextWrapping.Wrap;
        myPopup.Child = popupText;
        //</SnippetPopupPosition>

      //<SnippetChild>
        Popup myPopupWithText = new Popup();
        TextBlock textBlock = new TextBlock();
        textBlock.Text = "Popup Text";
        textBlock.Background = Brushes.Yellow;
        myPopupWithText.Child = textBlock;
        myStackPanel.Children.Add(myPopup);
       //</SnippetChild>

        LengthConverter myPopupLengthConverter = new LengthConverter();
       //<SnippetAllowsTransparency>
        myPopup.AllowsTransparency = true;
       //</SnippetAllowsTransparency>

        //<SnippetHorizontalVerticalOffset>
        myPopup.HorizontalOffset =
          (Double)myPopupLengthConverter.ConvertFromString(".5cm");
        myPopup.VerticalOffset =
          (Double)myPopupLengthConverter.ConvertFromString(".1cm");
        //</SnippetHorizontalVerticalOffset>

	//<SnippetHasDropShadow>
        bool hasDropShadow = myPopup.HasDropShadow;
        //</SnippetHasDropShadow>

        TextBlock myTextBlock = new TextBlock();
        myTextBlock.Text = "Special TextBlock";
        myTextBlock.Background = Brushes.Orange;
        myTextBlock.Height = 20;

        Popup myTextBlockPopup = new Popup();
        TextBlock popupDescription = new TextBlock();
        popupDescription.Background = Brushes.Coral;
        popupDescription.Text = "Special Popup Text"; 

        //<SnippetPlacement>
        myTextBlockPopup.PlacementTarget = myTextBlock;
        myTextBlockPopup.PlacementRectangle = new Rect(0, 0, 30, 40);
        myTextBlockPopup.Placement = PlacementMode.Center;
        myTextBlockPopup.Child = popupDescription;
        myTextBlockPopup.IsOpen = true;
        //</SnippetPlacement>

       //<SnippetAnimation>
       myTextBlockPopup.PopupAnimation = PopupAnimation.Fade;
       //</SnippetAnimation>
  

       //<SnippetStaysOpen>
       myTextBlockPopup.StaysOpen = true;
       //</SnippetStaysOpen>
        myStackPanel.Children.Add(myTextBlock);

     }

      
      //<SnippetClosed>
      private void PopupClosing(object sender, EventArgs e)
      {
          //Code to execute when Popup closes
      }
      //</SnippetClosed>

      //<SnippetOpened>
      private void PopupOpening(object sender, EventArgs e)
      {
          //Code to execute when Popup opens
      }
      //</SnippetOpened>
   }
}