using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HOWTOWindowManagementSnippets
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //<SnippetOpenNewWindowCODE>
            CustomWindow window = new CustomWindow();
            window.Show(); // Returns immediately
            //</SnippetOpenNewWindowCODE>

            //<SnippetOpenNewDialogBoxCODE>
            CustomDialogBox dialogBox = new CustomDialogBox();
            dialogBox.ShowDialog(); // Returns when dialog box has closed
            //</SnippetOpenNewDialogBoxCODE>

            //<SnippetGetDialogResultCODE>
            DialogBoxWithResult dialogBoxWithResult = new DialogBoxWithResult();
            // Open dialog box and retrieve dialog result when ShowDialog returns
            bool? dialogResult = dialogBoxWithResult.ShowDialog();
            switch (dialogResult)
            {
                case true:
                    // User accepted dialog box
                    break;
                case false:
                    // User canceled dialog box
                    break;
                default:
                    // Indeterminate
                    break;
            }
            //</SnippetGetDialogResultCODE>

            //<SnippetSetWindowSizeToContentPropertyCODE>

            // Manually alter window height and width
            this.SizeToContent = SizeToContent.Manual;

            // Automatically resize width relative to content
            this.SizeToContent = SizeToContent.Width;

            // Automatically resize height relative to content
            this.SizeToContent = SizeToContent.Height;

            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
            //</SnippetSetWindowSizeToContentPropertyCODE>
        }
    }
}