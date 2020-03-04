
all: repeateritem.dll templatedataboundcontrol.dll

repeateritem.dll: repeateritem.vb
	vbc /t:library repeateritem.vb

templatedataboundcontrol.dll: templatedataboundcontrol.vb repeateritem.dll
	vbc /t:library /r:repeateritem.dll templatedataboundcontrol.vb
