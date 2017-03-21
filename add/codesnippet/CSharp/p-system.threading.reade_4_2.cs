           if (!EventLog.SourceExists("MySource"))
           {
               EventLog.CreateEventSource("MySource", "MyPerformanceLog");
           }
           EventLog performanceLog = new EventLog();
           performanceLog.Source = "MySource";