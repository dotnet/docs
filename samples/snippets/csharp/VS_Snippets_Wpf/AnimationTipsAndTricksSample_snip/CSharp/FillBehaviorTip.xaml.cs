using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Animation
{
    /// <summary>
    /// Interaction logic for FillBehaviorTip.xaml
    /// </summary>

    public partial class FillBehaviorTip : System.Windows.Controls.Page
    {
        public FillBehaviorTip()
        {
            InitializeComponent();
        }

        // <SnippetFillBehaviorTipStoryboardC1CompletedHandler>
        private void StoryboardC_Completed(object sender, EventArgs e)
        {

            Storyboard translationAnimationStoryboard =
                (Storyboard)this.Resources["TranslationAnimationStoryboardResource"];
            translationAnimationStoryboard.Begin(this);
        }
        // </SnippetFillBehaviorTipStoryboardC1CompletedHandler>
    }
}