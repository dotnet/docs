all: soapprotocol.dll

soapprotocol.dll: soapprotocol.vb
	if not exist bin md bin
	vbc /t:library /out:bin/soapprotocol.dll soapprotocol.vb