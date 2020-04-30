//InteractiveExample.cpp file
//<SnippetInteractiveAnimationExampleWholePage>
/*

This sample animates the position of an ellipse when 
the user clicks within the main border. If the user
left-clicks, the SnapshotAndReplace HandoffBehavior
is used when applying the animations. If the user
right-clicks, the Compose HandoffBehavior is used
instead.

*/

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Navigation;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Controls;
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace Animation {
         namespace LocalAnimations {
            public ref class InteractiveAnimationExample : Page {
            private: 
               TranslateTransform^ interactiveTranslateTransform;
               Border^ containerBorder;
               Ellipse^ interactiveEllipse;

            public: 
               InteractiveAnimationExample () 
               {
                  WindowTitle = "Interactive Animation Example";
                  DockPanel^ myPanel = gcnew DockPanel();
                  myPanel->Margin = Thickness(20.0);

                  containerBorder = gcnew Border();
                  containerBorder->Background = Brushes::White;
                  containerBorder->BorderBrush = Brushes::Black;
                  containerBorder->BorderThickness = Thickness(2.0);
                  containerBorder->VerticalAlignment = System::Windows::VerticalAlignment::Stretch;

                  interactiveEllipse = gcnew Ellipse();
                  interactiveEllipse->Fill = Brushes::Lime;
                  interactiveEllipse->Stroke = Brushes::Black;
                  interactiveEllipse->StrokeThickness = 2.0;
                  interactiveEllipse->Width = 25;
                  interactiveEllipse->Height = 25;
                  interactiveEllipse->HorizontalAlignment = System::Windows::HorizontalAlignment::Left;
                  interactiveEllipse->VerticalAlignment = System::Windows::VerticalAlignment::Top;

                  interactiveTranslateTransform = gcnew TranslateTransform();
                  interactiveEllipse->RenderTransform = interactiveTranslateTransform;

                  containerBorder->MouseLeftButtonDown += 
                     gcnew MouseButtonEventHandler(this, &Microsoft::Samples::Animation::LocalAnimations::InteractiveAnimationExample::border_mouseLeftButtonDown);
                  containerBorder->MouseRightButtonDown += 
                     gcnew MouseButtonEventHandler(this, &Microsoft::Samples::Animation::LocalAnimations::InteractiveAnimationExample::border_mouseRightButtonDown);
                  containerBorder->Child = interactiveEllipse;

                  myPanel->Children->Add(containerBorder);
                  this->Content = myPanel;
               };

            private: 
               // When the user left-clicks, use the 
               // SnapshotAndReplace HandoffBehavior when applying the animation.        
               void border_mouseLeftButtonDown (System::Object^ sender, System::Windows::Input::MouseButtonEventArgs^ e)
               {
                  System::Windows::Point clickPoint = Mouse::GetPosition(containerBorder);

                  // Set the target point so the center of the ellipse
                  // ends up at the clicked point.
                  Point targetPoint = Point();
                  targetPoint.X = clickPoint.X - interactiveEllipse->Width / 2;
                  targetPoint.Y = clickPoint.Y - interactiveEllipse->Height / 2;

                  // Animate to the target point.
                  DoubleAnimation^ xAnimation = gcnew DoubleAnimation(targetPoint.X,
                     Duration(TimeSpan::FromSeconds(4)));
                  interactiveTranslateTransform->BeginAnimation(TranslateTransform::XProperty, xAnimation, HandoffBehavior::SnapshotAndReplace);

                  DoubleAnimation^ yAnimation = gcnew DoubleAnimation(targetPoint.Y,
                     Duration(TimeSpan::FromSeconds(4)));
                  interactiveTranslateTransform->BeginAnimation(TranslateTransform::YProperty, yAnimation, HandoffBehavior::SnapshotAndReplace);

                  // Chage the color of the ellipse.
                  interactiveEllipse->Fill = Brushes::Lime;
               }

            private:
               // When the user right-clicks, use the 
               // Compose HandoffBehavior when applying the animation.
               void border_mouseRightButtonDown (System::Object^ sender, System::Windows::Input::MouseButtonEventArgs^ e)
               {
                  // Find the point where the use clicked.
                  Point clickPoint = Mouse::GetPosition(containerBorder);

                  // Set the target point so the center of the ellipse
                  // ends up at the clicked point.
                  Point targetPoint = System::Windows::Point();
                  targetPoint.X = clickPoint.X - interactiveEllipse->Width / 2;
                  targetPoint.Y = clickPoint.Y - interactiveEllipse->Height / 2;

                  // Animate to the target point.
                  DoubleAnimation^ xAnimation = gcnew DoubleAnimation(targetPoint.X,
                     Duration(TimeSpan::FromSeconds(4)));
                  interactiveTranslateTransform->BeginAnimation(TranslateTransform::XProperty, xAnimation, HandoffBehavior::Compose);

                  DoubleAnimation^ yAnimation = gcnew DoubleAnimation(targetPoint.Y,
                     Duration(TimeSpan::FromSeconds(4)));

                  // Change the color of the ellipse.
                  interactiveTranslateTransform->BeginAnimation(TranslateTransform::YProperty, yAnimation, HandoffBehavior::Compose);
                  interactiveEllipse->Fill = Brushes::Orange;
               }
            };
         }
      }
   }
}
//</SnippetInteractiveAnimationExampleWholePage>
