// <snippet1>
namespace Samples.AspNet.CS.Controls {

    using System;
    using System.Security.Permissions;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;           
    using System.Web;
    using System.Web.UI;            
// <snippet2>
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
// </snippet2>    
    //////////////////////////////////////////////////////////////
    //
    // The abstract Cycle class represents bicycles and tricycles.
    //
    //////////////////////////////////////////////////////////////
    public abstract class Cycle : IStateManager {

        protected internal Cycle(int numWheels) : this(numWheels, "Red"){ }
        
        protected internal Cycle(int numWheels, String color) {    
            numberOfWheels = numWheels;
            CycleColor = color;
        }
        
        private int numberOfWheels = 0;
        public int NumberOfWheels {
            get { return numberOfWheels; }
        }
        
        public string CycleColor {
            get { 
                object o = ViewState["Color"];
                return (null == o) ? String.Empty : o.ToString() ;
            }
            set {
                ViewState["Color"] = value;            
            }        
        }

        internal void SetDirty() {
            ViewState.SetDirty(true);
        }
        
        // Because Cycle does not derive from Control, it does not 
        // have access to an inherited view state StateBag object.
        private StateBag viewState;
        private StateBag ViewState {
            get {
                if (viewState == null) {
                    viewState = new StateBag(false);
                    if (isTrackingViewState) {
                        ((IStateManager)viewState).TrackViewState();
                    }
                }
                return viewState;
            }
        }

        // The IStateManager implementation.
        private bool isTrackingViewState;
        bool IStateManager.IsTrackingViewState {
            get {
                return isTrackingViewState;
            }
        }

        void IStateManager.LoadViewState(object savedState) {
            object[] cycleState = (object[]) savedState;
            
            // In SaveViewState, an array of one element is created.
            // Therefore, if the array passed to LoadViewState has 
            // more than one element, it is invalid.
            if (cycleState.Length != 1) {
                throw new ArgumentException("Invalid Cycle View State");
            }
            
            // Call LoadViewState on the StateBag object.
            ((IStateManager)ViewState).LoadViewState(cycleState[0]);
        }

        // Save the view state by calling the StateBag's SaveViewState
        // method.
        object IStateManager.SaveViewState() {
            object[] cycleState = new object[1];

            if (viewState != null) {
                cycleState[0] = ((IStateManager)viewState).SaveViewState();
            }
            return cycleState;
        }

        // Begin tracking view state. Check the private variable, because 
        // if the view state has not been accessed or set, then it is not  
        // being used and there is no reason to store any view state.
        void IStateManager.TrackViewState() {
            isTrackingViewState = true;
            if (viewState != null) {
                ((IStateManager)viewState).TrackViewState();
            }
        }        
    }

    public sealed class Bicycle : Cycle {
    
        // Create a red Cycle with two wheels.
        public Bicycle() : base(2) {}    
    }
    
    public sealed class Tricycle : Cycle {
    
        // Create a red Cycle with three wheels.
        public Tricycle() : base(3) {}
    }

}
// </snippet1>