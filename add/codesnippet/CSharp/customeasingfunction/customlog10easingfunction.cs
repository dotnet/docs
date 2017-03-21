using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

// <SnippetCustomEasingFunction>
namespace CustomEasingFunction
{
    public class CustomSeventhPowerEasingFunction : EasingFunctionBase
    {
        public CustomSeventhPowerEasingFunction()
            : base()
        {
        }

        // Specify your own logic for the easing function by overriding
        // the EaseInCore method. Note that this logic applies to the "EaseIn"
        // mode of interpolation. 
        protected override double EaseInCore(double normalizedTime)
        {
            // applies the formula of time to the seventh power.
            return Math.Pow(normalizedTime, 7);
        }

        // Typical implementation of CreateInstanceCore
        protected override Freezable CreateInstanceCore()
        {

            return new CustomSeventhPowerEasingFunction();
        }

    }
}
// </SnippetCustomEasingFunction>