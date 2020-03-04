//SonicEffect.h file

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
         public ref class SonicEffect : OverlayRenderDecorator {
         public: 
            SonicEffect () ;

         public: 
            property int RingCount {
               int get () ;
               void set (int value) ;
            }

            property TimeSpan RingDelay {
               TimeSpan get () ;
               void set (TimeSpan value) ;
            }

            property double RingRadius {
               double get () ;
               void set (double value) ;
            }

            property double RingThickness {
               double get () ;
               void set (double value) ;
            }

            property Color RingColor {
               Color get () ;
               void set (Color value) ;
            }


         protected: 
            virtual void OnAttachChild (UIElement^ child) override ;
            virtual void OnDetachChild (UIElement^ child) override ;
            void OnFrameCallback (Object^ sender, EventArgs^ e) ;
            virtual void OnOverlayRender (DrawingContext^ dc) override ;

         private: 
            TimeTracker^ _timeTracker;
            int _ringCount;
            double _ringDelayInSeconds;
            double _ringRadius;
            double _ringThickness;
            Color _ringColor;
            Point _clickPosition;
            int _lowerRing;
            int _upperRing;

         private:
            void OnMouseLeftButtonUp (Object^ sender, MouseButtonEventArgs^ e) ;
            void OnTimerFired (Object^ sender, EventArgs^ e) ;
            void _initFields () ;
         };
      }
   }
}

