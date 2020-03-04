all : assemblybuilder_defineunmanagedresource2.exe EmittedTest3.exe

assemblybuilder_defineunmanagedresource2.exe : assemblybuilder_defineunmanagedresource2.cpp
	cl /clr assemblybuilder_defineunmanagedresource2.cpp

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource2.exe
	assemblybuilder_defineunmanagedresource2.exe

EmittedTest3.exe : MyEmitTestAssembly.dll EmittedTest3.cpp
	cl /clr EmittedTest3.cpp