using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Windows.Automation.Provider;


namespace ElementProvider
{
    class CustomGridItem : IRawElementProviderFragment, IGridItemProvider
	{
        string myText;
        int ItemColumn;  // pretend these are properties for the sake of snippets
        int ItemRow;
        IRawElementProviderSimple ItemContainingGrid;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomGridItem(string s, int row, int col, IRawElementProviderSimple ownerGrid)
        {
            myText = s;
            ItemColumn = col;
            ItemRow = row;
            ItemContainingGrid = ownerGrid;
        }


        #region IGridItemProvider Members

 // <Snippet104> 
        int IGridItemProvider.Column
        {
            get 
            {
                return ItemColumn;
            }
        }
// </Snippet104>

// <Snippet105> 
        int IGridItemProvider.Row
        {
            get 
            {
                return ItemRow;
            }
        }
// </Snippet105>


        /// <summary>
        /// Gets the number of columns spanned by the item.
        /// </summary>
// <Snippet106> 
        int IGridItemProvider.ColumnSpan
        {
            get 
            {
                return 1;    
            }
        }
// </Snippet106>

        /// <summary>
        /// Gets the number of rows spanned by the item.
        /// </summary>
// <Snippet107> 
        int IGridItemProvider.RowSpan
        {
            get 
            { 
                return 1; 
            }
        }
// </Snippet107>

// <Snippet108> 
        IRawElementProviderSimple IGridItemProvider.ContainingGrid
        {
            get 
            { 
                return ItemContainingGrid; 
            }
        }
// </Snippet108>

        #endregion

        #region IRawElementProviderSimple Members

        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == GridItemPatternIdentifiers.Pattern.Id)
            {
                
                return (IGridItemProvider)this;
            }
            return null;
        }


        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            return null;
        }

        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get { return null; }
        }

        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

        #endregion

        #region IRawElementProviderFragment Members

        System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
        {
            get { return (IRawElementProviderFragmentRoot)ItemContainingGrid; }
        }

        IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
        {
            return null;
        }

        int[] IRawElementProviderFragment.GetRuntimeId()
        {
            return null;
        }

        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            if (direction == NavigateDirection.Parent)
            {
                return (IRawElementProviderFragment)ItemContainingGrid;
            }
            else
            {
                return null;
            };
        }

        void IRawElementProviderFragment.SetFocus()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
