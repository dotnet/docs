using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TextTrimming_layout
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        void ChangeTextTrimmingProperty()
        {
            // <Snippet_TextTrimmingSetTextTrimming>
            myTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            // </Snippet_TextTrimmingSetTextTrimming>
        }
    }
}