all: service.dll server.exe client.exe

service.dll : service.cs
	csc /t:library service.cs

server.exe : server.cpp service.dll
	cl /clr:pure server.cpp

client.exe : client.cpp service.dll
	cl /clr:pure client.cpp

