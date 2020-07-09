using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyTextBoxExampleFrame.Content = new TextBoxExample();
            MyCharacterCasingExampleFrame.Content = new CharacterCasingExample();
            MySpellCheckExampleFrame.Content = new SpellCheckExample();
            MyBeginChangeEndChangeExampleFrame.Content = new BeginChangeEndChangeExample();
        }
    }
}
