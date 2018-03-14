
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation

Class ConditionSnips
#Region "Conditions"


    ' <Snippet120>
    Public Sub ConditionExamples(ByVal elementMainWindow As AutomationElement)
        If elementMainWindow Is Nothing Then
            Throw New ArgumentException()
        End If

        ' Use AndCondition to retrieve elements that match both of two conditions.
        Dim conditionEnabledButtons As Condition = _
            New AndCondition(New PropertyCondition(AutomationElement.IsEnabledProperty, True), _
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button))
        Dim enabledButtons As AutomationElementCollection = _
            elementMainWindow.FindAll(TreeScope.Subtree, conditionEnabledButtons)
        Console.WriteLine(vbLf + "Enabled buttons:")
        Dim autoElement As AutomationElement
        For Each autoElement In enabledButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use OrCondition to retrieve elements that match either of two conditions.
        Dim conditionButtons As Condition = New OrCondition(New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton))
        Dim elementCollectionButtons As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, conditionButtons)
        Console.WriteLine(vbLf + "Buttons and radio buttons:")
        For Each autoElement In elementCollectionButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use NotCondition to retrieve elements that do not match the previous condition.
        Dim conditionNotButtons As Condition = New NotCondition(conditionButtons)
        Dim elementCollectionNotButtons As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, conditionNotButtons)
        Console.WriteLine(vbLf + "Other control types:")
        For Each autoElement In elementCollectionNotButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use the static TrueCondition to retrieve all elements.
        Dim elementCollectionAll As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Condition.TrueCondition)
        Console.WriteLine(vbLf + "All control types:")
        For Each autoElement In elementCollectionAll
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use the static ContentViewCondition to retrieve all content elements.
        Dim elementCollectionContent As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Automation.ContentViewCondition)
        Console.WriteLine(vbLf + "All content elements:")
        For Each autoElement In elementCollectionContent
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use the static ControlViewCondition to retrieve all control elements.
        Dim elementCollectionControl As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Automation.ControlViewCondition)
        Console.WriteLine(vbLf + "All control elements:")
        For Each autoElement In elementCollectionControl
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

    End Sub 'ConditionExamples

    ' </Snippet120>
    ' <Snippet178> 
    ''' <summary>
    ''' Examples of using predefined conditions to find elements.
    ''' </summary>
    ''' <param name="elementMainWindow">The element for the target window.</param>
    Public Sub StaticConditionExamples(ByVal elementMainWindow As AutomationElement)
        If elementMainWindow Is Nothing Then
            Throw New ArgumentException()
        End If

        ' Use TrueCondition to retrieve all elements.
        Dim elementCollectionAll As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Condition.TrueCondition)
        Console.WriteLine(vbLf + "All control types:")
        Dim autoElement As AutomationElement
        For Each autoElement In elementCollectionAll
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use ContentViewCondition to retrieve all content elements.
        Dim elementCollectionContent As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Automation.ContentViewCondition)
        Console.WriteLine(vbLf + "All content elements:")
        For Each autoElement In elementCollectionContent
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Use ControlViewCondition to retrieve all control elements.
        Dim elementCollectionControl As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, Automation.ControlViewCondition)
        Console.WriteLine(vbLf & "All control elements:")
        For Each autoElement In elementCollectionControl
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

    End Sub 'StaticConditionExamples

    ' </Snippet178>        
    ' <Snippet176>
    ''' <summary>
    ''' Uses AndCondition to retrieve elements that match both of two conditions.
    ''' </summary>
    ''' <param name="elementMainWindow">An application window element.</param>
    Public Sub AndConditionExample(ByVal elementMainWindow As AutomationElement)
        If elementMainWindow Is Nothing Then
            Throw New ArgumentException()
        End If

        Dim conditionEnabledButtons As New AndCondition(New PropertyCondition(AutomationElement.IsEnabledProperty, True), New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button))
        Dim enabledButtons As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, conditionEnabledButtons)
        Console.WriteLine("Enabled buttons:")
        Dim autoElement As AutomationElement
        For Each autoElement In enabledButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Example of getting the conditions from the AndCondition.
        Dim conditions As Condition() = conditionEnabledButtons.GetConditions()
        Console.WriteLine("AndCondition has " & conditions.GetLength(0) & " subconditions.")

    End Sub 'AndConditionExample

    ' </Snippet176>
    ' <Snippet175>
    ''' <summary>
    ''' Uses OrCondition to retrieve elements that match either of two conditions.
    ''' </summary>
    ''' <param name="elementMainWindow">An application window element.</param>
    Public Sub OrConditionExample(ByVal elementMainWindow As AutomationElement)
        If elementMainWindow Is Nothing Then
            Throw New ArgumentException()
        End If

        Dim conditionButtons As New OrCondition(New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton))
        Dim elementCollectionButtons As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, conditionButtons)
        Console.WriteLine("Buttons and radio buttons:")
        Dim autoElement As AutomationElement
        For Each autoElement In elementCollectionButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement

        ' Example of getting the conditions from the OrCondition.
        Dim conditions As Condition() = conditionButtons.GetConditions()
        Console.WriteLine("OrCondition has " & conditions.GetLength(0) & " subconditions.")

    End Sub 'OrConditionExample

    ' </Snippet175>

    ' <Snippet177> 
    ''' <summary>
    ''' Uses NotCondition to retrieve elements that do not match specified conditions.
    ''' </summary>
    ''' <param name="elementMainWindow">An application window element.</param>
    Public Sub NotConditionExample(ByVal elementMainWindow As AutomationElement)
        If elementMainWindow Is Nothing Then
            Throw New ArgumentException()
        End If

        ' Set up a condition that finds all buttons and radio buttons.
        Dim conditionButtons As New OrCondition(New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.RadioButton))

        ' Use NotCondition to retrieve elements that are not buttons or radio buttons.
        Dim conditionNotButtons As Condition = New NotCondition(conditionButtons)
        Dim elementCollectionNotButtons As AutomationElementCollection = elementMainWindow.FindAll(TreeScope.Subtree, conditionNotButtons)
        Console.WriteLine("Elements other than buttons:")
        Dim autoElement As AutomationElement
        For Each autoElement In elementCollectionNotButtons
            Console.WriteLine(autoElement.Current.Name)
        Next autoElement
    End Sub 'NotConditionExample
    ' </Snippet177>

#End Region
End Class 'ConditionSnips 
'
