all: source.dll

source.dll: source.vb
	if not exist bin md bin
	vbc /t:library source.vb /out:bin/source.dll