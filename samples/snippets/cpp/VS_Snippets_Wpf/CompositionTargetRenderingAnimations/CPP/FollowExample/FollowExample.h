//FollowExample.h file

#pragma once

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         ref class FollowExample;
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
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class FollowExample : Page {
         public: 
            FollowExample () ;

         private: 
            System::Windows::Vector _rectangleVelocity;
            System::Windows::Point _lastMousePosition;
            System::Windows::Controls::Canvas^ containerCanvas;
            System::Windows::Shapes::Rectangle^ followRectangle;

         protected: 
            void UpdateRectangle (Object^ sender, EventArgs^ e) ;

         private: 
            void UpdateLastMousePosition (Object^ sender, MouseEventArgs^ e) ;
         };
      }
   }
}

