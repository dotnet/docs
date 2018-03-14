// <SnippetTextEffectTargetCodeExampleWholePage>
using System;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;

namespace SDKSample
{
	public partial class TextEffectTargetExample : Page
	{

        // Event handler for translating (moving) the text element.
        public void teTranslate(object sender, RoutedEventArgs e)
        {
            // Wipe out existing TextEffects on the TextBlock
            DisableTextEffects();

            TextEffect myEffect = new TextEffect();
            myEffect.PositionStart = 0;
            myEffect.PositionCount = 999;

            // Create a TranslateTransform that moves the TextBlock to an offset position of
            // 50,50.
            TranslateTransform myTranslateTransform = new TranslateTransform(50,50);
            myEffect.Transform = myTranslateTransform;

            // Apply the effect to the TextBlock
            EnableTextEffects(tb1, myEffect);

         }

         // Event handler for transforming the size of the text element.
        public void teScale(object sender, RoutedEventArgs e)
        {
            // Wipe out existing TextEffects on the TextBlock
            DisableTextEffects();

            TextEffect myEffect = new TextEffect();
            myEffect.PositionStart = 0;
            myEffect.PositionCount = 999;

            // Create a ScaleTransform that scales the TextBlock by 5.
            ScaleTransform myScaleTransform = new ScaleTransform(5,5);
            myEffect.Transform = myScaleTransform;

            // Apply the effect to the TextBlock
            EnableTextEffects(tb1, myEffect);
        }

        public void teRotate(object sender, RoutedEventArgs e)
        {
            // Wipe out existing TextEffects on the TextBlock
            DisableTextEffects();

            TextEffect myEffect = new TextEffect();
            myEffect.PositionStart = 0;
            myEffect.PositionCount = 999;

            // Create a ScaleTransform that rotates the text by 45 degrees.
            RotateTransform myRotateTransform = new RotateTransform(45);
            myEffect.Transform = myRotateTransform;

            // Apply the effect to the TextBlock
            EnableTextEffects(tb1, myEffect);
        }

        // Disable all existing text effects to make way for new ones.
        private void DisableTextEffects()
        {
            if (_textEffectTargets != null)
            {
                foreach (TextEffectTarget target in _textEffectTargets) 
                     target.Disable();
            }
        }

        // Enable TextEffectTargets and apply effect to TextBlock.
        private void EnableTextEffects(TextBlock tb, TextEffect effect)
        {
            _textEffectTargets = TextEffectResolver.Resolve(tb.ContentStart, tb.ContentEnd, effect);
            foreach (TextEffectTarget target in _textEffectTargets)
                target.Enable();           
        }

        private TextEffectTarget[] _textEffectTargets; 
    }
}
// </SnippetTextEffectTargetCodeExampleWholePage>