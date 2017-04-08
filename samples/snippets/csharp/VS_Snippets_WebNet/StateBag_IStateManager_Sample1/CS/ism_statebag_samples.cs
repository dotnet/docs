// <snippet1>
// Create a namespace that contains a class, MyItem,
// that implements the IStateManager interface and 
// another, MyControl, that overrides its own view-state
// management methods to use those of MyItem.
using System;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Security.Permissions;

namespace StateBagSample
{
    // <Snippet8>
    // Create a class that implements IStateManager so that
    // it can manage its own view state.   
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class MyItem : IStateManager
    {
        private string _message;

        // The StateBag object that allows you to save
        // and restore view-state information.
        private StateBag _viewstate;

        // The constructor for the MyItem class.
        public MyItem(string mesg)
        {
            _message = mesg;
            _viewstate = new StateBag();
            _viewstate.Add("message", _message);
        }

        // <Snippet2>
        // Create a Message property that reads from and writes
        // to view state. If the set accessor writes the message
        // value to view state, the StateBag.SetItemDirty method
        // is called, telling view state that the item has changed. 
        public string Message
        {
            get
            {
                return (string)_viewstate["message"];
            }
            set
            {
                _message = value;
                _viewstate.SetItemDirty("message", true);
            }
        }
        // </Snippet2>

        // <Snippet3>
        // Implement the LoadViewState method. If the saved view state
        // exists, the view-state value is loaded to the MyItem control. 
        void IStateManager.LoadViewState(object savedState)
        {
            _message = (string)_viewstate["message"];
            if (savedState != null)
                ((IStateManager)_viewstate).LoadViewState(savedState);
        }
        // </Snippet3>

        // <Snippet4>
        // Implement the SaveViewState method. If the StateBag
        // that stores the MyItem class's view state contains
        // a value for the message property and if the value
        // has changed since the TrackViewState method was last 
        // called, all view state for this class is deleted, 
        // using the StateBag.Clear method,and the new value is added.
        object IStateManager.SaveViewState()
        {
            // Check whether the message property exists in 
            // the ViewState property, and if it does, check
            // whether it has changed since the most recent
            // TrackViewState method call.
            if (!((IDictionary)_viewstate).Contains("message") || _viewstate.IsItemDirty("message"))
            {
                _viewstate.Clear();
                // Add the _message property to the StateBag.
                _viewstate.Add("message", _message);
            }
            return ((IStateManager)_viewstate).SaveViewState();
        }

        // </Snippet4>

        // <Snippet5>
        // Implement the TrackViewState method for this class by
        // calling the TrackViewState method of the class's private
        // _viewstate property.
        void IStateManager.TrackViewState()
        {
            ((IStateManager)_viewstate).TrackViewState();
        }
        // </Snippet5>

        // <snippet6>
        // Implement the IsTrackingViewState method for this class 
        // by calling the IsTrackingViewState method of the class's
        // private _viewstate property. 
        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return ((IStateManager)_viewstate).IsTrackingViewState;
            }
        }
        // </snippet6>

        // <Snippet7>
        // Create a function that iterates through the view-state
        // values stored for this class and returns the
        // results as a string.
        public string EnumerateViewState()
        {
            string keyName, keyValue;
            string result = String.Empty;
            StateItem myStateItem;
            IDictionaryEnumerator myDictionaryEnumerator = _viewstate.GetEnumerator();
            while (myDictionaryEnumerator.MoveNext())
            {
                keyName = (string)myDictionaryEnumerator.Key;
                myStateItem = (StateItem)myDictionaryEnumerator.Value;
                keyValue = (string)myStateItem.Value;
                result = result + "<br>ViewState[" + keyName + "] = " + keyValue;
            }
            return result;
        }
        // </Snippet7>
    }
    // </Snippet8>
    // <snippet9>
    // This class contains an instance of the MyItem class as 
    // private member. It overrides the state management methods 
    // of the Control class, since it has to invoke state 
    // management methods of MyItem whenever its own
    // view state is being saved, loaded, or tracked.
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class MyControl : Control
    {
        private MyItem myItem;
        public MyControl()
            : base()
        {
            myItem = new MyItem("Hello World!");
        }
        // Override the LoadViewState method of the Control class.
        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                object[] myState = (object[])savedState;
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);
                if (myState[1] != null)
                    ((IStateManager)myItem).LoadViewState(myState[1]);
            }
        }
        // Override the TrackViewState method of the Control class
        // to call the version of this method that was 
        // implemented in the MyItem class.
        protected override void TrackViewState()
        {
            base.TrackViewState();
            if (myItem != null)
                ((IStateManager)myItem).TrackViewState();
        }

        // Override the SaveViewState method of the Control class to
        // call the version of this method that was implemented by
        // the MyItem class.
        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object itemState = (myItem != null) ? ((IStateManager)myItem).SaveViewState() : null;
            object[] myState = new object[2];
            myState[0] = baseState;
            myState[1] = itemState;
            return myState;
        }

        public void SetMessage(string mesg)
        {
            myItem.Message = mesg;
        }

        public string GetMessage()
        {
            return myItem.Message;
        }

        // Display the contents of Message and ViewState properties. 
        protected override void Render(HtmlTextWriter output)
        {
            // Track changes to  view state before rendering.
            TrackViewState();
            output.Write("Message: " + myItem.Message);
            output.Write("<br>");
            output.Write("<br>Enumerating the view state of the custom control<br>");
            output.Write(myItem.EnumerateViewState());
        }
    }
    // </snippet9>
}
// </snippet1>
