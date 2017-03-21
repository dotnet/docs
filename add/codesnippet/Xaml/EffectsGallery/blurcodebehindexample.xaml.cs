// <SnippetCodeBehindBlurCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SDKSample
{

   public partial class BlurExample : Page
   {

      // Add Blur effect.
      void OnClickBlurButton(object sender, RoutedEventArgs args)
      {
         // Toggle effect
         if (((Button)sender).BitmapEffect != null)
         {
            ((Button)sender).BitmapEffect = null;
         }
         else
         {
            // <SnippetCodeBehindBlurCodeBehindExampleInline>
            // Get a reference to the Button.
            Button myButton = (Button)sender;

            // Initialize a new BlurBitmapEffect that will be applied
            // to the Button.
            BlurBitmapEffect myBlurEffect = new BlurBitmapEffect();

            // Set the Radius property of the blur. This determines how 
            // blurry the effect will be. The larger the radius, the more
            // blurring. 
            myBlurEffect.Radius = 10;

            // Set the KernelType property of the blur. A KernalType of "Box"
            // creates less blur than the Gaussian kernal type.
            myBlurEffect.KernelType = KernelType.Box;

            // Apply the bitmap effect to the Button.
            myButton.BitmapEffect = myBlurEffect;
            // </SnippetCodeBehindBlurCodeBehindExampleInline>
         }
      }

   }
}
// </SnippetCodeBehindBlurCodeBehindExampleWholePage>