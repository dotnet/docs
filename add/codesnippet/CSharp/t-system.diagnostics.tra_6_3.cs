        [Event(3, Message = "loading page {1} activityID={0}", Opcode = EventOpcode.Start, 
            Task = Tasks.Page, Keywords = Keywords.Page, Level = EventLevel.Informational)]
        public void PageStart(int ID, string url) { if (IsEnabled()) WriteEvent(3, ID, url); }