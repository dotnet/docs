//TimeTracker.cpp file

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Media;
using namespace System::Windows::Media::Animation;

namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         public ref class TimeTracker {

         public: 
            property double TimerInterval {
               double get () {
                  return _timerInterval;
               };
               void set (double value) {
                  _timerInterval = value;
               };
            }

            property System::DateTime ElapsedTime {
               System::DateTime get () {
                  return _lastTime;
               };
            }

            property double DeltaSeconds {
               double get () {
                  return _deltaTime;
               };
            }

         public: 
            TimeTracker () 
            {
               _initFields();
               _lastTime = DateTime::Now;
            }
            ;
            double Update () 
            {
               System::DateTime currentTime = DateTime::Now;

               //get the difference in time
               System::TimeSpan diffTime = currentTime - _lastTime;
               _deltaTime = diffTime.TotalSeconds;

               //does the user want a callback on regular intervals?
               if (_timerInterval > 0.0)
               {
                  if (currentTime != _lastTime)
                  {
                     TimerFired(this, nullptr);
                  }
               }

               //cycle old time
               _lastTime = currentTime;
               return _deltaTime;
            };

         public: 
            event System::EventHandler^ TimerFired ;

         private:
            System::DateTime _lastTime;
            double _deltaTime;
            double _timerInterval;

         private: 
            void _initFields () {
               _timerInterval = -1;
            };

         };
      }
   }
}

