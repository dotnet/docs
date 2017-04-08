all: Counter.dll Client.exe Server.exe

Counter.dll: Counter.cpp
	cl /clr:pure /LD Counter.cpp

Server.exe: Server.cpp
	cl /clr:pure Server.cpp

Client.exe: Client.cpp
	cl /clr:pure Client.cpp
