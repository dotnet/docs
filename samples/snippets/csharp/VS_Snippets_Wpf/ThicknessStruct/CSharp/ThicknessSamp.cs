using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace SDKSample
{
    public class MyApp : System.Windows.Application
    {
        Border myBorder1;
        Border myBorder2;
        Thickness myThickness;
        Canvas myCanvas;
        Window mainWindow;

    protected override void OnStartup (StartupEventArgs e)
    {
        base.OnStartup (e);
        CreateAndShowMainWindow ();
    }
        
    private void CreateAndShowMainWindow ()
    {
        // Create the application's main window
        mainWindow = new Window ();

        // <Snippet1>
        myBorder1 = new Border();
        myBorder1.BorderBrush = Brushes.SlateBlue;
        myBorder1.BorderThickness = new Thickness(5, 10, 15, 20);
        myBorder1.Background = Brushes.AliceBlue;
        myBorder1.Padding = new Thickness(5);
        myBorder1.CornerRadius = new CornerRadius(15);
        //</Snippet1>

        myCanvas = new Canvas();
        myCanvas.Background = Brushes.LightSteelBlue;
        myBorder1.Child = myCanvas;

        // <Snippet2>
        myBorder2 = new Border();
        myBorder2.BorderBrush = Brushes.SteelBlue;
        myBorder2.Width = 400;
        myBorder2.Height = 400;
        myThickness = new Thickness();
        myThickness.Bottom = 5;
        myThickness.Left = 10;
        myThickness.Right = 15;
        myThickness.Top = 20;
        myBorder2.BorderThickness = myThickness;
        //</Snippet2>

        myCanvas.Children.Add(myBorder2);
        Canvas.SetLeft(myBorder2, 100);
        Canvas.SetTop(myBorder2, 100);

        mainWindow.Content = myBorder1;
        mainWindow.Title = "Thickness Sample";
        mainWindow.Show();
    }
}

    internal static class EntryClass
    {
        [System.STAThread()]
            private static void Main ()
                {
                    MyApp app = new MyApp ();
                    app.Run ();
                }
    }
}