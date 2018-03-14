using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.Media.Animation;

namespace TextElementSnippets
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

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            //TextEffectsProp();
            //Stub1();
            Stub3();
        }

        void TextEffectsProp()
        {
            // <SnippetTextEffectSnippet1>
            // Create and configure a simple color animation sequence.  Timespan is in 1000ns ticks.
            ColorAnimation colorAnimation =
                new ColorAnimation(Colors.Maroon, Colors.White, new Duration(new TimeSpan(1000000)));
            colorAnimation.AutoReverse = true;
            colorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Create a new brush and apply the color animation.
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Black);
            solidColorBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            // Create a new TextEffect object. Set the foreground to the color-animated brush.
            TextEffect textEffect = new TextEffect();
            textEffect.Foreground = solidColorBrush;

            // Apply the TextEffect to the entire range of characters.
            textEffect.PositionStart = 0;
            textEffect.PositionCount = int.MaxValue;

            // Create a new text Run, and add the TextEffect to the TextEffectCollection of the Run.
            Run flickerRun = new Run("Text that flickers...");
            flickerRun.TextEffects = new TextEffectCollection();
            flickerRun.TextEffects.Add(textEffect);

            MyFlowDocument.Blocks.Add(new Paragraph(flickerRun));
            // </SnippetTextEffectSnippet1>
        }

        void Stub1()
        {
            TextEffect textEffect = new TextEffect();
            // <SnippetTextEffectSnippet2>
            // Ensure that all characters in the text are affected.
            textEffect.PositionCount = int.MaxValue;
            // </SnippetTextEffectSnippet2>
        }

        void Stub3()
        {
            // Create and configure a simple color animation sequence.  Timespan is in 1000ns ticks.
            ColorAnimation colorAnimation =
                new ColorAnimation(Colors.Maroon, Colors.White, new Duration(new TimeSpan(1000000)));
            colorAnimation.AutoReverse = true;
            colorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Create a new brush and apply the color animation.
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Black);
            solidColorBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            // <SnippetTextEffectSnippet3>
            // Create a new TextEffect object, setting only the foreground brush, position start, and position count.
            TextEffect textEffect = new TextEffect(null, solidColorBrush, null, 0, int.MaxValue);
            // </SnippetTextEffectSnippet3>

            // Create a new text Run, and add the TextEffect to the TextEffectCollection of the Run.
            Run flickerRun = new Run("Text that flickers...");
            flickerRun.TextEffects = new TextEffectCollection();
            flickerRun.TextEffects.Add(textEffect);

            MyFlowDocument.Blocks.Add(new Paragraph(flickerRun));
        }
    }
}