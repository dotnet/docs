using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupBoxExample
{
  /// <summary>
  /// Interaction logic for Page1.xaml
  /// </summary>

  public partial class Page1 : Page
  {

    //<Snippet2>
    private void displayData()
    {
      ListBoxItem lbi = empName.SelectedItem as ListBoxItem;
      emp.Text = "Name: " + lbi.Content.ToString();
      lbi = job.SelectedItem as ListBoxItem;
      ejob.Text = "Job: " + lbi.Content.ToString();
      lbi = skills.SelectedItem as ListBoxItem;
      eskill.Text = "Strongest Skill: " + lbi.Content.ToString();
    }
//<SnippetFEIsLoaded>   
    private void OnLoad(object sender, RoutedEventArgs e)
    {
        displayData();
    }
    private void updateSummary(object sender, RoutedEventArgs e)
    {
        if (GroupBoxPage.IsLoaded)
            displayData();
    }
//</SnippetFEIsLoaded>
    private void goToSummaryTab(object sender, RoutedEventArgs e)
    {
        displayData();
        Summary.IsSelected = true;
    }
    //</Snippet2>
  }
}