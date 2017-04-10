all: program.exe
 
program.exe: program.vb
 vbc /t:library program.vb /r:system.json.dll /r:System.ServiceModel.dll /r:System.Windows.Browser.dll /r:system.windows.dll /r:System.ServiceModel.PollingDuplex.dll /lib:c:\slassemblies /lib:"C:\Program Files\Microsoft SDKs\Silverlight\v2.0\Reference Assemblies"
 
