'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class WeatherForecastCallbacksConverter
'        Inherits JsonConverter(Of WeatherForecast)
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader,
'        '    type1 As Type,
'        '    options As JsonSerializerOptions) As WeatherForecast
'        '    ' Place "before" code here (OnDeserializing),
'        '    ' but note that there is no access here to the POCO instance.
'        '    Console.WriteLine("OnDeserializing")

'        '    ' Don't pass in options when recursively calling Deserialize.
'        '    Dim forecast As WeatherForecast = JsonSerializer.Deserialize(Of WeatherForecast)(reader)

'        '    ' Place "after" code here (OnDeserialized)
'        '    Console.WriteLine("OnDeserialized")

'        '    Return forecast
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter,
'            forecast As WeatherForecast, options As JsonSerializerOptions)
'            ' Place "before" code here (OnSerializing)
'            Console.WriteLine("OnSerializing")

'            ' Don't pass in options when recursively calling Serialize.
'            JsonSerializer.Serialize(writer, forecast)

'            ' Place "after" code here (OnSerialized)
'            Console.WriteLine("OnSerialized")
'        End Sub
'    End Class
'End Namespace
