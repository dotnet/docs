using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Collections;

namespace ResourcesSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            Button button = new Button();
            button.Content = "Click Me";
            button.Click += delegate
            {
                //// default is absolute
                //Uri relativeUri = new Uri("/Subfolder/LooseResource.bmp", UriKind.Relative);
                Uri bob = new Uri("pack://application:,,,/EmbeddedResource.bmp");

                //// For embedded resource
                ////StreamResourceInfo info = Application.GetResourceStream(relativeUri);

                // For loose resource
                //StreamResourceInfo info = Application.GetContentStream(bob);

                //// For resources at the site of origin
                //StreamResourceInfo info = Application.GetRemoteStream(relativeUri);

                //this.Title = info.ContentType;

                //<SnippetEnumerateAndListWPFEmbeddedResources>
                //// Enumerate and list all WPF embedded resources
                //Assembly asm = Assembly.GetExecutingAssembly();
                //string resourceName = asm.GetName().Name + ".g";
                //ResourceManager rm = new ResourceManager(resourceName, asm);
                //ResourceSet resourceSet = rm.GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true);
                //foreach (DictionaryEntry resource in resourceSet)
                //{
                //    Console.WriteLine("Key:" + resource.Key.ToString());
                //}
                //rm.ReleaseAllResources();
                //</SnippetEnumerateAndListWPFEmbeddedResources>

                //Page page = new Page();
                ////object bob = new object();
                //page = (Page)Application.LoadComponent(new Uri("Page2.xaml", UriKind.Relative));
                ////Application.LoadComponent(page, new Uri("Page2.xaml", UriKind.Relative));
                //this.Content = page;
            };
            this.Content = button;

            //// Absolute embedded resource
            //Uri uri = new Uri("pack://application:,,,/EmbeddedResource.bmp"); // Works
            //Uri uri = new Uri("pack://application:,,,/EmbeddedResource.bmp", UriKind.Relative); // Doesn't work - uri isn't relative
            //Uri uri = new Uri("pack://application:,,,/EmbeddedResource.bmp", UriKind.Absolute); // Works
            //Uri uri = new Uri("pack://application:,,,/EmbeddedResource.bmp", UriKind.RelativeOrAbsolute); // Works
            //StreamResourceInfo info = Application.GetResourceStream(uri);

            //// Absolute loose resource
            //Uri uri = new Uri("pack://application:,,,/LooseResource.bmp"); // Doesn't work - exception=cannot use absolute uri
            //Uri uri = new Uri("pack://application:,,,/LooseResource.bmp", UriKind.Relative); // Doesn't work - uri isn't relative
            //Uri uri = new Uri("pack://application:,,,/LooseResource.bmp", UriKind.Absolute); // Doesn't work - exception=cannot use absolute uri
            //Uri uri = new Uri("pack://application:,,,/LooseResource.bmp", UriKind.RelativeOrAbsolute); // Doesn't work - exception=cannot use absolute uri
            //StreamResourceInfo info = Application.GetContentStream(uri);

            //// Absolute site of origin resource
            //Uri uri = new Uri("pack://siteoforigin:,,,/LooseResource.bmp"); // Works
            //Uri uri = new Uri("pack://siteoforigin:,,,/LooseResource.bmp", UriKind.Relative); // Doesn't work - uri isn't relative
            //Uri uri = new Uri("pack://siteoforigin:,,,/LooseResource.bmp", UriKind.Absolute); // Works
            //Uri uri = new Uri("pack://siteoforigin:,,,/LooseResource.bmp", UriKind.RelativeOrAbsolute); // Works
            //StreamResourceInfo info = Application.GetRemoteStream(uri);

            // Get embedded resource in referenced assembly
            Uri uri = new Uri("pack://application:,,,/ResourceLibrary;component/ReferencedEmbeddedResource.bmp", UriKind.RelativeOrAbsolute); // Works
            StreamResourceInfo info = Application.GetResourceStream(uri);
            // Get loose resource in referenced assembly - doesn't work
            //Uri uri = new Uri("pack://application:,,,/ResourceLibrary;component/ReferencedLooseResource.bmp", UriKind.RelativeOrAbsolute); // Works
            //StreamResourceInfo info = Application.GetContentStream(uri);
            Console.Write(info.ContentType + " -> "); Console.WriteLine(info.Stream.ToString());
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }
    }
}