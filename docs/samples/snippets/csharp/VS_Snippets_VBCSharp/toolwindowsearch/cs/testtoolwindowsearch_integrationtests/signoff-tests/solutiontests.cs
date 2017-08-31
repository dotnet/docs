using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using EnvDTE;
using System.IO;
using Microsoft.VsSDK.IntegrationTestLibrary;


namespace TestToolWindowSearch_IntegrationTests.IntegrationTests
{
    [TestClass]
    public class SolutionTests
    {
        #region fields
        private delegate void ThreadInvoker();
        private TestContext _testContext;
        #endregion

        #region properties
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }
        #endregion


        #region ctors
        public SolutionTests()
        {
        }

        #endregion

        [TestMethod]
        [HostType("VS IDE")]
        public void CreateEmptySolution()
        {
            UIThreadInvoker.Invoke((ThreadInvoker)delegate()
            {
                TestUtils testUtils = new TestUtils();
                testUtils.CloseCurrentSolution(__VSSLNSAVEOPTIONS.SLNSAVEOPT_NoSave);
                testUtils.CreateEmptySolution(TestContext.TestDir, "EmptySolution");
            });
        }

    }
}
