all: soapbodybinding_parts.dll

soapbodybinding_parts.dll: soapbodybinding_parts.vb
	if not exist bin md bin
	vbc /t:library /out:bin/soapbodybinding_parts.dll soapbodybinding_parts.vb