        [Event(7, Level = EventLevel.Verbose, Keywords = Keywords.DataBase)]
        public void Mark(int ID) { if (IsEnabled()) WriteEvent(7, ID); }