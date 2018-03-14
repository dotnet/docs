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


namespace UIAIToggleProvider_snip
{
    public class ToggleProvider : IRawElementProviderSimple, IToggleProvider
    {
        // The custom control.
        private CustomControl customControl;
        // Window handle of the control.
        private IntPtr windowHandle;

        //Color[] toggleColor = new Color[3];

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">
        /// The control for which this object is providing UI Automation functionality.
        /// </param>
        public ToggleProvider(CustomControl control)
        {
            customControl = control;
            windowHandle = control.Handle;
            //toggleColor[(int)ToggleState.Off] = Color.Red;
            //toggleColor[(int)ToggleState.On] = Color.Green;
            //toggleColor[(int)ToggleState.Indeterminate] = Color.Yellow;
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
            if (patternId == TogglePatternIdentifiers.Pattern.Id)
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

        #region IToggleProvider Members

        // <SnippetToggleState>
        /// <summary>
        /// Retrieves the toggle state of the control.
        /// </summary>
        /// <remarks>
        /// For this custom control the toggle state is reflected by the color 
        /// of the control. This is analogous to the CheckBox IsChecked property.
        /// Green   - ToggleState.On
        /// Red     - ToggleState.Off
        /// Yellow  - ToggleState.Indeterminate
        /// </remarks>
        ToggleState IToggleProvider.ToggleState
        {
            get
            {
                return customControl.toggleStateColor[customControl.controlColor];;
            }
        }
        // </SnippetToggleState>

        // <SnippetToggle>
        /// <summary>
        /// Toggles the control.
        /// </summary>
        /// <remarks>
        /// For this custom control the toggle state is reflected by the color 
        /// of the control. This is analogous to the CheckBox IsChecked property.
        /// Green   - ToggleState.On
        /// Red     - ToggleState.Off
        /// Yellow  - ToggleState.Indeterminate
        /// </remarks>
        void IToggleProvider.Toggle()
        {
            ToggleState toggleState = 
                customControl.toggleStateColor[customControl.controlColor];
            // Invoke control method on separate thread to avoid clashing with UI.
            // Use anonymous method for simplicity.
            this.customControl.Invoke(new MethodInvoker(delegate()
            {
                if (toggleState == ToggleState.On)
                {
                    customControl.controlColor = Color.Red;
                }
                else if (toggleState == ToggleState.Off)
                {
                    customControl.controlColor = Color.Yellow;
                }
                else if (toggleState == ToggleState.Indeterminate)
                {
                    customControl.controlColor = Color.Green;
                }
                customControl.Refresh();
            }));
        }
        // </SnippetToggle>


        #endregion IToggleProvider Members

        #region Helper methods

        // <snippet_GetToggleState>
        /// <summary>
        /// Retrieves the toggle state of the control.
        /// </summary>
        //public ToggleState GetToggleState()
        //{
        //    return customControl.toggleColor[customControl.controlColor];
        //    //ListViewItem.CheckState current = (ListViewItem.CheckState)WindowsListView.GetCheckedState(_hwnd, _listviewItem);

        //    //switch (current)
        //    //{
        //    //    case ListViewItem.CheckState.NoCheckbox:
        //    //        {
        //    //            throw new InvalidOperationException(SR.Get(SRID.OperationCannotBePerformed));
        //    //        }

        //    //    case ListViewItem.CheckState.Checked:
        //    //        {
        //    //            return ToggleState.On;
        //    //        }

        //    //    case ListViewItem.CheckState.Unchecked:
        //    //        {
        //    //            return ToggleState.Off;
        //    //        }
        //    //}

        //    // developer defined custom values which cannot be interpret outside of the app's scope
        //    return ToggleState.Indeterminate;
        //}
        // </snippet_GetToggleState>
        #endregion Helper methods
    }
}
