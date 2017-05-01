using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

public partial class CustomContentPage : Page, IProvideCustomContentState
{
    DateTime dateTime = DateTime.Now;

    public CustomContentPage()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(CustomContentPage_Loaded);
    }

    void CustomContentPage_Loaded(object sender, RoutedEventArgs e)
    {
        this.textBlockLabel.Text = this.dateTime.ToString();
    }

    void addBackEntryButton_Click(object sender, RoutedEventArgs e)
    {
        this.NavigationService.AddBackEntry(new MyCustomContentState(this.textBlockLabel.Text, this.textBlockLabel));
        this.dateTime = DateTime.Now;
        this.textBlockLabel.Text = this.dateTime.ToString();
    }

    #region IProvideCustomContentState Members

    // Called when AddBackEntry(null) is called, and when a journal
    // navigation takes place (either via navigation chrome, or custom 
    // navigation buttons)
    public CustomContentState GetContentState()
    {
        return new MyCustomContentState(this.textBlockLabel.Text, this.textBlockLabel);
    }

    #endregion
}