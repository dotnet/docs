/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace TestToolWindowSearch_UnitTests.MyToolWindowTest
{
    class WindowFrameMock
    {
        const string propertiesName = "properties";

        private static GenericMockFactory frameFactory = null;

        /// <summary>
        /// Return a IVsWindowFrame without any special implementation
        /// </summary>
        /// <returns></returns>
        internal static IVsWindowFrame GetBaseFrame()
        {
            if (frameFactory == null)
                frameFactory = new GenericMockFactory("WindowFrame", new Type[] { typeof(IVsWindowFrame), typeof(IVsWindowFrame2) });
            IVsWindowFrame frame = (IVsWindowFrame)frameFactory.GetInstance();
            return frame;
        }
    }
}
