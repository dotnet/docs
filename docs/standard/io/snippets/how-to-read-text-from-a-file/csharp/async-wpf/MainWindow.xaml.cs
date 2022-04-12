using System.IO;
using System.Windows;

namespace TextFiles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            using (var sr = new StreamReader("TestFile.txt"))
            {
                ResultBlock.Text = await sr.ReadToEndAsync();
            }
        }
        catch (FileNotFoundException ex)
        {
            ResultBlock.Text = ex.Message;
        }
    }
}
