using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>

public partial class Window1 : Window
{
    RotatingStrokesAdorner adorner;
    AdornerLayer adornerLayer;

    public Window1()
    {
        InitializeComponent();
    }

    //<Snippet3>
    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Add the rotating strokes adorner to the InkPresenter.
        adornerLayer = AdornerLayer.GetAdornerLayer(inkPresenter1);
        adorner = new RotatingStrokesAdorner(inkPresenter1);

        adornerLayer.Add(adorner);
    }
    //</Snippet3>
}
