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
using System.Windows.Markup;

namespace SDKSamples
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

        private void OnLoaded(object sender, EventArgs e)
        {
            //  MessageBox.Show(TheBook.Title);

            //XmlnsDictionary dictionary = new XmlnsDictionary();
            //dictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            //dictionary.Add("custom", "NamespaceForCustomElements");

            //ParserContext pContext = new ParserContext();
            //XamlTypeMapper xMapper = pContext.XamlTypeMapper;

            //NamespaceMapEntry mapEntry = new NamespaceMapEntry();
            //mapEntry.AssemblyName = "blah";
            //mapEntry.ClrNamespace = "blah";
            //mapEntry.XmlNamespace = "blah";

            //<SnippetMarkupKeyboardNavigationTabNavigationCODE>
            Menu navigationMenu = new Menu();
            MenuItem item1 = new MenuItem();
            MenuItem item2 = new MenuItem();
            MenuItem item3 = new MenuItem();
            MenuItem item4 = new MenuItem();

            navigationMenu.Items.Add(item1);
            navigationMenu.Items.Add(item2);
            navigationMenu.Items.Add(item3);
            navigationMenu.Items.Add(item4);

            KeyboardNavigation.SetTabNavigation(navigationMenu,
                KeyboardNavigationMode.Cycle);
            //</SnippetMarkupKeyboardNavigationTabNavigationCODE>

            navigationMenu.Height = 50;
            item1.Header = "item1";
            item2.Header = "item2";
            item3.Header = "item3";
            item4.Header = "item4";
            navigationMenu.Background = Brushes.AliceBlue;
            navigationMenu.Focusable = true;
            MainStack.Children.Add(navigationMenu);

            Keyboard.Focus(item1);
        }
    }

    //<SnippetMarkupRuntimeNamePropertyAttribute>
    [RuntimeNameProperty("BookID")]
    public class Book
    {
        public Book()
        {
        }

        public string BookID
        {
            get { return _bookID; }
            set { _bookID = value; }
        }

        private string _bookID = string.Empty;
    }
    //</SnippetMarkupRuntimeNamePropertyAttribute>

    //<SnippetMarkupContentPropertyAttribute>
    [ContentProperty("Title")]
    public class Film
    {
        public Film()
        {
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _title;
    }
    //</SnippetMarkupContentPropertyAttribute>

    //<SnippetMarkupXmlLanguageProperty>
    [XmlLangProperty("Language")]
    public class MyElement : UIElement
    {
        public MyElement()
        {
        }

        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        private string _language;
    }
    //</SnippetMarkupXmlLanguageProperty>
}
