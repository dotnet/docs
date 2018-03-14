using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using MS.Win32;
using System.Collections;


namespace UIAITransformProvider_snip
{
    public class TransformProvider : IRawElementProviderSimple, ITransformProvider
    {
        // The custom control.
        private CustomControl customControl;
        // Window handle of the control.
        private IntPtr windowHandle;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">
        /// The control for which this object is providing UI Automation functionality.
        /// </param>
        public TransformProvider(CustomControl control)
        {
            customControl = control;
            windowHandle = control.Handle;
        }

        #region IRawElementProviderSimple Members
        
        /// <summary>
        /// Retrieves the object that supports the specified control pattern.
        /// </summary>
        /// <param name="patternId">The pattern identifier</param>
        /// <returns>
        /// The supporting object, or null if the pattern is not supported.
        /// </returns>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == TransformPatternIdentifiers.Pattern.Id)
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Gets provider property values.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <returns>The value of the property.</returns>
        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.Window.Id;
            }
            // It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
            //  because this value cannot be discovered by the HWND host provider. This is not 
            //  necessary for a Win32 provider.
            else if (propertyId == AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id)
            {
                return false;
            }
            else if (propertyId == AutomationElementIdentifiers.FrameworkIdProperty.Id)
            {
                return "Custom";
            }
            return null;
        }

        /// <summary>
        /// Gets the host provider.
        /// </summary>
        /// <remarks>
        /// Fragment roots return their window providers; most others return null.
        /// </remarks>
        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get
            {
                return AutomationInteropProvider.HostProviderFromHandle(windowHandle);
            }
        }

        /// <summary>
        /// Gets provider options.
        /// </summary>
        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

        #endregion IRawElementProviderSimple Members

        #region IRawElementProviderFragment Members

        /// <summary>
        /// Gets the bounding rectangle.
        /// </summary>
        /// <remarks>
        /// Fragment roots should return an empty rectangle. UI Automation will get the rectangle
        /// from the host control (the HWND in this case).
        /// </remarks>
        //System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        //{
        //    get
        //    {
        //        return System.Windows.Rect.Empty;
        //    }
        //}

        /// <summary>
        /// Gets the root of this fragment.
        /// </summary>
        //IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
        //{
        //    get
        //    {
        //        return this;
        //    }
        //}

        /// <summary>
        /// Gets any fragment roots that are embedded in this fragment.
        /// </summary>
        /// <returns>Null in this case.</returns>
        //IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
        //{
        //    return null;
        //}

        /// <summary>
        /// Gets the runtime identifier of the UI Automation element.
        /// </summary>
        /// <returns>Fragment roots return null.</returns>
        //int[] IRawElementProviderFragment.GetRuntimeId()
        //{
        //    return null;
        //}

        /// <summary>
        /// Navigates to adjacent elements in the UI Automation tree.
        /// </summary>
        /// <param name="direction">Direction of navigation.</param>
        /// <returns>The element in that direction, or null.</returns>
        /// <remarks>
        /// The provider only returns directions that it is responsible for.  
        /// In this case, none.
        ///</remarks>
        //IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        //{
        //    return null;
        //}

        /// <summary>
        /// Responds to a client request to set the focus to this control.
        /// </summary>
        /// <remarks>Setting focus to the control is handled by the parent window.</remarks>
        //void IRawElementProviderFragment.SetFocus()
        //{
        //    throw new Exception("The method is not implemented.");
        //}

        #endregion IRawElementProviderFragment Members
        
        #region IRawElementProviderFragmentRoot
 
        /// <summary>
        /// Gets the element at the specified point.
        /// </summary>
        /// <param name="x">Distance from the left of the application window.</param>
        /// <param name="y">Distance from the top of the application window.</param>
        /// <returns>The provider for the element at that point.</returns>
        //IRawElementProviderFragment
        //    IRawElementProviderFragmentRoot.ElementProviderFromPoint(double x, double y)
        //{
        //    System.Drawing.Point clientPoint = new System.Drawing.Point((int)x, (int)y);

        //    if (!this.OwnerTransformControl.DisplayRectangle.Contains(clientPoint))
        //    {
        //        return null;
        //    }
        //    return (IRawElementProviderFragment)this.OwnerTransformControl.Provider;
        //}

        /// <summary>
        /// Returns the element that gets focus.
        /// </summary>
        /// <returns>The selected item.</returns>
        //IRawElementProviderFragment IRawElementProviderFragmentRoot.GetFocus()
        //{
        //    return (IRawElementProviderFragment)this.OwnerTransformControl.Provider;
        //}

        #endregion IRawElementProviderFragmentRoot

        #region ITransformProvider Members

        // <SnippetCanMove>
        /// <summary>
        /// Specifies whether moving is supported.
        /// </summary>
        bool ITransformProvider.CanMove
        {
            get
            {
                return true;
            }
        }
        // </SnippetCanMove>

        // <SnippetCanResize>
        /// <summary>
        /// Specifies whether resizing is supported.
        /// </summary>
        bool ITransformProvider.CanResize
        {
            get
            {
                return true;
            }
        }
        // </SnippetCanResize>

        //<SnippetCanRotate>
        /// <summary>
        /// Specifies whether rotating is supported.
        /// </summary>
        bool ITransformProvider.CanRotate
        {
            get
            {
                return false;
            }
        }
        //</SnippetCanRotate>

        // <SnippetMove>
        /// <summary>
        /// Moves the provider to the specified position.
        /// </summary>
        /// <param name="x">The specified X screen coordinate.</param>
        /// <param name="y">The specified Y screen coordinate</param>
        void ITransformProvider.Move(double x, double y)
        {
            int leftInt = (int)x;
            int topInt = (int)y;

            if (!((ITransformProvider)this).CanMove)
                throw new InvalidOperationException(
                    "Operation cannot be performed.");

            // Move should never be allowed to place a control outside the 
            // bounds of its container; the control should always be accessible 
            // using the keyboard or mouse.
            // Use the bounds of the parent window to limit the placement 
            // of the custom control.
            int maxLeft = 10;
            int maxTop = 10;
            int maxRight = 
                this.customControl.formWidth - this.customControl.Width - 10;
            int maxBottom = 
                this.customControl.formHeight - this.customControl.Height - 10;

            if (leftInt < maxLeft)
                leftInt = 0;
            if (topInt < maxTop)
                topInt = 0;
            if (leftInt > maxRight)
                leftInt = maxRight;
            if (topInt > maxBottom)
                topInt = maxBottom;

            // Invoke control method on separate thread to avoid clashing with UI.
            // Use anonymous method for simplicity.
            this.customControl.Invoke(new MethodInvoker(delegate()
            {
                this.customControl.Left = leftInt;
                this.customControl.Top = topInt;
            }));
        }
        // </SnippetMove>

        // <SnippetResize>
        /// <summary>
        /// Resizes the provider to the specified height and width.
        /// </summary>
        /// <param name="height">The specified height.</param>
        /// <param name="width">The specified width.</param>
        void ITransformProvider.Resize(double width, double height)
        {
            if (!((ITransformProvider)this).CanResize)
                throw new InvalidOperationException("Operation cannot be performed.");

            if (width <= 0 | height <= 0)
                throw new InvalidOperationException("Operation cannot be performed.");

            int widthInt = (int)width;
            int heightInt = (int)height;

            // Resize should never be allowed to place a control outside the 
            // bounds of its container; the control should always be accessible 
            // using the keyboard or mouse.
            // Use the bounds of the parent window to limit the placement 
            // of the custom control.
            Size MaxSize = 
                new Size(this.customControl.formWidth - 20, 
                this.customControl.formHeight - 20);
            Size MinSize = new Size(10, 10);

            if (widthInt > MaxSize.Width)
                widthInt = MaxSize.Width;
            if (heightInt > MaxSize.Height)
                heightInt = MaxSize.Height;
            if (widthInt < MinSize.Width)
                widthInt = MinSize.Width;
            if (heightInt < MinSize.Height)
                heightInt = MinSize.Height;

            // Invoke control method on separate thread to avoid clashing with UI.
            // Use anonymous method for simplicity.
            this.customControl.Invoke(new MethodInvoker(delegate()
            {
                this.customControl.Size = new Size(widthInt, heightInt);
            }));
        }
        // </SnippetResize>

        // <SnippetRotate>
        /// <summary>
        /// Rotates the provider the specified number of degrees.
        /// </summary>
        void ITransformProvider.Rotate(double degreesToRotate)
        {
            throw new InvalidOperationException("Operation cannot be performed.");
        }
        // </SnippetRotate>


                    
        // Rotation code to be implemented.    
        //int degrees = (int)degreesToRotate;

            //int height = this.customControl.Height;
            //int width = this.customControl.Width;

            //Point offset = new Point();
            //offset.X = this.customControl.Width / 2;
            //offset.Y = this.customControl.Height / 2;

            //Point[] controlCorners = new Point[4];
            //controlCorners[0] = new Point(0, 0);
            //controlCorners[1] = new Point(this.customControl.Width, 0);
            //controlCorners[2] = new Point(this.customControl.Width, this.customControl.Height);
            //controlCorners[3] = new Point(0, this.customControl.Height);

            //Point[] controlCornersNew = new Point[4];


            //for (int loop = 0; loop <= 3; loop++)
            //{
            //    Point thisPoint = controlCorners[loop];
            //    double x = thisPoint.X - offset.X;
            //    double y = thisPoint.Y - offset.Y;
            //    thisPoint.X = (int)(x * Math.Cos(degrees) - y * Math.Sin(degrees));
            //    thisPoint.Y = (int)(x * Math.Sin(degrees) - y * Math.Cos(degrees));
            //    controlCornersNew[loop].X = thisPoint.X + offset.X;
            //    controlCornersNew[loop].Y = thisPoint.Y + offset.Y;
            //}

            //this.customControl.Invoke(new MethodInvoker(delegate()
            //{
            //    //this.customControl.Top = controlCornersNew[0].Y;
            //    //this.customControl.Left = controlCornersNew[0].X;
            //    this.customControl.Width = height;
            //    this.customControl.Height = width;
            //}));


        #endregion ITransformProvider Members

        #region Helper methods

        #endregion Helper methods
    }
}
