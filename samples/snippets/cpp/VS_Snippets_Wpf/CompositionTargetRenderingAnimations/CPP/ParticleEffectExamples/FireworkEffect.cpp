//FireworkEffect.cpp file

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

         protected: 
            Random^ _random;

         public: static initonly DependencyProperty^ RadiusProperty = 
                    DependencyProperty::Register(
                    "RadiusBase",
                    double::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(15.0));

         public: static initonly DependencyProperty^ RadiusVariationProperty =
                    DependencyProperty::Register(
                    "RadiusVariation",
                    double::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(5.0));

         public: static initonly DependencyProperty^ StartColorProperty = 
                    DependencyProperty::Register(
                    "StartColor",
                    Color::typeid, FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(Color::FromArgb(245, 200, 50, 20)));

         public: static initonly DependencyProperty^ EndColorProperty = 
                    DependencyProperty::Register(
                    "EndColor",
                    Color::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(Color::FromArgb(100, 200, 255, 20)));

         public: static initonly DependencyProperty^ StartColorVariationProperty = 
                    DependencyProperty::Register(
                    "StartColorVariation",
                    Color::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(Color::FromArgb(10, 55, 50, 20)));

         public: static initonly DependencyProperty^ EndColorVariationProperty = 
                    DependencyProperty::Register(
                    "EndColorVariation",
                    Color::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(Color::FromArgb(50, 20, 100, 20)));

         public: static initonly DependencyProperty^ MouseDropDelayProperty = 
                    DependencyProperty::Register(
                    "MouseDropDelay",
                    double::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(0.1));

         public: static initonly DependencyProperty^ MouseDropDelayVariationProperty = 
                    DependencyProperty::Register(
                    "MouseDropDelayVariation",
                    double::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(0.05));

         public: static initonly DependencyProperty^ ClickBurstSizeProperty = 
                    DependencyProperty::Register(
                    "ClickBurstSize",
                    int::typeid,
                    FireworkEffect::typeid,
                    gcnew FrameworkPropertyMetadata(30));

                 //#region properties
         public: 
            property double Radius {
               double get ()
               {
                  return ((double)GetValue(RadiusProperty));
               };
               void set (double value) 
               {
                  SetValue(RadiusProperty, value);
               };
            }

         public: property double RadiusVariation {
                    double get (){
                       return ((double)GetValue(RadiusVariationProperty));
                    } ;
                    void set (double value){
                       SetValue(RadiusVariationProperty, value);
                    } ;
                 }

         public: property Color StartColor {
                    Color get (){
                       return ((Color)GetValue(StartColorProperty));
                    } ;
                    void set (Color value){
                       SetValue(StartColorProperty, value);
                    } ;
                 }

         public: property Color EndColor {
                    Color get (){
                       return ((Color)GetValue(EndColorProperty));
                    } ;
                    void set (Color value){
                       SetValue(EndColorProperty, value);
                    } ;
                 }

         public: property Color StartColorVariation {
                    Color get (){
                       return ((Color)GetValue(StartColorVariationProperty));
                    } ;
                    void set (Color value){
                       SetValue(StartColorVariationProperty, value);
                    } ;
                 }

         public: property Color EndColorVariation {
                    Color get (){
                       return ((Color)GetValue(EndColorVariationProperty));
                    } ;
                    void set (Color value){
                       SetValue(EndColorVariationProperty, value);
                    } ;
                 }

         public: property bool BounceOffContainer {
                    bool get (){
                       return _bounceOffContainer;
                    } ;
                    void set (bool value){
                       _bounceOffContainer = value;
                    } ;
                 }

         public: property bool GravitateToMouse {
                    bool get (){
                       return _gravitateToMouse;
                    } ;
                    void set (bool value){
                       _gravitateToMouse = value;
                    } ;
                 }

         public: property double GravitateScale {
                    double get (){
                       return _gravitateScale;
                    } ;
                    void set (double value){
                       _gravitateScale = value;
                    } ;
                 }

         public: property bool MouseDropsParticles {
                    bool get (){
                       return _mouseDropsParticles;
                    } ;
                    void set (bool value){
                       _mouseDropsParticles = value;
                    } ;
                 }

         public: property double MouseDropDelay {
                    double get (){
                       return ((double)GetValue(MouseDropDelayProperty));
                    } ;
                    void set (double value){
                       SetValue(MouseDropDelayProperty, value);
                    } ;
                 }

         public: property double MouseDropDelayVariation {
                    double get () {
                       return ((double)GetValue(MouseDropDelayVariationProperty));
                    };
                    void set (double value) {
                       SetValue(MouseDropDelayVariationProperty, value);
                    };
                 }

         public: property int ClickBurstSize {
                    int get () {
                       return ((int)GetValue(ClickBurstSizeProperty));
                    };
                    void set (int value) {
                       SetValue(ClickBurstSizeProperty, value);
                    };
                 }

         public: FireworkEffect () {
                    _initFields();
                 };

         private: void _initFields ()
                  {
                     _particles = gcnew System::Collections::Generic::List<Microsoft::Samples::PerFrameAnimations::Particle^>();
                     _random = gcnew System::Random();
                     _bounceOffContainer = false;
                     _gravity = Vector(0.0, 10.0);
                     _gravitateToMouse = false;
                     _gravitateScale = 0.1;
                     _mouseDropsParticles = false;
                     _secondsUntilDrop = 0;
                     _lastMousePosition = Point(0, 0);
                  }
                  ;

         protected: 
            virtual void OnAttachChild (UIElement^ child) override 
            {
               CompositionTarget::Rendering += gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnFrameCallback);
               child->PreviewMouseLeftButtonUp += gcnew MouseButtonEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnMouseLeftButtonUp);
               child->PreviewMouseMove += gcnew MouseEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnMouseMove);
               _timeTracker = gcnew Microsoft::Samples::PerFrameAnimations::TimeTracker();
            };

            virtual void OnDetachChild (UIElement^ child) override 
            {
               CompositionTarget::Rendering -= gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnFrameCallback);
               child->PreviewMouseLeftButtonUp -= gcnew MouseButtonEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnMouseLeftButtonUp);
               child->PreviewMouseMove -= gcnew MouseEventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::FireworkEffect::OnMouseMove);
               _timeTracker = nullptr;
            };

            void OnFrameCallback (System::Object^ sender, System::EventArgs^ e) 
            {
               UpdateParticles(_timeTracker->Update());
            };

            virtual void UpdateParticles (double deltatime) 
            {
               //drop particles from mouse position
               if (_mouseDropsParticles && IsMouseOver)
               {
                  _secondsUntilDrop -= deltatime;
                  if (_secondsUntilDrop < 0.0)
                  {
                     AddRandomBurst(_lastMousePosition - Vector(Radius / 2.0, Radius / 2.0), 1);
                     _secondsUntilDrop = MouseDropDelay + (_random->NextDouble() * 2.0 - 1.0) * MouseDropDelayVariation;
                  }
               }
               if (_particles->Count > 0)
               {
                  InvalidateVisual();
               }
               //update all particles
               for (int i = 0;i < _particles->Count; )
               {
                  Particle^ p = _particles[i];
                  if (_gravitateToMouse)
                  {
                     p->Velocity += (_lastMousePosition - p->Location) * _gravitateScale;
                  } 
                  else
                  {
                     p->Velocity += _gravity;
                  }
                  p->Location += p->Velocity * deltatime;

                  if (_bounceOffContainer)
                  {
                     double radius = p->Diameter / 2.0;
                     if (p->Location.X - radius < 0.0)
                     {
                        p->Location.X = radius;
                        p->Velocity.X *= -0.9;
                     } 
                     else if (p->Location.X > ActualWidth - radius)
                     {
                        p->Location.X = ActualWidth - radius;
                        p->Velocity.X *= -0.9;
                     }
                     if (p->Location.Y - radius < 0.0)
                     {
                        p->Location.Y = radius;
                        p->Velocity.Y *= -0.9;
                     } 
                     else if (p->Location.Y > ActualHeight - radius)
                     {
                        p->Location.Y = ActualHeight - radius;
                        p->Velocity.Y *= -0.9;
                     }
                  }

                //only increment counter for live particles
                  if (_timeTracker->ElapsedTime > p->DeathTime)
                  {
                     _particles->RemoveAt(i);
                  }
                  else
                  {
                     i++;
                  }
               }

            };

            virtual void OnOverlayRender (DrawingContext^ drawingContext) override 
            {

               for (int i = 0; i < _particles->Count; i++)
               {
                  Microsoft::Samples::PerFrameAnimations::Particle^ p = _particles[i];
                  double particlelife = (_timeTracker->ElapsedTime - p->LifeTime).TotalSeconds / (p->DeathTime - p->LifeTime).TotalSeconds;
                  Color currentcolor = Color::Multiply(p->StartColor, ((float)(1.0 - particlelife))) + Color::Multiply(p->EndColor, ((float)particlelife));
                  Brush^ brush = gcnew RadialGradientBrush(currentcolor, Color::FromArgb(0, currentcolor.R, currentcolor.G, currentcolor.B));
                  RectangleGeometry^ rect = gcnew RectangleGeometry(Rect(Point(p->Location.X - p->Diameter / 2.0, p->Location.Y - p->Diameter / 2.0), Size(p->Diameter, p->Diameter)));
                  drawingContext->DrawGeometry(brush, nullptr, rect);
               }

            };

         private: 
            void OnMouseMove (System::Object^ sender, Input::MouseEventArgs^ e)
            {
               _lastMousePosition = e->GetPosition(this);
            };

            void OnMouseLeftButtonUp (System::Object^ sender, Input::MouseButtonEventArgs^ e) 
            {
               AddRandomBurst(e->GetPosition(this));
            };

         public: 
            void AddRandomBurst () 
            {
               Point point = Point(_random->NextDouble() * ActualWidth, _random->NextDouble() * ActualHeight);
               AddRandomBurst(point, ClickBurstSize);
            };

            void AddRandomBurst (Point location) 
            {
               AddRandomBurst(location, ClickBurstSize);
            };

            void AddRandomBurst (Point location, int count) 
            {

               for (int i = 0; i < count; i++)
               {
                  Particle^ p = gcnew Particle();

                  double radius = Radius + (_random->NextDouble() * 2.0 - 1.0) * RadiusVariation;
                  double lifetime = _random->NextDouble() * 3.0 + 1.0;

                  p->Location = location;
                  p->Velocity = Vector(_random->NextDouble() * 200.0 - 100.0, _random->NextDouble() * -200 + 100.0);
                  p->LifeTime = _timeTracker->ElapsedTime;
                  p->DeathTime = _timeTracker->ElapsedTime + TimeSpan::FromSeconds(lifetime);
                  p->Diameter = 2.0 * radius;

                  Color startColor = StartColor;
                  Color startColorVariation = StartColorVariation;
                  Color endColor = EndColor;
                  Color endColorVariation = EndColorVariation;

                  Color startRandColor = Color::FromScRgb(startColorVariation.ScA * ((float)(_random->NextDouble() * 2.0 - 1.0)), startColorVariation.ScR * ((float)(_random->NextDouble() * 2.0 - 1.0)), startColorVariation.ScG * ((float)(_random->NextDouble() * 2.0 - 1.0)), startColorVariation.ScB * ((float)(_random->NextDouble() * 2.0 - 1.0)));
                  Color endRandColor = Color::FromScRgb(endColorVariation.ScA * ((float)(_random->NextDouble() * 2.0 - 1.0)), endColorVariation.ScR * ((float)(_random->NextDouble() * 2.0 - 1.0)), endColorVariation.ScG * ((float)(_random->NextDouble() * 2.0 - 1.0)), endColorVariation.ScB * ((float)(_random->NextDouble() * 2.0 - 1.0)));

                  p->StartColor = startColor + startRandColor;
                  p->EndColor = endColor + endRandColor;
                  _particles->Add(p);
               }

            };
         };
      }
   }
}