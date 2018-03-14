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


namespace TabControlContentTemplateSelector
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void infoBtn_Click(object sender, RoutedEventArgs e)
         {
            //<Snippet4>
            if (tabCtrl1.SelectedContent is Person)
            {
                Person selectedPerson = tabCtrl1.SelectedContent as Person;
                StringBuilder personInfo = new StringBuilder();

                personInfo.Append(selectedPerson.FirstName);
                personInfo.Append(" ");
                personInfo.Append(selectedPerson.LastName);
                personInfo.Append(", ");
                personInfo.Append(selectedPerson.HomeTown);
                MessageBox.Show(personInfo.ToString());
            }
            //</Snippet4>
        }

    }

    //<Snippet3>
    public class PersonTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            // The content of each TabItem is a Person object.
            if (item is Person)
            {
                Person person = item as Person;

                Window win = Application.Current.MainWindow;

                // Select one of the DataTemplate objects, based on the 
                // person's home town.
                if (person.HomeTown == "Seattle")
                {
                    return win.FindResource("SeattleTemplate") as DataTemplate;
                }
                else
                {
                    return win.FindResource("DetailTemplate") as DataTemplate;

                }
            }

            return null;
        }

    }
    //</Snippet3>
}