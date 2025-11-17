(*
Compiler error: The type %s is less accessible than the value, member or type %s it is used in

Notice that in this example, the type Person is private, but the function _getName is public by default.
Also, the function _getName uses the type Person in its signature, which is not allowed since Person is
less accessible than _getName.
*)
module Person =
    type private Person = { Name: string; Email: string }

    let _getName (p: Person) = p.Name
