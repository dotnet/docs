        public StackView()
        {
            this.InitializeComponent();

            // Assign icons to ToolStripButton controls.
            this.InitializeImages();

            // Set up renderers.
            this.stackStrip.Renderer = new StackRenderer();
        }