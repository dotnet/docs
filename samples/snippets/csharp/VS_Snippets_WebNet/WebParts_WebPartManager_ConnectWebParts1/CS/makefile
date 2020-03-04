all: Bin\ConnectionSampleCS.dll
Bin\ConnectionSampleCS.dll:ZipCodeComponent.cs
	IF NOT EXIST Bin md Bin
	csc /t:library /out:Bin\ConnectionSampleCS.dll ZipCodeComponent.cs
