//LocalAnimationExample.cpp file
//<Snippet11>
/*

   This sample demonstrates how to apply non-storyboard animations to a property.
   To animate in markup, you must use storyboards.

*/

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Navigation;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Controls;


namespace Microsoft {
   namespace Samples {
      namespace Animation {
         namespace LocalAnimations {
            // Create the demonstration.
            public ref class LocalAnimationExample : Page {

            public: 
               LocalAnimationExample ()
               {
                  WindowTitle = "Local Animation Example";
                  StackPanel^ myStackPanel = gcnew StackPanel();
                  myStackPanel->Margin = Thickness(20);

                  // Create and set the Button.
                  Button^ aButton = gcnew Button();
                  aButton->Content = "A Button";

                  // Animate the Button's Width.
                  DoubleAnimation^ myDoubleAnimation = gcnew DoubleAnimation();
                  myDoubleAnimation->From = 75;
                  myDoubleAnimation->To = 300;
                  myDoubleAnimation->Duration = Duration(TimeSpan::FromSeconds(5));
                  myDoubleAnimation->AutoReverse = true;
                  myDoubleAnimation->RepeatBehavior = RepeatBehavior::Forever;

                  // Apply the animation to the button's Width property.
                  aButton->BeginAnimation(Button::WidthProperty, myDoubleAnimation);

                  // Create and animate a Brush to set the button's Background.
                  SolidColorBrush^ myBrush = gcnew SolidColorBrush();
                  myBrush->Color = Colors::Blue;

                  ColorAnimation^ myColorAnimation = gcnew ColorAnimation();
                  myColorAnimation->From = Colors::Blue;
                  myColorAnimation->To = Colors::Red;
                  myColorAnimation->Duration = Duration(TimeSpan::FromMilliseconds(7000));
                  myColorAnimation->AutoReverse = true;
                  myColorAnimation->RepeatBehavior = RepeatBehavior::Forever;

                  // Apply the animation to the brush's Color property.
                  myBrush->BeginAnimation(SolidColorBrush::ColorProperty, myColorAnimation);
                  aButton->Background = myBrush;

                  // Add the Button to the panel.
                  myStackPanel->Children->Add(aButton);
                  this->Content = myStackPanel;
               };
            };
         }
      }
   }
}
//</Snippet11>
