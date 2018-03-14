// <SnippetMultipleEffectExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SDKSample
{
    public partial class MultipleEffectExample : Page
    {
        public MultipleEffectExample()
        {
            Button myButton = new Button();
            myButton.Content = "DropShadow under this Button";
            myButton.Margin = new Thickness(50);
            myButton.Width = 300;

            // Create the BitmapEffects to apply to the button.
            BlurBitmapEffect myBlurBitmapEffect = new BlurBitmapEffect();
            myBlurBitmapEffect.Radius = 2;

            DropShadowBitmapEffect myDropShadowBitmapEffect = new DropShadowBitmapEffect();
            myDropShadowBitmapEffect.Color = Colors.Black;
            myDropShadowBitmapEffect.Direction = 320;
            myDropShadowBitmapEffect.ShadowDepth = 30;
            myDropShadowBitmapEffect.Softness = 1;
            myDropShadowBitmapEffect.Opacity = 0.5;

            BitmapEffectGroup myBitmapEffectGroup = new BitmapEffectGroup();
            myBitmapEffectGroup.Children.Add(myBlurBitmapEffect);
            myBitmapEffectGroup.Children.Add(myDropShadowBitmapEffect);

            myButton.BitmapEffect = myBitmapEffectGroup;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myButton);
            this.Content = myStackPanel;

        }      
    }
}
// </SnippetMultipleEffectExampleWholePage>