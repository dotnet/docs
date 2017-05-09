using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Graphics.UsingImageBrush
{
    /// <summary>
    /// Interaction logic for TextFillsExample.xaml
    /// </summary>

    public partial class InteractiveExample : Page
    {
      RadioButton selectedButton = null;

        public InteractiveExample()
        {

            
        }

        private void InteractiveExampleLoaded(object sender, RoutedEventArgs args)
        {

          loadInteractiveMenus();
          MyDefaultImageButton.IsChecked = true;
          
        }
  

        // Initializes the image brush menu options.
        private void loadInteractiveMenus()
        {
            string[] values;
            
            
            values = Enum.GetNames(typeof(Stretch));
            foreach (string stretchMode in values)
                stretchSelector.Items.Add(stretchMode);
            stretchSelector.SelectedItem = myImageBrush.Stretch.ToString();

            values = Enum.GetNames(typeof(System.Windows.Media.AlignmentX));
            foreach (string hAlign in values)
                horizontalAlignmentSelector.Items.Add(hAlign);
            horizontalAlignmentSelector.SelectedItem = myImageBrush.AlignmentX.ToString();

            values = Enum.GetNames(typeof(System.Windows.Media.AlignmentY));
            foreach (string vAlign in values)
                verticalAlignmentSelector.Items.Add(vAlign);
            verticalAlignmentSelector.SelectedItem = myImageBrush.AlignmentY.ToString();

            values = Enum.GetNames(typeof(TileMode));
            foreach (string tileMode in values)
                tileSelector.Items.Add(tileMode);
            tileSelector.SelectedItem = myImageBrush.TileMode.ToString();

            values = Enum.GetNames(typeof(BrushMappingMode));
            foreach (string mappingMode in values)
            {
                viewportUnitsSelector.Items.Add(mappingMode);
                viewboxUnitsSelector.Items.Add(mappingMode);
            }
            viewportUnitsSelector.SelectedItem = myImageBrush.ViewportUnits.ToString();
            viewboxUnitsSelector.SelectedItem = myImageBrush.ViewboxUnits.ToString();
            viewportEntry.Text = myImageBrush.Viewport.ToString();
            viewboxEntry.Text = myImageBrush.Viewbox.ToString();
        
        }

        private void setSelectedButton(object sender, RoutedEventArgs args)
        {
            this.selectedButton = sender as RadioButton;
        }
      
        // Applies the selected options to the image brush.
        private void updateBrush(object sender, RoutedEventArgs args)
        {
            try
            {

                myImageBrush.ImageSource = (this.selectedButton.Content as Image).Source;
                myImageBrush.Stretch = (Stretch)Enum.Parse(typeof(Stretch), (string)stretchSelector.SelectedItem);
                myImageBrush.AlignmentX = (System.Windows.Media.AlignmentX)Enum.Parse(typeof(System.Windows.Media.AlignmentX), (string)horizontalAlignmentSelector.SelectedItem);
                myImageBrush.AlignmentY = (System.Windows.Media.AlignmentY)Enum.Parse(typeof(System.Windows.Media.AlignmentY), (string)verticalAlignmentSelector.SelectedItem);
                myImageBrush.TileMode = (TileMode)Enum.Parse(typeof(TileMode), (string)tileSelector.SelectedItem);
                myImageBrush.ViewportUnits = (BrushMappingMode)Enum.Parse(typeof(BrushMappingMode), (string)viewportUnitsSelector.SelectedItem);
                myImageBrush.ViewboxUnits = (BrushMappingMode)Enum.Parse(typeof(BrushMappingMode), (string)viewboxUnitsSelector.SelectedItem);
                
                RectConverter myRectConverter = new RectConverter();
                string parseString;
                parseString = viewportEntry.Text;
               
                if (parseString != null && parseString != string.Empty)
                    myImageBrush.Viewport = (Rect)myRectConverter.ConvertFromString(parseString);
                else
                {
                    myImageBrush.Viewport = Rect.Empty;
                    viewportEntry.Text = "Empty";
                }

                parseString = viewboxEntry.Text;
                
                if (parseString != null && parseString != string.Empty && parseString.ToLower() != "(auto)")
                    myImageBrush.Viewbox = (Rect)myRectConverter.ConvertFromString(parseString);
                else
                {
                    viewboxEntry.Text = "Empty";
                    myImageBrush.Viewbox = Rect.Empty;
                }
                
                
            }
            catch (InvalidOperationException invalidOpEx)
            {
                MessageBox.Show("Invalid Viewport or Viewbox. " + invalidOpEx.ToString());
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Invalid Viewport or Viewbox. " + formatEx.ToString());
            }

        }

    }
}