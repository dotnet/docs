all: testMethod.dll EndInvoke.exe WaitHandle.exe polling.exe Callback.exe

testMethod.dll: testmethod.cpp
	cl /clr:pure /LD testmethod.cpp

EndInvoke.exe: endinvoke.cpp testMethod.dll
	cl /clr endinvoke.cpp 

WaitHandle.exe: waithandle.cpp testMethod.dll
	cl /clr waithandle.cpp 

polling.exe: polling.cpp testmethod.dll
	cl /clr polling.cpp 

Callback.exe: Callback.cpp testmethod.dll
	cl /clr Callback.cpp 
clean:
	del *.dll
	del *.exe