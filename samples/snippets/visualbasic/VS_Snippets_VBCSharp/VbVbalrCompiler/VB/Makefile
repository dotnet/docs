all: Class1.dll OptionExplicitOff.dll OptionStrictOff.dll netcf.exe

Class1.dll: Class1.vb
	vbc Class1.vb /t:library

OptionExplicitOff.dll: OptionExplicitOff.vb
	vbc OptionExplicitOff.vb /t:library

OptionStrictOff.dll: OptionStrictOff.vb
	vbc OptionStrictOff.vb /t:library

netcf.exe: netcf.vb
	vbc netcf.vb
