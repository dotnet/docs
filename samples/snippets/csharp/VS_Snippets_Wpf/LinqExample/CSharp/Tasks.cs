using System.ComponentModel;
using System.Collections.ObjectModel;

namespace LinqExample
{
    public class Task : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private int priority;
        private TaskType type;


        public event PropertyChangedEventHandler PropertyChanged;

        public Task()
        {
        }

        public Task(string name, string description, int priority, TaskType type)
        {
            this.name = name;
            this.description = description;
            this.priority = priority;
            this.type = type;
        }

        public override string ToString()
        {
            return name.ToString();
        }

        public string TaskName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("TaskName");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public TaskType TaskType
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("TaskType");
            }
        }

        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }

    public class Tasks : ObservableCollection<Task>
    {
        public Tasks()
            : base()
        {
            Add(new Task("Groceries", "Pick up Groceries and Detergent", 2, TaskType.Home));
            Add(new Task("Laundry", "Do my Laundry", 2, TaskType.Home));
            Add(new Task("Email", "Email clients", 1, TaskType.Work));
            Add(new Task("Clean", "Clean my office", 3, TaskType.Work));
            Add(new Task("Dinner", "Get ready for family reunion", 1, TaskType.Home));
            Add(new Task("Proposals", "Review new budget proposals", 2, TaskType.Work));
        }
    }

    public enum TaskType
    {
        Home,
        Work
    }
}
