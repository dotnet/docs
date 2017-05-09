namespace Microsoft.Samples.PerFrameAnimations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Threading;
    using System.Windows.Media;
    using System.Windows.Markup;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// This class is used internally to delegate it's rendering to the parent OverlayRenderDecorator.
    /// </summary>
    internal class OverlayRenderDecoratorOverlayVisual : DrawingVisual
    {
        private bool _hitTestVisible = false;

        internal bool IsHitTestVisible
        {
            get
            {
                return _hitTestVisible;
            }
            set
            {
                _hitTestVisible = value;
            }
        }

        //dont hit test, these are just overlay graphics
        protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
        {
            if (IsHitTestVisible)
                return base.HitTestCore(hitTestParameters);
            else
                return null;
        }

        //dont hit test, these are just overlay graphics
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            if (IsHitTestVisible)
                return base.HitTestCore(hitTestParameters);
            else
                return null;
        }
    }



    /// <summary>
    /// OverlayRenderDecorator provides a simple overlay graphics mechanism similar 
    /// to OnRender called OnOverlayRender
    /// </summary>
    [ContentProperty("Child")]
    public class OverlayRenderDecorator : FrameworkElement
    {
        //the only logical child
        private UIElement _child;
        private VisualCollection _vc;

        //this will be a visual child, but not a logical child.  as the last child, it can 'overlay' graphics
        // by calling back to us with OnOverlayRender
        private OverlayRenderDecoratorOverlayVisual _overlayVisual;


        //-------------------------------------------------------------------
        //
        //  Constructors
        //
        //-------------------------------------------------------------------

        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public OverlayRenderDecorator()
            : base()
        {
            _overlayVisual = new OverlayRenderDecoratorOverlayVisual();

            _vc = new VisualCollection(this);

            //insert the overlay element into the visual tree
            _vc.Add(_overlayVisual);
        }

        #endregion


        //-------------------------------------------------------------------
        //
        //  Public Properties
        //
        //-------------------------------------------------------------------

        #region Public Properties

        /// <summary>
        /// Enables/Disables hit testing on the overlay visual
        /// </summary>
        public bool IsOverlayHitTestVisible
        {
            get
            {
                if (_overlayVisual != null)
                    return _overlayVisual.IsHitTestVisible;
                else
                    return false;
            }
            set
            {
                if (_overlayVisual != null)
                    _overlayVisual.IsHitTestVisible = value;
            }
        }

        /// <summary>
        /// The single child of an <see cref="System.Windows.Media.Animation.OverlayRenderDecorator" />
        /// </summary>
        [DefaultValue(null)]
//<SnippetAddRemoveLogicalChild>
        public virtual UIElement Child
        {
            get
            {
                return _child;
            }
            set
            {
                if (_child != value)
                {
                    //need to remove old element from logical tree
                    if (_child != null)
                    {
                        OnDetachChild(_child);
                        RemoveLogicalChild(_child);
                    }

                    _vc.Clear();

                    if (value != null)
                    {
                        //add to visual
                        _vc.Add(value);
                        //add to logical
                        AddLogicalChild(value);
                    }

                    //always add the overlay child back into the visual tree if its set
                    if (_overlayVisual != null)
                        _vc.Add(_overlayVisual);

                    //cache the new child
                    _child = value;

                    //notify derived types of the new child
                    if (value != null)
                        OnAttachChild(_child);

                    InvalidateMeasure();
                }
            }
        }
//</SnippetAddRemoveLogicalChild>

        /// <summary> 
        /// Returns enumerator to logical children.
        /// </summary>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                if (_child == null)
                {
                    return (IEnumerator)new List<UIElement>().GetEnumerator();
                }
                List<UIElement> l = new List<UIElement>();
                l.Add(_child);
                return (IEnumerator)l.GetEnumerator();
            }
        }


        #endregion

        //-------------------------------------------------------------------
        //
        //  Protected Methods
        //
        //-------------------------------------------------------------------

        #region Protected Methods

        /// <summary>
        /// Updates DesiredSize of the OverlayRenderDecorator.  Called by parent UIElement.  This is the first pass of layout.
        /// </summary>
        /// <remarks>
        /// OverlayRenderDecorator determines a desired size it needs from the child's sizing properties, margin, and requested size.
        /// </remarks>
        /// <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
        /// <returns>The OverlayRenderDecorator's desired size.</returns>
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            UIElement child = Child;
            if (child != null)
            {
                child.Measure(constraint);
                return (child.DesiredSize);
            }
            return (new System.Windows.Size());
        }

        /// <summary>
        /// OverlayRenderDecorator computes the position of its single child inside child's Margin and calls Arrange
        /// on the child.
        /// </summary>
        /// <param name="arrangeSize">Size the OverlayRenderDecorator will assume.</param>
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
        {
            UIElement child = Child;
            if (child != null)
            {
                child.Arrange(new Rect(arrangeSize));
            }

            //Our OnRender gets called in Arrange, but
            //  we dont have access to that, so update the 
            //  overlay here.
            if (_overlayVisual != null)
            {
                using (DrawingContext dc = _overlayVisual.RenderOpen())
                {
                    //delegate to derived types
                    OnOverlayRender(dc);
                }
            }

            return (arrangeSize);
        }

        /// <summary>
        /// render method for overlay graphics.
        /// </summary>
        /// <param name="dc"></param>
        protected virtual void OnOverlayRender(DrawingContext dc)
        {

        }

        /// <summary>
        /// gives derives types a simple way to respond to a new child being added
        /// </summary>
        /// <param name="child"></param>
        protected virtual void OnAttachChild(UIElement child)
        {

        }

        /// <summary>
        /// gives derives types a simple way to respond to a child being removed
        /// </summary>
        /// <param name="child"></param>
        protected virtual void OnDetachChild(UIElement child)
        {

        }

        protected override int VisualChildrenCount
        {
            get {return _vc.Count;}
        }

        protected override Visual GetVisualChild(int index)
        {
            return _vc[index];
        }

        #endregion


    }

}