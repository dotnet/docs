all: trackinghandler.dll remoteservice.dll server.dll client.dll

trackinghandler.dll: trackinghandler.cs
	csc /t:library trackinghandler.cs

remoteservice.dll: remoteservice.cs
	csc /t:library remoteservice.cs

server.dll: server.cs trackinghandler.dll remoteservice.dll
	csc /t:library server.cs /r:trackinghandler.dll /r:remoteservice.dll
client.dll: client.cs trackinghandler.dll remoteservice.dll server.dll
	csc /t:library client.cs /r:trackinghandler.dll /r:remoteservice.dll /r:server.dll