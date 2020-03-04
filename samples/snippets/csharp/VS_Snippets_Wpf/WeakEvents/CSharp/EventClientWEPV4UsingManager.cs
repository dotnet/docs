using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WeakEvents
{
    class EventClientWEPV4UsingManager : EventClient
    {

        public EventClientWEPV4UsingManager(EventSource source) : base(source) { }

        protected override void AttachListeners()
        {
            // Still uses a WeakEventManager class
            SomeEventWeakEventManager.AddHandler(Source, source_SomeEvent);
        }

        void source_SomeEvent(object sender, SomeEventEventArgs e)
        {
            MessageBox.Show("EventClientWEPV4UsingManager handles EventSource.SomeEvent");
        }
    }
}
