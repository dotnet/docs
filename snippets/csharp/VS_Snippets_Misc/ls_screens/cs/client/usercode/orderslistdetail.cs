using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class OrdersListDetail
    {
        //<Snippet2>
        partial void ApprovedCheckBox_Validate
            (ScreenValidationResultsBuilder results)
        {
            ApprovedCheckBox = false;

        }
        //</Snippet2>
    }
}
