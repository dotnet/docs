//MagnetismCanvas.h file

#pragma once

#include "TimeTracker.h"


using namespace System;
using namespace System::Windows;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;
using namespace System::Windows::Controls;
using namespace System::Collections::Generic;
using namespace System::Windows::Input;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class MagnitismCanvas : Canvas {

         public: 
            MagnitismCanvas () ;

         public: 
            property double BorderForce {
               double get () ;
               void set (double value) ;
            }

            property double ChildForce {
               double get () ;
               void set (double value) ;
            }

            property double Drag {
               double get () ;
               void set (double value) ;
            }

         private: 
            TimeTracker^ _timeTracker;
            System::Collections::Generic::Dictionary<System::Windows::UIElement^,System::Windows::Vector>^ _childrenVelocities;
            double _borderforce;
            double _childforce;
            double _drag;


         protected: 
            void UpdateChildren (System::Object^ sender, System::EventArgs^ e) ;

         private: 
            void _initFields () ;
            bool AreRectsOverlapping (System::Windows::Rect r1, System::Windows::Rect r2) ;
            System::Windows::Point IntersectInsideRect (System::Windows::Rect r, System::Windows::Point raystart, System::Windows::Vector raydir) ;
            System::Windows::Vector VectorBetweenRects (System::Windows::Rect r1, System::Windows::Rect r2) ;
            System::Windows::Point GetRenderTransformOffset (System::Windows::UIElement^ e) ;
            void SetRenderTransformOffset (System::Windows::UIElement^ e, System::Windows::Point offset) ;
            System::Windows::Point GetTruePosition (System::Windows::UIElement^ e) ;
            void SetTruePosition (System::Windows::UIElement^ e, System::Windows::Point p) ;
            System::Windows::Point GetCenter (System::Windows::Rect r) ;

         };
      }
   }
}

