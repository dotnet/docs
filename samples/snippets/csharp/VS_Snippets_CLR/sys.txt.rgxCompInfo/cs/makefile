all : genFishRegex.exe useFishRegex.exe 

genFishRegex.exe: genFishRegex.cs
	csc genFishRegex.cs

FishRegex.dll: genFishRegex.exe
	genFishRegex.exe

useFishRegex.exe: useFishRegex.cs FishRegex.dll
	csc /r:FishRegex.dll useFishRegex.cs

