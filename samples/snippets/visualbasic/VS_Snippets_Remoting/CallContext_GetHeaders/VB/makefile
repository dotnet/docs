all: callcontext_Server.exe callcontext_Client.exe

callcontext_Server.exe: callcontext_Server.vb callcontext_Share.dll
	vbc callcontext_Server.vb /r:callcontext_Share.dll

callcontext_Client.exe: callcontext_Client.vb callcontext_Share.dll
	vbc callcontext_Client.vb /r:callcontext_Share.dll

callcontext_Share.dll: callcontext_Share.vb
	vbc /t:library callcontext_Share.vb
