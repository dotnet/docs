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
using System.IO;
using System.Xml;
using System.ComponentModel;

namespace XamlReaderWriterSnippets
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

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            ButtonRoundTripSyncStream();
        }

        public void ButtonRoundTripSyncString()
        {
            //<SnippetXamlReaderLoadXmlReader>
            // Create the Button.
            Button originalButton = new Button();
            originalButton.Height = 50;
            originalButton.Width = 100;
            originalButton.Background = Brushes.AliceBlue;
            originalButton.Content = "Click Me";
            
            // Save the Button to a string.
            string savedButton = XamlWriter.Save(originalButton);

            // Load the button
            StringReader stringReader = new StringReader(savedButton);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Button readerLoadButton = (Button)XamlReader.Load(xmlReader);
            //</SnippetXamlReaderLoadXmlReader>

            StackArea.Children.Add(readerLoadButton);

        }

        public void ButtonRoundTripSyncStream()
        {
            //<SnippetXamlReaderLoadStream>
            // Create the Button.
            Button originalButton = new Button();
            originalButton.Height = 50;
            originalButton.Width = 100;
            originalButton.Background = Brushes.AliceBlue;
            originalButton.Content = "Click Me";

            // Save the Button to a string.
            Stream savedButton = new MemoryStream();
            XamlWriter.Save(originalButton, savedButton);

            // Reset the position of the Stream.
            savedButton.Position = 0;

            // Load the button.
            Button readerLoadButton = (Button)XamlReader.Load(savedButton);
            //</SnippetXamlReaderLoadStream>

            StackArea.Children.Add(readerLoadButton);
        }

        // Not being Snippeted right now
        public void ButtonRoundTripASyncStream()
        {

            // Create the Button
            //Button originalButton = new Button();
            //originalButton.Height = 50;
            //originalButton.Width = 100;
            //originalButton.Background = Brushes.AliceBlue;
            //originalButton.Content = "Click Me";

            //// Serialize the Button to a string
            //Stream seralizedButton = new MemoryStream();
            //XamlWriter.Save(originalButton, seralizedButton);

            //// Reset the position of the Stream
            //seralizedButton.Position = 0;

            //// Load the button
            //XmlReader xmlReasder = XmlReader.Create("F:\\Test\\seralizedButton.xaml");
            //XamlReader xReader= new XamlReader();

            //Button deserializedButton = (Button)xReader.LoadAsync(xmlReasder);


            //this.Background = Brushes.AliceBlue;
            //StackArea.Children.Add(deserializedButton);
        }

        private void xReader_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled != true)
            {
                // Load new button

            }
        }
        private void OnSerializeChecked(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            if (source != null)
            {
                switch (source.Name)
                {
                    case "RB1":
                        ButtonRoundTripSyncString();
                        break;
                    case "RB2":
                        ButtonRoundTripSyncStream();
                        break;
                    case "RB3":

                        break;
                    case "RB4":
                        ButtonRoundTripASyncStream();
                        break;
                    default:
                        break;

                }
            }
        }
    }
}