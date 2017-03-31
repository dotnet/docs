using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ContentStringSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
    }

    //<SnippetGroupStyleData>
    // The converter to group the items.
    public class GroupByPrice : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              System.Globalization.CultureInfo culture)
        {

            if (!(value is double))
            {
                return null;
            }

            double itemPrice = (double)value;

            if (itemPrice < 100)
            {
                return 100;
            }

            if (itemPrice < 250)
            {
                return 250;
            }

            if (itemPrice < 500)
            {
                return 500;
            }

            return 1000;



        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // The type of objects that are added to the ItemsControl.
    public class PurchaseItem 
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime OfferExpires { get; set; }

        public PurchaseItem()
        {
        }

        public PurchaseItem(string desc, double price, DateTime endDate)
        {
            Description = desc;
            Price = price;
            OfferExpires = endDate;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1:c}, {2:D}", Description, Price, OfferExpires);
        }
    }

    // The source of the ItemsControl.
    public class ItemsForSale : ObservableCollection<PurchaseItem>
    {

        public ItemsForSale()
        {
            Add((new PurchaseItem("Snowboard and bindings", 120, new DateTime(2009, 1, 1))));
            Add((new PurchaseItem("Inside C#, second edition", 10, new DateTime(2009, 2, 2))));
            Add((new PurchaseItem("Laptop - only 1 year old", 499.99, new DateTime(2009, 2, 28))));
            Add((new PurchaseItem("Set of 6 chairs", 120, new DateTime(2009, 2, 28))));
            Add((new PurchaseItem("My DVD Collection", 15, new DateTime(2009, 1, 1))));
            Add((new PurchaseItem("TV Drama Series", 39.985, new DateTime(2009, 1, 1))));
            Add((new PurchaseItem("Squash racket", 60, new DateTime(2009, 2, 28))));

        }

    }
    //</SnippetGroupStyleData>

    //TabControl.ContentStringFormat
    #region TabControlData
    public class Student : IFormattable
    {

        public string Name { get; set; }
        ObservableCollection<Course> Courses { get; set; }

        public Student()
            : this("")
        {

        }

        public Student(string name)
        {
            Name = name;
            Courses = new ObservableCollection<Course>();
        }

        // Add a course to the student's schedule.
        public void AddCourse(string name, int id, string desc)
        {
            Courses.Add(new Course(name, id, desc));
        }

        //<SnippetTabControlToString>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            // 'n': print the name only.
            if (format == "n")
            {
                return Name;
            }

            // 'cl': print the course list.
            if (format == "cl")
            {
                string stringFormat = "{0,-25}{1,-30}{2,-10}\r\n";

                StringBuilder str = new StringBuilder();

                str.AppendLine(); 
                str.AppendFormat(stringFormat, "Title", "Description", "ID");
                str.AppendLine(); 

                foreach (Course c in Courses)
                {
                    str.AppendFormat(stringFormat, c.Title, c.Description, c.SectionID);
                }
        
                return str.ToString();
            }

            return this.ToString();
        }
        //</SnippetTabControlToString>
    }

    public class Course
    {
        public string Title { get; set; }
        public int SectionID { get; set; }
        public string Description { get; set; }

        public Course()
        {
        }

        public Course(string title, int section, string desc)
        {
            Title = title;
            SectionID = section;
            Description = desc;
        }
    }

    public class Students : ObservableCollection<Student>
    {
        public Students()
        {
            Student s1 = new Student("Sunil Uppal");
            s1.AddCourse("Calculus 303", 19, "Advanced Calculus");
            s1.AddCourse("History 110", 35, "Introduction to World History");
            s1.AddCourse("Psychology 110", 40, "Behavioral Psychology");
            s1.AddCourse("Physical Education 204", 80, "Racquetball");
            this.Add(s1);

            Student s2 = new Student("Alice Ciccu");
            s2.AddCourse("English 200", 50, "Advanced Composition");
            s2.AddCourse("English 315", 100, "Shakespear's Sonnets");
            s2.AddCourse("History 230", 38, "European History 1000-1500");
            this.Add(s2);


            Student s3 = new Student("Jeff Price");
            s3.AddCourse("History 230", 38, "European History 1000-1500");
            s3.AddCourse("History 110", 35, "Introduction to World History");
            s3.AddCourse("Physical Education 204", 80, "Racquetball");
            this.Add(s3);


        }
    }

    #endregion
}
