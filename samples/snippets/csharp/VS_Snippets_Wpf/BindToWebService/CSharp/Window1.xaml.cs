using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

//<SnippetNamespace>
// 1. Include the web service namespace
using BindtoContentService.com.microsoft.msdn.services;
//</SnippetNamespace>
namespace BindtoContentService
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

        // Handler for the Windows Loaded event 
        void OnLoad(object sender, RoutedEventArgs e)
        {
//<SnippetWebServiceCall>
            // 2. Set up the request object
            // To use the MSTP web service, we need to configure and send a request
            // In this example, we create a simple request that has the ID of the XmlReader.Read method page
            getContentRequest request = new getContentRequest();
            request.contentIdentifier = "abhtw0f1";

            // 3. Create the proxy
            ContentService proxy = new ContentService();

            // 4. Call the web service method and set the DataContext of the Window
            // (GetContent returns an object of type getContentResponse)
            this.DataContext = proxy.GetContent(request);
//</SnippetWebServiceCall>
        }
    }
}