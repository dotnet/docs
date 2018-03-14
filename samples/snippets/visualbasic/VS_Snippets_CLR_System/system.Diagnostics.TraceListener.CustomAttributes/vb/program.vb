'<Snippet1>
' This code example uses the following application configuration file:
'<?xml version="1.0" encoding="utf-8"?>
'<configuration>
'  <system.diagnostics>
'    <sources>
'      <source name="TraceTest" switchName="SourceSwitch" switchType="System.Diagnostics.SourceSwitch" >
'        <listeners>
'          <add name="Testlistener" />
'        </listeners>
'      </source>
'    </sources>
'    <switches>
'      <add name="SourceSwitch" value="Warning" />
'    </switches>
'    <sharedListeners>
'      <add name="Testlistener" type="CustomTraceListener.TestListener, CustomTraceListener, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" initializeData="TestListener" Source="test"/>
'    </sharedListeners>
'    <trace autoflush="true" indentsize="4" />
'  </system.diagnostics>
'</configuration>
Imports System
Imports System.Diagnostics
Imports System.Configuration
Imports System.Reflection
Imports System.Collections

Namespace CustomTraceListener

    Class Program

        Shared Sub Main(ByVal args() As String)
            Dim ts As New TraceSource("TraceTest")
            Console.WriteLine(ts.Switch.DisplayName)
            Dim traceListener As TraceListener
            For Each traceListener In ts.Listeners
                Console.Write("TraceListener: " + traceListener.Name + vbTab)
                ' The following output can be used to update the configuration file.
                Console.WriteLine("AssemblyQualifiedName = " + traceListener.GetType().AssemblyQualifiedName)
            Next traceListener
            ts.TraceEvent(TraceEventType.Error, 1, "test error message")

        End Sub 'Main
    End Class 'Program

    Public Class TestListener
        Inherits TraceListener
        Private [m_source] As String
        Private m_name As String

        Public Sub New(ByVal listenerName As String)
            m_name = listenerName
        End Sub 'New


        Public Property [Source]() As String
            Get
                Dim de As DictionaryEntry
                For Each de In Me.Attributes
                    If de.Key.ToString().ToLower() = "source" Then
                        [Source] = de.Value.ToString()
                    End If
                Next de
                Return [m_source]
            End Get
            Set(ByVal value As String)
                [m_source] = value
            End Set
        End Property

        Public Overrides Sub Write(ByVal s As String)
            Console.Write(m_name + " " + [Source] + ": " + s)

        End Sub 'Write

        Public Overrides Sub WriteLine(ByVal s As String)
            Console.WriteLine(s)

        End Sub 'WriteLine

        Protected Overrides Function GetSupportedAttributes() As String()
            Return New String() {"Source"}

        End Function 'GetSupportedAttributes
    End Class 'TestListener 
End Namespace 'CustomTraceListener
' This code example creates the following output:
'
'SourceSwitch
'TraceListener: Default  AssemblyQualifiedName = System.Diagnostics.DefaultTraceL
'istener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0
'89
'TraceListener: Testlistener     AssemblyQualifiedName = CustomTraceListener.Test
'Listener, CustomTraceListener, Version=1.0.0.0, Culture=neutral, PublicKeyToken=
'null
'TestListener test: TraceTest Error: 1 : test error message
'
'</Snippet1>