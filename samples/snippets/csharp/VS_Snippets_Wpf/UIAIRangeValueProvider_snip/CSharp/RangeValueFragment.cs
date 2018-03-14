using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Drawing;

namespace UIAIRangeValueProvider_snip
{
    class RangeValueProvider : IRangeValueProvider, IRawElementProviderSimple
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
        public RangeValueProvider(CustomControl control)
        {
            customControl = control;
            windowHandle = control.Handle;
        }

       #region IRangeValueProvider Members

        // <SnippetIsReadOnly>
        /// <summary>
        /// Specifies whether the control is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get 
            { 
                return !(this.customControl.Enabled); 
            }
        }
        // </SnippetIsReadOnly>

        // <SnippetLargeChange>
        /// <summary>
        /// Specifies the large change value.
        /// </summary>
        public double LargeChange
        {
            get 
            { 
                return 5.0;
            }
        }
        // </SnippetLargeChange>

        // <SnippetMaximum>
        /// <summary>
        /// Specifies the maximum value of the range.
        /// </summary>
        public double Maximum
        {
            get 
            { 
                return 255.0;
            }
        }
        // </SnippetMaximum>

        // <SnippetMinimum>
        /// <summary>
        /// Specifies the minimum value of the range.
        /// </summary>
        public double Minimum
        {
            get 
            { 
                return 0.0;
            }
        }
        // </SnippetMinimum>

        // <SnippetSetValue>
        /// <summary>
        /// Sets the value of the control.
        /// </summary>
        /// <param name="value">
        /// The value to set the control to.
        /// </param>
        /// <remarks>
        /// For the purposes of this sample, the custom control displays 
        /// its value through the alpha setting of its base color.
        /// </remarks>
        public void SetValue(double value)
        {
            if (value < Minimum | value > Maximum)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Color color = customControl.controlColor;
                // Invoke control method on separate thread to avoid 
                // clashing with UI.
                // Use anonymous method for simplicity.
                this.customControl.Invoke(new MethodInvoker(delegate()
                {
                    customControl.controlColor =
                        Color.FromArgb((int)value, color);
                    customControl.Refresh();
                }));
            }
        }
        // </SnippetSetValue>

        // <SnippetSmallChange>
        /// <summary>
        /// Specifies the small change value.
        /// </summary>
        public double SmallChange
        {
            get 
            { 
                return 1.0; 
            }
        }
        // </SnippetSmallChange>

        // <SnippetValue>
        /// <summary>
        /// Specifies the current value of the control.
        /// </summary>
        /// <remarks>
        /// For the purposes of this sample, the custom control displays 
        /// its value through the alpha setting of the base color.
        /// </remarks>
        public double Value
        {
            get 
            {
                return customControl.colorAlpha; 
            }
        }
        // </SnippetValue>

        #endregion

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
            if (patternId == RangeValuePatternIdentifiers.Pattern.Id)
            {
                return this;
            }
            return null;
        }

        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.Window.Id;
            }
            // It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
            // because this value cannot be discovered by the HWND host provider. This is not 
            // necessary for a Win32 provider.
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

        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

        #endregion
    }
}
