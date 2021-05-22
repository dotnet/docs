Imports System.Runtime.CompilerServices
Imports System.Text.Json.Serialization

Namespace SystemTextJsonSamples

    ' <WF>
    Public Class WeatherForecast
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
    End Class

    ' </WF>
    ' <WFWithReqPptyConverterAttr>
    ' This code example doesn't apply to Visual Basic. For more information, go to the following URL:
    ' https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to#visual-basic-support
    ' </WFWithReqPptyConverterAttr>

    ' <WFWithPrevious>
    Public Class WeatherForecastWithPrevious
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public Property PreviousForecast As WeatherForecast
    End Class

    ' </WFWithPrevious>

    ' <WFWithPreviousAsObject>
    Public Class WeatherForecastWithPreviousAsObject
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public Property PreviousForecast As Object
    End Class

    ' </WFWithPreviousAsObject>

    ' <WFWithLong>
    ' This code example doesn't apply to Visual Basic. For more information, go to the following URL:
    ' https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to#visual-basic-support
    ' </WFWithLong>

    ' <WFWithDefault>
    Public Class WeatherForecastWithDefault

        Public Sub New()
            [Date] = DateTimeOffset.Parse("2001-01-01")
            Summary = "No summary"
        End Sub

        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
    End Class

    ' </WFWithDefault>

    ' <WFWithExtensionData>
    Public Class WeatherForecastWithExtensionData
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String

        <JsonExtensionData>
        Public Property ExtensionData As Dictionary(Of String, Object)

    End Class

    ' </WFWithExtensionData>

    ' <WFWithConverterAttribute>
    ' This code example doesn't apply to Visual Basic. For more information, go to the following URL:
    ' https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to#visual-basic-support
    ' </WFWithConverterAttribute>

    ' <WFWithPropertyNameAttribute>
    Public Class WeatherForecastWithPropertyNameAttribute
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String

        <JsonPropertyName("Wind")>
        Public Property WindSpeed As Integer

    End Class

    ' </WFWithPropertyNameAttribute>

    ' <WFWithIgnoreAttribute>
    Public Class WeatherForecastWithIgnoreAttribute
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer

        <JsonIgnore>
        Public Property Summary As String

    End Class

    ' </WFWithIgnoreAttribute>

    ' <WFDerived>
    Public Class WeatherForecastDerived
        Inherits WeatherForecast
        Public Property WindSpeed As Integer
    End Class

    ' </WFDerived>

    ' <WFWithObjectProperties>
    Public Class WeatherForecastWithObjectProperties
        Public Property [Date] As Object
        Public Property TemperatureCelsius As Object
        Public Property Summary As Object
    End Class

    ' </WFWithObjectProperties>

    ' <WFWithROProperty>
    Public Class WeatherForecastWithROProperty
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Private _windSpeedReadOnly As Integer

        Public Property WindSpeedReadOnly As Integer
            Get
                Return _windSpeedReadOnly
            End Get
            Private Set(Value As Integer)
                _windSpeedReadOnly = Value
            End Set
        End Property

    End Class

    ' </WFWithROProperty>

    ' <WFWithTemperatureStruct>
    ' This code example doesn't apply to Visual Basic. For more information, go to the following URL:
    ' https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to#visual-basic-support
    ' </WFWithTemperatureStruct>

    ' <WFWithDictionary>
    Public Class WeatherForecastWithDictionary
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public Property TemperatureRanges As Dictionary(Of String, Integer)
    End Class

    ' </WFWithDictionary>

    ' <WFWithEnumDictionary>
    Public Class WeatherForecastWithEnumDictionary
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public Property TemperatureRanges As Dictionary(Of SummaryWordsEnum, Integer)
    End Class

    Public Enum SummaryWordsEnum
        Cold
        Hot
    End Enum

    ' </WFWithEnumDictionary>

    ' <WFWithPOCOs>
    Public Class WeatherForecastWithPOCOs
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As String
        Public SummaryField As String
        Public Property DatesAvailable As IList(Of DateTimeOffset)
        Public Property TemperatureRanges As Dictionary(Of String, HighLowTemps)
        Public Property SummaryWords As String()
    End Class

    Public Class HighLowTemps
        Public Property High As Integer
        Public Property Low As Integer
    End Class

    ' serialization output formatted (pretty-printed with whitespace and indentation):
    ' {
    '   "Date": "2019-08-01T00:00:00-07:00",
    '   "TemperatureCelsius": 25,
    '   "Summary": "Hot",
    '   "DatesAvailable": [
    '     "2019-08-01T00:00:00-07:00",
    '     "2019-08-02T00:00:00-07:00"
    '   ],
    '   "TemperatureRanges": {
    '     "Cold": {
    '       "High": 20,
    '       "Low": -10
    '     },
    '     "Hot": {
    '       "High": 60,
    '       "Low": 20
    '     }
    '   },
    '   "SummaryWords": [
    '     "Cool",
    '     "Windy",
    '     "Humid"
    '   ]
    ' }
    ' </WFWithPOCOs>

    ' <WFWithEnum>
    Public Class WeatherForecastWithEnum
        Public Property [Date] As DateTimeOffset
        Public Property TemperatureCelsius As Integer
        Public Property Summary As Summary
    End Class

    Public Enum Summary
        Cold
        Cool
        Warm
        Hot
    End Enum

    ' </WFWithEnum>

    Public Module WeatherForecastExtensions

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecast)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithDefault)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithROProperty)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithPropertyNameAttribute)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithIgnoreAttribute)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithEnum)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithExtensionData)
            Console.WriteLine($"Date: {wf.[Date]}")
            Console.WriteLine($"TemperatureCelsius: {wf.TemperatureCelsius}")
            Console.WriteLine($"Summary: {wf.Summary}")
            Console.WriteLine($"ExtensionData:")
            If wf.ExtensionData IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In wf.ExtensionData
                    Console.WriteLine($"  {kvp.Key} {kvp.Value}")
                Next
            End If
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastDerived)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithObjectProperties)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithEnumDictionary)
            Utilities.DisplayPropertyValues(wf)
            Console.Write($"TemperatureRanges:")
            For Each kvp As KeyValuePair(Of SummaryWordsEnum, Integer) In wf.TemperatureRanges
                Console.Write($"  {kvp.Key}, {kvp.Value}")
            Next
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithDictionary)
            Utilities.DisplayPropertyValues(wf)
            Console.Write($"TemperatureRanges:")
            For Each kvp As KeyValuePair(Of String, Integer) In wf.TemperatureRanges
                Console.Write($"  {kvp.Key}, {kvp.Value}")
            Next
            Console.WriteLine()
        End Sub

        <Extension()>
        Public Sub DisplayPropertyValues(wf As WeatherForecastWithPOCOs)
            Utilities.DisplayPropertyValues(wf)
            Console.WriteLine($"SummaryField: {wf.SummaryField}")
            Console.WriteLine($"TemperatureRanges:")
            For Each kvp As KeyValuePair(Of String, HighLowTemps) In wf.TemperatureRanges
                Console.WriteLine($"  {kvp.Key} {kvp.Value.Low} {kvp.Value.High}")
            Next
            Console.WriteLine($"SummaryWords:")
            For Each word As String In wf.SummaryWords
                Console.WriteLine($"  {word}")
            Next
            Console.WriteLine()
        End Sub

    End Module

    Public Module WeatherForecastFactories

        Public Function CreateWeatherForecast() As WeatherForecast
            Dim weatherForecast1 As WeatherForecast = New WeatherForecast With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithPrevious() As WeatherForecastWithPrevious
            Dim weatherForecast1 As WeatherForecastWithPrevious = New WeatherForecastWithPrevious With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .PreviousForecast = CreateWeatherForecastDerived()
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithPreviousAsObject() As WeatherForecastWithPreviousAsObject
            Dim weatherForecast1 As WeatherForecastWithPreviousAsObject = New WeatherForecastWithPreviousAsObject With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .PreviousForecast = CreateWeatherForecastDerived()
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithROProperty() As WeatherForecastWithROProperty
            Dim weatherForecast1 As WeatherForecastWithROProperty = New WeatherForecastWithROProperty With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithEnum() As WeatherForecastWithEnum
            Dim weatherForecast1 As WeatherForecastWithEnum = New WeatherForecastWithEnum With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = Summary.Hot
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithPropertyNameAttribute() As WeatherForecastWithPropertyNameAttribute
            Dim weatherForecast1 As WeatherForecastWithPropertyNameAttribute = New WeatherForecastWithPropertyNameAttribute With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .WindSpeed = 35
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithIgnoreAttribute() As WeatherForecastWithIgnoreAttribute
            Dim weatherForecast1 As WeatherForecastWithIgnoreAttribute = New WeatherForecastWithIgnoreAttribute With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastCyrillic() As WeatherForecast
            Dim weatherForecast1 As WeatherForecast = New WeatherForecast With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "жарко"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithExtensionData() As WeatherForecastWithExtensionData
            Dim weatherForecast1 As WeatherForecastWithExtensionData = New WeatherForecastWithExtensionData With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastDerived() As WeatherForecastDerived
            Dim weatherForecast1 As WeatherForecastDerived = New WeatherForecastDerived With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .WindSpeed = 35
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithObjectProperties() As WeatherForecastWithObjectProperties
            Dim weatherForecast1 As WeatherForecastWithObjectProperties = New WeatherForecastWithObjectProperties With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot"
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithEnumDictionary() As WeatherForecastWithEnumDictionary
            Dim weatherForecast1 As WeatherForecastWithEnumDictionary = New WeatherForecastWithEnumDictionary With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .TemperatureRanges = New Dictionary(Of SummaryWordsEnum, Integer) From {
                    {SummaryWordsEnum.Cold, 20},
                    {SummaryWordsEnum.Hot, 40}
                }
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithDictionary() As WeatherForecastWithDictionary
            Dim weatherForecast1 As WeatherForecastWithDictionary = New WeatherForecastWithDictionary With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .TemperatureRanges = New Dictionary(Of String, Integer) From {
                    {"ColdMinTemp", 20},
                    {"HotMinTemp", 40}
                }
            }
            Return weatherForecast1
        End Function

        Public Function CreateWeatherForecastWithPOCOs() As WeatherForecastWithPOCOs
            Dim weatherForecast1 As WeatherForecastWithPOCOs = New WeatherForecastWithPOCOs With {
                .[Date] = Date.Parse("2019-08-01"),
                .TemperatureCelsius = 25,
                .Summary = "Hot",
                .SummaryField = "Hot",
                .DatesAvailable = New List(Of DateTimeOffset) From {
                    Date.Parse("2019-08-01"),
                    Date.Parse("2019-08-02")
                },
                .TemperatureRanges = New Dictionary(Of String, HighLowTemps) From {
                        {"Cold", New HighLowTemps With {
                            .High = 20,
                            .Low = -10
                        }},
                        {"Hot", New HighLowTemps With {
                            .High = 60,
                            .Low = 20}}
                },
                .SummaryWords = New String() {"Cool", "Windy", "Humid"}
            }
            Return weatherForecast1
        End Function

    End Module
End Namespace
