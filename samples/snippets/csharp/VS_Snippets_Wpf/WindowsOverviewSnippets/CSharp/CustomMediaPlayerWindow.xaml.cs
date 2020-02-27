//<SnippetActivationDeactivationCODEBEHIND>
using System;
using System.Windows;

namespace SDKSample
{
    public partial class CustomMediaPlayerWindow : Window
    {
        public CustomMediaPlayerWindow()
        {
            InitializeComponent();
        }

        void window_Activated(object sender, EventArgs e)
        {
            // Recommence playing media if window is activated
            this.mediaElement.Play();
        }

        void window_Deactivated(object sender, EventArgs e)
        {
            // Pause playing if media is being played and window is deactivated
            this.mediaElement.Pause();
        }
    }
}
//</SnippetActivationDeactivationCODEBEHIND>