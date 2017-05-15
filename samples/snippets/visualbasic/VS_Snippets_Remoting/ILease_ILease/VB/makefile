all: ILease_Server.exe ILease_Client.exe

ILease_Server.exe: ILease_Server.vb ILease_Share.dll
	vbc ILease_Server.vb /r:ILease_Share.dll /r:System.Runtime.Remoting.dll

ILease_Client.exe: ILease_Client.vb ILease_Share.dll
	vbc ILease_Client.vb /r:ILease_Share.dll /r:System.Runtime.Remoting.dll

ILease_Share.dll: ILease_Share.vb
	vbc /t:library ILease_Share.vb
