//OverlayRenderDecorator.cpp file

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

            //public: 
            //   OverlayRenderDecoratorOverlayVisual () ;
         private: 
            bool _hitTestVisible;
            void _initFields () 
            {
               _hitTestVisible = false;
            }

         internal:
            property bool IsHitTestVisible {
               bool get () 
               {
                  return _hitTestVisible;
               };
               void set (bool value) 
               {
                  _hitTestVisible = value;
               }
               ;
            }

         protected: 
            virtual GeometryHitTestResult^ HitTestCore (GeometryHitTestParameters^ hitTestParameters) override 
            {
               if (IsHitTestVisible)
               {
                  return DrawingVisual::HitTestCore(hitTestParameters);
               } else
               {
                  return nullptr;
               }
            };


            virtual HitTestResult^ HitTestCore (PointHitTestParameters^ hitTestParameters) override 
            {
               if (IsHitTestVisible)
               {
                  return DrawingVisual::HitTestCore(hitTestParameters);
               } else
               {
                  return nullptr;
               }
            }
            ;
         };

         /// <summary>
         /// OverlayRenderDecorator provides a simple overlay graphics mechanism similar 
         /// to OnRender called OnOverlayRender
         /// </summary>
         [ContentProperty("Child")]
         public ref class OverlayRenderDecorator : FrameworkElement {
         public:
            OverlayRenderDecorator () 
            {
               _overlayVisual = gcnew OverlayRenderDecoratorOverlayVisual();
               _vc = gcnew VisualCollection(this);
               _vc->Add(_overlayVisual);
            };

         public:
            property bool IsOverlayHitTestVisible {
               bool get () 
               {
                  if (_overlayVisual != nullptr)
                  {
                     return _overlayVisual->IsHitTestVisible;
                  } else
                  {
                     return false;
                  }
               };
               void set (bool value) 
               {
                  if (_overlayVisual != nullptr)
                  {
                     _overlayVisual->IsHitTestVisible = value;
                  }
               };
            }

            //[DefaultValue(nullptr)]
            property UIElement^ Child {
               virtual UIElement^ get () 
               {
                  return _child;
               };
               virtual void set (UIElement^ value) 
               {
                  if (_child != value)
                  {
                     //need to remove old element from logical tree
                     if (_child != nullptr)
                     {
                        OnDetachChild(_child);
                        RemoveLogicalChild(_child);
                     }

                     _vc->Clear();

                     if (value != nullptr)
                     {
                        //add to visual
                        _vc->Add(value);
                        //add to logical
                        AddLogicalChild(value);
                     }

                     //always add the overlay child back into the visual tree if its set
                     if (_overlayVisual != nullptr)
                        _vc->Add(_overlayVisual);

                     //cache the new child
                     _child = value;

                     //notify derived types of the new child
                     if (value != nullptr)
                        OnAttachChild(_child);

                     InvalidateMeasure();
                  }

               };
            }

         protected: 
            property System::Collections::IEnumerator^ LogicalChildren {
               virtual System::Collections::IEnumerator^ get () override 
               {
                  if (_child == nullptr)
                  {
                     List<UIElement^> enumerator = gcnew List<UIElement^>;
                     return (enumerator.GetEnumerator());
                  }
                  List<UIElement^>^ l = gcnew List<UIElement^>();
                  l->Add(_child);
                  return ((System::Collections::IEnumerator^)l->GetEnumerator());
               };
            }

            property int VisualChildrenCount {
               virtual int get () override 
               {
                  return _vc->Count;
               };
            }

         private:
            UIElement^ _child;
            VisualCollection^ _vc;
            OverlayRenderDecoratorOverlayVisual^ _overlayVisual;





            /// <summary>
            /// Updates DesiredSize of the OverlayRenderDecorator.  Called by parent UIElement.  This is the first pass of layout.
            /// </summary>
            /// <remarks>
            /// OverlayRenderDecorator determines a desired size it needs from the child's sizing properties, margin, and requested size.
            /// </remarks>
            /// <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
            /// <returns>The OverlayRenderDecorator's desired size.</returns>
         protected:
            virtual Size MeasureOverride (Size constraint) override 
            {
               UIElement^ child = Child;
               if (child != nullptr)
               {
                  child->Measure(constraint);
                  return (child->DesiredSize);
               }
               return (Size());
            };

            /// <summary>
            /// OverlayRenderDecorator computes the position of its single child inside child's Margin and calls Arrange
            /// on the child.
            /// </summary>
            /// <param name="arrangeSize">Size the OverlayRenderDecorator will assume.</param>
            virtual Size ArrangeOverride (Size arrangeSize) override 
            {
               UIElement^ child = Child;
               if (child != nullptr)
               {
                  child->Arrange(Rect(arrangeSize));
               }
               if (_overlayVisual != nullptr)
               {
                  {
                     DrawingContext^ dc = _overlayVisual->RenderOpen();
                     try
                     {
                        OnOverlayRender(dc);
                     } finally
                     {
                        delete dc;
                     }
                  }
               }
               return (arrangeSize);
            };

            /// <summary>
            /// render method for overlay graphics.
            /// </summary>
            /// <param name="dc"></param>
            virtual void OnOverlayRender (DrawingContext^ dc) {} ;

            /// <summary>
            /// gives derives types a simple way to respond to a new child being added
            /// </summary>
            /// <param name="child"></param>
            virtual void OnAttachChild (UIElement^ child) {} ;

            /// <summary>
            /// gives derives types a simple way to respond to a child being removed
            /// </summary>
            /// <param name="child"></param>
            virtual void OnDetachChild (UIElement^ child) {} ;

            virtual Visual^ GetVisualChild (int index) override 
            {
               return _vc[index];
            };
         };
      }
   }
}