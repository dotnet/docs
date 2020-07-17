using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace CustomElementClient
{
    class PropertySnips
    {
        //AutomationElement autoElement;

        /// <summary>
        /// Constructor.
        /// </summary>

        public PropertySnips()
        {
            ;
        }

        // <Snippet172>

        AutomationPropertyChangedEventHandler propChangeHandler;
        /// <summary>
        /// Adds a handler for property-changed event; in particular, a change in the enabled state.
        /// </summary>
        /// <param name="element">The UI Automation element whose state is being monitored.</param>
        public void SubscribePropertyChange(AutomationElement element)
        {
            Automation.AddAutomationPropertyChangedEventHandler(element,
                TreeScope.Element,
                propChangeHandler = new AutomationPropertyChangedEventHandler(OnPropertyChange),
                AutomationElement.IsEnabledProperty);
        }

        /// <summary>
        /// Handler for property changes.
        /// </summary>
        /// <param name="src">The source whose properties changed.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPropertyChange(object src, AutomationPropertyChangedEventArgs e)
        {
            AutomationElement sourceElement = src as AutomationElement;
            if (e.Property == AutomationElement.IsEnabledProperty)
            {
                bool enabled = (bool)e.NewValue;
                // TODO: Do something with the new value.
                // The element that raised the event can be identified by its runtime ID property.
            }
            else
            {
                // TODO: Handle other property-changed events.
            }
        }

        public void UnsubscribePropertyChange(AutomationElement element)
        {
            if (propChangeHandler != null)
            {
                Automation.RemoveAutomationPropertyChangedEventHandler(element, propChangeHandler);
            }
        }
        // </Snippet172>

        public void GetAllProperties(AutomationElement autoElement)
        {

            // *** AcceleratorKeyProperty
            // <Snippet124>
            string acceleratorKey =
                autoElement.GetCurrentPropertyValue(AutomationElement.AcceleratorKeyProperty) as string;
            // </Snippet124>

            // <Snippet125>
            string acceleratorKeyString;
            object acceleratorKeyNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.AcceleratorKeyProperty, true);
            if (acceleratorKeyNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                acceleratorKeyString = acceleratorKeyNoDefault as string;
            }
            // </Snippet125>

            // *** AccessKeyProperty
            // <Snippet127>
            string accessKey =
                autoElement.GetCurrentPropertyValue(AutomationElement.AccessKeyProperty) as string;
            // </Snippet127>

            // <Snippet128>
            string accessKeyString;
            object accessKeyNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.AccessKeyProperty, true);
            if (accessKeyNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                accessKeyString = accessKeyNoDefault as string;
            }
            // </Snippet128>

            // *** AutomationIdProperty
            // <Snippet129>
            string autoId =
                autoElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty) as string;
            // </Snippet129>

            // <Snippet130>
            string autoIdString;
            object autoIdNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, true);
            if (autoIdNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                autoIdString = autoIdNoDefault as string;
            }
            // </Snippet130>

            // *** BoundingRectangleProperty. Default is Rect.Empty.
            // <Snippet131>
            System.Windows.Rect boundingRect = (System.Windows.Rect)
                autoElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
            // </Snippet131>

            // <Snippet132>
            System.Windows.Rect boundingRect1;
            object boundingRectNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty, true);
            if (boundingRectNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                boundingRect1 = (System.Windows.Rect)boundingRectNoDefault;
            }
            // </Snippet132>

            // *** ClassNameProperty
            // <Snippet133>
            string className =
                autoElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty) as string;
            // </Snippet133>

            // <Snippet134>
            string classNameString;
            object classNameNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty, true);
            if (classNameNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                classNameString = classNameNoDefault as string;
            }
            // </Snippet134>

            // *** ClickablePointProperty.
            // <Snippet135>
            System.Windows.Point clickablePoint = new System.Windows.Point(-1,-1);
            object prop = autoElement.GetCurrentPropertyValue(AutomationElement.ClickablePointProperty);
            // Do not attempt to cast prop if it is null.
            if (prop is System.Windows.Point)
            {
                clickablePoint = (System.Windows.Point)prop;
            }
            // </Snippet135>

            // <Snippet166>
            System.Windows.Point clickablePoint1;
            object clickablePointNoDefault =
                autoElement.GetCurrentPropertyValue(AutomationElement.ClickablePointProperty, true);
            if (clickablePointNoDefault == AutomationElement.NotSupported)
            {
                // TODO Handle the case where you do not wish to proceed using the default value.
            }
            else
            {
                clickablePoint1 = (System.Windows.Point)clickablePointNoDefault;
            }
            // </Snippet166>

            // *** ControlTypeProperty
            // <Snippet136>
             ControlType controlTypeId =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty)
                 as ControlType;
            // </Snippet136>

             // <Snippet137>
             ControlType controlTypeId1;
             object controlTypeNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty, true);
             if (controlTypeNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 controlTypeId1 = controlTypeNoDefault as ControlType;
             }
             // </Snippet137>

             // *** CultureInfoProperty
             // <Snippet138>
             System.Globalization.CultureInfo culture =
                autoElement.GetCurrentPropertyValue(AutomationElement.CultureProperty)
                as System.Globalization.CultureInfo;
             // </Snippet138>

             // *** FrameworkIdProperty
             // <Snippet139>
             string frameworkId =
                autoElement.GetCurrentPropertyValue(AutomationElement.FrameworkIdProperty)
                as string;
             // </Snippet139>

             // *** HasKeyboardFocusProperty
             // <Snippet140>
             bool hasFocus = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty);
             // </Snippet140>

             // *** IsContentElementProperty
             // <Snippet141>
             bool isContent = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsContentElementProperty);
             // </Snippet141>

             // <Snippet142>
             bool isContent1;
             object isContentNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.IsContentElementProperty, true);
             if (isContentNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 isContent1 = (bool)isContentNoDefault;
             }
             // </Snippet142>

             // *** IsControlElementProperty
             // <Snippet143>
             bool isControl = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsControlElementProperty);
             // </Snippet143>

             // <Snippet144>
             bool isControl1;
             object isControlNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.IsControlElementProperty, true);
             if (isControlNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 isControl1 = (bool)isControlNoDefault;
             }
             // </Snippet144>

            // *** IsXXXPatternAvailableProperty
             // <Snippet145>
             // TODO  Substitute the appropriate field for IsDockPatternAvailableProperty.
             bool isPatternAvailable = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsDockPatternAvailableProperty);
             // </Snippet145>

            // *** IsEnabledProperty
             // <Snippet146>
             bool isControlEnabled = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
             // </Snippet146>

             // *** IsKeyboardFocusableProperty
             // <Snippet147>
             bool isControlFocusable = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty);
             // </Snippet147>

             // *** IsOffscreenProperty
             // <Snippet148>
             bool isControlOffscreen = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty);
             // </Snippet148>

             // <Snippet149>
             bool isControlOffscreen1;
             object isOffscreenNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty, true);
             if (isOffscreenNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 isControlOffscreen1 = (bool)isOffscreenNoDefault;
             }
             // </Snippet149>

             // *** IsPasswordProperty
             // <Snippet150>
             bool isTextPassword = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsPasswordProperty);
             // </Snippet150>

             // *** IsRequiredForFormProperty
            // <Snippet151>
             bool isRequired = (bool)
                autoElement.GetCurrentPropertyValue(AutomationElement.IsRequiredForFormProperty);
            // </Snippet151>

             // *** ItemStatusProperty
             // <Snippet152>
             string itemStatus =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ItemStatusProperty) as string;
             // </Snippet152>

            // <Snippet153>
             string itemStatus1;
             object itemStatusNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ItemStatusProperty, true);
             if (itemStatusNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 itemStatus1 = itemStatusNoDefault as string;
             }
             // </Snippet153>

             // *** ItemTypeProperty
             // <Snippet154>
             string itemType =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ItemTypeProperty) as string;
             // </Snippet154>

             // <Snippet155>
             string itemType1;
             object itemTypeNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ItemTypeProperty, true);
             if (itemTypeNoDefault == AutomationElement.NotSupported)
             {
                 itemType1 = "Unknown type";
             }
             else
             {
                 itemType1 = itemStatusNoDefault as string;
             }
             // </Snippet155>

             // *** LabeledByProperty
             // <Snippet156>
             AutomationElement labeler =
                 autoElement.GetCurrentPropertyValue(AutomationElement.LabeledByProperty) as AutomationElement;
             // </Snippet156>

             // <Snippet157>
             AutomationElement labeler1;
             object labelerNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.LabeledByProperty, true);
             if (labelerNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 labeler1 = labelerNoDefault as AutomationElement;
             }
             // </Snippet157>

             // *** LocalizedControlTypeProperty
             // <Snippet158>
             string localizedType =
                 autoElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty) as string;
             // </Snippet158>

             // <Snippet159>
             string localizedType1;
             object localizedTypeNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, true);
             if (localizedTypeNoDefault == AutomationElement.NotSupported)
             {
                 localizedType1 = "Unknown type.";
             }
             else
             {
                 localizedType1 = localizedTypeNoDefault as string;
             }
             // </Snippet159>

             // *** NameProperty
             // <Snippet160>
             string nameProp =
                 autoElement.GetCurrentPropertyValue(AutomationElement.NameProperty) as string;
             // </Snippet160>

             // <Snippet161>
             string nameProp1;
             object namePropNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.NameProperty, true);
             if (namePropNoDefault == AutomationElement.NotSupported)
             {
                 nameProp1 = "No name.";
             }
             else
             {
                 nameProp1 = namePropNoDefault as string;
             }
             // </Snippet161>

             // *** NativeWindowHandleProperty
             // <Snippet162>
             int nativeHandle = (int)
                 autoElement.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty);
             // </Snippet162>

             // <Snippet163>
             int nativeHandle1;
             object nativeHandleNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty, true);
             if (nativeHandleNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 nativeHandle1 = (int)nativeHandleNoDefault;
             }
             // </Snippet163>

             // *** OrientationProperty
             // <Snippet164>
             OrientationType orientationType = (OrientationType)
                 autoElement.GetCurrentPropertyValue(AutomationElement.OrientationProperty);
             // </Snippet164>

             // <Snippet165>
             OrientationType orientationType1;
             object orientationTypeNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.OrientationProperty, true);
             if (orientationTypeNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 orientationType1 = (OrientationType)orientationTypeNoDefault;
             }
             // </Snippet165>

             // *** ProcessIdProperty
             // <Snippet167>
             int processIdentifier = (int)
                 autoElement.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty);
             // </Snippet167>

             // <Snippet168>
             int processIdentifier1;
             object processIdentifierNoDefault =
                 autoElement.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty, true);
             if (processIdentifierNoDefault == AutomationElement.NotSupported)
             {
                 // TODO Handle the case where you do not wish to proceed using the default value.
             }
             else
             {
                 processIdentifier1 = (int)processIdentifierNoDefault;
             }
             // </Snippet168>

             // *** RuntimeIdProperty
             // <Snippet169>
             int[] runtimeIdentifier = (int[])
                 autoElement.GetCurrentPropertyValue(AutomationElement.RuntimeIdProperty);
             // </Snippet169>

             // <Snippet999>
             //  To be written.
             // </Snippet999>
        }
}
}
