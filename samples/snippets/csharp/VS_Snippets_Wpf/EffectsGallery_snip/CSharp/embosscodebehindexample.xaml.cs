// <SnippetCodeBehindEmbossCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SDKSample
{

    public partial class EmbossExample : Page
	{

        // Add Bevel effect.
        void OnLoadEmbossImage(object sender, RoutedEventArgs args)
        {
            // Get a reference to the Button.
            Image myImage = (Image)sender;

            // Initialize a new BevelBitmapEffect that will be applied
            // to the Button.
            EmbossBitmapEffect myEmbossEffect = new EmbossBitmapEffect();

            // The LightAngle determines from what direction the artificial
            // light is cast upon the embossed object which effects shadowing.
            // The valid range is from 0-360 (degrees)with 0 specifying the
            // right-hand side of the object and successive values moving
            // counter-clockwise around the object.
            // Set the LightAngle to 320 degrees (lower right side).
            myEmbossEffect.LightAngle = 320;

            // The Relief property determines the amount of relief of the emboss.
            // The valid range of values is 0-1 with 0 having the least relief and
            // 1 having the most. The default value is 0.44.
            myEmbossEffect.Relief = 0.8;

            // Apply the bitmap effect to the Image.
            myImage.BitmapEffect = myEmbossEffect;
        }
    }
}
// </SnippetCodeBehindEmbossCodeBehindExampleWholePage>