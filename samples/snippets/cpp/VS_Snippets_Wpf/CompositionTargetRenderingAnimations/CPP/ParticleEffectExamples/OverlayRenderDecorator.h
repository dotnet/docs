//OverlayRenderDecorator.h file

#pragma once

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Diagnostics;
using namespace System::Windows::Threading;
using namespace System::Windows::Media;
using namespace System::Windows::Markup;
using namespace System::Windows;
using namespace System::Windows::Controls;


namespace Microsoft {
   namespace Samples {
      namespace PerFrameAnimations {
         private ref class OverlayRenderDecoratorOverlayVisual : DrawingVisual {

         //public: OverlayRenderDecoratorOverlayVisual () ;
         private: 
            bool _hitTestVisible;
            void _initFields () ;

         internal:
            property bool IsHitTestVisible {
               bool get () ;
               void set (bool value) ;
            }

         protected: 
            virtual System::Windows::Media::GeometryHitTestResult^ HitTestCore (System::Windows::Media::GeometryHitTestParameters^ hitTestParameters) override ;
            virtual System::Windows::Media::HitTestResult^ HitTestCore (System::Windows::Media::PointHitTestParameters^ hitTestParameters) override ;
         };


         [ContentProperty("Child")]
         public ref class OverlayRenderDecorator : FrameworkElement {
         public:
            OverlayRenderDecorator () ;

         public:
            property bool IsOverlayHitTestVisible {
               bool get () ;
               void set (bool value) ;
            }

            //[DefaultValue(nullptr)]
            property System::Windows::UIElement^ Child {
               virtual System::Windows::UIElement^ get () ;
               virtual void set (System::Windows::UIElement^ value) ;
            }

         protected: 
            property System::Collections::IEnumerator^ LogicalChildren {
               virtual System::Collections::IEnumerator^ get () override ;
            }

            property int VisualChildrenCount {
               virtual int get () override ;
            }

         private:
            System::Windows::UIElement^ _child;
            System::Windows::Media::VisualCollection^ _vc;
            Microsoft::Samples::PerFrameAnimations::OverlayRenderDecoratorOverlayVisual^ _overlayVisual;

         protected:
            virtual System::Windows::Size MeasureOverride (System::Windows::Size constraint) override ;
            virtual System::Windows::Size ArrangeOverride (System::Windows::Size arrangeSize) override ;
            virtual void OnOverlayRender (System::Windows::Media::DrawingContext^ dc) ;
            virtual void OnAttachChild (System::Windows::UIElement^ child) ;
            virtual void OnDetachChild (System::Windows::UIElement^ child) ;
            virtual System::Windows::Media::Visual^ GetVisualChild (int index) override ;
         };
      }
   }
}

