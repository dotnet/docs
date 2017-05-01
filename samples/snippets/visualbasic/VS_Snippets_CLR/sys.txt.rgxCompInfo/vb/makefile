all : genFishRegex.exe useFishRegex.exe 

genFishRegex.exe: genFishRegex.vb
	vbc genFishRegex.vb

FishRegex.dll: genFishRegex.exe
	genFishRegex.exe

useFishRegex.exe: useFishRegex.vb FishRegex.dll
	vbc /r:FishRegex.dll useFishRegex.vb

