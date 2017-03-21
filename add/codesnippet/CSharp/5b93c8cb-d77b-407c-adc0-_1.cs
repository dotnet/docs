    // Display the contents of an InstanceData object.
    public static void ProcessInstanceDataObject(string name, CounterSample CSRef)
    {

        InstanceData instData = new InstanceData(name, CSRef);
        Console.WriteLine("    Data from InstanceData object:\r\n" +
            "      InstanceName: {0,-31} RawValue: {1}", instData.InstanceName, instData.RawValue);

        CounterSample sample = instData.Sample;
        Console.WriteLine("    Data from CounterSample object:\r\n" +
            "      CounterType: {0,-32} SystemFrequency: {1}\r\n" +
            "      BaseValue: {2,-34} RawValue: {3}\r\n" +
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}\r\n" +
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", sample.CounterType, sample.SystemFrequency, sample.BaseValue, sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, sample.TimeStamp, sample.TimeStamp100nSec);
    }