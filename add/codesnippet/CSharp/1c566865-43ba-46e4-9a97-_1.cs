
        // Create an event collection.
        // Add to it the created simulatedEvents.
        public static void AddEvents()
        {
            events = 
            new System.Web.Management.WebBaseEventCollection(
            simulatedEvents);
        }
