all: Client.netmodule

Client.netmodule: Stringer.netmodule Client.vb
    vbc /addmodule:Stringer.netmodule /t:module Client.vb

Stringer.netmodule: Stringer.vb
    vbc /t:module Stringer.vb
