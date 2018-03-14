all: source1.exe source2.dll source3.exe

source1.exe: source1.cpp
    cl /clr:pure source1.cpp

source2.dll: source2.cpp
    cl /clr:pure /LD source2.cpp

source3.exe: source2.dll source3.cpp
    cl /clr:pure /FUsource2.dll source3.cpp

