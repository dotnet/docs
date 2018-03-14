all: service.exe client.exe
 
service.exe: ServiceEndpointCollection.service.overview.cs
 csc /t:exe ServiceEndpointCollection.service.overview.cs proxy.cs /r:System.ServiceModel.dll,System.dll,System.Configuration.dll,System.Xml.dll 
 
client.exe: ServiceEndpointCollection.client.overview.cs
 csc /t:exe ServiceEndpointCollection.client.overview.cs proxy.cs  /r:System.ServiceModel.dll,System.dll,System.Configuration.dll,System.Xml.dll 
