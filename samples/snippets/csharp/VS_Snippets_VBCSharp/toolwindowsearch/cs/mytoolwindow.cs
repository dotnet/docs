// Walkthrough: Adding Search to a Tool Window
// f78c4892-8060-49c4-8ecd-4360f1b4d133

//<Snippet3>
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
//</Snippet3>

namespace Microsoft.TestToolWindowSearch
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("c35081aa-153d-4a84-b1f1-6608ba87de39")]
    public class MyToolWindow : ToolWindowPane
    {
        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public MyToolWindow() :
            base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.ToolWindowTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.
            base.Content = new MyControl();
        }


        //<Snippet2>
        public override bool SearchEnabled
        {
            get { return true; }
        }
        //</Snippet2>


        //<Snippet4>
        public override IVsSearchTask CreateSearch(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback)
        {
            if (pSearchQuery == null || pSearchCallback == null)
                return null;
            return new TestSearchTask(dwCookie, pSearchQuery, pSearchCallback, this);
        }

        public override void ClearSearch()
        {
            MyControl control = (MyControl)this.Content;
            control.SearchResultsTextBox.Text = control.SearchContent;
        }

        internal class TestSearchTask : VsSearchTask
        {
            private MyToolWindow m_toolWindow;

            public TestSearchTask(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback, MyToolWindow toolwindow)
                : base(dwCookie, pSearchQuery, pSearchCallback)
            {
                m_toolWindow = toolwindow;
            }

            protected override void OnStartSearch()
            {
                // Use the original content of the text box as the target of the search.
                var separator = new string[] { Environment.NewLine };
                string[] contentArr = ((MyControl)m_toolWindow.Content).SearchContent.Split(separator, StringSplitOptions.None);

                // Get the search option.
                bool matchCase = false;
                // matchCase = m_toolWindow.MatchCaseOption.Value;

                // Set variables that are used in the finally block.
                StringBuilder sb = new StringBuilder("");
                uint resultCount = 0;
                this.ErrorCode = VSConstants.S_OK;

                try
                {
                    string searchString = this.SearchQuery.SearchString;

                    // Determine the results.
                    uint progress = 0;
                    foreach (string line in contentArr)
                    {
                        if (matchCase == true)
                        {
                            if (line.Contains(searchString))
                            {
                                sb.AppendLine(line);
                                resultCount++;
                            }
                        }
                        else
                        {
                            if (line.ToLower().Contains(searchString.ToLower()))
                            {
                                sb.AppendLine(line);
                                resultCount++;
                            }
                        }

                        // SearchCallback.ReportProgress(this, progress++, (uint)contentArr.GetLength(0));

                        // Uncomment the following line to demonstrate the progress bar.
                        //<Snippet8>
                        // System.Threading.Thread.Sleep(100);
                        //</Snippet8>
                    }
                }
                catch (Exception e)
                {
                    this.ErrorCode = VSConstants.E_FAIL;
                }
                finally
                {
                    ThreadHelper.Generic.Invoke(() =>
                    { ((TextBox)((MyControl)m_toolWindow.Content).SearchResultsTextBox).Text = sb.ToString(); });

                    this.SearchResults = resultCount;
                }

                // Call the implementation of this method in the base class.
                // This sets the task status to complete and reports task completion.
                base.OnStartSearch();
            }

            protected override void OnStopSearch()
            {
                this.SearchResults = 0;
            }
        }
        //</Snippet4>


        internal class TestSearchTask2 : VsSearchTask
        {
            private MyToolWindow m_toolWindow;

            public TestSearchTask2(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback, MyToolWindow toolwindow)
                : base(dwCookie, pSearchQuery, pSearchCallback)
            {
                m_toolWindow = toolwindow;
            }

            private void Misc()
            {
                //<Snippet7>
                System.Threading.Thread.Sleep(100);
                //</Snippet7>
            }

            //<Snippet13>
            private string RemoveFromString(string origString, string stringToRemove)
            {
                int index = origString.IndexOf(stringToRemove);
                if (index == -1)
                    return origString;
                else
                    return origString.Substring(0, index) + origString.Substring(index + stringToRemove.Length);
            }

            private string[] GetEvenItems(string[] contentArr)
            {
                int length = contentArr.Length / 2;
                string[] evenContentArr = new string[length];

                int indexB = 0;
                for (int index = 1; index < contentArr.Length; index += 2)
                {
                    evenContentArr[indexB] = contentArr[index];
                    indexB++;
                }

                return evenContentArr;
            }
            //</Snippet13>

            //<Snippet14>
            protected override void OnStartSearch()
            {
                // Use the original content of the text box as the target of the search.
                var separator = new string[] { Environment.NewLine };
                string[] contentArr = ((MyControl)m_toolWindow.Content).SearchContent.Split(separator, StringSplitOptions.None);

                // Get the search option.
                bool matchCase = false;
                //<Snippet11>
                matchCase = m_toolWindow.MatchCaseOption.Value;
                //</Snippet11>

                // Set variables that are used in the finally block.
                StringBuilder sb = new StringBuilder("");
                uint resultCount = 0;
                this.ErrorCode = VSConstants.S_OK;

                try
                {
                    string searchString = this.SearchQuery.SearchString;

                    // If the search string contains the filter string, filter the content array.
                    string filterString = "lines:\"even\"";


                    if (this.SearchQuery.SearchString.Contains(filterString))
                    {
                        // Retain only the even items in the array.
                        contentArr = GetEvenItems(contentArr);

                        // Remove 'lines:"even"' from the search string.
                        searchString = RemoveFromString(searchString, filterString);
                    }

                    // Determine the results.
                    uint progress = 0;
                    foreach (string line in contentArr)
                    {
                        if (matchCase == true)
                        {
                            if (line.Contains(searchString))
                            {
                                sb.AppendLine(line);
                                resultCount++;
                            }
                        }
                        else
                        {
                            if (line.ToLower().Contains(searchString.ToLower()))
                            {
                                sb.AppendLine(line);
                                resultCount++;
                            }
                        }

                        //<Snippet15>
                        SearchCallback.ReportProgress(this, progress++, (uint)contentArr.GetLength(0));
                        //</Snippet15>

                        // Uncomment the following line to demonstrate the progress bar.
                        // System.Threading.Thread.Sleep(100);
                    }
                }
                catch (Exception e)
                {
                    this.ErrorCode = VSConstants.E_FAIL;
                }
                finally
                {
                    ThreadHelper.Generic.Invoke(() =>
                    { ((TextBox)((MyControl)m_toolWindow.Content).SearchResultsTextBox).Text = sb.ToString(); });

                    this.SearchResults = resultCount;
                }

                // Call the implementation of this method in the base class.
                // This sets the task status to complete and reports task completion.
                base.OnStartSearch();
            }
            //</Snippet14>

            protected override void OnStopSearch()
            {
                this.SearchResults = 0;
            }
        }


        //<Snippet5>
        public override void ProvideSearchSettings(IVsUIDataSource pSearchSettings)
        {
            Utilities.SetValue(pSearchSettings, SearchSettingsDataSource.SearchStartTypeProperty.Name, (uint)VSSEARCHSTARTTYPE.SST_INSTANT);
        }
        //</Snippet5>

        private void ProvideSearchSettings2(IVsUIDataSource pSearchSettings)
        {
            //<Snippet6>
            Utilities.SetValue(pSearchSettings, SearchSettingsDataSource.SearchProgressTypeProperty.Name, (uint)VSSEARCHPROGRESSTYPE.SPT_DETERMINATE);
            //</Snippet6>
        }


        //<Snippet9>
        private IVsEnumWindowSearchOptions m_optionsEnum;
        public override IVsEnumWindowSearchOptions SearchOptionsEnum
        {
            get
            {
                if (m_optionsEnum == null)
                {
                    List<IVsWindowSearchOption> list = new List<IVsWindowSearchOption>();

                    list.Add(this.MatchCaseOption);

                    m_optionsEnum = new WindowSearchOptionEnumerator(list) as IVsEnumWindowSearchOptions;
                }
                return m_optionsEnum;
            }
        }

        private WindowSearchBooleanOption m_matchCaseOption;
        public WindowSearchBooleanOption MatchCaseOption
        {
            get
            {
                if (m_matchCaseOption == null)
                {
                    m_matchCaseOption = new WindowSearchBooleanOption("Match case", "Match case", false);
                }
                return m_matchCaseOption;
            }
        }
        //</Snippet9>

        //<Snippet12>
        public override IVsEnumWindowSearchFilters SearchFiltersEnum
        {
            get
            {
                List<IVsWindowSearchFilter> list = new List<IVsWindowSearchFilter>();
                list.Add(new WindowSearchSimpleFilter("Search even lines only", "Search even lines only", "lines", "even"));
                return new WindowSearchFilterEnumerator(list) as IVsEnumWindowSearchFilters;
            }
        }
        //</Snippet12>

    }
}
