//FrameIndependentFollowExample.h file

#pragma once
namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         ref class FrameIndependentFollowExample;
      }
   }
}

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Controls;
using namespace System::Windows::Data;
using namespace System::Windows::Documents;
using namespace System::Windows::Media;
using namespace System::Windows::Navigation;
using namespace System::Windows::Shapes;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FrameIndependentFollowExample : Page {
         public: 
            FrameIndependentFollowExample () ;

         private: 
            System::Windows::Controls::Canvas^ containerCanvas;
            System::Windows::Shapes::Rectangle^ followRectangle;
            System::Windows::Vector _rectangleVelocity;
            System::Windows::Point _lastMousePosition;
            System::TimeSpan _lastRender;

         private: 
            void UpdateRectangle (System::Object^ sender, System::EventArgs^ e) ;
            void _initFields () ;
            void UpdateLastMousePosition (System::Object^ sender, System::Windows::Input::MouseEventArgs^ e) ;
         };
      }
   }
}

