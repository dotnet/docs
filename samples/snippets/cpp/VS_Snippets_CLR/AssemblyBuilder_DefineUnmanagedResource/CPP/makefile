all : assemblybuilder_defineunmanagedresource.exe EmittedTest2.exe

assemblybuilder_defineunmanagedresource.exe : assemblybuilder_defineunmanagedresource.cpp
	cl /clr assemblybuilder_defineunmanagedresource.cpp

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource.exe
	assemblybuilder_defineunmanagedresource.exe

EmittedTest2.exe : MyEmitTestAssembly.dll EmittedTest2.cpp
	cl /clr EmittedTest2.cpp