all: ILease_Server.exe ILease_Client.exe

ILease_Server.exe: ILease_Server.cs ILease_Share.dll
	csc ILease_Server.cs /r:ILease_Share.dll

ILease_Client.exe: ILease_Client.cs ILease_Share.dll
	csc ILease_Client.cs /r:ILease_Share.dll

ILease_Share.dll: ILease_Share.cs
	csc /t:library ILease_Share.cs
