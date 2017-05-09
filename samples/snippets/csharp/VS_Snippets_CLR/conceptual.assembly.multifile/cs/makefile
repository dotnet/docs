all: Client.netmodule

Client.netmodule: Stringer.netmodule Client.cs
    csc /addmodule:Stringer.netmodule /t:module Client.cs

Stringer.netmodule: Stringer.cs
    csc /t:module Stringer.cs
