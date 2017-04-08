using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //CodeWindow window = new CodeWindow();
            //window.Show();

            //MarkupAndCodeBehindWindow window = new MarkupAndCodeBehindWindow();
            //window.Show();

            //EllipseEventHandlingWindow window = new EllipseEventHandlingWindow();
            //window.Show();

            //MediaElementWindow window = new MediaElementWindow();
            //window.Show();

            //FlowDocumentReaderWindow window = new FlowDocumentReaderWindow();
            //window.Show();

            //DocumentViewerWindow window = new DocumentViewerWindow();
            //window.Show();

            //AnnotationsWindow window = new AnnotationsWindow();
            //window.Show();

            //ControlTemplateButtonWindow window = new ControlTemplateButtonWindow();
            //window.Show();

            //DataTemplateWindowBefore ThemeWindow = new DataTemplateWindowBefore();
            //ThemeWindow.Show();

            //DataTemplateWindow window2 = new DataTemplateWindow();
            //window2.Show();

            //StyleWindow window = new StyleWindow();
            //window.Show();

            //LayoutWindow window = new LayoutWindow();
            //window.Show();

            //TextBoxContentWindow window = new TextBoxContentWindow();
            //window.Show();

            //ButtonContentWindow window = new ButtonContentWindow();
            //window.Show();

            //UserControlWindow window = new UserControlWindow();
            //window.Show();

            //ResourcesWindow window = new ResourcesWindow();
            //window.Show();

            TextDecorationsWindow window = new TextDecorationsWindow();
            window.Show();
        }
    }
}