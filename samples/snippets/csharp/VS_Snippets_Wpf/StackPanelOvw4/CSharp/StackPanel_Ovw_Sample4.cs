using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace SDKSample
{
    public class app : Application
    {
        Border myBorder;
        Grid myGrid;
        StackPanel myStackPanel;
        DockPanel myDockPanel;
        Window mainWindow;
        
        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow ()
        {
            // <Snippet1>

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "StackPanel vs. DockPanel";

            // Add root Grid
            myGrid = new Grid();
            myGrid.Width = 175;
            myGrid.Height = 150;
            RowDefinition myRowDef1 = new RowDefinition();
            RowDefinition myRowDef2 = new RowDefinition();
            myGrid.RowDefinitions.Add(myRowDef1);
            myGrid.RowDefinitions.Add(myRowDef2);

            // Define the DockPanel
            myDockPanel = new DockPanel();
            Grid.SetRow(myDockPanel, 0);

            //Define an Image and Source
            Image myImage = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("smiley_stackpanel.png", UriKind.Relative);
            bi.EndInit();
            myImage.Source = bi;

            Image myImage2 = new Image();
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri("smiley_stackpanel.png", UriKind.Relative);
            bi2.EndInit();
            myImage2.Source = bi2;
            
            // <Snippet3>
            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("smiley_stackpanel.PNG", UriKind.Relative);
            bi3.EndInit();
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = bi3;
            //</Snippet3>

            // Add the images to the parent DockPanel
            myDockPanel.Children.Add(myImage);
            myDockPanel.Children.Add(myImage2);
            myDockPanel.Children.Add(myImage3);

            //Define a StackPanel
            myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Horizontal;
            Grid.SetRow(myStackPanel, 1);

            Image myImage4 = new Image();
            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri("smiley_stackpanel.png", UriKind.Relative);
            bi4.EndInit();
            myImage4.Source = bi4;

            Image myImage5 = new Image();
            BitmapImage bi5 = new BitmapImage();
            bi5.BeginInit();
            bi5.UriSource = new Uri("smiley_stackpanel.png", UriKind.Relative);
            bi5.EndInit();
            myImage5.Source = bi5;

            Image myImage6 = new Image();
            BitmapImage bi6 = new BitmapImage();
            bi6.BeginInit();
            bi6.UriSource = new Uri("smiley_stackpanel.PNG", UriKind.Relative);
            bi6.EndInit();
            myImage6.Stretch = Stretch.Fill;
            myImage6.Source = bi6;

            // Add the images to the parent StackPanel
            myStackPanel.Children.Add(myImage4);
            myStackPanel.Children.Add(myImage5);
            myStackPanel.Children.Add(myImage6);

            // Add the layout panels as children of the Grid
            myGrid.Children.Add(myDockPanel);
            myGrid.Children.Add(myStackPanel);
            
            // Add the Grid as the Content of the Parent Window Object
            mainWindow.Content = myGrid;
            mainWindow.Show ();

            //</Snippet1>
        }
    }

    // Define a static entry class
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            app app = new app ();
            app.Run ();
        }
    }
}