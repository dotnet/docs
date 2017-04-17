// <SnippetCodeBehindOuterGlowCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SDKSample
{

	public partial class OuterGlowExample : Page
	{

        // Add OuterGlow effect.
        void OnFocusCreateGlow(object sender, RoutedEventArgs args)
        {

            // Get a reference to the TextBox.
            TextBox myTextBox = (TextBox)sender;

            // Initialize a new OuterGlowBitmapEffect that will be applied
            // to the TextBox.
            OuterGlowBitmapEffect myGlowEffect = new OuterGlowBitmapEffect();

            // Set the size of the glow to 30 pixels.
            myGlowEffect.GlowSize = 30;

            // Set the color of the glow to blue.
            Color myGlowColor = new Color();
            myGlowColor.ScA = 1;
            myGlowColor.ScB = 1;
            myGlowColor.ScG = 0;
            myGlowColor.ScR = 0;
            myGlowEffect.GlowColor = myGlowColor;

            // Set the noise of the effect to the maximum possible (range 0-1).
            myGlowEffect.Noise = 1;

            // Set the Opacity of the effect to 40%. Note that the same effect
            // could be done by setting the ScA property of the Color to 0.4.
            myGlowEffect.Opacity = 0.4;

            // Apply the bitmap effect to the TextBox.
            myTextBox.BitmapEffect = myGlowEffect;

        }

    }
}
// </SnippetCodeBehindOuterGlowCodeBehindExampleWholePage>