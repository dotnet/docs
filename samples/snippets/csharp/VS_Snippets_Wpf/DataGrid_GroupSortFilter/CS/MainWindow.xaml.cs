// <snippet100>
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace DGGroupSortFilterExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Get a reference to the tasks collection.
            Tasks _tasks = (Tasks)this.Resources["tasks"];

            // Generate some task data and add it to the task list.
            for (int i = 1; i <= 14; i++)
            {
                _tasks.Add(new Task()
                {
                    ProjectName = "Project " + ((i % 3) + 1).ToString(),
                    TaskName = "Task " + i.ToString(),
                    DueDate = DateTime.Now.AddDays(i),
                    Complete = (i % 2 == 0)
                });
            }
        }
        
        private void UngroupButton_Click(object sender, RoutedEventArgs e)
        {
            // <snippet114>
            // <snippet102>
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
            // </snippet102>
            if (cvTasks != null)
            {
                cvTasks.GroupDescriptions.Clear();
            }
            // </snippet114>
        }
        
        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            // <snippet112>
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
            if (cvTasks != null && cvTasks.CanGroup == true)
            {
                cvTasks.GroupDescriptions.Clear();
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("ProjectName"));
                cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("Complete"));
            }
            // </snippet112>
        }
        
        private void CompleteFilter_Changed(object sender, RoutedEventArgs e)
        {
            // Refresh the view to apply filters.
            CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource).Refresh();
        }

        // <snippet113>
        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Task t = e.Item as Task;
            if (t != null)
            // If filter is turned on, filter completed items.
            {
                if (this.cbCompleteFilter.IsChecked == true && t.Complete == true)
                    e.Accepted = false;
                else
                    e.Accepted = true;
            }
        }
        // </snippet113>
    }

    [ValueConversion(typeof(Boolean), typeof(String))]
    public class CompleteConverter : IValueConverter
    {
        // This converter changes the value of a Tasks Complete status from true/false to a string value of
        // "Complete"/"Active" for use in the row group header.
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool complete = (bool)value;
            if (complete)
                return "Complete";
            else
                return "Active";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strComplete = (string)value;
            if (strComplete == "Complete")
                return true;
            else
                return false;
        }
    }

    // Task Class
    // Requires using System.ComponentModel;
    public class Task : INotifyPropertyChanged, IEditableObject
    {
        // The Task class implements INotifyPropertyChanged and IEditableObject 
        // so that the datagrid can properly respond to changes to the 
        // data collection and edits made in the DataGrid.

        // Private task data.
        private string m_ProjectName = string.Empty;
        private string m_TaskName = string.Empty;
        private DateTime m_DueDate = DateTime.Now;
        private bool m_Complete = false;

        // Data for undoing canceled edits.
        private Task temp_Task = null;
        private bool m_Editing = false;

        // Public properties. 
        public string ProjectName
        {
            get { return this.m_ProjectName; }
            set
            {
                if (value != this.m_ProjectName)
                {
                    this.m_ProjectName = value;
                    NotifyPropertyChanged("ProjectName");
                }
            }
        }

        public string TaskName
        {
            get { return this.m_TaskName; }
            set
            {
                if (value != this.m_TaskName)
                {
                    this.m_TaskName = value;
                    NotifyPropertyChanged("TaskName");
                }
            }
        }

        public DateTime DueDate
        {
            get { return this.m_DueDate; }
            set
            {
                if (value != this.m_DueDate)
                {
                    this.m_DueDate = value;
                    NotifyPropertyChanged("DueDate");
                }
            }
        }

        public bool Complete
        {
            get { return this.m_Complete; }
            set
            {
                if (value != this.m_Complete)
                {
                    this.m_Complete = value;
                    NotifyPropertyChanged("Complete");
                }
            }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Task = this.MemberwiseClone() as Task;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.ProjectName = temp_Task.ProjectName;
                this.TaskName = temp_Task.TaskName;
                this.DueDate = temp_Task.DueDate;
                this.Complete = temp_Task.Complete;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Task = null;
                m_Editing = false;
            }
        }
    }
    // <snippet101>
    // Requires using System.Collections.ObjectModel;
    public class Tasks : ObservableCollection<Task>
    {
        // Creating the Tasks collection in this way enables data binding from XAML.
    }
    // </snippet101>
}
// </snippet100>
