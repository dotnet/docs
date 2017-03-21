// <SnippetCodeBehindDropShadowCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SDKSample
{

    public partial class DropShadowExample : Page
	{

        // Add Blur effect.
        void OnClickDropShadowButton(object sender, RoutedEventArgs args)
        {

            // Get a reference to the Button.
            Button myButton = (Button)sender;

            // Initialize a new DropShadowBitmapEffect that will be applied
            // to the Button.
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1; // Note that the alpha value is ignored by Color property. The Opacity property is used to control the alpha.
            myShadowColor.ScB = 0;
            myShadowColor.ScG = 0;
            myShadowColor.ScR = 0;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 320;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 25;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 1;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0.5;

            // Apply the bitmap effect to the Button.
            myButton.BitmapEffect = myDropShadowEffect;

        }

    }
}
// </SnippetCodeBehindDropShadowCodeBehindExampleWholePage>