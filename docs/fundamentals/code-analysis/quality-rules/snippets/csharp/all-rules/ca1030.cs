using System;
using System.Collections.Generic;

namespace ca1030
{
    //<snippet1>
    // This class violates the rule.
    public class BadButton
    {
        private readonly List<Action> _clickHandlers = new List<Action>();

        public void AddOnClick(Action handler)
        {
            // Some internal logic...

            _clickHandlers.Add(handler);
        }

        public void RemoveOnClick(Action handler)
        {
            // Some internal logic...

            _clickHandlers.Remove(handler);
        }

        public void FireClick()
        {
            foreach (Action handler in _clickHandlers)
            {
                handler();
            }
        }
    }

    // This class satisfies the rule.
    public class GoodButton
    {
        private EventHandler? _clickHandler;

        public event EventHandler? ClickHandler
        {
            add
            {
                // Some internal logic...

                _clickHandler += value;
            }
            remove
            {
                // Some internal logic...

                _clickHandler -= value;
            }
        }

        protected virtual void OnClick(EventArgs e)
        {
            _clickHandler?.Invoke(this, e);
        }

        public void Click()
        {
            OnClick(EventArgs.Empty);
        }
    }
    //</snippet1>
}
