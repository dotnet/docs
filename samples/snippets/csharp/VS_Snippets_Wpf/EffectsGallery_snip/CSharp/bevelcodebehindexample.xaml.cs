// <SnippetCodeBehindBevelCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SDKSample
{

    public partial class BevelExample : Page
	{

        // Add Bevel effect.
        void OnMouseOverBevelButton(object sender, RoutedEventArgs args)
        {
            // Get a reference to the Button.
            Button myButton = (Button)sender;

            // Initialize a new BevelBitmapEffect that will be applied
            // to the Button.
            BevelBitmapEffect myBevelEffect = new BevelBitmapEffect();

            // Set the BevelWidth. The default for BevelWidth is 5.
            myBevelEffect.BevelWidth = 15;

            // Set the EdgeProfile. The default value is Linear.
            myBevelEffect.EdgeProfile = EdgeProfile.CurvedIn;

            // Set the LightAngle (direction where light is coming from) to 320 degrees.
            myBevelEffect.LightAngle = 320;

            // Set the Relief to an intermediate value of 0.5. Relief specifies the relief
            // between light and shadow for the bevel. The default value is 0.3.
            myBevelEffect.Relief = 0.4;

            // Set the Smoothness. The default value is 0.5. This example sets
            // the property to the maximum value which is 1.
            myBevelEffect.Smoothness = 0.4;

            // Apply the bitmap effect to the Button.
            myButton.BitmapEffect = myBevelEffect;
        }
    }
}
// </SnippetCodeBehindBevelCodeBehindExampleWholePage>