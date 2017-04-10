// <Snippet3>

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;
using System.Timers;

namespace TimerSample {
    // Define the event arguments
    [Serializable]
    public class TimerServiceEventArgs : EventArgs {
        private string m_Message;
        public TimerServiceEventArgs(string message) {
            m_Message = message;
        }

        public string Message {
            get {
                return m_Message;
            }
        }
    }
    
    // Define the delegate for the event
    public delegate void TimerExpiredEventHandler (object sender, TimerServiceEventArgs e);

    // Define the remote service class
    public class TimerService : MarshalByRefObject {
        private double m_MinutesToTime;
        private Timer m_Timer;

        // The client will subscribe and unsubscribe to this event
        public event TimerExpiredEventHandler TimerExpired;

        // Default: Initialize the TimerService to 4 minutes, the time required
        // to brew coffee in a French Press.
        public TimerService():this(4.0) {
        }
        
        public TimerService(double minutes) {
            Console.WriteLine("TimerService instantiated.");
            m_MinutesToTime = minutes;
            m_Timer = new Timer();
            m_Timer.Elapsed += new ElapsedEventHandler(OnElapsed);
        }
        
        public double MinutesToTime {
            get {
                return m_MinutesToTime;
            }
            set {
                m_MinutesToTime = value;
            }
        }

        public void Start() {
            if(!m_Timer.Enabled) {
                TimeSpan interval = TimeSpan.FromMinutes(m_MinutesToTime);
                m_Timer.Interval = interval.TotalMilliseconds;
                m_Timer.Enabled = true;
            }
            else {
                // TODO: Raise an exception
            }
        }
        
        private void OnElapsed(object source, ElapsedEventArgs e) {
            m_Timer.Enabled = false;

            // Fire Event
            if (TimerExpired != null) {
                // Package String in TimerServiceEventArgs
                TimerServiceEventArgs timerEventArgs = new TimerServiceEventArgs("TimerServiceEventArgs: Timer Expired.");
                Console.WriteLine("Firing TimerExpired Event");
                TimerExpired(this, timerEventArgs);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override Object InitializeLifetimeService() {
            ILease lease = (ILease)base.InitializeLifetimeService();
            if (lease.CurrentState == LeaseState.Initial) {
                lease.InitialLeaseTime = TimeSpan.FromMinutes(0.125);
                lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
                Console.WriteLine("TimerService: InitializeLifetimeService");
            }
             return lease;
        }
    }
}

// </Snippet3>