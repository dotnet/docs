all : assemblybuilder_defineunmanagedresource.exe EmittedTest2.exe

assemblybuilder_defineunmanagedresource.exe : assemblybuilder_defineunmanagedresource.vb
	vbc assemblybuilder_defineunmanagedresource.vb

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource.exe
	assemblybuilder_defineunmanagedresource.exe

EmittedTest2.exe : MyEmitTestAssembly.dll EmittedTest2.vb
	vbc /r:MyEmitTestAssembly.dll EmittedTest2.vb