//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace SliderExample
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

    public partial class Pane1 : StackPanel
    {
        public Pane1()
        {
            InitializeComponent();

            CreateBasicSlider();
            CreateSelectionRangeSlider();
        }
 
        void CreateBasicSlider()
        {
        //<SnippetBasic>
            Slider hslider = new Slider();
            hslider.Width = 100;
            hslider.Orientation = Orientation.Horizontal;
            hslider.IsSnapToTickEnabled = true;
            hslider.Minimum = 1;
            hslider.Maximum = 20;
            hslider.TickPlacement = TickPlacement.Both;
            hslider.TickFrequency = 2;
            hslider.AutoToolTipPlacement =
              AutoToolTipPlacement.BottomRight;
            cv1.Children.Add(hslider);
         //</SnippetBasic> 
       }

        void CreateSelectionRangeSlider()
        {
        //<SnippetSelectionRange>
            Slider hslider = new Slider();
            hslider.Orientation = Orientation.Horizontal;
            hslider.Width = 100;
            hslider.Minimum = 1;
            hslider.Maximum = 10;
            hslider.IsDirectionReversed = true;
            hslider.IsMoveToPointEnabled = true;
            hslider.AutoToolTipPrecision = 2;
            hslider.AutoToolTipPlacement =
              AutoToolTipPlacement.BottomRight;
            hslider.TickPlacement = TickPlacement.BottomRight;

            // Manually add ticks to the slider.
            DoubleCollection tickMarks = new DoubleCollection();
            tickMarks.Add(0.5);
            tickMarks.Add(1.5);
            tickMarks.Add(2.5);
            tickMarks.Add(3.5);
            tickMarks.Add(4.5);
            tickMarks.Add(5.5);
            tickMarks.Add(6.5);
            tickMarks.Add(7.5);
            tickMarks.Add(8.5);
            tickMarks.Add(9.5);
            hslider.Ticks = tickMarks;

            // Create a selection range.
            hslider.IsSelectionRangeEnabled = true;
            hslider.SelectionStart = 2.5;
            hslider.SelectionEnd = 7.5;
            cv2.Children.Add(hslider);
        //</SnippetSelectionRange>   
       }
     }
}