//SonicEffect.cpp file

#include "OverlayRenderDecorator.h"
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
            SonicEffect () 
            {
               _initFields();
            }
            ;

         public: 
            property int RingCount {
               int get () 
               {
                  return _ringCount;
               };
               void set (int value) 
               {
                  _ringCount = ((int)value);
               };
            }

            property System::TimeSpan RingDelay {
               System::TimeSpan get () 
               {
                  return TimeSpan::FromSeconds(_ringDelayInSeconds);
               };
               void set (System::TimeSpan value) 
               {
                  _ringDelayInSeconds = (((System::TimeSpan)value)).TotalSeconds;
               };
            }

            property double RingRadius {
               double get () {
                  return _ringRadius;
               };
               void set (double value) {
                  _ringRadius = ((double)value);
               };
            }

            property double RingThickness {
               double get () {
                  return _ringThickness;
               };
               void set (double value) {
                  _ringThickness = ((double)value);
               };
            }

            property Color RingColor {
               Color get () {
                  return _ringColor;
               };
               void set (Color value) {
                  _ringColor = ((Color)value);
               };
            }


         protected: 
            virtual void OnAttachChild (UIElement^ child) override 
            {
               child->PreviewMouseLeftButtonUp += gcnew MouseButtonEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnMouseLeftButtonUp);
            };
            virtual void OnDetachChild (UIElement^ child) override 
            {
               CompositionTarget::Rendering -= gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnFrameCallback);
               child->PreviewMouseLeftButtonUp -= gcnew MouseButtonEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnMouseLeftButtonUp);
               _timeTracker = nullptr;
            };
            void OnFrameCallback (System::Object^ sender, System::EventArgs^ e) 
            {
               if (_timeTracker != nullptr)
               {
                  _timeTracker->Update();
                  InvalidateVisual();
               }
            };
            virtual void OnOverlayRender (DrawingContext^ dc) override 
            {
               if (_timeTracker != nullptr)
               {

                  for (
                     int i = _lowerRing;
                     i < _upperRing;
                  i++)
                  {
                     double radius = _ringRadius * (i + 1);
                     dc->DrawEllipse(Brushes::Transparent, gcnew Pen(gcnew SolidColorBrush(_ringColor), _ringThickness), _clickPosition, radius, radius);
                  }

               }
            };

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
            void OnMouseLeftButtonUp (System::Object^ sender, MouseButtonEventArgs^ e) 
            {
               if (_timeTracker != nullptr)
               {
                  _timeTracker->TimerFired -= gcnew EventHandler(this,
                     &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnTimerFired);
                  _timeTracker = nullptr;
               }
               CompositionTarget::Rendering += gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnFrameCallback);
               _timeTracker = gcnew TimeTracker();
               _timeTracker->TimerInterval = _ringDelayInSeconds;
               _timeTracker->TimerFired += gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnTimerFired);
               _lowerRing = _upperRing = 0;
               _clickPosition = e->GetPosition(this);
            };

            void OnTimerFired (System::Object^ sender, System::EventArgs^ e) 
            {
               if (_upperRing < _ringCount)
               {
                  _upperRing++;
               } else
               {
                  _lowerRing++;
                  if (_lowerRing >= _upperRing)
                  {
                     _timeTracker->TimerFired -= gcnew EventHandler(this,
                        &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnTimerFired);
                     _timeTracker = nullptr;
                     CompositionTarget::Rendering -= gcnew EventHandler(this,
                        &Microsoft::Samples::PerFrameAnimations::SonicEffect::OnFrameCallback);
                  }
               }
            };
            void _initFields () 
            {
               _ringCount = 5;
               _ringDelayInSeconds = 0.1;
               _ringRadius = 7.0;
               _ringThickness = 5.0;
               _ringColor = Color::FromArgb(128, 128, 128, 128);
            };         };
      }
   }
}






