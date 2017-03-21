    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class CDesigner : System.ComponentModel.Design.ComponentDesigner 
    {
        public override void Initialize(IComponent comp) 
        {
            base.Initialize(comp);

            IMenuCommandService mcs = (IMenuCommandService)comp.Site.
                        GetService(typeof(IMenuCommandService));
            MenuCommand mc = new MenuCommand(new EventHandler(OnF1Help), StandardCommands.F1Help);
            mc.Enabled = true;
            mc.Visible = true;
            mc.Supported = true;
            mcs.AddCommand(mc);
            System.Windows.Forms.MessageBox.Show("Initialize() has been invoked.");
        }

        private void OnF1Help(object sender, EventArgs e) 
        {
            System.Windows.Forms.MessageBox.Show("F1Help has been invoked.");
        }
    }