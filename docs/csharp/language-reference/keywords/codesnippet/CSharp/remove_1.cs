
    class Events : IDrawingObject
    {
        event EventHandler PreDrawEvent;

        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent -= value;
                }
            }
        }

    }