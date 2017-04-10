using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Collections;

namespace UIAIValueProvider_snip
{
    public class ValueProvider : IRawElementProviderSimple, IRawElementProviderFragmentRoot, IValueProvider
    {
        // The custom control.
        private CustomControl customControl;
        // Window handle of the control.
        private IntPtr windowHandle;
        // Default value for control
        private string controlValue;

          /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">
        /// The control for which this object is providing UI Automation functionality.
        /// </param>
        public ValueProvider(CustomControl control)
        {
            customControl = control;
            windowHandle = control.Handle;
            controlValue = "x";
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
            if (patternId == ValuePatternIdentifiers.Pattern.Id)
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
                return true;
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

        #region IValueProvider members

        // <SnippetIsReadOnly>
        /// <summary>
        /// Specifies whether the custom control is read only.
        /// </summary>
        bool IValueProvider.IsReadOnly
        {
            get
            {
                return false;
            }
        }
        // </SnippetIsReadOnly>

        // <SnippetValue>
        /// <summary>
        /// Retrieves the value of the custom control.
        /// </summary>
        string IValueProvider.Value
        {
            get
            {
                return controlValue;
            }
        }
        // </SnippetValue>

        // <SnippetSetValue>
        /// <summary>
        /// Sets the value of the control.
        /// </summary>
        /// <param name="value">
        /// The new value.
        /// </param>
        void IValueProvider.SetValue(string value)
        {
            if (((IValueProvider)this).IsReadOnly)
                throw new InvalidOperationException(
                    "Operation cannot be performed.");
            // Arbitrary string length limit.
            if (value.Length > 5)
                throw new ArgumentOutOfRangeException(
                    "String is greater than five characters in length.");
            controlValue = value;
        }
        // </SnippetSetValue>



        #endregion IValueProvider members
        
        #region IRawElementProviderFragment Members

        /// <summary>
        /// Gets the bounding rectangle.
        /// </summary>
        /// <remarks>
        /// Fragment roots should return an empty rectangle. UI Automation will get the rectangle
        /// from the host control (the HWND in this case).
        /// </remarks>
        System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        {
            get
            {
                return System.Windows.Rect.Empty;
            }
        }

        /// <summary>
        /// Gets the root of this fragment.
        IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets any fragment roots that are embedded in this fragment.
        /// </summary>
        /// <returns>Null in this case.</returns>
        IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
        {
            return null;
        }

        /// <summary>
        /// Gets the runtime identifier of the UI Automation element.
        /// </summary>
        /// <returns>Fragment roots return null.</returns>
        int[] IRawElementProviderFragment.GetRuntimeId()
        {
            return null;
        }

        /// <summary>
        /// Navigates to adjacent elements in the UI Automation tree.
        /// </summary>
        /// <param name="direction">Direction of navigation.</param>
        /// <returns>The element in that direction, or null.</returns>
        /// <remarks>The provider only returns directions that it is responsible for.  
        /// UI Automation knows how to navigate between HWNDs, so only the custom item 
        /// navigation needs to be provided.
        ///</remarks>
        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            switch (direction)
            {
                case NavigateDirection.Parent:
                    return null;

                case NavigateDirection.NextSibling:
                    return null;

                case NavigateDirection.PreviousSibling:
                    return null;

                case NavigateDirection.FirstChild:
                    return null;

                case NavigateDirection.LastChild:
                    return null;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Responds to a client request to set the focus to this control.
        /// </summary>
        /// <remarks>Setting focus to the control is handled by the parent window.</remarks>
        void IRawElementProviderFragment.SetFocus()
        {
            throw new Exception("The method is not implemented.");
        }

        #endregion IRawElementProviderFragment Members

        #region IRawElementProviderFragmentRoot Members

        public IRawElementProviderFragment ElementProviderFromPoint(double x, double y)
        {
            return (IRawElementProviderFragment)this.customControl.Provider;
        }

        public IRawElementProviderFragment GetFocus()
        {
            return (IRawElementProviderFragment)this.customControl.Provider;
        }

        #endregion
    }
}
