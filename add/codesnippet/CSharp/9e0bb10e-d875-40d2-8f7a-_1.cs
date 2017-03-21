    // This class defines the smart tags that appear on the control
    // that is being designed.
    internal class DemoActionList :
          System.ComponentModel.Design.DesignerActionList
    {
        // Cache a reference to the designer host.
        private IDesignerHost host = null;

        // Cache a reference to the control.
        private DemoControl relatedControl = null;

        // Cache a reference to the designer.
        private DemoControlDesigner relatedDesigner = null;

        //The constructor associates the control 
        //with the smart tag list.
        public DemoActionList(IComponent component)
            : base(component)
        {
            this.relatedControl = component as DemoControl;

            this.host =
                this.Component.Site.GetService(typeof(IDesignerHost))
                as IDesignerHost;

            IDesigner dcd = host.GetDesigner(this.Component);
            this.relatedDesigner = dcd as DemoControlDesigner;
        }

        // This method creates and populates the 
        // DesignerActionItemCollection which is used to 
        // display smart tag items.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items =
                new DesignerActionItemCollection();

            // If the Timer component has not been created, show the
            // "Create Timer" DesignerAction item.
            //
            // If the Timer component exists, show the timer-related
            // options.

            if (this.relatedDesigner.createdTimer == null)
            {
                items.Add(new DesignerActionMethodItem(
                    this,
                    "CreateTimer",
                    "Create Timer",
                    true));
            }
            else
            {   
                items.Add(new DesignerActionMethodItem(
                    this,
                    "ShowEventHandlerCode",
                    "Show Event Handler Code",
                    true));

                items.Add(new DesignerActionMethodItem(
                    this,
                    "RemoveTimer",
                    "Remove Timer",
                    true));
            }

            items.Add(new DesignerActionMethodItem(
               this,
               "GetExtenderProviders",
               "Get Extender Providers",
               true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetDemoControlReferences",
              "Get DemoControl References",
              true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetPathOfAssembly",
              "Get Path of Executing Assembly",
              true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetComponentTypes",
              "Get ScrollableControl Types",
              true));

            items.Add(new DesignerActionMethodItem(
                this,
                "GetToolboxCategories",
                "Get Toolbox Categories",
                true));

            items.Add(new DesignerActionMethodItem(
                this,
                "SetBackColor",
                "Set Back Color",
                true));

            return items;
        }

        // This method creates a Timer component using the 
        // IDesignerHost.CreateComponent method. It also 
        // creates an event handler for the Timer component's
        // tick event.
        private void CreateTimer()
        {
            if (this.host != null)
            {
                if (this.relatedDesigner.createdTimer == null)
                {
                    // Create and configure the Timer object.
                    this.relatedDesigner.createdTimer =
                        this.host.CreateComponent(typeof(Timer)) as Timer;
                    Timer t = this.relatedDesigner.createdTimer;
                    t.Interval = 1000;
                    t.Enabled = true;

                    EventDescriptorCollection eventColl =
                        TypeDescriptor.GetEvents(t, new Attribute[0]);

                    if (eventColl != null)
                    {
                        EventDescriptor ed =
                            eventColl["Tick"] as EventDescriptor;
                        if (ed != null)
                        {
                            PropertyDescriptor epd =
                                this.relatedDesigner.eventBindingService.GetEventProperty(ed);

                            epd.SetValue(t, "timer_Tick");
                        }
                    }

					this.relatedDesigner.actionUiService.Refresh(this.relatedControl);
                }
            }
        }

        // This method uses the IEventBindingService.ShowCode
        // method to start the Code Editor. It places the caret
        // in the timer_tick method created by the CreateTimer method.
        private void ShowEventHandlerCode()
        {
            Timer t = this.relatedDesigner.createdTimer;

            if (t != null)
            {
                EventDescriptorCollection eventColl =
                    TypeDescriptor.GetEvents(t, new Attribute[0]);
                if (eventColl != null)
                {
                    EventDescriptor ed =
                        eventColl["Tick"] as EventDescriptor;
                    if (ed != null)
                    {
                        this.relatedDesigner.eventBindingService.ShowCode(t, ed);
                    }
                }
            }
        }

        // This method uses the IDesignerHost.DestroyComponent method
        // to remove the Timer component from the design environment.
        private void RemoveTimer()
        {
            if (this.host != null)
            {
                if (this.relatedDesigner.createdTimer != null)
                {
                    this.host.DestroyComponent(
                        this.relatedDesigner.createdTimer);

                    this.relatedDesigner.createdTimer = null;

					this.relatedDesigner.actionUiService.Refresh(
                        this.relatedControl);
                }
            }
        }

        // This method uses IExtenderListService.GetExtenderProviders
        // to enumerate all the extender providers and display them 
        // in a MessageBox.
        private void GetExtenderProviders()
        {
            if (this.relatedDesigner.listService != null)
            {
                StringBuilder sb = new StringBuilder();

                IExtenderProvider[] providers =
                    this.relatedDesigner.listService.GetExtenderProviders();

                for (int i = 0; i < providers.Length; i++)
                {
                    sb.Append(providers[i].ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(
                    sb.ToString(), 
                    "Extender Providers");
            }
        }

        // This method uses the IReferenceService.GetReferences method
        // to enumerate all the instances of DemoControl on the 
        // design surface.
        private void GetDemoControlReferences()
        {
            if (this.relatedDesigner.referenceService != null)
            {
                StringBuilder sb = new StringBuilder();

                object[] refs = this.relatedDesigner.referenceService.GetReferences(typeof(DemoControl));

                for (int i = 0; i < refs.Length; i++)
                {
                    sb.Append(refs[i].ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(
                    sb.ToString(), 
                    "DemoControl References");
            }
        }


        // This method uses the ITypeResolutionService.GetPathOfAssembly
        // method to display the path of the executing assembly.
        private void GetPathOfAssembly()
        {
            if (this.relatedDesigner.typeResService != null)
            {
                System.Reflection.AssemblyName name =
                    System.Reflection.Assembly.GetExecutingAssembly().GetName();

                MessageBox.Show(
                    this.relatedDesigner.typeResService.GetPathOfAssembly(name),
                    "Path of executing assembly");
            }
        }

        // This method uses the IComponentDiscoveryService.GetComponentTypes 
        // method to find all the types that derive from 
        // ScrollableControl.
        private void GetComponentTypes()
        {
            if (this.relatedDesigner.componentDiscoveryService != null)
            {
                ICollection components = this.relatedDesigner.componentDiscoveryService.GetComponentTypes(host, typeof(ScrollableControl));

                if (components != null)
                {
                    if (components.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        IEnumerator e = components.GetEnumerator();

                        while (e.MoveNext())
                        {
                            sb.Append(e.Current.ToString());
                            sb.Append("\r\n");

                        }

                        MessageBox.Show(
                            sb.ToString(), 
                            "Controls derived from ScrollableControl");
                    }
                }
            }
        }

        // This method uses the IToolboxService.CategoryNames
        // method to enumerate all the categories that appear
        // in the Toolbox.
        private void GetToolboxCategories()
        {
            if (this.relatedDesigner.toolboxService != null)
            {
                StringBuilder sb = new StringBuilder();

                CategoryNameCollection names = this.relatedDesigner.toolboxService.CategoryNames;

                foreach (string name in names)
                {
                    sb.Append(name.ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(sb.ToString(), "Toolbox Categories");
            }
        }

        // This method sets the shadowed BackColor property on the 
        // designer. This is the value that is serialized by the 
        // design environment.
        private void SetBackColor()
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                this.relatedDesigner.BackColor = d.Color;
            }
        }
    }