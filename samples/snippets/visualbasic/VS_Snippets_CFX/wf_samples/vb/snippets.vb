
Imports System

Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization

Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Imports System.IO

Imports System.Runtime.Serialization

Imports System.Text

Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Runtime.Tracking

Imports System.Xml

Imports System.Windows.Forms
Imports WF_Snippets

Namespace WF_Snippets


    'Snippets:  New home for custom snippets created for Windows Workflow Foundation API pages (not from samples)
    Class snippets
        '<snippet0>
        'Implementation of the abstract WorkflowCommitWorkBatchService class
        Class DefaultCommitWorkBatchService
            Inherits WorkflowCommitWorkBatchService

            Protected Overrides Sub CommitWorkBatch(ByVal commitWorkBatchCallback As CommitWorkBatchCallback)
                ' Call base implementation
                Try
                    MyBase.CommitWorkBatch(commitWorkBatchCallback)
                Catch e As Exception
                    ' Report work batch commit failures
                    Console.WriteLine("Work batch failed: " + e.Message.ToString())
                    Throw
                End Try
            End Sub
        End Class
        '</snippet0>

        Partial Public Class CustomExternalMethodActivity
            Inherits CallExternalMethodActivity
            '<snippet1>
            Protected Overrides Sub OnMethodInvoked(ByVal e As EventArgs)
                MyBase.OnMethodInvoked(e)
                Console.WriteLine("External Method Invoked.")
            End Sub
            '</snippet1>
        End Class

        Public Class Workflow1

        End Class

        Public Sub Container0()
            '<snippet2>
            ' Create a new Correlation Property object
            Dim correlationProperty As New CorrelationProperty("taskName", "reportBalance")
            ' Read the property name
            Dim taskName As String = correlationProperty.Name
            ' Read the property value
            Dim taskValue As Object = correlationProperty.Value
            '</snippet2>

            '<snippet3>
            ' Create a new Correlation Token
            Dim subscriptionToken As New CorrelationToken()
            ' Assign the token name
            subscriptionToken.Name = "Operation"
            '</snippet3>

            '<snippet4>
            ' Create a new Correlation Token
            Dim testToken As New CorrelationToken()
            ' Read the Initialized value
            Dim tokenInitialized As Boolean = testToken.Initialized
            '</snippet4>

            '<snippet5>
            ' Create a new Correlation Token
            Dim propertiedToken As New CorrelationToken()
            ' Fetch a list of the correlation token properties
            Dim tokenProperties As List(Of CorrelationProperty) = CType(propertiedToken.Properties, List(Of CorrelationProperty))
            '</snippet5>

            '<snippet6>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Obtain the type of the TrackingService abstract class
            Dim serviceType As Type = GetType(TrackingService)
            ' Create a services collection
            Dim services As ReadOnlyCollection(Of TrackingService)
            ' Fetch a collection of all services that match the given type
            services = workflowRuntime.GetAllServices(Of TrackingService)()
            '</snippet6>

            '<snippet7>
            ' Create the main workflow runtime
            Dim runtime As New WorkflowRuntime()
            ' Create a workflow instance
            Dim workflowInstance As WorkflowInstance = runtime.CreateWorkflow(GetType(Workflow1))
            ' Obtain a reference to the instance's parent runtime
            Dim runtime2 As WorkflowRuntime = workflowInstance.WorkflowRuntime
            '</snippet7>
        End Sub

        Public Sub Container1()
            '<snippet8>
            ' Create a workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a workflow instance
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            ' Start the workflow
            workflowInstance.Start()
            ' Terminate the workflow, passing in a message
            workflowInstance.Terminate("Workflow manually terminated")
            '</snippet8>
        End Sub

        Public Sub Container2()
            '<snippet9>
            ' Create a workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a workflow instance
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            ' Start the workflow
            workflowInstance.Start()
            ' Suspend the workflow, passing in a message
            workflowInstance.Suspend("Workflow manually suspended")
            '</snippet9>
        End Sub

        Public Sub Container3()
            '<snippet10>
            '<snippet11>
            ' Create a WorkflowRuntime object
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a new instance of the out-of-box SqlWorkflowPersistenceService
            Dim persistenceService As _
               New SqlWorkflowPersistenceService( _
               "Initial Catalog=SqlPersistenceServiceData Source=localhostIntegrated Security=SSPI")
            ' Add the service to the runtime
            workflowRuntime.AddService(persistenceService)
            ' Create a WorkflowInstance object
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            ' Start the workflow instance
            workflowInstance.Start()
            'Unload the instance
            workflowInstance.Unload()
            '</snippet11>
            'Reload the previously unloaded instance
            workflowInstance.Load()
            '</snippet10>
        End Sub

        Public Sub Container4()
            '<snippet12>
            ' Create a workflow runtime environment
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a new instance of the out-of-box SqlWorkflowPersistenceService.
            ' Use the non-locking constructor, since we're only creating a single Workflow Runtime.
            Dim parameters As New NameValueCollection()
            parameters.Add("ConnectionString", _
                "Initial Catalog=SqlPersistenceServiceData Source=localhostIntegrated Security=SSPI")
            'Set UnloadOnIdle to true, so that the service will persist the workflow
            parameters.Add("UnloadOnIdle", "true")
            Dim persistenceService As _
               New SqlWorkflowPersistenceService(parameters)

            ' Add the service to the runtime
            workflowRuntime.AddService(persistenceService)
            ' Create a WorkflowInstance object
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            ' Start the instance
            workflowInstance.Start()
            ' Create an instance of a class that implements IPendingWork for notification
            Dim pendingWork As New PendingService()
            ' Send the workflow the message
            workflowInstance.EnqueueItemOnIdle("ActionQueue", "StartWork", pendingWork, "ActionItem")
            '</snippet12>
        End Sub

        Public Sub Container5()
            '<snippet13>
            'Create a workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            'Create a workflow instance
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            'Start the instance
            workflowInstance.Start()
            'Abort the instance
            workflowInstance.Abort()
            '</snippet13>
        End Sub

        Public Sub Container6()
            '<snippet14>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Add a method as the event handler for the Stopped event.
            AddHandler workflowRuntime.Stopped, AddressOf RuntimeStopped
            '</snippet14>
        End Sub

        Public Sub RuntimeStopped(ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)

        End Sub

        Public Sub Container7()
            '<snippet15>
            ' Create a new workflow runtime
            Dim startingRuntime As New WorkflowRuntime()
            ' Add a method as the event handler for the Started event.
            AddHandler startingRuntime.Started, AddressOf RuntimeStarted
            '</snippet15>
        End Sub

        Public Sub RuntimeStarted(ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)

        End Sub

        Public Sub Container8()
            '<snippet16>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a new instance of the out-of-box SqlWorkflowPersistenceService
            Dim persistenceService As New SqlWorkflowPersistenceService( _
               "Initial Catalog=SqlPersistenceServiceData Source=localhostIntegrated Security=SSPI")
            ' Add the service to the runtime
            workflowRuntime.AddService(persistenceService)
            ' Start the runtime
            workflowRuntime.StartRuntime()
            ' Stop the runtime
            workflowRuntime.StopRuntime()
            ' Remove the service from the runtime
            workflowRuntime.RemoveService(persistenceService)
            '</snippet16>
        End Sub
        Public Sub Container9()
            '<snippet17>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Create a new instance of the out-of-box SqlWorkflowPersistenceService.  
            ' A persistence service is necessary in order to get workflows from the runtime.
            Dim persistenceService As New SqlWorkflowPersistenceService( _
                "Initial Catalog=SqlPersistenceServiceData Source=localhostIntegrated Security=SSPI")
            ' Add the service to the runtime
            workflowRuntime.AddService(persistenceService)
            ' Start the runtime
            workflowRuntime.StartRuntime()

            ' Create a new workflow instance
            Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(Workflow1))
            ' Start the workflow
            workflowInstance.Start()

            ' Fetch the instance ID of the workflow
            Dim workflowId As Guid = workflowInstance.InstanceId

            ' Fetch a reference to the workflow Imports the GetWorkflow method.
            Dim workflowReference As WorkflowInstance = workflowRuntime.GetWorkflow(workflowId)
            '</snippet17>
        End Sub

        Public Sub Container10()
            '<snippet18>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Start the runtime
            workflowRuntime.StartRuntime()
            ' Create a collection of workflow instances
            Dim workflows As ReadOnlyCollection(Of WorkflowInstance)
            ' Populate the collection of workflow instances
            workflows = workflowRuntime.GetLoadedWorkflows()
            '</snippet18>
        End Sub
        Public Sub Container11()
            '<snippet19>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Obtain the type of the TrackingService abstract class
            Dim serviceType As Type = GetType(TrackingService)
            ' Create a services collection
            Dim services As ReadOnlyCollection(Of Object)
            ' Fetch a collection of all services that match the given type
            services = workflowRuntime.GetAllServices(serviceType)
            '</snippet19>
        End Sub
        Public Sub Container12()
            '<snippet20>
            ' Create a new WorkflowRuntime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Assign a name to the runtime
            workflowRuntime.Name = "Main Runtime"
            '</snippet20>
        End Sub
        Public Sub Container13()
            '<snippet21>
            ' Create a new workflow runtime
            Dim workflowRuntime As New WorkflowRuntime()
            ' Start the runtime
            workflowRuntime.StartRuntime()
            ' If the runtime is started, report to the console.
            If workflowRuntime.IsStarted Then
                Console.WriteLine("Runtime is started.")
            End If
            '</snippet21>
        End Sub
        '<snippet22>
        Class WorkflowLoaderServiceExample

            Public Shared Sub CreateRuntime()
                'Create the workflow runtime to host the custom loader service
                Dim workflowRuntime As New WorkflowRuntime()
                'Create an instance of the default implementation of the WorkflowLoaderService
                Dim loaderService As New CustomWorkflowLoaderService()
                workflowRuntime.AddService(loaderService)

                'Dispose of the runtime properly
                workflowRuntime.Dispose()
            End Sub

            Public Class CustomWorkflowLoaderService
                Inherits WorkflowLoaderService
                Protected Overrides Function CreateInstance(ByVal workflowDefinitionReader As XmlReader, ByVal rulesReader As XmlReader) As Activity
                    'For the purpose of me sample, return a blank SequentialWorkflowActivity.
                    Return New SequentialWorkflowActivity()
                End Function

                Protected Overrides Function CreateInstance(ByVal workflowType As Type) As Activity
                    'For the purpose of me sample, return a blank SequentialWorkflowActivity.
                    Return New SequentialWorkflowActivity()
                End Function
            End Class
        End Class
        '</snippet22>

        Public Class ParallelIfBranchDesigner
            Inherits SequentialActivityDesigner

            ' <snippet23>
            Public Overrides Function CanBeParentedTo(ByVal parentActivityDesigner As CompositeActivityDesigner) As Boolean
                If parentActivityDesigner Is Nothing Then
                    Throw New ArgumentNullException("parentActivityDesigner")
                End If

                If Not TypeOf parentActivityDesigner.Activity Is ParallelIfActivity Then
                    Return False
                Else
                    Return MyBase.CanBeParentedTo(parentActivityDesigner)
                End If
            End Function
            ' </snippet23>
        End Class

        ' <snippet24>
        <ActivityDesignerTheme(GetType(ParallelIfTheme))> _
        Public Class ParallelIfDesigner
            Inherits ParallelActivityDesigner
            ' </snippet24>

            ' <snippet25>
            Public Overrides Function CanInsertActivities(ByVal insertLocation As HitTestInfo, ByVal activitiesToInsert As ReadOnlyCollection(Of Activity)) As Boolean
                Return False
            End Function
            ' </snippet25>

            ' <snippet26>
            Public Overrides Function CanMoveActivities(ByVal moveLocation As HitTestInfo, ByVal activitiesToMove As ReadOnlyCollection(Of Activity)) As Boolean
                Return False
            End Function
            ' </snippet26>

            ' <snippet27>
            Public Overrides Function CanRemoveActivities(ByVal activitiesToRemove As ReadOnlyCollection(Of Activity)) As Boolean
                Return True
            End Function
            ' </snippet27>

            ' <snippet28>
            ' <snippet29>
            Protected Overrides Function OnCreateNewBranch() As CompositeActivity
                Return New ParallelIfBranch()
            End Function
            ' </snippet29>

            Private Sub OnAddBranch(ByVal sender As Object, ByVal e As EventArgs)
                Dim activity1 As CompositeActivity = Me.OnCreateNewBranch()
                Dim activity2 As CompositeActivity = CType(MyBase.Activity, CompositeActivity)

                If (activity2 IsNot Nothing) And (activity1 IsNot Nothing) Then

                    Dim num1 As Integer = Me.ContainedDesigners.Count
                    Dim activityArray1() As Activity = {activity1}

                    If (CanInsertActivities(New ConnectorHitTestInfo(Me, HitTestLocations.Designer, activity2.Activities.Count), _
                        New List(Of Activity)(activityArray1).AsReadOnly())) Then

                        CompositeActivityDesigner.InsertActivities(Me, _
                            New ConnectorHitTestInfo(Me, HitTestLocations.Designer, activity2.Activities.Count), _
                            New List(Of Activity)(activityArray1).AsReadOnly(), _
                            String.Format("Adding branch 0}", activity1.GetType().Name))

                        If (Me.ContainedDesigners.Count > num1) And (Me.ContainedDesigners.Count > 0) Then
                            Me.ContainedDesigners(Me.ContainedDesigners.Count - 1).EnsureVisible()
                        End If
                    End If
                End If
            End Sub
            ' </snippet28>

            Protected Overrides Sub OnExecuteDesignerAction(ByVal designerAction As DesignerAction)

            End Sub
        End Class
        ' <snippet30>
        Public Class ParallelIfTheme
            Inherits CompositeDesignerTheme

            Public Sub New(ByVal theme As WorkflowTheme)
                MyBase.new(theme)

                Me.ShowDropShadow = True
                Me.ConnectorStartCap = LineAnchor.None
                Me.ConnectorEndCap = LineAnchor.None
                Me.BorderStyle = DashStyle.Dash
                Me.WatermarkImagePath = "parallelIfWatermark.png"
                Me.WatermarkAlignment = DesignerContentAlignment.Fill
            End Sub
        End Class
        ' </snippet30>
        Public Class WorkflowLoader
            Inherits WorkflowDesignerLoader
            Friend Shared Sub DestroyObjectGraphFromDesignerHost(ByVal designerHost As IDesignerHost, ByVal activity As Activity)
            End Sub
            ' <snippet31>
            Protected Overrides Sub Initialize()
                MyBase.Initialize()

                Dim host As IDesignerLoaderHost = Me.LoaderHost
                If host IsNot Nothing Then
                    host.RemoveService(GetType(IIdentifierCreationService))
                    host.AddService(GetType(IIdentifierCreationService), New IdentifierCreationService(host))
                    host.AddService(GetType(IMenuCommandService), New WorkflowMenuCommandService(host))
                    host.AddService(GetType(IToolboxService), New Toolbox(host))
                    Dim typeProvider As New TypeProvider(host)
                    typeProvider.AddAssemblyReference(GetType(String).Assembly.Location)
                    host.AddService(GetType(ITypeProvider), typeProvider, True)
                    host.AddService(GetType(IEventBindingService), New EventBindingService())
                End If
            End Sub
            ' </snippet31>

            ' <snippet32>
            Public Overrides ReadOnly Property FileName() As String
                ' return path of workflow file
                Get
                    Return Me.XomlFile
                End Get
            End Property
            ' </snippet32>


            Private xomlValue As String
            Public Property Xoml() As String
                Get
                    Return xomlValue
                End Get
                Set(ByVal value As String)
                    xomlValue = value
                End Set
            End Property

            Private xomlFileValue As String = String.Empty

            Public Property XomlFile() As String
                Get
                    Return Me.xomlFileValue
                End Get
                Set(ByVal value As String)
                    Me.xomlFileValue = value
                End Set
            End Property

            ' <snippet33>
            Public Overrides Function GetFileReader(ByVal filePath As String) As TextReader
                Return New StreamReader(New FileStream(filePath, FileMode.OpenOrCreate))
            End Function
            ' </snippet33>

            ' <snippet34>
            Public Overrides Function GetFileWriter(ByVal filePath As String) As TextWriter
                Return New StreamWriter(New FileStream(filePath, FileMode.OpenOrCreate))
            End Function
            ' </snippet34>

            ' <snippet35>
            Public Overrides Sub Flush()
                Me.PerformFlush(Nothing)
            End Sub

            Protected Overrides Sub PerformFlush(ByVal manager As IDesignerSerializationManager)
                Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)

                If host IsNot Nothing And host.RootComponent IsNot Nothing Then
                    Dim service As Activity = CType(host.RootComponent, Activity)

                    If service IsNot Nothing Then
                        Using writer As XmlWriter = XmlWriter.Create(Me.XomlFile)
                            Dim xomlSerializer As New WorkflowMarkupSerializer()
                            If manager IsNot Nothing Then
                                xomlSerializer.Serialize(writer, service)
                            Else
                                xomlSerializer.Serialize(manager, writer, service)
                            End If
                        End Using
                    End If
                End If
            End Sub
            ' </snippet35>

            ' <snippet36>
            Protected Overrides Sub OnEndLoad(ByVal successful As Boolean, ByVal errors As ICollection)
                MyBase.OnEndLoad(successful, errors)

                If Not successful And errors IsNot Nothing Then
                    Dim sb As New System.Text.StringBuilder("Errors\r\n")
                    For Each errorMessage As String In errors
                        sb.Append(errorMessage + "\r\n")
                    Next

                    MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Sub
            ' </snippet36>

            ' <snippet37>
            Protected Overrides Sub PerformLoad(ByVal serializationManager As IDesignerSerializationManager)
                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                Dim rootActivity As Activity = Nothing

                ' If a WorkflowType already exists, create an instance instead of reading from file
                If WorkflowType IsNot Nothing Then
                    rootActivity = CType(Activator.CreateInstance(WorkflowType), Activity)
                Else
                    ' Create a text reader out of the doc data
                    Dim reader As TextReader = New StringReader(Me.Xoml)
                    Try
                        Using xmlReader As XmlReader = xmlReader.Create(reader)
                            Dim xomlSerializer As New WorkflowMarkupSerializer()
                            rootActivity = CType(xomlSerializer.Deserialize(xmlReader), Activity)
                        End Using
                    Finally
                        reader.Close()
                    End Try
                End If

                If rootActivity IsNot Nothing And designerHost IsNot Nothing Then
                    AddObjectGraphToDesignerHost(designerHost, rootActivity)
                End If
            End Sub

            Private Shared Sub AddObjectGraphToDesignerHost(ByVal designerHost As IDesignerHost, ByVal activity As Activity)
                Dim Definitions_Class As New Guid("3FA84B23-B15B-4161-8EB8-37A54EFEEFC7")

                If designerHost IsNot Nothing Then
                    Throw New ArgumentNullException("designerHost")
                End If
                If activity IsNot Nothing Then
                    Throw New ArgumentNullException("activity")
                End If

                Dim rootSiteName As String = activity.QualifiedName
                If activity.Parent Is Nothing Then
                    Dim fullClassName As String = CType(activity.UserData(Definitions_Class), String)
                    If fullClassName Is Nothing Then
                        fullClassName = activity.GetType().FullName
                    End If
                    rootSiteName = IIf(Not fullClassName.LastIndexOf(".") = -1, fullClassName.Substring(fullClassName.LastIndexOf(".") + 1), fullClassName)
                    designerHost.Container.Add(activity, rootSiteName)
                Else
                    designerHost.Container.Add(activity, activity.QualifiedName)
                End If

                If TypeOf activity Is CompositeActivity Then
                    For Each activity2 As Activity In GetNestedActivities(CType(activity, CompositeActivity))
                        designerHost.Container.Add(activity2, activity2.QualifiedName)
                    Next
                End If
            End Sub

            Private Shared Function GetNestedActivities(ByVal compositeActivity As CompositeActivity) As Activity()
                If compositeActivity Is Nothing Then
                    Throw New ArgumentNullException("compositeActivity")
                End If

                Dim childActivities As IList(Of Activity) = Nothing
                Dim nestedActivities As New ArrayList()
                Dim compositeActivities As New Queue()
                compositeActivities.Enqueue(compositeActivity)
                While compositeActivities.Count > 0
                    Dim compositeActivity2 As CompositeActivity = CType(compositeActivities.Dequeue(), CompositeActivity)
                    childActivities = compositeActivity2.Activities

                    For Each activity As Activity In childActivities
                        nestedActivities.Add(activity)
                        If (activity Is compositeActivity) Then
                            compositeActivities.Enqueue(activity)
                        End If
                    Next
                End While
                Return CType(nestedActivities.ToArray(GetType(Activity)), Activity())

            End Function
            ' </snippet37>

            Private workflowTypeValue As Type = Nothing

            Public Property WorkflowType() As Type
                Get
                    Return workflowTypeValue
                End Get
                Set(ByVal value As Type)
                    workflowTypeValue = value
                End Set
            End Property

            ' <snippet38>
            Public Sub SaveLayout()
                Using writer As XmlWriter = XmlWriter.Create("wfInstanceId.designer.xml")
                    Dim layoutSaveErrors As IList = CType(New ArrayList(), IList)

                    Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                    Dim rootDesigner As ActivityDesigner = CType(host.GetDesigner(host.RootComponent), ActivityDesigner)
                    Me.SaveDesignerLayout(writer, rootDesigner, layoutSaveErrors)

                    If layoutSaveErrors.Count > 0 Then
                        Dim sb As New System.Text.StringBuilder("Errors:\r\n")
                        For Each errorMessage As WorkflowMarkupSerializationException In layoutSaveErrors
                            sb.Append(errorMessage.Message + "\r\n")
                        Next
                        MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Sub
            ' </snippet38>

            ' <snippet39>
            Public Sub LoadLayout()
                Using reader As XmlReader = XmlReader.Create("wfInstanceId.designer.xml")

                    Dim layoutLoadErrors As IList = CType(New ArrayList(), IList)
                    Me.LoadDesignerLayout(reader, layoutLoadErrors)

                    If layoutLoadErrors.Count > 0 Then
                        Dim sb As New System.Text.StringBuilder("Errors:\r\n")
                        For Each errorMessage As WorkflowMarkupSerializationException In layoutLoadErrors
                            sb.Append(errorMessage.Message + "\r\n")
                        Next
                        MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End Using
            End Sub
            ' </snippet39>

            ' <snippet40>
            Public Sub RemoveLastChildActivity()
                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                Dim rootActivity As CompositeActivity = CType(designerHost.RootComponent, CompositeActivity)

                If rootActivity.Activities.Count > 0 Then
                    Dim activityToRemove As Activity = rootActivity.Activities(rootActivity.Activities.Count - 1)
                    rootActivity.Activities.Remove(activityToRemove)
                    Me.RemoveActivityFromDesigner(activityToRemove)
                End If
            End Sub
            ' </snippet40>
        End Class

        ' <snippet41>
        Friend NotInheritable Class IdentifierCreationService
            Implements IIdentifierCreationService
            Private serviceProvider As IServiceProvider = Nothing

            Friend Sub New(ByVal serviceProvider As IServiceProvider)
                Me.serviceProvider = serviceProvider
            End Sub

            ' <snippet42>
            Sub ValidateIdentifier(ByVal activity As Activity, ByVal identifier As String) Implements IIdentifierCreationService.ValidateIdentifier
                If identifier Is Nothing Then
                    Throw New ArgumentNullException("identifier")
                End If
                If activity Is Nothing Then
                    Throw New ArgumentNullException("activity")
                End If
                If activity.Name.ToLower().Equals(identifier.ToLower()) Then
                    Return
                End If
                Dim identifiers As New ArrayList()
                Dim rootActivity As Activity = GetRootActivity(activity)
                identifiers.AddRange(GetIdentifiersInCompositeActivity(CType(rootActivity, CompositeActivity)))
                identifiers.Sort()
                If identifiers.BinarySearch(identifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0 Then
                    Throw New ArgumentException(String.Format("Duplicate Component Identifier 0}", identifier))
                End If
            End Sub
            ' </snippet42>

            ' <snippet43>
            Sub EnsureUniqueIdentifiers(ByVal parentActivity As CompositeActivity, ByVal childActivities As ICollection) Implements IIdentifierCreationService.EnsureUniqueIdentifiers

                If parentActivity Is Nothing Then
                    Throw New ArgumentNullException("parentActivity")
                End If
                If childActivities Is Nothing Then
                    Throw New ArgumentNullException("childActivities")
                End If
                Dim allActivities As New List(Of Activity)()

                Dim activities As New Queue(childActivities)
                While activities.Count > 0

                    Dim activity As Activity = CType(activities.Dequeue(), Activity)
                    If TypeOf activity Is CompositeActivity Then
                        For Each child As Activity In CType(activity, CompositeActivity).Activities
                            activities.Enqueue(child)
                        Next
                    End If

                    'If we are moving activities, we need not regenerate their identifiers
                    If CType(activity, IComponent).Site IsNot Nothing Then
                        Continue While
                    End If

                    allActivities.Add(activity)
                End While

                ' get the root activity
                Dim rootActivity As CompositeActivity = CType(GetRootActivity(parentActivity), CompositeActivity)
                Dim identifiers As New ArrayList() ' all the identifiers in the workflow
                identifiers.AddRange(GetIdentifiersInCompositeActivity(rootActivity))

                For Each activity As Activity In allActivities

                    Dim finalIdentifier As String = activity.Name

                    ' now loop until we find a identifier that hasn't been used.
                    Dim baseIdentifier As String = GetBaseIdentifier(activity)
                    Dim index As Integer = 0

                    identifiers.Sort()
                    While finalIdentifier Is Nothing Or _
                    finalIdentifier.Length = 0 Or _
                    identifiers.BinarySearch(finalIdentifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0
                        finalIdentifier = String.Format("0}1}", baseIdentifier, ++index)
                    End While

                    ' add new identifier to collection 
                    identifiers.Add(finalIdentifier)
                    activity.Name = finalIdentifier
                Next
            End Sub

            Private Shared Function GetIdentifiersInCompositeActivity(ByVal CompositeActivity As CompositeActivity) As IList
                Dim identifiers As New ArrayList()
                If CompositeActivity IsNot Nothing Then
                    identifiers.Add(CompositeActivity.Name)
                    Dim allChildren As IList(Of Activity) = GetAllNestedActivities(CompositeActivity)
                    For Each activity As Activity In allChildren
                        identifiers.Add(activity.Name)
                    Next
                End If

                Return ArrayList.ReadOnly(identifiers)
            End Function

            Private Shared Function GetBaseIdentifier(ByVal activity As Activity)
                Dim baseIdentifier As String = activity.GetType().Name
                Dim b As New StringBuilder(baseIdentifier.Length)
                For i As Integer = 0 To baseIdentifier.Length
                    If Char.IsUpper(baseIdentifier(i)) And (i = 0 Or i = baseIdentifier.Length - 1 Or Char.IsUpper(baseIdentifier(i + 1))) Then
                        b.Append(Char.ToLower(baseIdentifier(i)))
                    Else
                        b.Append(baseIdentifier.Substring(i))
                        Exit For
                    End If
                Next
                Return b.ToString()
            End Function

            Private Shared Function GetRootActivity(ByVal activity As Activity) As Activity
                If activity Is Nothing Then
                    Throw New ArgumentException("activity")
                End If

                While activity.Parent IsNot Nothing
                    activity = activity.Parent
                End While

                Return activity
            End Function

            Private Shared Function GetAllNestedActivities(ByVal compositeActivity As CompositeActivity) As Activity()

                If compositeActivity Is Nothing Then
                    Throw New ArgumentNullException("compositeActivity")
                End If

                Dim nestedActivities As New ArrayList()
                Dim compositeActivities As New Queue()
                compositeActivities.Enqueue(compositeActivity)
                While compositeActivities.Count > 0

                    Dim compositeActivity2 As CompositeActivity = CType(compositeActivities.Dequeue(), CompositeActivity)

                    For Each activity As Activity In compositeActivity2.Activities
                        nestedActivities.Add(activity)
                        If activity Is compositeActivity Then
                            compositeActivities.Enqueue(activity)
                        End If
                    Next

                    For Each activity As Activity In compositeActivity2.EnabledActivities
                        If Not nestedActivities.Contains(activity) Then
                            nestedActivities.Add(activity)
                            If (activity Is compositeActivity) Then
                                compositeActivities.Enqueue(activity)
                            End If
                        End If
                    Next
                End While
                Return CType(nestedActivities.ToArray(GetType(Activity)), Activity())
                ' </snippet43>
            End Function
            ' </snippet41>
        End Class


        ' <snippet44>
        Friend NotInheritable Class WorkflowMenuCommandService
            Inherits MenuCommandService
            Public Sub New(ByVal serviceProvider As IServiceProvider)
                MyBase.new(serviceProvider)
            End Sub
            ' <snippet45>
            Public Overrides Sub ShowContextMenu(ByVal menuID As CommandID, ByVal x As Integer, ByVal y As Integer)

                If menuID.ID = WorkflowMenuCommands.SelectionMenu.ID Then
                    Dim contextMenu As New ContextMenu()

                    For Each verb As DesignerVerb In Verbs
                        Dim MenuItem As New MenuItem(verb.Text, AddressOf OnMenuClicked)
                        MenuItem.Tag = verb
                        contextMenu.MenuItems.Add(MenuItem)
                    Next

                    Dim items As MenuItem() = GetSelectionMenuItems()
                    If (items.Length > 0) Then

                        contextMenu.MenuItems.Add(New MenuItem("-"))
                        For Each item As MenuItem In items
                            contextMenu.MenuItems.Add(item)
                        Next

                        Dim workflowView As WorkflowView = CType(GetService(GetType(WorkflowView)), WorkflowView)
                        If workflowView Is Nothing Then
                            contextMenu.Show(workflowView, workflowView.PointToClient(New Point(x, y)))
                        End If
                    End If
                End If
                ' </snippet45>
            End Sub

            ' <snippet46>
            Private Function GetSelectionMenuItems() As MenuItem()

                Dim menuItems As New List(Of MenuItem)()

                Dim addMenuItems As Boolean = True
                Dim selectionService As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                If selectionService IsNot Nothing Then

                    For Each obj As Object In selectionService.GetSelectedComponents()
                        If Not TypeOf obj Is Activity Then
                            addMenuItems = False
                            Exit For
                        End If
                    Next
                End If


                If (addMenuItems) Then

                    Dim selectionCommands As New Dictionary(Of CommandID, String)()
                    selectionCommands.Add(WorkflowMenuCommands.Cut, "Cut")
                    selectionCommands.Add(WorkflowMenuCommands.Copy, "Copy")
                    selectionCommands.Add(WorkflowMenuCommands.Paste, "Paste")
                    selectionCommands.Add(WorkflowMenuCommands.Delete, "Delete")
                    selectionCommands.Add(WorkflowMenuCommands.Collapse, "Collapse")
                    selectionCommands.Add(WorkflowMenuCommands.Expand, "Expand")
                    selectionCommands.Add(WorkflowMenuCommands.Disable, "Disable")
                    selectionCommands.Add(WorkflowMenuCommands.Enable, "Enable")

                    For Each id As CommandID In selectionCommands.Keys

                        Dim command As MenuCommand = FindCommand(id)
                        If command IsNot Nothing Then
                            Dim menuItem As New MenuItem(selectionCommands(id), AddressOf OnMenuClicked)
                            menuItem.Tag = command
                            menuItems.Add(menuItem)
                        End If
                    Next
                End If

                Return menuItems.ToArray()
            End Function

            Private Sub OnMenuClicked(ByVal sender As Object, ByVal e As EventArgs)

                Dim menuItem As MenuItem = CType(sender, MenuItem)
                If menuItem IsNot Nothing And TypeOf menuItem.Tag Is MenuCommand Then
                    Dim command As MenuCommand = CType(menuItem.Tag, MenuCommand)
                    command.Invoke()
                End If
            End Sub
            ' </snippet46>
        End Class
        ' </snippet44>

        Partial Public Class WFPadWorkflowDesignerControl
            Inherits UserControl
            Implements IDisposable, IServiceProvider

            Friend Class Resources
                Friend Shared draft As New Bitmap(0, 0)
                Friend Shared ToolboxImage As New Bitmap(0, 0)
            End Class

            Private workflowView As WorkflowView
            Private designSurface As DesignSurface
            Private loader As WorkflowLoader
            Private splitContainer1 As System.Windows.Forms.SplitContainer
            Private btnAutoSynch As System.Windows.Forms.ToolStripButton
            Private xomlView As System.Windows.Forms.TextBox

            Public Sub New()
                Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
                Me.btnAutoSynch = New ToolStripButton()
                Me.xomlView = New TextBox()
            End Sub
            Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            End Sub

            Sub changeService_ComponentAdded(ByVal sender As Object, ByVal e As ComponentEventArgs)
            End Sub

            Sub changeService_ComponentChanged(ByVal sender As Object, ByVal e As ComponentChangedEventArgs)
            End Sub
            Sub changeService_ComponentRemoved(ByVal sender As Object, ByVal e As ComponentEventArgs)
            End Sub
            Sub changeService_ComponentRename(ByVal sender As Object, ByVal e As ComponentRenameEventArgs)
            End Sub
            Public Function GetCurrentXoml() As String
                Return ""
            End Function

            Protected Overrides Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
                Return IIf(Me.workflowView IsNot Nothing, CType(Me.workflowView, IServiceProvider).GetService(serviceType), Nothing)
            End Function

            Public Property XomlFile() As String
                Get
                    Return String.Empty
                End Get

                Set(ByVal value As String)

                End Set
            End Property

            ' <snippet47>
            Private Function LoadWorkflow(ByVal workflowType As Type) As ICollection
                Dim loader As New WorkflowLoader()
                loader.WorkflowType = workflowType
                Return LoadWorkflow(loader)
            End Function

            Private Function LoadWorkflow(ByVal loader As WorkflowLoader) As ICollection

                SuspendLayout()

                Dim designSurface As New DesignSurface()
                designSurface.BeginLoad(loader)
                If designSurface.LoadErrors.Count > 0 Then
                    Return designSurface.LoadErrors
                End If

                ' <snippet48>
                Dim designerHost As IDesignerHost = CType(designSurface.GetService(GetType(IDesignerHost)), IDesignerHost)
                If designerHost IsNot Nothing And designerHost.RootComponent IsNot Nothing Then

                    Dim rootDesigner As IRootDesigner = CType(designerHost.GetDesigner(designerHost.RootComponent), IRootDesigner)
                    If rootDesigner IsNot Nothing Then
                        UnloadWorkflow()

                        Me.designSurface = designSurface
                        Me.loader = loader
                        Me.workflowView = CType(rootDesigner.GetView(ViewTechnology.Default), WorkflowView)
                        Me.splitContainer1.Panel1.Controls.Add(Me.workflowView)
                        Me.workflowView.Dock = DockStyle.Fill
                        Me.workflowView.TabIndex = 1
                        Me.workflowView.TabStop = True
                        Me.workflowView.HScrollBar.TabStop = False
                        Me.workflowView.VScrollBar.TabStop = False
                        Me.workflowView.ShadowDepth = 0
                        Me.workflowView.EnableFitToScreen = True
                        Me.workflowView.Focus()

                        Dim selectionService As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
                        Dim changeService As IComponentChangeService = CType(GetService(GetType(IComponentChangeService)), IComponentChangeService)

                        If selectionService IsNot Nothing Then
                            AddHandler selectionService.SelectionChanged, AddressOf OnSelectionChanged
                        End If

                        If changeService IsNot Nothing Then

                            AddHandler changeService.ComponentAdded, AddressOf changeService_ComponentAdded
                            AddHandler changeService.ComponentChanged, AddressOf changeService_ComponentChanged
                            AddHandler changeService.ComponentRemoved, AddressOf changeService_ComponentRemoved
                            AddHandler changeService.ComponentRename, AddressOf changeService_ComponentRename
                        End If
                    End If
                End If
                ' </snippet48>

                ResumeLayout(True)

                If btnAutoSynch.Checked = True Then
                    Me.xomlView.Text = GetCurrentXoml()
                End If

                Return Nothing
            End Function

            ' </snippet47>

            ' <snippet49>
            Private Sub UnloadWorkflow()


                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                If designerHost IsNot Nothing And designerHost.Container.Components.Count > 0 Then
                    WorkflowLoader.DestroyObjectGraphFromDesignerHost(designerHost, CType(designerHost.RootComponent, Activity))
                End If

                If Me.designSurface IsNot Nothing Then
                    Me.designSurface.Dispose()
                    Me.designSurface = Nothing
                End If


                If Me.workflowView IsNot Nothing Then
                    Controls.Remove(Me.workflowView)
                    Me.workflowView.Dispose()
                    Me.workflowView = Nothing
                End If

            End Sub
            ' </snippet49>

            ' <snippet50>
            Public Sub EnableFitToScreen()

                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                Dim workflowView As WorkflowView = _
                    CType(designerHost.RootComponent.Site.GetService(GetType(WorkflowView)), WorkflowView)

                If workflowView IsNot Nothing Then
                    workflowView.EnableFitToScreen = True
                    workflowView.FitToScreenSize()
                End If
            End Sub
            ' </snippet50>

            ' <snippet51>
            Public Sub FitToPage()
                Me.workflowView.FitToScreenSize()
                Me.workflowView.Update()
            End Sub
            ' </snippet51>

            ' <snippet52>
            Public Sub ProcessZoom(ByVal zoomFactor As Integer)
                Me.workflowView.Zoom = zoomFactor
            End Sub
            ' </snippet52>

            ' <snippet53>
            Friend Sub SaveExistingWorkflow(ByVal filePath As String)
                If Me.designSurface IsNot Nothing And Me.loader IsNot Nothing Then
                    Me.XomlFile = filePath
                    Me.loader.Flush()
                End If
            End Sub
            ' </snippet53>

            ' <snippet54>
            Public ReadOnly Property IsDesignerLocked() As Boolean
                Get
                    Dim loader As WorkflowDesignerLoader = CType(GetService(GetType(WorkflowDesignerLoader)), WorkflowDesignerLoader)
                    If loader IsNot Nothing And loader.InDebugMode Then
                        Return True
                    End If

                    Return False
                End Get
            End Property
            ' </snippet54>

            ' <snippet55>
            Public Sub AddCodeActivityToDesigner()

                Dim loader As WorkflowDesignerLoader = CType(GetService(GetType(WorkflowDesignerLoader)), WorkflowDesignerLoader)
                If loader Is Nothing Then Return
                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                Dim rootActivity As CompositeActivity = CType(designerHost.RootComponent, CompositeActivity)
                Dim codeActivity As New CodeActivity()
                rootActivity.Activities.Add(codeActivity)
                loader.AddActivityToDesigner(codeActivity)
                Return
            End Sub
            ' </snippet55>

            ' <snippet56>
            Public Sub Print()
                Dim doc As System.Drawing.Printing.PrintDocument = Me.workflowView.PrintDocument
                Dim dlg As New PrintDialog()
                If dlg.ShowDialog() = DialogResult.OK Then
                    doc.PrinterSettings = dlg.PrinterSettings
                    doc.Print()
                End If
            End Sub
            ' </snippet56>

            ' <snippet57>
            Public Sub PrintPreview(ByVal enablePrintPreview As Boolean)
                Me.workflowView.PrintPreviewMode = enablePrintPreview
            End Sub
            ' </snippet57>

            ' <snippet58>
            Sub workflowView_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
                Using g As Graphics = Me.workflowView.CreateGraphics()
                    Dim draftImage As Bitmap = Resources.draft
                    draftImage.MakeTransparent(Color.Magenta)
                    g.DrawImage(draftImage, Me.workflowView.ViewPortRectangle)
                End Using

                MyBase.OnPaint(e)
            End Sub
            ' </snippet58>

            ' <snippet59>
            Public Sub SaveViewState()

                Using fs As New FileStream("viewstate.bin", FileMode.Create)
                    Me.workflowView.SaveViewState(fs)
                End Using
            End Sub
            ' </snippet59>

            ' <snippet60>
            Public Sub LoadViewState()
                Using fs As New FileStream("viewstate.bin", FileMode.Open)
                    Me.workflowView.LoadViewState(fs)
                End Using
            End Sub
            ' </snippet60>

            ' <snippet61>
            Public Sub CopyWorkflowImage()
                Me.workflowView.SaveWorkflowImageToClipboard()
            End Sub
            ' </snippet61>

            ' <snippet62>
            Public Sub SaveWorkflowImage()
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "Bitmap Files|*.bmp"
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    Me.workflowView.SaveWorkflowImage(SaveFileDialog.FileName, ImageFormat.Bmp)
                End If
            End Sub
            ' </snippet62>

            ' <snippet63>
            Public Sub SaveWorkflowImageImportsStream()

                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "Bitmap Files|*.bmp"
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    Using fileStream As New FileStream(SaveFileDialog.FileName, FileMode.Create)
                        Me.workflowView.SaveWorkflowImage(fileStream, ImageFormat.Bmp)
                    End Using
                End If
            End Sub
            ' </snippet63>

            ' <snippet64>
            Public Sub FindSelection()
                Dim selectionService As ISelectionService
                selectionService = CType(CType(Me.workflowView, IServiceProvider).GetService(GetType(ISelectionService)), ISelectionService)

                If selectionService IsNot Nothing Then
                    Me.workflowView.EnsureVisible(selectionService.PrimarySelection)
                End If
            End Sub
            ' </snippet64>

            ' <snippet65>
            Public Sub DisplayFullWorkflowView()
                Dim designerHost As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)
                If designerHost IsNot Nothing And designerHost.RootComponent IsNot Nothing Then
                    Dim workflowView As WorkflowView = _
                                CType(designerHost.RootComponent.Site.GetService(GetType(WorkflowView)), WorkflowView)
                    If workflowView IsNot Nothing Then
                        workflowView.Dock = DockStyle.Fill
                        workflowView.TabIndex = 1
                        workflowView.TabStop = True
                        workflowView.HScrollBar.TabStop = False
                        workflowView.VScrollBar.TabStop = False
                        workflowView.Focus()
                        workflowView.FitToWorkflowSize()
                    End If
                End If
            End Sub
            ' </snippet65>

            Private Class CustomWorkflowViewMessageFilter
                Inherits WorkflowDesignerMessageFilter


                Private mouseDown As Boolean
                Private _serviceProvider As IServiceProvider
                Private _workflowView As WorkflowView

                Public Sub New(ByVal provider As IServiceProvider, ByVal workflowView As WorkflowView)
                    mouseDown = False
                    _serviceProvider = provider
                    _workflowView = workflowView
                End Sub



                Dim positionXOld As Integer
                Dim positionYOld As Integer

                Protected Overrides Function OnMouseDown(ByVal eventArgs As MouseEventArgs) As Boolean
                    ' Save mouse position and allow other components to process 
                    ' me event by not returning true.
                    mouseDown = True
                    Me.positionXOld = eventArgs.X
                    Me.positionYOld = eventArgs.Y
                    Return False
                End Function

                Protected Overrides Function OnMouseMove(ByVal eventArgs As MouseEventArgs) As Boolean
                    'Allow other components to process me event by not returning true.
                    If Me.mouseDown Then
                        _workflowView.ScrollPosition = New Point(_workflowView.ScrollPosition.X - (eventArgs.X - positionXOld), _workflowView.ScrollPosition.Y - (eventArgs.Y - positionYOld))
                        positionXOld = eventArgs.X
                        positionYOld = eventArgs.Y
                    End If
                    Return False
                End Function

                Protected Overrides Function OnMouseUp(ByVal eventArgs As MouseEventArgs) As Boolean
                    'Allow other components to process me event by not returning true.
                    mouseDown = False
                    Return False
                End Function

                Protected Overrides Function OnMouseDoubleClick(ByVal eventArgs As MouseEventArgs) As Boolean
                    mouseDown = False
                    Return True
                End Function

                Protected Overrides Function OnMouseEnter(ByVal eventArgs As MouseEventArgs) As Boolean
                    'Allow other components to process me event by not returning true.
                    mouseDown = False
                    Return False
                End Function

                Protected Overrides Function OnMouseHover(ByVal eventArgs As MouseEventArgs) As Boolean
                    'Allow other components to process me event by not returning true.
                    mouseDown = False
                    Return False
                End Function

                Protected Overrides Function OnMouseLeave() As Boolean
                    'Allow other components to process me event by not returning true.
                    mouseDown = False
                    Return False
                End Function

                ' <snippet66>
                Protected Overrides Function OnMouseWheel(ByVal eventArgs As MouseEventArgs) As Boolean
                    If eventArgs.Delta < 0 Then
                        Me._workflowView.Zoom = Me._workflowView.Zoom - 10
                    Else
                        Me._workflowView.Zoom = Me._workflowView.Zoom + 10
                    End If

                    mouseDown = False
                    Return True
                End Function
                ' </snippet66>

                Protected Overrides Function OnMouseCaptureChanged() As Boolean
                    'Allow other components to process me event by not returning true.
                    mouseDown = False
                    Return False
                End Function

                Protected Overrides Function OnDragEnter(ByVal eventArgs As DragEventArgs) As Boolean
                    Return False
                End Function

                Protected Overrides Function OnDragOver(ByVal eventArgs As DragEventArgs) As Boolean
                    Return False
                End Function

                Protected Overrides Function OnDragLeave() As Boolean
                    Return False
                End Function

                Protected Overrides Function OnDragDrop(ByVal eventArgs As DragEventArgs) As Boolean
                    Return False
                End Function

                Protected Overrides Function OnGiveFeedback(ByVal gfbevent As GiveFeedbackEventArgs) As Boolean
                    Return False
                End Function

                Protected Overrides Function OnQueryContinueDrag(ByVal qcdevent As QueryContinueDragEventArgs) As Boolean
                    Return False
                End Function

                Protected Overrides Function OnKeyUp(ByVal eventArgs As KeyEventArgs) As Boolean
                    Return True
                End Function

                Protected Overrides Function OnShowContextMenu(ByVal menuPoint As Point) As Boolean
                    Return True
                End Function
            End Class
            ' <snippet67>
            <ToolboxItem(GetType(CustomActivityToolboxItem))> _
            <ActivityValidator(GetType(CustomActivityValidator))> _
            Partial Public Class CustomActivity
                ' </snippet67>
                Inherits System.Workflow.ComponentModel.CompositeActivity
                <System.Diagnostics.DebuggerNonUserCode()> _
                Private Sub InitializeComponent()
                    Me.Name = "Activity1"
                End Sub

                Public Sub New()
                    InitializeComponent()
                End Sub

                Public Shared MyPropertyProperty As DependencyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyProperty", GetType(String), GetType(CustomActivity))

                <Description("This is the description which appears in the Property Browser")> _
                <Category("This is the category which will be displayed in the Property Browser")> _
                <Browsable(True)> _
                <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
                            Public Property MyProperty() As String
                    Get
                        Return CType(MyBase.GetValue(CustomActivity.MyPropertyProperty), String)
                    End Get
                    Set(ByVal value As String)
                        MyBase.SetValue(CustomActivity.MyPropertyProperty, value)
                    End Set
                End Property

            End Class

            ' <snippet68>
            Friend NotInheritable Class CustomActivityValidator
                Inherits ActivityValidator
                ' <snippet69>
                Public Overrides Function Validate(ByVal manager As ValidationManager, ByVal obj As Object) As ValidationErrorCollection
                    Dim validationErrors As ValidationErrorCollection = MyBase.Validate(manager, obj)

                    Dim ca As CustomActivity = CType(obj, CustomActivity)
                    If ca Is Nothing Then
                        Throw New ArgumentException("Activity instance is null", GetType(CustomActivity).FullName)
                    End If

                    Dim parent As Activity = ca.Parent
                    While parent IsNot Nothing
                        If TypeOf parent Is ListenActivity Then
                            validationErrors.Add(New ValidationError("Cannot add custom activity to ListenActivity", 1))
                            Exit While
                        End If
                        parent = parent.Parent

                    End While

                    Return validationErrors
                End Function
                ' </snippet69>
            End Class
            ' </snippet68>

            ' <snippet70>
            <Serializable()> _
            Friend Class CustomActivityToolboxItem
                Inherits ActivityToolboxItem

                Public Sub New(ByVal type As Type)
                    MyBase.new(type)
                End Sub

                Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
                    Deserialize(info, context)
                End Sub

                ' <snippet71>
                Protected Overrides Function CreateComponentsCore(ByVal designerHost As IDesignerHost) As IComponent()
                    Dim parallel As New ParallelActivity()
                    parallel.Activities.Add(New CustomActivity())
                    parallel.Activities.Add(New CustomActivity())

                    Return New IComponent() {parallel}
                End Function
                ' </snippet71>
            End Class
            ' </snippet70>

            ' <snippet72>
            <ActivityDesignerTheme(GetType(CustomCompositeActivityDesignerTheme))> _
            Public Class CustomActivityDesigner
                Inherits ActivityDesigner

               
                Public Overrides Function CanBeParentedTo(ByVal parentActivityDesigner As CompositeActivityDesigner) As Boolean
                    If parentActivityDesigner.GetType().ToString() = "System.Workflow.Activities.IfElseBranchDesigner" Then
                        Return False
                    End If
                    Return True
                End Function

                ' <snippet73>
                Private verbsValue As ActivityDesignerVerbCollection = Nothing

                Protected Overrides ReadOnly Property Verbs() As ActivityDesignerVerbCollection
                    Get
                        If verbsValue Is Nothing Then
                            CreateActivityVerbs()
                        End If
                        Return Me.verbsValue

                    End Get
                End Property

                Private Sub CreateActivityVerbs()
                    Me.verbsValue = New ActivityDesignerVerbCollection()

                    Dim addBranchVerb As New ActivityDesignerVerb(Me, DesignerVerbGroup.View, "Add New Parallel Branch", AddressOf OnAddParallelBranch)

                    Me.verbsValue.Clear()

                    Me.verbsValue.Add(addBranchVerb)
                End Sub

                Protected Sub OnAddParallelBranch(ByVal sender As Object, ByVal e As EventArgs)
                    ' Code for adding a new branch to the parallel activity goes here
                End Sub
                ' </snippet73>

                ' <snippet74>
                Protected Overrides ReadOnly Property ImageRectangle() As Rectangle

                    Get
                        Dim Bounds As Rectangle = Me.Bounds
                        Dim sz As New Size(24, 24)

                        Dim imageRect As New Rectangle()
                        imageRect.X = Bounds.Left + ((Bounds.Width - sz.Width) / 2)
                        imageRect.Y = Bounds.Top + 4
                        imageRect.Size = sz

                        Return imageRect
                    End Get
                End Property
                ' </snippet74>

                ' <snippet75>
                Protected Overrides ReadOnly Property TextRectangle() As Rectangle
                    Get
                        Return New Rectangle( _
                            Me.Bounds.Left + 2, _
                             Me.ImageRectangle.Bottom, _
                            Me.Bounds.Width - 4, _
                            Me.Bounds.Height - Me.ImageRectangle.Height - 1)
                    End Get
                End Property

                ' </snippet75>

                ' <snippet76>
                Protected Overrides Sub Initialize(ByVal activity As Activity)

                    MyBase.Initialize(activity)
                    Dim bmp As Bitmap = Resources.ToolboxImage
                    bmp.MakeTransparent()
                    Me.Image = bmp
                End Sub
                ' </snippet76>

                ' <snippet77>
                Shared ReadOnly BaseSize As New Size(64, 64)
                Protected Overrides Function OnLayoutSize(ByVal e As ActivityDesignerLayoutEventArgs) As Size
                    Return BaseSize
                End Function
                ' </snippet77>

                ' <snippet78>
                Private expandedValue As Boolean = True
                Private useBasePaintValue As Boolean = False

                Public Property UseBasePaint() As Boolean
                    Get
                        Return Me.useBasePaintValue
                    End Get

                    Set(ByVal value As Boolean)
                        Me.useBasePaintValue = value
                    End Set
                End Property

                Public Property Expanded() As Boolean
                    Get
                        Return Me.expandedValue
                    End Get
                    Set(ByVal value As Boolean)
                        Me.expandedValue = value
                    End Set
                End Property


                Protected Overrides Sub OnPaint(ByVal e As ActivityDesignerPaintEventArgs)
                    If Me.UseBasePaint = True Then
                        MyBase.OnPaint(e)
                        Return
                    End If

                    DrawCustomActivity(e)
                End Sub

                Private Sub DrawCustomActivity(ByVal e As ActivityDesignerPaintEventArgs)
                    Dim graphics As Graphics = e.Graphics

                    Dim compositeDesignerTheme As CompositeDesignerTheme = CType(e.DesignerTheme, CompositeDesignerTheme)

                    ActivityDesignerPaint.DrawRoundedRectangle(graphics, compositeDesignerTheme.BorderPen, Me.Bounds, compositeDesignerTheme.BorderWidth)

                    Dim text As String = Me.Text
                    Dim TextRectangle As Rectangle = Me.TextRectangle
                    If Not String.IsNullOrEmpty(text) And Not TextRectangle.IsEmpty Then
                        ActivityDesignerPaint.DrawText(graphics, compositeDesignerTheme.Font, text, TextRectangle, StringAlignment.Center, e.AmbientTheme.TextQuality, compositeDesignerTheme.ForegroundBrush)
                    End If

                    Dim Image As System.Drawing.Image = Me.Image
                    Dim ImageRectangle As Rectangle = Me.ImageRectangle
                    If Image IsNot Nothing And Not ImageRectangle.IsEmpty Then
                        ActivityDesignerPaint.DrawImage(graphics, Image, ImageRectangle, DesignerContentAlignment.Fill)
                    End If

                    ActivityDesignerPaint.DrawExpandButton(graphics, _
                        New Rectangle(Me.Location.X, Me.Location.Y, 10, 10), _
                        Me.Expanded, _
                        compositeDesignerTheme)
                End Sub
                ' </snippet78>
            End Class
            ' </snippet72>

            Public Class CustomCompositeActivityDesignerTheme
                Inherits CompositeDesignerTheme

                Public Sub New(ByVal theme As WorkflowTheme)
                    MyBase.new(theme)
                    Me.BorderStyle = DashStyle.Solid
                    Me.BorderColor = Color.FromArgb(0, 0, 0)
                    Me.BackColorStart = Color.FromArgb(37, 15, 242)
                    Me.BackColorEnd = Color.FromArgb(189, 184, 254)
                    Me.BackgroundStyle = LinearGradientMode.Vertical
                    Me.ForeColor = Color.Black
                End Sub
            End Class


            ' <snippet79>
            <ActivityDesignerTheme(GetType(CustomActivityDesignerTheme))> _
            Public Class CustomActivityDesigner2
                Inherits ActivityDesigner
                ' </snippet79>
            End Class
        End Class

        ' <snippet80>
        Public Class CustomActivityDesignerTheme
            Inherits ActivityDesignerTheme
            Public Sub New(ByVal theme As WorkflowTheme)
                MyBase.new(theme)

                MyBase.Initialize()
                Me.BorderStyle = DashStyle.Solid
                Me.BorderColor = Color.FromArgb(0, 0, 0)
                Me.BackColorStart = Color.FromArgb(37, 15, 242)
                Me.BackColorEnd = Color.FromArgb(189, 184, 254)
                Me.BackgroundStyle = LinearGradientMode.Vertical
                Me.ForeColor = Color.Black
            End Sub
        End Class
        ' </snippet80>


        Public Class ParallelIfActivity
            Inherits CompositeActivity
            Implements IActivityEventListener(Of ActivityExecutionStatusChangedEventArgs)
            Sub OnEvent(ByVal sender As Object, ByVal e As ActivityExecutionStatusChangedEventArgs) Implements IActivityEventListener(Of ActivityExecutionStatusChangedEventArgs).OnEvent
            End Sub
        End Class

        Public Class ParallelIfBranch
            Inherits SequenceActivity
        End Class
 

        Public Class PendingService
            Implements IPendingWork

            Sub Commit(ByVal transaction As System.Transactions.Transaction, ByVal items As ICollection) Implements IPendingWork.Commit
            End Sub

            Sub Complete(ByVal succeeded As Boolean, ByVal items As ICollection) Implements IPendingWork.Complete
            End Sub

            Function MustCommit(ByVal items As ICollection) As Boolean Implements IPendingWork.MustCommit
                Return True
            End Function
        End Class
        Public Class Toolbox
            Inherits Panel
            Implements IToolboxService
            Private provider As IServiceProvider

            Public Sub New(ByVal provider As IServiceProvider)
                Me.provider = provider
            End Sub

            Public Overrides Sub Refresh() Implements IToolboxService.Refresh

            End Sub

            Public Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String) Implements IToolboxService.AddCreator

            End Sub
            Public Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String, ByVal host As IDesignerHost) Implements IToolboxService.AddCreator

            End Sub

            Public Sub AddLinkedToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal host As IDesignerHost) Implements IToolboxService.AddLinkedToolboxItem

            End Sub

            Public Sub AddLinkedToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String, ByVal host As IDesignerHost) Implements IToolboxService.AddLinkedToolboxItem

            End Sub

            Public Overridable Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem) Implements IToolboxService.AddToolboxItem

            End Sub

            Public Overridable Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal host As IDesignerHost)

            End Sub

            Public Overridable Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String) Implements IToolboxService.AddToolboxItem

            End Sub

            Public Overridable Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String, ByVal host As IDesignerHost)

            End Sub

            Public Function DeserializeToolboxItem(ByVal dataObject As Object) As ToolboxItem Implements IToolboxService.DeserializeToolboxItem

                Return DeserializeToolboxItem(dataObject, Nothing)
            End Function
            Public Function DeserializeToolboxItem(ByVal data As Object, ByVal host As IDesignerHost) As ToolboxItem Implements IToolboxService.DeserializeToolboxItem
                Return New ToolboxItem()
            End Function
            Public Function GetToolboxItems() As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
                Return Nothing
            End Function

            Public Function GetToolboxItems(ByVal host As IDesignerHost) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
                Return Nothing
            End Function

            Public Function GetToolboxItems(ByVal category As String) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
                Return Nothing
            End Function

            Public Function GetToolboxItems(ByVal category As String, ByVal host As IDesignerHost) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
                Return Nothing
            End Function

            Public Function IsSupported(ByVal data As Object, ByVal host As IDesignerHost) As Boolean Implements IToolboxService.IsSupported
                Return True
            End Function

            Public Function IsSupported(ByVal serializedObject As Object, ByVal filterAttributes As ICollection) As Boolean Implements IToolboxService.IsSupported
                Return True
            End Function

            Public Function IsToolboxItem(ByVal dataObject As Object) As Boolean Implements IToolboxService.IsToolboxItem
                Return IsToolboxItem(dataObject, Nothing)
            End Function

            Public Function IsToolboxItem(ByVal data As Object, ByVal host As IDesignerHost) As Boolean Implements IToolboxService.IsToolboxItem
                Return False
            End Function

            Public Overridable Function GetSelectedToolboxItem() As ToolboxItem Implements IToolboxService.GetSelectedToolboxItem
                Return Nothing
            End Function

            Public Overridable Function GetSelectedToolboxItem(ByVal host As IDesignerHost) As ToolboxItem Implements IToolboxService.GetSelectedToolboxItem
                Return GetSelectedToolboxItem()
            End Function
            Public Sub RemoveCreator(ByVal format As String) Implements IToolboxService.RemoveCreator
                RemoveCreator(format, Nothing)
            End Sub

            Public Sub RemoveCreator(ByVal format As String, ByVal host As IDesignerHost) Implements IToolboxService.RemoveCreator

            End Sub

            Public Overridable Sub RemoveToolboxItem(ByVal toolComponentClass As ToolboxItem) Implements IToolboxService.RemoveToolboxItem

            End Sub


            Public Overridable Sub RemoveToolboxItem(ByVal componentClass As ToolboxItem, ByVal category As String) Implements IToolboxService.RemoveToolboxItem

            End Sub
            Public Sub SelectedToolboxItemUsed() Implements IToolboxService.SelectedToolboxItemUsed

            End Sub

            Public Function SerializeToolboxItem(ByVal toolboxItem As ToolboxItem) As Object Implements IToolboxService.SerializeToolboxItem
                Dim components As IComponent() = toolboxItem.CreateComponents()
                Dim activities(components.Length) As Activity
                components.CopyTo(activities, 0)

                Return CompositeActivityDesigner.SerializeActivitiesToDataObject(Me.provider, activities)
            End Function
            Public Overridable Function SetCursor() As Boolean Implements IToolboxService.SetCursor
                Return False
            End Function

            Public Overridable Sub SetSelectedToolboxItem(ByVal selectedToolClass As ToolboxItem) Implements IToolboxService.SetSelectedToolboxItem

            End Sub

            Public ReadOnly Property CategoryNames() As CategoryNameCollection Implements IToolboxService.CategoryNames
                Get
                    Return Nothing
                End Get
            End Property
            Public Property SelectedCategory() As String Implements IToolboxService.SelectedCategory
                Get
                    Return Nothing
                End Get
                Set(ByVal value As String)
                End Set
            End Property
        End Class

        Friend Class EventBindingService
            Implements IEventBindingService

            Public Sub New()

            End Sub

            Public Function CreateUniqueMethodName(ByVal component As IComponent, ByVal e As EventDescriptor) As String _
            Implements IEventBindingService.CreateUniqueMethodName
                Return e.DisplayName
            End Function

            Public Function GetCompatibleMethods(ByVal e As EventDescriptor) As ICollection _
            Implements IEventBindingService.GetCompatibleMethods
                Return New ArrayList()
            End Function

            Public Function GetEvent(ByVal propertyDescriptor As PropertyDescriptor) As EventDescriptor _
            Implements IEventBindingService.GetEvent
                Return IIf(TypeOf propertyDescriptor Is EventPropertyDescriptor, _
                CType(propertyDescriptor, EventPropertyDescriptor).EventDescriptor, _
                Nothing)
            End Function

            Public Function GetEventProperties(ByVal events As EventDescriptorCollection) As PropertyDescriptorCollection Implements IEventBindingService.GetEventProperties
                Return Nothing
            End Function

            Public Function GetEventProperty(ByVal e As EventDescriptor) As PropertyDescriptor _
            Implements IEventBindingService.GetEventProperty
                Return New EventPropertyDescriptor(e)
            End Function

            Public Function ShowCode() As Boolean _
            Implements IEventBindingService.ShowCode
                Return False
            End Function

            Public Function ShowCode(ByVal lineNumber As Integer) As Boolean _
            Implements IEventBindingService.ShowCode
                Return False
            End Function

            Public Function ShowCode(ByVal component As IComponent, ByVal e As EventDescriptor) As Boolean _
            Implements IEventBindingService.ShowCode
                Return False
            End Function

            Private Class EventPropertyDescriptor
                Inherits PropertyDescriptor
                Private eventDescriptorValue As EventDescriptor

                Public ReadOnly Property EventDescriptor() As EventDescriptor
                    Get

                        Return Me.eventDescriptorValue
                    End Get
                End Property

                Public Sub New(ByVal eventDescriptor As EventDescriptor)
                    MyBase.new(eventDescriptor, Nothing)
                    Me.eventDescriptorValue = eventDescriptor
                End Sub

                Public Overrides ReadOnly Property ComponentType() As Type
                    Get
                        Return Me.EventDescriptor.ComponentType
                    End Get
                End Property

                Public Overrides ReadOnly Property PropertyType() As Type
                    Get
                        Return Me.EventDescriptor.EventType
                    End Get
                End Property

                Public Overrides ReadOnly Property IsReadOnly() As Boolean
                    Get
                        Return True
                    End Get
                End Property

                Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
                    Return False
                End Function

                Public Overrides Function GetValue(ByVal component As Object) As Object

                    Return Nothing
                End Function

                Public Overrides Sub ResetValue(ByVal component As Object)

                End Sub


                Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)

                End Sub

                Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
                    Return False
                End Function

            End Class 'End EventPropertyDescriptor
        End Class ' End EventBindingService
    End Class ' End Snippets
End Namespace




