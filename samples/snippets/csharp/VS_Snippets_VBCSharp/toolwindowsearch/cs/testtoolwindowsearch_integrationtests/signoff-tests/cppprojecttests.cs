using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VsSDK.IntegrationTestLibrary;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using EnvDTE;
using System.IO;

namespace TestToolWindowSearch_IntegrationTests.IntegrationTests
{
    [TestClass]
    public class CPPProjectTests
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
        public CPPProjectTests()
        {
        }
        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [HostType("VS IDE")]
        [TestMethod]
        public void CPPWinformsApplication()
        {
            UIThreadInvoker.Invoke((ThreadInvoker)delegate()
            {
                //Solution and project creation parameters
                string solutionName = "CPPWinApp";
                string projectName = "CPPWinApp";

                //Template parameters
                string projectType = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
                string projectTemplateName = "mc++winapp.vsz";

                string itemTemplateName = "newc++file.cpp";
                string newFileName = "Test.cpp";

                DTE dte = (DTE)VsIdeTestHostContext.ServiceProvider.GetService(typeof(DTE));

                TestUtils testUtils = new TestUtils();

                testUtils.CreateEmptySolution(TestContext.TestDir, solutionName);
                Assert.AreEqual<int>(0, testUtils.ProjectCount());

                //Add new CPP Windows application project to existing solution
                string solutionDirectory = Directory.GetParent(dte.Solution.FullName).FullName;
                string projectDirectory = TestUtils.GetNewDirectoryName(solutionDirectory, projectName);
                string projectTemplatePath = Path.Combine(dte.Solution.get_TemplatePath(projectType), projectTemplateName);
                Assert.IsTrue(File.Exists(projectTemplatePath), string.Format("Could not find template file: {0}", projectTemplatePath));
                dte.Solution.AddFromTemplate(projectTemplatePath, projectDirectory, projectName, false);

                //Verify that the new project has been added to the solution
                Assert.AreEqual<int>(1, testUtils.ProjectCount());

                //Get the project
                Project project = dte.Solution.Item(1);
                Assert.IsNotNull(project);
                Assert.IsTrue(string.Compare(project.Name, projectName, StringComparison.InvariantCultureIgnoreCase) == 0);

                //Verify Adding new code file to project
                string newItemTemplatePath = Path.Combine(dte.Solution.ProjectItemsTemplatePath(projectType), itemTemplateName);
                Assert.IsTrue(File.Exists(newItemTemplatePath));
                ProjectItem item = project.ProjectItems.AddFromTemplate(newItemTemplatePath, newFileName);
                Assert.IsNotNull(item);

            });
        }

    }
}
