using System;

namespace ca1003
{
    //<snippet1>
    // This delegate violates the rule.
    public delegate void CustomEventHandler(object sender, CustomEventArgs e);

    public class CustomEventArgs : EventArgs
    {
        public string info = "data";
    }

    public class ClassThatRaisesEvent
    {
        public event CustomEventHandler SomeEvent;

        protected virtual void OnSomeEvent(CustomEventArgs e)
        {
            SomeEvent?.Invoke(this, e);
        }

        public void SimulateEvent()
        {
            OnSomeEvent(new CustomEventArgs());
        }
    }

    public class ClassThatHandlesEvent
    {
        public ClassThatHandlesEvent(ClassThatRaisesEvent eventRaiser)
        {
            eventRaiser.SomeEvent += new CustomEventHandler(HandleEvent);
        }

        private void HandleEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine("Event handled: {0}", e.info);
        }
    }

    class Test
    {
        static void MainEvent()
        {
            var eventRaiser = new ClassThatRaisesEvent();
            var eventHandler = new ClassThatHandlesEvent(eventRaiser);

            eventRaiser.SimulateEvent();
        }
    }
    //</snippet1>
}

namespace ca1003_fix
{
    //<snippet2>
    public class CustomEventArgs : EventArgs
    {
        public string info = "data";
    }

    public class ClassThatRaisesEvent
    {
        public event EventHandler<CustomEventArgs> SomeEvent;

        protected virtual void OnSomeEvent(CustomEventArgs e)
        {
            SomeEvent?.Invoke(this, e);
        }

        public void SimulateEvent()
        {
            OnSomeEvent(new CustomEventArgs());
        }
    }

    public class ClassThatHandlesEvent
    {
        public ClassThatHandlesEvent(ClassThatRaisesEvent eventRaiser)
        {
            eventRaiser.SomeEvent += new EventHandler<CustomEventArgs>(HandleEvent);
        }

        private void HandleEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine("Event handled: {0}", e.info);
        }
    }

    class Test
    {
        static void MainEvent()
        {
            var eventRaiser = new ClassThatRaisesEvent();
            var eventHandler = new ClassThatHandlesEvent(eventRaiser);

            eventRaiser.SimulateEvent();
        }
    }
    //</snippet2>
}
