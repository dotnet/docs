Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'Imports GFUDemo_VB


<TestClass()> Public Class AutomobileTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region


    <TestMethod()> Public Sub DefaultAutomobileIsInitializedCorrectly()
        Dim myAuto As New Automobile

        '<Snippet1>
        Assert.IsTrue((myAuto.Model = "Not specified") And (myAuto.TopSpeed = -1))
        '</Snippet1>
    End Sub

    <TestMethod()> Public Sub AutomobileWithModelNameCanStart()
        Dim model As String = "Contoso"
        Dim topSpeed As Integer = 199
        Dim myAuto As New Automobile(model, topSpeed)

        '<Snippet3>
        myAuto.Start()
        Assert.IsTrue(myAuto.IsRunning = True)
        '</Snippet3>
    End Sub


End Class
