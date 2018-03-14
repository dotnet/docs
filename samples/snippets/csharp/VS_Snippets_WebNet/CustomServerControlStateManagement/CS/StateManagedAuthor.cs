// <Snippet3>
// StateManagedAuthor.cs
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

namespace Samples.AspNet.CS.Controls
{
    [
    TypeConverter(typeof(StateManagedAuthorConverter))
    ]
    public class StateManagedAuthor : IStateManager
    {
        private bool _isTrackingViewState;
        private StateBag _viewState;

        public StateManagedAuthor()
            :
            this(String.Empty, String.Empty, String.Empty)
        {
        }

        public StateManagedAuthor(string first, string last)
            :
            this(first, String.Empty, last)
        {
        }

        public StateManagedAuthor(string first, string middle, string last)
        {
            FirstName = first;
            MiddleName = middle;
            LastName = last;
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("First name of author"),
        NotifyParentProperty(true)
        ]
        public virtual String FirstName
        {
            get
            {
                string s = (string)ViewState["FirstName"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["FirstName"] = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Last name of author"),
        NotifyParentProperty(true)
        ]
        public virtual String LastName
        {
            get
            {
                string s = (string)ViewState["LastName"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["LastName"] = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("Middle name of author"),
        NotifyParentProperty(true)
        ]
        public virtual String MiddleName
        {
            get
            {
                string s = (string)ViewState["MiddleName"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["MiddleName"] = value;
            }
        }

        protected virtual StateBag ViewState
        {
            get
            {
                if (_viewState == null)
                {
                    _viewState = new StateBag(false);

                    if (_isTrackingViewState)
                    {
                        ((IStateManager)_viewState).TrackViewState();
                    }
                }
                return _viewState;
            }
        }


        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture);
        }

        public string ToString(CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(
                GetType()).ConvertToString(null, culture, this);
        }

        #region IStateManager implementation
        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return _isTrackingViewState;
            }
        }

        void IStateManager.LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                ((IStateManager)ViewState).LoadViewState(savedState);
            }
        }

        object IStateManager.SaveViewState()
        {
            object savedState = null;

            if (_viewState != null)
            {
                savedState =
                   ((IStateManager)_viewState).SaveViewState();
            }
            return savedState;
        }

        void IStateManager.TrackViewState()
        {
            _isTrackingViewState = true;

            if (_viewState != null)
            {
                ((IStateManager)_viewState).TrackViewState();
            }
        }
        #endregion

        internal void SetDirty()
        {
            _viewState.SetDirty(true);
        }
    }
}
// </Snippet3>
