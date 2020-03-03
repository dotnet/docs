all: Client.netmodule

Client.netmodule: Stringer.netmodule Client.cpp
    cl /clr:pure /FUStringer.netmodule /LN Client.cpp

Stringer.netmodule: Stringer.cpp
    cl /clr:pure /LN Stringer.cpp

