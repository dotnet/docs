// <Snippet_graphicsmm_StateEventHandlers>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{

    public partial class StateExample : Page
    {

        private void parentTimelineStateInvalidated(object sender, EventArgs args)
        {
            Clock myClock = (Clock)sender;
            ParentTimelineStateTextBlock.Text +=
                myClock.CurrentTime.ToString() + ":"
                + myClock.CurrentState.ToString() + " ";
        }

        private void animation1StateInvalidated(object sender, EventArgs args)
        {

            Clock myClock = (Clock)sender;

            Animation1StateTextBlock.Text +=
                myClock.Parent.CurrentTime.ToString() + ":"
                + myClock.CurrentState.ToString() + " ";
        }

        private void animation2StateInvalidated(object sender, EventArgs args)
        {

            Clock myClock = (Clock)sender;
            Animation2StateTextBlock.Text +=
                myClock.Parent.CurrentTime.ToString() + ":"
                + myClock.CurrentState.ToString() + " ";
        }
    }
}
// </Snippet_graphicsmm_StateEventHandlers>