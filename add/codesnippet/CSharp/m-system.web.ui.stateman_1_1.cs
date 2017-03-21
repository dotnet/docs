    //////////////////////////////////////////////////////////////
    //
    // The strongly typed CycleCollection class is a collection
    // that contains Cycle class instances, which implement the
    // IStateManager interface.
    //
    //////////////////////////////////////////////////////////////
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level=AspNetHostingPermissionLevel.Minimal)]
    public sealed class CycleCollection : StateManagedCollection {
        
        private static readonly Type[] _typesOfCycles 
            = new Type[] { typeof(Bicycle), typeof(Tricycle) };

        protected override object CreateKnownType(int index) {
            switch(index) {
                case 0:
                    return new Bicycle();
                case 1:
                    return new Tricycle();                    
                default:
                    throw new ArgumentOutOfRangeException("Unknown Type");
            }            
        }

        protected override Type[] GetKnownTypes() {
            return _typesOfCycles;
        }

        protected override void SetDirtyObject(object o) {
            ((Cycle)o).SetDirty();
        }

    }