        Dim document As XPathDocument = New XPathDocument("valueas.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' ValueAsBoolean
        navigator.MoveToChild("root", "")
        navigator.MoveToChild("booleanElement", "")
        Dim booleanValue As Boolean = navigator.ValueAsBoolean
        Console.WriteLine(navigator.LocalName + ": " + booleanValue)

        ' ValueAsDateTime
        navigator.MoveToNext("dateTimeElement", "")
        Dim dateTimeValue As DateTime = navigator.ValueAsDateTime
        Console.WriteLine(navigator.LocalName + ": " + dateTimeValue)

        ' ValueAsDouble, ValueAsInt32, ValueAsInt64, ValueAsSingle
        navigator.MoveToNext("numberElement", "")
        Dim doubleValue As Double = navigator.ValueAsDouble
        Dim int32Value As Int32 = navigator.ValueAsInt
        Dim int64Value As Int64 = navigator.ValueAsLong
        Console.WriteLine(navigator.LocalName + ": " + doubleValue)
        Console.WriteLine(navigator.LocalName + ": " + int32Value)
        Console.WriteLine(navigator.LocalName + ": " + int64Value)