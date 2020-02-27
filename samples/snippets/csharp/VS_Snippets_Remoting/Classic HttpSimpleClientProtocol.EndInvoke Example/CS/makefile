all: source.dll

source.dll: source.cs
	if not exist bin md bin
	csc /t:library /out:bin/source.dll source.cs