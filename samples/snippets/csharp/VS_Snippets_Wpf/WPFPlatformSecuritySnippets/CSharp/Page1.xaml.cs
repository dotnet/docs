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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Security.Permissions;
using System.Security;

namespace WPFPlatformSecuritySnippet
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            
            //<SnippetPermission>
            FileIOPermission fp = new FileIOPermission(PermissionState.Unrestricted);
            fp.Assert();

            // Perform operation that uses the assert

            // Revert the assert when operation is completed
            CodeAccessPermission.RevertAssert();
            //</SnippetPermission>
        }

    }
}