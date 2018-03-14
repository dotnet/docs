using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Foo
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        MyData myDataObject;
        //<SnippetBringIntoViewRectCode>
        void GoToLake(object sender, RoutedEventArgs e)
        {
            mapframe.BringIntoView(new Rect(800, 400, 200, 200));
        }
        //</SnippetBringIntoViewRectCode>

        void BuildAndAdd(object sender, EventArgs e)
        {
            //<SnippetSetBindingPath>
            myDataObject = new MyData(System.DateTime.Now);
            root.DataContext = myDataObject;
            myText.SetBinding(TextBlock.TextProperty, "MyDataProperty");
            //</SnippetSetBindingPath>
        }
        //<SnippetFETryFindResource>
        void TryFind(object sender, RoutedEventArgs e)  {
            Button b = e.Source as Button;
            b.Background = (Brush)b.TryFindResource("customBrush");
        }    
        //</SnippetFETryFindResource>
        
     }

     public class MyData: INotifyPropertyChanged
     {
        private string _myDataProperty;

        public MyData(DateTime adate)
        {
           _myDataProperty = "Last bound time was " + adate.ToLongTimeString();
        }

        public String MyDataProperty
        {
            get {return _myDataProperty;}
            set {
                _myDataProperty = value;
                OnPropertyChanged("MyDataProperty");
            }
        }

        // Declare event
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        // OnPropertyChanged event handler to update property value in binding
        private void OnPropertyChanged(string info)
        {
          if (PropertyChanged !=null)
          {
            PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(info));
          }
        }
    }
}