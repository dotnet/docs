//FollowMouseCanvas.h file

#pragma once
namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         ref class FollowMouseCanvas;
      }
   }
}

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FollowMouseCanvas : Canvas {
         private:
            System::Windows::Vector _velocity;
            System::Windows::Point _parentLastMousePosition;
            System::Windows::Controls::Canvas^ _parentCanvas;
            System::TimeSpan _lastRender;

         public:
            FollowMouseCanvas () ;

         private:
            void _initFields () ;
            void UpdatePosition (System::Object^ sender, System::EventArgs^ e) ;
            void UpdateLastMousePosition (System::Object^ sender, System::Windows::Input::MouseEventArgs^ e) ;
         };
      }
   }
}

