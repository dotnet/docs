/******************************************************************************
 *
 * File: RecordAndPlaybackStore.cs
 *
 * Description: Storage class for record and playback.
 *
 * See FindByAutomationID.xaml.cs for a full description of this sample.
 *
 *
 *  This file is part of the Microsoft WinfFX SDK Code Samples.
 *
 *  Copyright (C) Microsoft Corporation.  All rights reserved.
 *
 * This source code is intended only as a supplement to Microsoft
 * Development Tools and/or on-line documentation.  See these other
 * materials for detailed information regarding Microsoft code samples.
 *
 * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 *
 *****************************************************************************/

using System.Windows.Automation;
using System;

namespace UIAAutomationID_snip
{
    public class ElementStore
    {
        /// <summary>
        /// Stores and retrieves the AutomationElementInformation.AutomationID
        /// of the current automation element.
        /// </summary>
        public string AutomationID
        {
            get
            {
                return automationID;
            }
            set
            {
                automationID = value;
            }
        }
        string automationID;

        public string Name
        {
            get
            {
                return controlName;
            }
            set
            {
                controlName = value;
            }
        }
        string controlName;

        /// <summary>
        /// Stores and retrieves the AutomationElementInformation.ClassName
        /// of the current automation element.
        /// </summary>
        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
            }
        }
        string className;

        /// <summary>
        /// Stores and retrieves the
        /// AutomationElementInformation.ControlType.ProgrammaticName
        /// of the current automation element.
        /// </summary>
        public string ControlType
        {
            get
            {
                return controlType;
            }
            set
            {
                controlType = value;
            }
        }
        string controlType;

        /// <summary>
        /// Stores and retrieves the string name equivalent of the event ID
        /// the current automation element is reporting.
        /// </summary>
        public string EventID
        {
            get
            {
                return eventID;
            }
            set
            {
                eventID = value;
            }
        }
        string eventID;

        /// <summary>
        /// Stores and retrieves the time of an event.
        /// </summary>
        public DateTime EventTime
        {
            get
            {
                return eventTime;
            }
            set
            {
                eventTime = value;
            }
        }
        DateTime eventTime;

        /// <summary>
        /// Stores and retrieves the an array of supported Automation Patterns
        /// for the current automation element.
        /// </summary>
        public AutomationPattern[] SupportedPatterns
        {
            get
            {
                return supportedPatterns;
            }
            set
            {
                supportedPatterns = value;
            }
        }
        AutomationPattern[] supportedPatterns;
    }
}
