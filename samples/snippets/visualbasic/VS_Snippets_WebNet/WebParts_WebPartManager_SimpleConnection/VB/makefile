all: Bin\ConnectionSampleVB.dll
Bin\ConnectionSampleVB.dll:ZipCodeComponent.vb 
	IF NOT EXIST Bin md Bin
	vbc /t:library /out:Bin\ConnectionSampleVB.dll ZipCodeComponent.vb 
