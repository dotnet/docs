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
    RotatingStrokesAdorner _adorner;
    AdornerLayer _adornerLayer;

    public Window1()
    {
        InitializeComponent();
    }

    //<Snippet3>
    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Add the rotating strokes adorner to the InkPresenter.
        _adornerLayer = AdornerLayer.GetAdornerLayer(InkPresenter1);
        _adorner = new RotatingStrokesAdorner(InkPresenter1);

        _adornerLayer.Add(_adorner);
    }
    //</Snippet3>
}
