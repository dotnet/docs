    ' This class defines the smart tags that appear on the control
    ' that is being designed.

    Friend Class DemoActionList
        Inherits System.ComponentModel.Design.DesignerActionList
        ' Cache a reference to the designer host.
        Private host As IDesignerHost = Nothing

        ' Cache a reference to the control.
        Private relatedControl As DemoControl = Nothing

        ' Cache a reference to the designer.
        Private relatedDesigner As DemoControlDesigner = Nothing

        'The constructor associates the control 
        'with the smart tag list.
        Public Sub New(ByVal component As IComponent)
            MyBase.New(component)
            Me.relatedControl = component '

            Me.host = Me.Component.Site.GetService(GetType(IDesignerHost))

            Dim dcd As IDesigner = host.GetDesigner(Me.Component)
            Me.relatedDesigner = dcd

        End Sub

        ' This method creates and populates the 
        ' DesignerActionItemCollection which is used to 
        ' display smart tag items.
        Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            ' If the Timer component has not been created, show the
            ' "Create Timer" DesignerAction item.
            '
            ' If the Timer component exists, show the timer-related
            ' options.
            If Me.relatedDesigner.createdTimer Is Nothing Then
                items.Add(New DesignerActionMethodItem(Me, "CreateTimer", "Create Timer", True))
            Else
                items.Add(New DesignerActionMethodItem(Me, "ShowEventHandlerCode", "Show Event Handler Code", True))

                items.Add(New DesignerActionMethodItem(Me, "RemoveTimer", "Remove Timer", True))
            End If

            items.Add(New DesignerActionMethodItem(Me, "GetExtenderProviders", "Get Extender Providers", True))

            items.Add(New DesignerActionMethodItem(Me, "GetDemoControlReferences", "Get DemoControl References", True))

            items.Add(New DesignerActionMethodItem(Me, "GetPathOfAssembly", "Get Path of Executing Assembly", True))

            items.Add(New DesignerActionMethodItem(Me, "GetComponentTypes", "Get ScrollableControl Types", True))

            items.Add(New DesignerActionMethodItem(Me, "GetToolboxCategories", "Get Toolbox Categories", True))

            items.Add(New DesignerActionMethodItem(Me, "SetBackColor", "Set Back Color", True))

            Return items
        End Function

        ' This method creates a Timer component using the 
        ' IDesignerHost.CreateComponent method. It also 
        ' creates an event handler for the Timer component's
        ' tick event.
        Private Sub CreateTimer()
            If (Me.host IsNot Nothing) Then
                If Me.relatedDesigner.createdTimer Is Nothing Then
                    ' Create and configure the Timer object.
                    Me.relatedDesigner.createdTimer = Me.host.CreateComponent(GetType(Timer))

                    Dim t As Timer = Me.relatedDesigner.createdTimer
                    t.Interval = 1000
                    t.Enabled = True

                    Dim eventColl As EventDescriptorCollection = TypeDescriptor.GetEvents(t, New Attribute(-1) {})

                    If (eventColl IsNot Nothing) Then
                        Dim ed As EventDescriptor = eventColl("Tick")

                        If (ed IsNot Nothing) Then
                            Dim epd As PropertyDescriptor = Me.relatedDesigner.eventBindingService.GetEventProperty(ed)

                            epd.SetValue(t, "timer_Tick")
                        End If
                    End If

                    Me.relatedDesigner.actionUiService.Refresh(Me.relatedControl)
                End If
            End If
        End Sub

        ' This method uses the IEventBindingService.ShowCode
        ' method to start the Code Editor. It places the caret
        ' in the timer_tick method created by the CreateTimer method.
        Private Sub ShowEventHandlerCode()
            Dim t As Timer = Me.relatedDesigner.createdTimer

            If (t IsNot Nothing) Then
                Dim eventColl As EventDescriptorCollection = TypeDescriptor.GetEvents(t, New Attribute(-1) {})
                If (eventColl IsNot Nothing) Then
                    Dim ed As EventDescriptor = eventColl("Tick")

                    If (ed IsNot Nothing) Then
                        Me.relatedDesigner.eventBindingService.ShowCode(t, ed)
                    End If
                End If
            End If
        End Sub

        ' This method uses the IDesignerHost.DestroyComponent method
        ' to remove the Timer component from the design environment.
        Private Sub RemoveTimer()
            If (Me.host IsNot Nothing) Then
                If (Me.relatedDesigner.createdTimer IsNot Nothing) Then
                    Me.host.DestroyComponent(Me.relatedDesigner.createdTimer)

                    Me.relatedDesigner.createdTimer = Nothing

                    Me.relatedDesigner.actionUiService.Refresh(Me.relatedControl)
                End If
            End If
        End Sub

        ' This method uses IExtenderListService.GetExtenderProviders
        ' to enumerate all the extender providers and display them 
        ' in a MessageBox.
        Private Sub GetExtenderProviders()
            If (Me.relatedDesigner.listService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim providers As IExtenderProvider() = Me.relatedDesigner.listService.GetExtenderProviders()

                Dim i As Integer
                For i = 0 To providers.Length - 1
                    Dim o As Object = providers(i)
                    sb.Append(o.ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next i

                MessageBox.Show(sb.ToString(), "Extender Providers")
            End If
        End Sub

        ' This method uses the IReferenceService.GetReferences method
        ' to enumerate all the instances of DemoControl on the 
        ' design surface.
        Private Sub GetDemoControlReferences()
            If (Me.relatedDesigner.referenceService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim refs As Object() = Me.relatedDesigner.referenceService.GetReferences(GetType(DemoControl))

                Dim i As Integer
                For i = 0 To refs.Length - 1
                    sb.Append(refs(i).ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next i

                MessageBox.Show(sb.ToString(), "DemoControl References")
            End If
        End Sub

        ' This method uses the ITypeResolutionService.GetPathOfAssembly
        ' method to display the path of the executing assembly.
        Private Sub GetPathOfAssembly()
            If (Me.relatedDesigner.typeResService IsNot Nothing) Then
                Dim name As System.Reflection.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName()

                MessageBox.Show(Me.relatedDesigner.typeResService.GetPathOfAssembly(name), "Path of executing assembly")
            End If
        End Sub


        ' This method uses the IComponentDiscoveryService.GetComponentTypes 
        ' method to find all the types that derive from 
        ' ScrollableControl.
        Private Sub GetComponentTypes()
            If (Me.relatedDesigner.componentDiscoveryService IsNot Nothing) Then
                Dim components As ICollection = Me.relatedDesigner.componentDiscoveryService.GetComponentTypes(host, GetType(ScrollableControl))

                If (components IsNot Nothing) Then
                    If components.Count > 0 Then
                        Dim sb As New StringBuilder()

                        Dim e As IEnumerator = components.GetEnumerator()

                        While e.MoveNext()
                            sb.Append(e.Current.ToString())
                            sb.Append(ControlChars.Cr + ControlChars.Lf)
                        End While

                        MessageBox.Show(sb.ToString(), "Controls derived from ScrollableControl")
                    End If
                End If
            End If
        End Sub


        ' This method uses the IToolboxService.CategoryNames
        ' method to enumerate all the categories that appear
        ' in the Toolbox.
        Private Sub GetToolboxCategories()
            If (Me.relatedDesigner.toolboxService IsNot Nothing) Then
                Dim sb As New StringBuilder()

                Dim names As CategoryNameCollection = Me.relatedDesigner.toolboxService.CategoryNames

                Dim name As String
                For Each name In names
                    sb.Append(name.ToString())
                    sb.Append(ControlChars.Cr + ControlChars.Lf)
                Next name

                MessageBox.Show(sb.ToString(), "Toolbox Categories")
            End If
        End Sub


        ' This method sets the shadowed BackColor property on the 
        ' designer. This is the value that is serialized by the 
        ' design environment.
        Private Sub SetBackColor()
            Dim d As New ColorDialog()
            If d.ShowDialog() = DialogResult.OK Then
                Me.relatedDesigner.BackColor = d.Color
            End If
        End Sub
    End Class