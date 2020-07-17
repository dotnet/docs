using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakEvents
{
    public abstract class EventClient
    {
        protected EventSource Source { get; set; }
        protected abstract void AttachListeners();

        public EventClient(EventSource source)
        {
            this.Source = source;
            this.AttachListeners();
        }
    }
}
