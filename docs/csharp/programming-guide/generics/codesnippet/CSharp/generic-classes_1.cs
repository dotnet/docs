        class BaseNode { }
        class BaseNodeGeneric<T> { }

        // concrete type
        class NodeConcrete<T> : BaseNode { }

        //closed constructed type
        class NodeClosed<T> : BaseNodeGeneric<int> { }

        //open constructed type 
        class NodeOpen<T> : BaseNodeGeneric<T> { }