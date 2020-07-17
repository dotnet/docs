using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        void OnLoad(object sender, RoutedEventArgs e)
        {
            //<SnippetListViewView>
            ListView myListView = new ListView();
            //<SnippetGridViewColumn>

            //<SnippetGridViewAllowsColumnReorder>
            GridView myGridView = new GridView();
            myGridView.AllowsColumnReorder = true;
            myGridView.ColumnHeaderToolTip = "Employee Information";
            //</SnippetGridViewAllowsColumnReorder>

            //<SnippetGridViewColumnProperties>
            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("FirstName");
            gvc1.Header = "FirstName";
            gvc1.Width = 100;
            //</SnippetGridViewColumnProperties>
            myGridView.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("LastName");
            gvc2.Header = "Last Name";
            gvc2.Width = 100;
            myGridView.Columns.Add(gvc2);
            //<SnippetAddToColumns>
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("EmployeeNumber");
            gvc3.Header = "Employee No.";
            gvc3.Width = 100;
            myGridView.Columns.Add(gvc3);
            //</SnippetAddToColumns>

            //</SnippetGridViewColumn>
            //ItemsSource is ObservableCollection of EmployeeInfo objects
            myListView.ItemsSource = new myEmployees();
            myListView.View = myGridView;
            myStackPanel.Children.Add(myListView);
            //</SnippetListViewView>
        }

        private void LastNameCM_Click(object sender, RoutedEventArgs e)
        {
            // handle ascending/descending last name context menu choices
        }
    }

    public class EmployeeInfo
    {
        private string _firstName;
        private string _lastName;
        private string _employeeNumber;

        public string FirstName
        {
            get {return _firstName;}
            set {_firstName = value;}
        }

        public string LastName
        {
            get {return _lastName;}
            set {_lastName = value;}
        }

        public string EmployeeNumber
        {
            get {return _employeeNumber;}
            set {_employeeNumber = value;}
        }

        public EmployeeInfo(string firstname, string lastname, string empnumber)
        {
            _firstName = firstname;
            _lastName = lastname;
            _employeeNumber = empnumber;
        }
    }
    public class myEmployees :
            ObservableCollection<EmployeeInfo>
    {
        public myEmployees()
        {
            Add(new EmployeeInfo("Jesper", "Aaberg", "12345"));
            Add(new EmployeeInfo("Dominik", "Paiha", "98765"));
            Add(new EmployeeInfo("Yale", "Li", "23875"));
            Add(new EmployeeInfo("Muru", "Subramani", "49392"));
        }
    }
}