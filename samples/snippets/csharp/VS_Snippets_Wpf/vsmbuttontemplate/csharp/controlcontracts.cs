using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VSMButtonTemplate
{
    //<SnippetComboBoxContract>
    [TemplatePartAttribute(Name = "PART_EditableTextBox", Type = typeof(TextBox))]
    [TemplatePartAttribute(Name = "PART_Popup", Type = typeof(Popup))]
    public class ComboBox : ItemsControl
    {
    }
    //</SnippetComboBoxContract>

    public class Control : Object { }
    public class ContentPresenter { }
    public class Popup : Control { }
    public class ItemsControl : Control { }
    public class ButtonBase { }
    public class TextBox { }

    //<SnippetButtonContract>
    [TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "MouseOver", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Pressed", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Unfocused", GroupName = "FocusStates")]
    [TemplateVisualState(Name = "Focused", GroupName = "FocusStates")]
    public class Button : ButtonBase
    {
        public static readonly DependencyProperty BackgroundProperty;
        public static readonly DependencyProperty BorderBrushProperty;
        public static readonly DependencyProperty BorderThicknessProperty;
        public static readonly DependencyProperty ContentProperty;
        public static readonly DependencyProperty ContentTemplateProperty;
        public static readonly DependencyProperty FontFamilyProperty;
        public static readonly DependencyProperty FontSizeProperty;
        public static readonly DependencyProperty FontStretchProperty;
        public static readonly DependencyProperty FontStyleProperty;
        public static readonly DependencyProperty FontWeightProperty;
        public static readonly DependencyProperty ForegroundProperty;
        public static readonly DependencyProperty HorizontalContentAlignmentProperty;
        public static readonly DependencyProperty PaddingProperty;
        public static readonly DependencyProperty TextAlignmentProperty;
        public static readonly DependencyProperty TextDecorationsProperty;
        public static readonly DependencyProperty TextWrappingProperty;
        public static readonly DependencyProperty VerticalContentAlignmentProperty;

        public Brush Background { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }
        public object Content { get; set; }
        public DataTemplate ContentTemplate { get; set; }
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }
        public FontStretch FontStretch { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontWeight FontWeight { get; set; }
        public Brush Foreground { get; set; }
        public HorizontalAlignment HorizontalContentAlignment { get; set; }
        public Thickness Padding { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public TextDecorationCollection TextDecorations { get; set; }
        public TextWrapping TextWrapping { get; set; }
        public VerticalAlignment VerticalContentAlignment { get; set; }
    }
    //</SnippetButtonContract>



}
