all: Reader.exe Writer.exe
Reader.exe: Reader.cpp Person.dll
	cl /clr:pure Reader.cpp
Writer.exe: Writer.cpp Person.dll
	cl /clr:pure Writer.cpp
Person.dll: Person.cpp
	cl /LD /clr:pure Person.cpp
clean:
	del *.exe
