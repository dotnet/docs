using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Input;

namespace InkCanvasEditingModeSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    //<Snippet1>
    public partial class Window1 : Window
    {
        RadioButton inkEditingMode;
        RadioButton selectEditingMode;
        RadioButton eraseByStrokeEditingMode;
        RadioButton eraseByPointEditingMode;

        InkCanvas inkCanvas1;

        StackPanel stackPanel1;

        DockPanel root;

        public Window1()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            root = new DockPanel();
            this.Content = root;

            stackPanel1 = new StackPanel();
            root.Children.Add(stackPanel1);

            inkEditingMode = new RadioButton();
            inkEditingMode.Content = "Ink";
            stackPanel1.Children.Add(inkEditingMode);
            inkEditingMode.Click += new RoutedEventHandler(inkEditingMode_Click);
            inkEditingMode.IsChecked = true;

            selectEditingMode = new RadioButton();
            selectEditingMode.Content = "Select";
            stackPanel1.Children.Add(selectEditingMode);
            selectEditingMode.Click += new RoutedEventHandler(selectEditingMode_Click);

            eraseByStrokeEditingMode = new RadioButton();
            eraseByStrokeEditingMode.Content = "Erase by Stroke";
            stackPanel1.Children.Add(eraseByStrokeEditingMode);
            eraseByStrokeEditingMode.Click += new RoutedEventHandler(eraseByStrokeEditingMode_Click);

            eraseByPointEditingMode = new RadioButton();
            eraseByPointEditingMode.Content = "Erase by Point";
            stackPanel1.Children.Add(eraseByPointEditingMode);
            eraseByPointEditingMode.Click += new RoutedEventHandler(eraseByPointEditingMode_Click);

            inkCanvas1 = new InkCanvas();
            root.Children.Add(inkCanvas1);
        }

        void eraseByPointEditingMode_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        void eraseByStrokeEditingMode_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        void selectEditingMode_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.EditingMode = InkCanvasEditingMode.Select;
        }

        void inkEditingMode_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
        }
    }
    //</Snippet1>
}