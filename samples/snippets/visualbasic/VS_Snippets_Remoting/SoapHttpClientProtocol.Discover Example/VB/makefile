all: source.dll

source.dll: source.vb
	if not exist bin md bin
	vbc /t:library /out:bin/source.dll source.vb 