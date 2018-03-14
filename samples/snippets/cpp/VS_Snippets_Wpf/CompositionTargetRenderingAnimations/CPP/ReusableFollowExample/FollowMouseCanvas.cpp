//FollowMouseCanvas.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media;
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FollowMouseCanvas : Canvas {

         private: 
            Vector _velocity;
            Point _parentLastMousePosition;
            Canvas^ _parentCanvas;
            TimeSpan _lastRender;

         public: 
            FollowMouseCanvas () : Canvas() {
               _initFields();
               _lastRender = TimeSpan::FromTicks(DateTime::Now.Ticks);
               CompositionTarget::Rendering += gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FollowMouseCanvas::UpdatePosition);
            };


         private:
            void _initFields () 
            {
               _velocity = Vector(0, 0);
               _parentLastMousePosition = Point(0, 0);
               _parentCanvas = nullptr;
            };

            void UpdatePosition (System::Object^ sender, System::EventArgs^ e)
            {
               RenderingEventArgs^ renderingArgs = ((RenderingEventArgs^)e);

               double deltaTime = (renderingArgs->RenderingTime - _lastRender).TotalSeconds;
               _lastRender = renderingArgs->RenderingTime;

               if (_parentCanvas == nullptr)
               {
                  _parentCanvas = dynamic_cast<Canvas^>(VisualTreeHelper::GetParent(this));
                  if (_parentCanvas == nullptr)
                  {
                     //parent isnt canvas so just abort trying to follow mouse
                     CompositionTarget::Rendering -= gcnew EventHandler(this,
                        &Microsoft::Samples::PerFrameAnimations::FollowMouseCanvas::UpdatePosition);
                  } else
                  {
                     //parent is canvas, so track mouse position and time
                     _parentCanvas->PreviewMouseMove += gcnew MouseEventHandler(this,
                        &Microsoft::Samples::PerFrameAnimations::FollowMouseCanvas::UpdateLastMousePosition);
                  }
               }

               //get location
               Point location = Point(Canvas::GetLeft(this), Canvas::GetTop(this));

               //check for NaN's and replace with 0,0
               if (double::IsNaN(location.X) || double::IsNaN(location.Y))
               {
                  location = Point(0, 0);
               }
               //find vector toward mouse location
               Vector toMouse = _parentLastMousePosition - location;
               //add a force toward the mouse to the rectangles velocity
               double followForce = 1.0;
               _velocity += toMouse * followForce;

               //dampen the velocity to add stability
               double drag = 0.95;
               _velocity *= drag;

               //update the new location from the velocity
               location += _velocity * deltaTime;

               //set new position
               Canvas::SetLeft(this, location.X);
               Canvas::SetTop(this, location.Y);
            };

            void UpdateLastMousePosition (Object^ sender, MouseEventArgs^ e) 
            {
               if (_parentCanvas == nullptr)
               {
                  return;
               }
               _parentLastMousePosition = e->GetPosition(_parentCanvas);
            };
         };
      }
   }
}




