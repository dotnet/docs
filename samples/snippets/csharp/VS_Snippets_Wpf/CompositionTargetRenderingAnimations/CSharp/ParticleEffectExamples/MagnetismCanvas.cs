namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Windows.Input;
    using System.Security.Permissions;

    public class MagnitismCanvas : Canvas
    {
        #region Private Members

        private TimeTracker _timeTracker;
        private Dictionary<UIElement, Vector> _childrenVelocities = new Dictionary<UIElement, Vector>();
        private double _borderforce = 1000.0;
        private double _childforce = 200.0;
        private double _drag = 0.9;

        #endregion

        #region Properties
        public double BorderForce
        {
            get
            {
                return _borderforce;
            }
            set
            {
                _borderforce = value;
            }
        }
        public double ChildForce
        {
            get
            {
                return _childforce;
            }
            set
            {
                _childforce = value;
            }
        }
        public double Drag
        {
            get
            {
                return _drag;
            }
            set
            {
                _drag = value;
            }
        }
        #endregion

        [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlAppDomain)]
        public MagnitismCanvas()
            : base()
        {
            // suppress movement in the visual studio designer.
            if( System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                CompositionTarget.Rendering += UpdateChildren;
            _timeTracker = new TimeTracker();
        }

        private void UpdateChildren(object sender, EventArgs e)
        {
            //update time delta
            _timeTracker.Update();

            foreach (UIElement child in LogicalTreeHelper.GetChildren(this))
            {
                Vector velocity;
                if (_childrenVelocities.ContainsKey(child))
                {
                    //get the velocity that we previously stored
                    velocity = _childrenVelocities[child];
                }
                else
                {
                    //setup the initial velocity randomly
                    velocity = new Vector(0, 0);
                }

                //compute velocity dampening
                velocity = velocity * _drag;

                Point truePosition = GetTruePosition(child);
                Rect childRect = new Rect(truePosition, child.RenderSize);


                //accumulate forces
                Vector forces = new Vector(0, 0);

                //add wall repulsion
                forces.X += _borderforce / Math.Max(1, childRect.Left);
                forces.X -= _borderforce / Math.Max(1, this.RenderSize.Width - childRect.Right);
                forces.Y += _borderforce / Math.Max(1, childRect.Top);
                forces.Y -= _borderforce / Math.Max(1, this.RenderSize.Height - childRect.Bottom);

                //each other child pushes away based on the square distance
                foreach (UIElement otherchild in LogicalTreeHelper.GetChildren(this))
                {
                    //dont push against itself
                    if (otherchild == child)
                        continue;

                    Point otherchildtruePosition = GetTruePosition(otherchild);
                    Rect otherchildRect = new Rect(otherchildtruePosition, otherchild.RenderSize);

                    //make sure rects aren't the same
                    if (otherchildRect == childRect)
                        continue;

                    //ignore children with a size of 0,0
                    if (otherchildRect.Width == 0 && otherchildRect.Height == 0 || childRect.Width == 0 && childRect.Height == 0)
                        continue;

                    //vector from current other child to current child
                    Vector toChild;
                    double length;
                    //are they overlapping?  if so, distance is 0
                    if (AreRectsOverlapping(childRect, otherchildRect))
                    {
                        toChild = new Vector(0, 0);
                    }
                    else
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
                SetTruePosition(child, truePosition + _timeTracker.DeltaSeconds * velocity);
            }
        }

        private bool AreRectsOverlapping(Rect r1, Rect r2)
        {
            if (r1.Bottom < r2.Top) return false;
            if (r1.Top > r2.Bottom) return false;

            if (r1.Right < r2.Left) return false;
            if (r1.Left > r2.Right) return false;

            return true;
        }

        private Point IntersectInsideRect(Rect r, Point raystart, Vector raydir)
        {
            double xtop = raystart.X + raydir.X * (r.Top - raystart.Y) / raydir.Y;
            double xbottom = raystart.X + raydir.X * (r.Bottom - raystart.Y) / raydir.Y;
            double yleft = raystart.Y + raydir.Y * (r.Left - raystart.X) / raydir.X;
            double yright = raystart.Y + raydir.Y * (r.Right - raystart.X) / raydir.X;
            Point top = new Point(xtop, r.Top);
            Point bottom = new Point(xbottom, r.Bottom);
            Point left = new Point(r.Left, yleft);
            Point right = new Point(r.Right, yright);
            Vector tv = raystart - top;
            Vector bv = raystart - bottom;
            Vector lv = raystart - left;
            Vector rv = raystart - right;
            //classify ray direction
            if (raydir.Y < 0)
            {
                if (raydir.X < 0) //top left
                {

                    if (tv.LengthSquared < lv.LengthSquared)
                        return top;
                    else
                        return left;
                }
                else //top right
                {
                    if (tv.LengthSquared < rv.LengthSquared)
                        return top;
                    else
                        return right;
                }
            }
            else
            {
                if (raydir.X < 0) //bottom left
                {
                    if (bv.LengthSquared < lv.LengthSquared)
                        return bottom;
                    else
                        return left;
                }
                else //bottom right
                {
                    if (bv.LengthSquared < rv.LengthSquared)
                        return bottom;
                    else
                        return right;
                }
            }
        }

        private Vector VectorBetweenRects(Rect r1, Rect r2)
        {
            //find the edge points and use these to measure the distance
            Point r1Center = GetCenter(r1);
            Point r2Center = GetCenter(r2);
            Vector between = (r1Center - r2Center);
            between.Normalize();
            Point edge1 = IntersectInsideRect(r1, r1Center, -between);
            Point edge2 = IntersectInsideRect(r2, r2Center, between);
            return edge1 - edge2;
        }

        private Point GetRenderTransformOffset(UIElement e)
        {
            //make sure they object's render transform is a translation
            TranslateTransform renderTranslation = e.RenderTransform as TranslateTransform;
            if (renderTranslation == null)
            {
                renderTranslation = new TranslateTransform(0, 0);
                e.RenderTransform = renderTranslation;
            }

            return new Point(renderTranslation.X, renderTranslation.Y);
        }

        private void SetRenderTransformOffset(UIElement e, Point offset)
        {
            //make sure they object's render transform is a translation
            TranslateTransform renderTranslation = e.RenderTransform as TranslateTransform;
            if (renderTranslation == null)
            {
                renderTranslation = new TranslateTransform(0, 0);
                e.RenderTransform = renderTranslation;
            }

            //set new offset
            renderTranslation.X = offset.X;
            renderTranslation.Y = offset.Y;
        }

        private Point GetTruePosition(UIElement e)
        {
            Point renderTranslation = GetRenderTransformOffset(e);
            return new Point(Canvas.GetLeft(e) + renderTranslation.X, Canvas.GetTop(e) + renderTranslation.Y);
        }

        private void SetTruePosition(UIElement e, Point p)
        {
            Vector canvasOffset = new Vector(Canvas.GetLeft(e), Canvas.GetTop(e));
            Point renderTranslation = p - canvasOffset;

            SetRenderTransformOffset(e, renderTranslation);
        }

        private Point GetCenter(Rect r)
        {
            return new Point((r.Left + r.Right) / 2.0, (r.Top + r.Bottom) / 2.0);
        }

    }

}
