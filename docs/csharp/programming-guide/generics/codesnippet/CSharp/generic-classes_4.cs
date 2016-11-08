        class NodeItem<T> where T : System.IComparable<T>, new() { }
        class SpecialNodeItem<T> : NodeItem<T> where T : System.IComparable<T>, new() { }