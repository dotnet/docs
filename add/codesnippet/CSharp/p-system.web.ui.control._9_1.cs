        // Create an event that adds and removes handlers from the
        // Control.Events collection when this event is called from
        // a participating page.
        public event EventHandler Click {
            add {
                Events.AddHandler(EventClick, value);
            }
            remove {
                Events.RemoveHandler(EventClick, value);
            }
        }