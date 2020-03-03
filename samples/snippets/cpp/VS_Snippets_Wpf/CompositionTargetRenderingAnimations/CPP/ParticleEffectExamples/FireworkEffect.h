//FireworkEffect.h file
#pragma once

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
         private ref class Particle {
         public: 
            Point Location;
            Vector Velocity;
            System::DateTime LifeTime;
            System::DateTime DeathTime;
            Color StartColor;
            Color EndColor;
            double Diameter;
         };

         public ref class FireworkEffect : OverlayRenderDecorator {

         private: 
            List<Particle^>^ _particles;
            bool _bounceOffContainer;
            Vector _gravity;
            bool _gravitateToMouse;
            double _gravitateScale;
            bool _mouseDropsParticles;
            double _secondsUntilDrop;
            Point _lastMousePosition;
            TimeTracker^ _timeTracker;

         protected: System::Random^ _random;

         public: 
            FireworkEffect () ;
            static initonly DependencyProperty^ RadiusProperty = DependencyProperty::Register("RadiusBase", double::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(15.0));
            static initonly DependencyProperty^ RadiusVariationProperty = DependencyProperty::Register("RadiusVariation", double::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(5.0));
            static initonly DependencyProperty^ StartColorProperty = DependencyProperty::Register("StartColor", Color::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(Color::FromArgb(245, 200, 50, 20)));
            static initonly DependencyProperty^ EndColorProperty = DependencyProperty::Register("EndColor", Color::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(Color::FromArgb(100, 200, 255, 20)));
            static initonly DependencyProperty^ StartColorVariationProperty = DependencyProperty::Register("StartColorVariation", Color::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(Color::FromArgb(10, 55, 50, 20)));
            static initonly DependencyProperty^ EndColorVariationProperty = DependencyProperty::Register("EndColorVariation", Color::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(Color::FromArgb(50, 20, 100, 20)));
            static initonly DependencyProperty^ MouseDropDelayProperty = DependencyProperty::Register("MouseDropDelay", double::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(0.1));
            static initonly DependencyProperty^ MouseDropDelayVariationProperty = DependencyProperty::Register("MouseDropDelayVariation", double::typeid, FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(0.05));
            static initonly DependencyProperty^ ClickBurstSizeProperty = DependencyProperty::Register("ClickBurstSize", int::typeid, Microsoft::Samples::PerFrameAnimations::FireworkEffect::typeid, gcnew FrameworkPropertyMetadata(30));

            //#region Public Properties
         public: 
            property double Radius {
               double get () ;
               void set (double value) ;
            }

            property double RadiusVariation {
               double get () ;
               void set (double value) ;
            }

            property Color StartColor {
               Color get () ;
               void set (Color value) ;
            }

            property Color EndColor {
               Color get () ;
               void set (Color value) ;
            }

            property Color StartColorVariation {
               Color get () ;
               void set (Color value) ;
            }

            property Color EndColorVariation {
               Color get () ;
               void set (Color value) ;
            }

            property bool BounceOffContainer {
               bool get () ;
               void set (bool value) ;
            }

            property bool GravitateToMouse {
               bool get () ;
               void set (bool value) ;
            }

            property double GravitateScale {
               double get () ;
               void set (double value) ;
            }

            property bool MouseDropsParticles {
               bool get () ;
               void set (bool value) ;
            }

            property double MouseDropDelay {
               double get () ;
               void set (double value) ;
            }

            property double MouseDropDelayVariation {
               double get () ;
               void set (double value) ;
            }

            property int ClickBurstSize {
               int get () ;
               void set (int value) ;
            }


         protected: 
            virtual void OnAttachChild (UIElement^ child) override ;
            virtual void OnDetachChild (UIElement^ child) override ;
            void OnFrameCallback (System::Object^ sender, System::EventArgs^ e) ;
            virtual void UpdateParticles (double deltatime) ;
            virtual void OnOverlayRender (DrawingContext^ drawingContext) override ;

         private: 
            void _initFields () ;
            void OnMouseMove (System::Object^ sender, Input::MouseEventArgs^ e) ;
            void OnMouseLeftButtonUp (System::Object^ sender, Input::MouseButtonEventArgs^ e) ;

         public: 
            void AddRandomBurst () ;
            void AddRandomBurst (Point location) ;
            void AddRandomBurst (Point location, int count) ;
         };
      }
   }
}

