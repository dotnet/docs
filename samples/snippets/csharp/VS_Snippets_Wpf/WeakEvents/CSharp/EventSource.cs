using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakEvents
{
    public class SomeEventEventArgs : EventArgs
    {
        public string TimeStamp { get; set; }

        public SomeEventEventArgs()
        {
            TimeStamp = DateTime.Now.ToLongTimeString();
        }


    }

    public class EventSource
    {
        public event EventHandler<SomeEventEventArgs> SomeEvent;

        public void RaiseDoEvent()
        {
            OnSomeEvent(new SomeEventEventArgs());
        }

        protected void OnSomeEvent(SomeEventEventArgs e)
        {
            if (SomeEvent != null)
            {
                SomeEvent(this, e);
            }
        }
    }
}
