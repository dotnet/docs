open System

let object1 =
    { new Object() with
        override this.ToString() = "This overrides object.ToString()" }

printfn "%s" (object1.ToString())