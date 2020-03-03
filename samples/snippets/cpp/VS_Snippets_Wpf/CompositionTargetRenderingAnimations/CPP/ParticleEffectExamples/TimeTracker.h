//TimeTracker.h file

#pragma once
using namespace System;
using namespace System::Windows;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class TimeTracker {

         public: 
            TimeTracker () ;
            double Update () ;


         public: 
            property double TimerInterval {
                    double get () ;
                    void set (double value) ;
                 }

            property System::DateTime ElapsedTime {
                    System::DateTime get () ;
                 }

            property double DeltaSeconds {
                    double get () ;
                 }

         public: 
            event System::EventHandler^ TimerFired ;

         private:
            System::DateTime _lastTime;
            double _deltaTime;
            double _timerInterval;

         private: 
            void _initFields () ;

         };
      }
   }
}

