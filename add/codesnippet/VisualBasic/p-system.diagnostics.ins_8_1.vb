    ' Display the contents of an InstanceData object.
    Sub ProcessInstanceDataObject(ByVal name As String, _
                                  ByVal CSRef As CounterSample)

        Dim instData As New InstanceData(name, CSRef)
        Console.WriteLine("    Data from InstanceData object:" & vbCrLf & _
            "      InstanceName: {0,-31} RawValue: {1}", _
            instData.InstanceName, instData.RawValue)

        Dim sample As CounterSample = instData.Sample
        Console.WriteLine("    Data from CounterSample object:" & vbCrLf & _
            "      CounterType: {0,-32} SystemFrequency: {1}" & vbCrLf & _
            "      BaseValue: {2,-34} RawValue: {3}" & vbCrLf & _
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}" & vbCrLf & _
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", _
            sample.CounterType, sample.SystemFrequency, sample.BaseValue, _
            sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, _
            sample.TimeStamp, sample.TimeStamp100nSec)
    End Sub