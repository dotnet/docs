//MagnetismCanvas.cpp file

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
            MagnitismCanvas ()
            {
               _initFields();
               CompositionTarget::Rendering += gcnew EventHandler(this,
                  &Microsoft::Samples::PerFrameAnimations::MagnitismCanvas::UpdateChildren);
               _timeTracker = gcnew Microsoft::Samples::PerFrameAnimations::TimeTracker();
            };

         public: 
            property double BorderForce {
               double get ()            {
                  return _borderforce;
               };
               void set (double value)
               {
                  _borderforce = value;
               };
            }

            property double ChildForce {
               double get (){
                  return _childforce;
               } ;
               void set (double value) {
                  _childforce = value;
               };
            }

            property double Drag {
               double get ()  {
                  return _drag;
               };
               void set (double value) {
                  _drag = value;
               };
            }

         private: 
            TimeTracker^ _timeTracker;
            Dictionary<UIElement^,Vector>^ _childrenVelocities;
            double _borderforce;
            double _childforce;
            double _drag;


         protected: 
            void UpdateChildren (System::Object^ sender, System::EventArgs^ e) 
            {
               _timeTracker->Update();
               for each (UIElement^ child in LogicalTreeHelper::GetChildren(this))
               {
                  Vector velocity;
                  if (_childrenVelocities->ContainsKey(child))
                  {
                     velocity = _childrenVelocities[child];
                  } else
                  {
                     velocity = Vector(0, 0);
                  }
                  //compute velocity dampening
                  velocity = velocity * _drag;

                  Point truePosition = GetTruePosition(child);
                  Rect childRect = Rect(truePosition, child->RenderSize);


                  //accumulate forces
                  Vector forces = Vector(0, 0);

                  //add wall repulsion
                  forces.X += _borderforce / Math::Max(1.0, childRect.Left);
                  forces.X -= _borderforce / Math::Max(1.0, this->RenderSize.Width - childRect.Right);
                  forces.Y += _borderforce / Math::Max(1.0, childRect.Top);
                  forces.Y -= _borderforce / Math::Max(1.0, this->RenderSize.Height - childRect.Bottom);

                  //each other child pushes away based on the square distance
                  for each (UIElement^ otherchild in LogicalTreeHelper::GetChildren(this))
                  {
                     //dont push against itself
                     if (otherchild == child)
                     {
                        continue;
                     }
                     Point otherchildtruePosition = GetTruePosition(otherchild);
                     Rect otherchildRect = Rect(otherchildtruePosition, otherchild->RenderSize);

                     //make sure rects aren't the same
                     if (otherchildRect == childRect)
                     {
                        continue;
                     }
                     //ignore children with a size of 0,0
                     if (otherchildRect.Width == 0 && otherchildRect.Height == 0 || childRect.Width == 0 && childRect.Height == 0)
                     {
                        continue;
                     }
                     //vector from current other child to current child
                     Vector toChild;
                     double length;
                     //are they overlapping?  if so, distance is 0
                     if (AreRectsOverlapping(childRect, otherchildRect))
                     {
                        toChild = Vector(0, 0);
                     } else
                     {
                        toChild = VectorBetweenRects(childRect, otherchildRect);
                     }

                     length = toChild.Length;
                     if (length < 1)
                     {
                        length = 1;
                        Point childCenter = GetCenter(childRect);
                        Point otherchildCenter = GetCenter(otherchildRect);
                        //compute toChild from the center of both rects
                        toChild = childCenter - otherchildCenter;
                     }

                     double childpush = _childforce / length;

                     toChild.Normalize();
                     forces += toChild * childpush;
                  }

                  //add forces to velocity and store it for next iteration
                  velocity += forces;
                  _childrenVelocities[child] = velocity;

                  //move the object based on it's velocity
                  SetTruePosition(child, truePosition + _timeTracker->DeltaSeconds * velocity);
               }
            };

         private: 
            void _initFields (){
               _childrenVelocities = gcnew Dictionary<UIElement^,Vector>();
               _borderforce = 1000.0;
               _childforce = 200.0;
               _drag = 0.9;
            };

            bool AreRectsOverlapping (Rect r1, Rect r2) 
            {
               if (r1.Bottom < r2.Top)
               {
                  return false;
               }
               if (r1.Top > r2.Bottom)
               {
                  return false;
               }
               if (r1.Right < r2.Left)
               {
                  return false;
               }
               if (r1.Left > r2.Right)
               {
                  return false;
               }
               return true;
            };

            Point IntersectInsideRect (Rect r, Point raystart, Vector raydir) 
            {
               double xtop = raystart.X + raydir.X * (r.Top - raystart.Y) / raydir.Y;
               double xbottom = raystart.X + raydir.X * (r.Bottom - raystart.Y) / raydir.Y;
               double yleft = raystart.Y + raydir.Y * (r.Left - raystart.X) / raydir.X;
               double yright = raystart.Y + raydir.Y * (r.Right - raystart.X) / raydir.X;
               Point top = Point(xtop, r.Top);
               Point bottom = Point(xbottom, r.Bottom);
               Point left = Point(r.Left, yleft);
               Point right = Point(r.Right, yright);
               Vector tv = raystart - top;
               Vector bv = raystart - bottom;
               Vector lv = raystart - left;
               Vector rv = raystart - right;
               if (raydir.Y < 0)
               {
                  if (raydir.X < 0)
                  {
                     if (tv.LengthSquared < lv.LengthSquared)
                     {
                        return top;
                     } else
                     {
                        return left;
                     }
                  } else 		
                     if (tv.LengthSquared < rv.LengthSquared)
                     {
                        return top;
                     } else
                     {
                        return right;
                     }
               } else 	
                  if (raydir.X < 0)
                  {
                     if (bv.LengthSquared < lv.LengthSquared)
                     {
                        return bottom;
                     } else
                     {
                        return left;
                     }
                  } else 	
                     if (bv.LengthSquared < rv.LengthSquared)
                     {
                        return bottom;
                     } else
                     {
                        return right;
                     }
            };

            Vector VectorBetweenRects (Rect r1, Rect r2) 
            {
               //find the edge points and use these to measure the distance
               Point r1Center = GetCenter(r1);
               Point r2Center = GetCenter(r2);
               Vector between = (r1Center - r2Center);
               between.Normalize();
               Point edge1 = IntersectInsideRect(r1, r1Center, -between);
               Point edge2 = IntersectInsideRect(r2, r2Center, between);
               return edge1 - edge2;
            };

            Point GetRenderTransformOffset (UIElement^ e) 
            {
               //make sure they object's render transform is a translation
               TranslateTransform^ renderTranslation = dynamic_cast<TranslateTransform^>(e->RenderTransform);
               if (renderTranslation == nullptr)
               {
                  renderTranslation = gcnew TranslateTransform(0, 0);
                  e->RenderTransform = renderTranslation;
               }
               return Point(renderTranslation->X, renderTranslation->Y);
            };

            void SetRenderTransformOffset (UIElement^ e, Point offset) 
            {
               //make sure they object's render transform is a translation
               TranslateTransform^ renderTranslation = dynamic_cast<TranslateTransform^>(e->RenderTransform);
               if (renderTranslation == nullptr)
               {
                  renderTranslation = gcnew TranslateTransform(0, 0);
                  e->RenderTransform = renderTranslation;
               }

               //set new offset
               renderTranslation->X = offset.X;
               renderTranslation->Y = offset.Y;
            };

            Point GetTruePosition (UIElement^ e) 
            {
               Point renderTranslation = GetRenderTransformOffset(e);
               return Point(Canvas::GetLeft(e) + renderTranslation.X, Canvas::GetTop(e) + renderTranslation.Y);
            };

            void SetTruePosition (UIElement^ e, Point p) 
            {
               Vector canvasOffset = Vector(Canvas::GetLeft(e), Canvas::GetTop(e));
               Point renderTranslation = p - canvasOffset;

               SetRenderTransformOffset(e, renderTranslation);
            };

            Point GetCenter (Rect r) 
            {
               return Point((r.Left + r.Right) / 2.0, (r.Top + r.Bottom) / 2.0);
            };

         };
      }
   }
}

