using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TabControlContentTemplateSelector
{
    // Create a class that represents a person.  
    // This class contains a person's first name, last name, 
    // and home town.
    public class Person : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string hometown;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
        }

        public Person(string first, string last, string town)
        {
            this.firstname = first;
            this.lastname = last;
            this.hometown = town;
        }

        public override string ToString()
        {
            return firstname.ToString();
        }

        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        public string HomeTown
        {
            get { return hometown; }
            set
            {
                hometown = value;
                OnPropertyChanged("HomeTown");
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

    // Create a collection of Person objects.
    public class People : ObservableCollection<Person>
    {
        public People()
            : base()
        {
            Add(new Person("Michael", "Alexander", "Boston"));
            Add(new Person("Timothy", "Sneath", "Seattle"));
            Add(new Person("Christina", "Lee", "New York"));
            Add(new Person("Samantha", "Smith", "Seattle"));
            Add(new Person("Jeff", "Hay", "Los Angeles"));
        }
    }
}
