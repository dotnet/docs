all: soapbodybinding_parts.dll

soapbodybinding_parts.dll: soapbodybinding_parts.cs
	if not exist bin md bin
	csc /t:library /out:bin/soapbodybinding_parts.dll soapbodybinding_parts.cs