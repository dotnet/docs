using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;

internal class Diagnostics
{
    public static void RunIt()
    {
        // <AddLink>
        ActivityContext activityContext = new(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None);
        ActivityLink activityLink = new(activityContext);

        Activity activity = new("LinkTest");
        activity.AddLink(activityLink);
        // </AddLink>

        // <Gauge>
        Meter soundMeter = new("MeasurementLibrary.Sound");
        Gauge<int> gauge = soundMeter.CreateGauge<int>(
            name: "NoiseLevel",
            unit: "dB", // Decibels.
            description: "Background Noise Level"
            );
        gauge.Record(10, new TagList() { { "Room1", "dB" } });
        // </Gauge>

        // <Wildcard>
        // The complete meter name is "MyCompany.MyMeter".
        var meter = new Meter("MyCompany.MyMeter");
        // Create a counter and allow publishing values.
        meter.CreateObservableCounter("MyCounter", () => 1);

        // Create the listener to use the wildcard character
        // to listen to all meters using prefix names.
        MyEventListener listener = new MyEventListener();
        // </Wildcard>
    }
}

// <EventListener>
internal class MyEventListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        Console.WriteLine(eventSource.Name);
        if (eventSource.Name == "System.Diagnostics.Metrics")
        {
            // Listen to all meters with names starting with "MyCompany".
            // If using "*", allow listening to all meters.
            EnableEvents(
                eventSource,
                EventLevel.Informational,
                (EventKeywords)0x3,
                new Dictionary<string, string?>() { { "Metrics", "MyCompany*" } }
                );
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        // Ignore other events.
        if (eventData.EventSource.Name != "System.Diagnostics.Metrics" ||
            eventData.EventName == "CollectionStart" ||
            eventData.EventName == "CollectionStop" ||
            eventData.EventName == "InstrumentPublished"
            )
            return;

        Console.WriteLine(eventData.EventName);

        if (eventData.Payload is not null)
        {
            for (int i = 0; i < eventData.Payload.Count; i++)
                Console.WriteLine($"\t{eventData.PayloadNames![i]}: {eventData.Payload[i]}");
        }
    }
}
// </EventListener>
