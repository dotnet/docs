//FrameIndependentFollowExample.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media::Animation;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FrameIndependentFollowExample : Page {

         private: 
            Canvas^ containerCanvas;
            Shapes::Rectangle^ followRectangle;
            Vector _rectangleVelocity;
            Point _lastMousePosition;

            //timing variables
            TimeSpan _lastRender;

         public: 
            FrameIndependentFollowExample () : Page()
            {
               _initFields();
               containerCanvas->Background = Brushes::Transparent;
               followRectangle->Width = 50;
               followRectangle->Height = 50;
               followRectangle->Fill = Brushes::Red;
               Canvas::SetLeft(followRectangle, 0);
               Canvas::SetTop(followRectangle, 0);
               containerCanvas->Children->Add(followRectangle);

               _lastRender = TimeSpan::FromTicks(DateTime::Now.Ticks);
               CompositionTarget::Rendering += gcnew EventHandler(this,&Microsoft::Samples::PerFrameAnimations::FrameIndependentFollowExample::UpdateRectangle);
               this->PreviewMouseMove += gcnew System::Windows::Input::MouseEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FrameIndependentFollowExample::UpdateLastMousePosition);

               this->Content = containerCanvas;
            };

         private: 
            void UpdateRectangle (Object^ sender, EventArgs^ e) 
            {
               System::Windows::Media::RenderingEventArgs^ renderArgs = ((System::Windows::Media::RenderingEventArgs^)e);
               System::Double deltaTime = (renderArgs->RenderingTime - _lastRender).TotalSeconds;
               _lastRender = renderArgs->RenderingTime;

               System::Windows::Point location = System::Windows::Point(Canvas::GetLeft(followRectangle), Canvas::GetTop(followRectangle));

               //find vector toward mouse location
               System::Windows::Vector toMouse = _lastMousePosition - location;

               //add a force toward the mouse to the rectangles velocity
               double followForce = 1.00;
               _rectangleVelocity += toMouse * followForce;

               //dampen the velocity to add stability
               double drag = 0.9;
               _rectangleVelocity *= drag;

               //update the new location from the velocity
               location += _rectangleVelocity * deltaTime;

               //set new position
               Canvas::SetLeft(followRectangle, location.X);
               Canvas::SetTop(followRectangle, location.Y);
            };


            void _initFields()
            {
               containerCanvas = gcnew Canvas();
               followRectangle = gcnew Rectangle();
               _rectangleVelocity = Vector(0, 0);
               _lastMousePosition = Point(0, 0);
            };


            void UpdateLastMousePosition (Object^ sender, System::Windows::Input::MouseEventArgs^ e)
            {
               _lastMousePosition = e->GetPosition(containerCanvas);
            };
         };
      }
   }
}
