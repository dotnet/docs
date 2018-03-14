
Imports System
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.ProcessModelSection
' members selected by the user.

Class UsingProcessModelSection
   
   Public Shared Sub Main()
      
      Try
         '  <Snippet1>
         ' Get the Web application configuration
            Dim configuration _
            As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
         
         ' Get the section.
            Dim processModelSection _
            As System.Web.Configuration.ProcessModelSection = _
            CType(configuration.GetSection( _
            "system.web/processModel"), ProcessModelSection)
         
         ' </Snippet1>
         ' <Snippet2>
         ' Get the current Enable property value.
         Dim enable As Boolean = processModelSection.Enable
         
         ' Set the Enable property to false.
         processModelSection.Enable = False
         
         ' </Snippet2>
         ' <Snippet3>
         ' Get the current MemoryLimit property value.
            Dim memLimit As Integer = _
            processModelSection.MemoryLimit
         
         ' Set the MemoryLimit property to 50.
         processModelSection.MemoryLimit = 50
         
         ' </Snippet3>
         ' <Snippet4>
         ' Get the current MinIOThreads property value.
            Dim minIOThreads As Integer = _
            processModelSection.MinIOThreads
         
         ' Set the MinIOThreads property to 1.
         processModelSection.MinIOThreads = 1
         
         ' </Snippet4>
         ' <Snippet5>
         ' Get the current MaxIOThreads property value.
            Dim maxIOThreads As Integer = _
            processModelSection.MaxIOThreads
         
         ' Set the MaxIOThreads property to 64.
         processModelSection.MaxIOThreads = 64
         
         ' </Snippet5>
         ' <Snippet6>
         ' Get the current MinWorkerThreads property value.
            Dim minWorkerThreads As Integer = _
            processModelSection.MinWorkerThreads
         
         ' Set the MinWorkerThreads property to 2.
         processModelSection.MinWorkerThreads = 2
         
         ' </Snippet6>
         ' <Snippet7>
         ' Get the current MaxWorkerThreads property value.
            Dim maxWorkerThreads As Integer = _
            processModelSection.MaxWorkerThreads
         
         ' Set the MaxWorkerThreads property to 128.
         processModelSection.MaxWorkerThreads = 128
         
         ' </Snippet7>
         ' <Snippet8>
         ' Get the current RequestLimit property value.
            Dim reqLimit As Integer = _
            processModelSection.RequestLimit
         
         ' Set the RequestLimit property to 4096.
         processModelSection.RequestLimit = 4096
         
         ' </Snippet8>
         ' <Snippet9>
         ' Get the current RestartQueueLimit property value.
            Dim restartQueueLimit As Integer = _
            processModelSection.RestartQueueLimit
         
         ' Set the RestartQueueLimit property to 8.
         processModelSection.RestartQueueLimit = 8
         
         ' </Snippet9>
         ' <Snippet10>
         ' Get the current RequestQueueLimit property value.
            Dim requestQueueLimit As Integer = _
            processModelSection.RequestQueueLimit
         
         ' Set the RequestQueueLimit property to 10240.
         processModelSection.RequestQueueLimit = 10240
         
         ' </Snippet10>
         ' <Snippet11>
         ' Get the current ResponseRestartDeadlockInterval property
         ' value.
            Dim respRestartDeadlock As TimeSpan = _
            processModelSection.ResponseRestartDeadlockInterval
         
         ' Set the ResponseRestartDeadlockInterval property to
         ' TimeSpan.Parse("04:00:00").
            processModelSection.ResponseRestartDeadlockInterval = _
            TimeSpan.Parse("04:00:00")
         
         ' </Snippet11>
         ' <Snippet12>
         ' Get the current Timeout property value.
            Dim timeout As TimeSpan = _
            processModelSection.Timeout
         
         ' Set the Timeout property to TimeSpan.Parse("00:00:30").
            processModelSection.Timeout = _
            TimeSpan.Parse("00:00:30")
         
         ' </Snippet12>
         ' <Snippet13>
         ' Get the current PingFrequency property value.
            Dim pingFreq As TimeSpan = _
            processModelSection.PingFrequency
         
         ' Set the PingFrequency property to
         ' TimeSpan.Parse("00:01:00").
            processModelSection.PingFrequency = _
            TimeSpan.Parse("00:01:00")
         
         ' </Snippet13>
         ' <Snippet14>
         ' Get the current PingTimeout property value.
            Dim pingTimeout As TimeSpan = _
            processModelSection.PingTimeout
         
         ' Set the PingTimeout property to TimeSpan.Parse("00:00:30").
            processModelSection.PingTimeout = _
            TimeSpan.Parse("00:00:30")
         
         ' </Snippet14>
         ' <Snippet15>
         ' Get the current ShutdownTimeout property value.
            Dim shutDownTimeout As TimeSpan = _
            processModelSection.ShutdownTimeout
         
         ' Set the ShutdownTimeout property to
         ' TimeSpan.Parse("00:00:30").
            processModelSection.ShutdownTimeout = _
            TimeSpan.Parse("00:00:30")
         
         ' </Snippet15>
         ' <Snippet16>
         ' Get the current IdleTimeout property value.
            Dim idleTimeout As TimeSpan = _
            processModelSection.IdleTimeout
         
         ' Set the IdleTimeout property to TimeSpan.Parse("12:00:00").
            processModelSection.IdleTimeout = _
            TimeSpan.Parse("12:00:00")
         
         ' </Snippet16>
         ' <Snippet17>
         ' Get the current ResponseDeadlockInterval property value.
            Dim respDeadlock As TimeSpan = _
            processModelSection.ResponseDeadlockInterval
         
         ' Set the ResponseDeadlockInterval property to
         ' TimeSpan.Parse("00:05:00").
            processModelSection.ResponseDeadlockInterval = _
            TimeSpan.Parse("00:05:00")
         
         ' </Snippet17>
         ' <Snippet18>
         ' Get the current ClientConnectedCheck property value.
            Dim clConnectCheck As TimeSpan = _
            processModelSection.ClientConnectedCheck
         
         ' Set the ClientConnectedCheck property to
         ' TimeSpan.Parse("00:15:00").
            processModelSection.ClientConnectedCheck = _
            TimeSpan.Parse("00:15:00")
         
         ' </Snippet18>
         ' <Snippet19>
         ' Get the current UserName property value.
            Dim userName As String = _
            processModelSection.UserName
         
         ' Set the UserName property to "CustomUser".
         processModelSection.UserName = "CustomUser"
         
         ' </Snippet19>
         ' <Snippet20>
         ' Get the current Password property value.
            Dim password As String = _
            processModelSection.Password
         
         ' Set the Password property to "CUPassword".
         processModelSection.Password = "CUPassword"
         
         ' </Snippet20>
         ' <Snippet21>
         ' Get the current ComAuthenticationLevel property value.
            Dim comAuthLevel _
            As ProcessModelComAuthenticationLevel = _
            processModelSection.ComAuthenticationLevel
         
         ' Set the ComAuthenticationLevel property to
         ' ProcessModelComAuthenticationLevel.Call.
            processModelSection.ComAuthenticationLevel = _
            ProcessModelComAuthenticationLevel.Call

         
         ' </Snippet21>
         ' <Snippet22>
         ' Get the current ComImpersonationLevel property value.
            Dim comImpLevel _
            As ProcessModelComImpersonationLevel = _
            processModelSection.ComImpersonationLevel
         
         ' Set the ComImpersonationLevel property to
         ' ProcessModelComImpersonationLevel.Anonymous.
            processModelSection.ComImpersonationLevel = _
            ProcessModelComImpersonationLevel.Anonymous
         
         ' </Snippet22>
         ' <Snippet23>
         ' Get the current LogLevel property value.
            Dim comLogLevel As ProcessModelLogLevel = _
            processModelSection.LogLevel
         
         ' Set the LogLevel property to ProcessModelLogLevel.All.
         processModelSection.LogLevel = ProcessModelLogLevel.All
         
         ' </Snippet23>
         ' <Snippet24>
         ' Get the current WebGarden property value.
            Dim webGarden As Boolean = _
            processModelSection.WebGarden
         
         ' Set the WebGarden property to true.
         processModelSection.WebGarden = True
         
         ' </Snippet24>
         ' <Snippet25>
         ' Get the current CpuMask property value.
            Dim cpuMask As Integer = _
            processModelSection.CpuMask
         
         ' Set the CpuMask property to 0x000000FF.
         processModelSection.CpuMask = &HFF
         
         ' </Snippet25>
         ' <Snippet26>
         ' Get the current AsyncOption property value.
         ' not in use anymore
         '   Dim asyncOpt As Integer = _
         '   processModelSection.AsyncOption
         
         ' Set the AsyncOption property to 0.
         ' processModelSection.AsyncOption = 0
         
         ' </Snippet26>
         ' <Snippet27>
         ' Get the current MaxAppDomains property value.
            Dim maxAppdomains As Integer = _
            processModelSection.MaxAppDomains
         
         ' Set the MaxAppDomains property to 4.
         processModelSection.MaxAppDomains = 4
         
         ' </Snippet27>
         ' <Snippet28>
         ' Get the current ServerErrorMessageFile property value.
            Dim srvErrMsgFile As String = _
            processModelSection.ServerErrorMessageFile
         
         ' Set the ServerErrorMessageFile property to
         ' "custommessages.log".
            processModelSection.ServerErrorMessageFile = _
            "custommessages.log"
         
         ' </Snippet28>
         ' Update if not locked.
         If Not processModelSection.SectionInformation.IsLocked Then
            configuration.Save()
         End If
      
      Catch e As System.ArgumentException
         ' Never display this.
         Dim [error] As String = e.ToString()
         ' Unknown error.
            Dim msgToDisplay As String = _
            "Error detected in UsingProcessModelSection."
      End Try
   End Sub 'Main 
End Class 'UsingProcessModelSection

