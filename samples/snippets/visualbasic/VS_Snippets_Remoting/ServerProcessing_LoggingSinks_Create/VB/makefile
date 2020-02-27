all: server.exe client.exe serverprocessing_loggingsinks.dll serverprocessing_share.dll

server.exe: serverprocessing_Server.vb serverprocessing_Share.dll serverprocessing_loggingsinks.dll
	vbc serverprocessing_Server.vb /r:serverprocessing_Share.dll /r:serverprocessing_loggingsinks.dll

client.exe: serverprocessing_Client.vb serverprocessing_Share.dll serverprocessing_loggingsinks.dll
	vbc serverprocessing_Client.vb /r:serverprocessing_Share.dll /r:serverprocessing_loggingsinks.dll

serverprocessing_loggingsinks.dll: serverprocessing_loggingsinks.vb
	vbc /t:library serverprocessing_loggingsinks.vb

serverprocessing_share.dll: serverprocessing_share.vb
	vbc /t:library serverprocessing_share.vb
