
all: repeateritem.dll templatedataboundcontrol.dll

repeateritem.dll: repeateritem.cs
	csc /t:library repeateritem.cs

templatedataboundcontrol.dll: templatedataboundcontrol.cs repeateritem.dll
	csc /t:library /r:repeateritem.dll templatedataboundcontrol.cs
