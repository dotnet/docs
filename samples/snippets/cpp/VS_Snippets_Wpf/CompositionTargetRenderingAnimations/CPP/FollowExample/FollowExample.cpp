//FollowExample.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FollowExample : Page {
         private: 
            Vector _rectangleVelocity;
            Point _lastMousePosition;
            Canvas^ containerCanvas;
            Rectangle^ followRectangle;

         public: 
            FollowExample () 	: Page()
            {
               _rectangleVelocity = Vector(0, 0);
               _lastMousePosition = Point(0, 0);

               containerCanvas = gcnew Canvas();
               containerCanvas->Background = Brushes::Transparent;

               followRectangle = gcnew Rectangle();
               followRectangle->Fill = Brushes::Red;
               followRectangle->Width = 50;
               followRectangle->Height = 50;
               Canvas::SetLeft(followRectangle, 0);
               Canvas::SetTop(followRectangle, 0);
               containerCanvas->Children->Add(followRectangle);

               CompositionTarget::Rendering += gcnew EventHandler(this,&Microsoft::Samples::PerFrameAnimations::FollowExample::UpdateRectangle);
               this->PreviewMouseMove += gcnew MouseEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FollowExample::UpdateLastMousePosition);

               this->Content = containerCanvas;
            };

         protected:
            void UpdateRectangle (System::Object^ sender, System::EventArgs^ e) {
               Point location = Point(Canvas::GetLeft(followRectangle), Canvas::GetTop(followRectangle));

               //find vector toward mouse location
               Vector toMouse = _lastMousePosition - location;

               //add a force toward the mouse to the rectangles velocity
               double followForce = 0.01;
               _rectangleVelocity += toMouse * followForce;

               //dampen the velocity to add stability
               double drag = 0.8;
               _rectangleVelocity *= drag;

               //update the new location from the velocity
               location += _rectangleVelocity;

               //set new position
               Canvas::SetLeft(followRectangle, location.X);
               Canvas::SetTop(followRectangle, location.Y);
            };

         private: 
            void UpdateLastMousePosition (System::Object^ sender, MouseEventArgs^ e) 
            {
               _lastMousePosition = e->GetPosition(containerCanvas);
            };
         };
      }
   }
}


