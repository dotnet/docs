all: Bin\CustomDisplayModeVB.dll
Bin\CustomDisplayModeVB.dll:CustomDisplayMode.vb 
	IF NOT EXIST Bin md Bin
	vbc /t:library /out:Bin\CustomDisplayModeVB.dll CustomDisplayMode.vb 
