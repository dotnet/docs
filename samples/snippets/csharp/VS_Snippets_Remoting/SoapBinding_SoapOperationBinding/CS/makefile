all: soapprotocol.dll

soapprotocol.dll: soapprotocol.cs
	if not exist bin md bin
	csc /t:library  /out:bin/soapprotocol.dll soapprotocol.cs