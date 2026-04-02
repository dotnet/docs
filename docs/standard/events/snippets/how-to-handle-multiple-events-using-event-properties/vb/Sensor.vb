' <EventProperties>
Imports System.ComponentModel

' <SensorEventArgs>
Public Class SensorEventArgs
    Inherits EventArgs

    Public ReadOnly Property SensorId As String
    Public ReadOnly Property Value As Double

    Public Sub New(sensorId As String, value As Double)
        Me.SensorId = sensorId
        Me.Value = value
    End Sub
End Class
' </SensorEventArgs>

' Sensor defines 10 event properties backed by a single EventHandlerList.
' EventHandlerList is memory-efficient for classes with many events: it only
' allocates storage for events that have active subscribers.
Class Sensor

    ' <EventHandlerListField>
    Protected listEventDelegates As New EventHandlerList()
    ' </EventHandlerListField>

    ' <EventKeys>
    Shared ReadOnly temperatureChangedKey  As New Object()
    Shared ReadOnly humidityChangedKey     As New Object()
    Shared ReadOnly pressureChangedKey     As New Object()
    Shared ReadOnly batteryLowKey          As New Object()
    Shared ReadOnly signalLostKey          As New Object()
    Shared ReadOnly signalRestoredKey      As New Object()
    Shared ReadOnly thresholdExceededKey   As New Object()
    Shared ReadOnly calibrationRequiredKey As New Object()
    Shared ReadOnly dataReceivedKey        As New Object()
    Shared ReadOnly errorDetectedKey       As New Object()
    ' </EventKeys>

    ' <SingleEventProperty>
    Public Custom Event TemperatureChanged As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(temperatureChangedKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(temperatureChangedKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(temperatureChangedKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event
    ' </SingleEventProperty>

    Public Custom Event HumidityChanged As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(humidityChangedKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(humidityChangedKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(humidityChangedKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event PressureChanged As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(pressureChangedKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(pressureChangedKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(pressureChangedKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event BatteryLow As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(batteryLowKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(batteryLowKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(batteryLowKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event SignalLost As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(signalLostKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(signalLostKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(signalLostKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event SignalRestored As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(signalRestoredKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(signalRestoredKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(signalRestoredKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event ThresholdExceeded As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(thresholdExceededKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(thresholdExceededKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(thresholdExceededKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event CalibrationRequired As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(calibrationRequiredKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(calibrationRequiredKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(calibrationRequiredKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event DataReceived As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(dataReceivedKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(dataReceivedKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(dataReceivedKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Custom Event ErrorDetected As EventHandler(Of SensorEventArgs)
        AddHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.AddHandler(errorDetectedKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of SensorEventArgs))
            listEventDelegates.RemoveHandler(errorDetectedKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As SensorEventArgs)
            CType(listEventDelegates(errorDetectedKey), EventHandler(Of SensorEventArgs))?.Invoke(sender, e)
        End RaiseEvent
    End Event

End Class
' </EventProperties>
