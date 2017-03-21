using System;
using System.Windows;

// <SnippetDisableDpiAwarenessAttribute1>
// Disable Dpi awareness in the application assembly.
[assembly: System.Windows.Media.DisableDpiAwareness]
// </SnippetDisableDpiAwarenessAttribute1>

namespace WindowsApplication1
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
}