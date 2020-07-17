using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace TreeViewDataBinding
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

        //<Snippet5>
        private void SelectedNewspaperChanged(object sender,
                             RoutedPropertyChangedEventArgs<Object> e)
        {

            EnglishNewspaper engnews = EnglishNewspapers.SelectedItem as EnglishNewspaper;
            if( engnews != null ) NewspaperFrame.Navigate(new System.Uri(engnews.Website));
        }
        //</Snippet5>
    }

    //<Snippet3>
    public class EnglishNewspaper
    {
        private string _name;
        private string _website;

        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public EnglishNewspaper(string name, string website)
        {
            Name = name;
            Website = website;
        }
    }
    //</Snippet3>

    //<Snippet4>
    public class EasternHemisphereNewspapers :
              ObservableCollection<EnglishNewspaper>
    {
        public EasternHemisphereNewspapers()
        {
            Add(new EnglishNewspaper("SofiaEcho(Bulgaria)",
                                     "http://www.sofiaecho.com/"));
            Add(new EnglishNewspaper("India Times(India)",
                                     "http://www.indiatimes.com"));
            Add(new EnglishNewspaper("Aftenposten(Norway)",
                                     "http://www.aftenposten.no/english/"));
        }
    }

    public class WesternHemisphereNewspapers :
           ObservableCollection<EnglishNewspaper>
    {
        public WesternHemisphereNewspapers()
        {
            Add(new EnglishNewspaper("Buenos Aires Herald (Argentina)",
                                     "http://www.buenosairesherald.com/"));
            Add(new EnglishNewspaper("Tico Times (Central America)",
                                     "http://www.ticotimes.net/"));
            Add(new EnglishNewspaper("New York Times (United States)",
                                     "http://www.nytimes.com"));
        }
    }
    //</Snippet4>
}