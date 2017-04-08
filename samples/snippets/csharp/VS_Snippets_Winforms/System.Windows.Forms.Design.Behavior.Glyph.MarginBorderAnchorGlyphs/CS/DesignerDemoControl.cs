// <snippet1>
// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
// </snippet2>

public class Form1 : Form
{
    private DemoControl demoControl1;
    private DemoControl demoControl2;

    private System.ComponentModel.IContainer components = null;

    public Form1()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    private void InitializeComponent()
    {
        this.demoControl2 = new DemoControl();
        this.demoControl1 = new DemoControl();
        this.SuspendLayout();
        // 
        // demoControl2
        // 
        this.demoControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.demoControl2.BackColor = System.Drawing.Color.LightBlue;
        this.demoControl2.Location = new System.Drawing.Point(40, 40);
        this.demoControl2.Margin = new System.Windows.Forms.Padding(20);
        this.demoControl2.Name = "demoControl2";
        this.demoControl2.Padding = new System.Windows.Forms.Padding(20);
        this.demoControl2.Size = new System.Drawing.Size(284, 177);
        this.demoControl2.TabIndex = 1;
        // 
        // demoControl1
        // 
        this.demoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
        this.demoControl1.BackColor = System.Drawing.Color.LightBlue;
        this.demoControl1.Location = new System.Drawing.Point(354, 21);
        this.demoControl1.Margin = new System.Windows.Forms.Padding(10);
        this.demoControl1.Name = "demoControl1";
        this.demoControl1.Padding = new System.Windows.Forms.Padding(10);
        this.demoControl1.Size = new System.Drawing.Size(184, 207);
        this.demoControl1.TabIndex = 0;
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(594, 352);
        this.Controls.Add(this.demoControl2);
        this.Controls.Add(this.demoControl1);
        this.Name = "Form1";
        this.Padding = new System.Windows.Forms.Padding(20);
        this.Text = "a";
        this.ResumeLayout(false);

    } 
}

// This control demonstrates the use of a custom designer.
[DesignerAttribute(typeof(DemoControlDesigner))]
public class DemoControl : UserControl
{   
    private System.ComponentModel.IContainer components = null;

    public DemoControl()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        // 
        // DemoControl
        // 
        this.Name = "DemoControl";

    }
}

// This class demonstrates how to build a custom designer.
// When an instance of the associated control type is created
// in a design environment like Visual Studio, this designer
// provides custom design-time behavior.
//
// When you drop an instance of DemoControl onto a form,
// this designer creates two adorner windows: one is used
// for glyphs that represent the Margin and Padding properties
// of the control, and the other is used for glyphs that
// represent the Anchor property.
//
// The AnchorGlyph type defines an AnchorBehavior type that
// allows you to change the value of the Anchor property 
// by double-clicking on an AnchorGlyph.
//
// This designer also offers a smart tag for changing the 
// Anchor property.
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
public class DemoControlDesigner : ControlDesigner
{
    // This adorner holds the glyphs that represent the Anchor property.
    private Adorner anchorAdorner = null;

    // This adorner holds the glyphs that represent the Margin and
    // Padding properties.
    private Adorner marginAndPaddingAdorner = null;

    // This defines the size of the anchor glyphs.
    private const int glyphSize = 6;

    // This defines the size of the hit bounds for an AnchorGlyph.
    private const int hitBoundSize = glyphSize + 4;

    // References to designer services, for convenience.
    private IComponentChangeService changeService = null;
    private ISelectionService selectionService = null;
    private BehaviorService behaviorSvc = null;

    // This is the collection of DesignerActionLists that
    // defines the smart tags offered on the control. 
    private DesignerActionListCollection actionLists = null;
    
    public DemoControlDesigner()
    {   
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (this.behaviorSvc != null)
            {   
                // Remove the adorners added by this designer from
                // the BehaviorService.Adorners collection.
                this.behaviorSvc.Adorners.Remove(this.marginAndPaddingAdorner);
                this.behaviorSvc.Adorners.Remove(this.anchorAdorner);
            }
        }

        base.Dispose(disposing);
    }

    // <snippet7>
    // This method is where the designer initializes its state when
    // it is created.
    public override void Initialize(IComponent component)
    {
        base.Initialize(component);

        // Connect to various designer services.
        InitializeServices();

        // Initialize adorners.
        this.InitializeMarginAndPaddingAdorner();
        this.InitializeAnchorAdorner();

    }
    // </snippet7>

    // <snippet3>
    // This demonstrates changing the appearance of a control while
    // it is being designed. In this case, the BackColor property is
    // set to LightBlue. 
    
    public override void InitializeNewComponent(IDictionary defaultValues)
    {
        base.InitializeNewComponent(defaultValues);

        PropertyDescriptor colorPropDesc = 
            TypeDescriptor.GetProperties(Component)["BackColor"];

        if (colorPropDesc != null &&
            colorPropDesc.PropertyType == typeof(Color) &&
            !colorPropDesc.IsReadOnly &&
            colorPropDesc.IsBrowsable)
        {
            colorPropDesc.SetValue(Component, Color.LightBlue);
        }
    }
    // </snippet3>

    // <snippet8>
    // This utility method creates an adorner for the anchor glyphs.
    // It then creates four AnchorGlyph objects and adds them to 
    // the adorner's Glyphs collection.
    private void InitializeAnchorAdorner()
    {
        this.anchorAdorner = new Adorner();
        this.behaviorSvc.Adorners.Add(this.anchorAdorner);

        this.anchorAdorner.Glyphs.Add(new AnchorGlyph(
            AnchorStyles.Left,
            this.behaviorSvc,
            this.changeService,
            this.selectionService,
            this,
            this.anchorAdorner)
            );

        this.anchorAdorner.Glyphs.Add(new AnchorGlyph(
            AnchorStyles.Top,
            this.behaviorSvc,
            this.changeService,
            this.selectionService,
            this,
            this.anchorAdorner)
            );

        this.anchorAdorner.Glyphs.Add(new AnchorGlyph(
            AnchorStyles.Right,
            this.behaviorSvc,
            this.changeService,
            this.selectionService,
            this,
            this.anchorAdorner)
            );

        this.anchorAdorner.Glyphs.Add(new AnchorGlyph(
            AnchorStyles.Bottom,
            this.behaviorSvc,
            this.changeService,
            this.selectionService,
            this,
            this.anchorAdorner)
            );
    }
    // </snippet8>
        
    // <snippet9>
    // This utility method creates an adorner for the margin and 
    // padding glyphs. It then creates a MarginAndPaddingGlyph and 
    // adds it to the adorner's Glyphs collection.
    private void InitializeMarginAndPaddingAdorner()
    {
        this.marginAndPaddingAdorner = new Adorner();
        this.behaviorSvc.Adorners.Add(this.marginAndPaddingAdorner);

        this.marginAndPaddingAdorner.Glyphs.Add(new MarginAndPaddingGlyph(
            this.behaviorSvc,
            this.changeService,
            this.selectionService,
            this,
            this.marginAndPaddingAdorner));
    }
    // </snippet9>

    // This utility method connects the designer to various services.
    // These references are cached for convenience.
    private void InitializeServices()
    {
        // Acquire a reference to IComponentChangeService.
        this.changeService = 
            GetService(typeof(IComponentChangeService)) 
            as IComponentChangeService;

        // Acquire a reference to ISelectionService.
        this.selectionService =
            GetService(typeof(ISelectionService))
            as ISelectionService;

        // Acquire a reference to BehaviorService.
        this.behaviorSvc =
            GetService(typeof(BehaviorService))
            as BehaviorService;
    }

    // This method creates the DesignerActionList on demand, causing
    // smart tags to appear on the control being designed.
    public override DesignerActionListCollection ActionLists
    {
        get
        {
            if (null == actionLists)
            {
                actionLists = new DesignerActionListCollection();
                actionLists.Add(
                    new AnchorActionList(this.Component));
            }

            return actionLists;
        }
    }

    // This class defines the smart tags that appear on the control
    // being designed. In this case, the Anchor property appears
    // on the smart tag and its value can be changed through a 
    // UI Type Editor created automatically by the 
    // DesignerActionService.
    public class AnchorActionList :
          System.ComponentModel.Design.DesignerActionList
    {   
        // Cache a reference to the control.
        private DemoControl relatedControl;
        
        //The constructor associates the control 
        //with the smart tag list.
        public AnchorActionList(IComponent component): base(component)
        {
            this.relatedControl = component as DemoControl;
        }

        // Properties that are targets of DesignerActionPropertyItem entries.
        public AnchorStyles Anchor
        {
            get
            {
                return this.relatedControl.Anchor;
            }
            set
            {
                PropertyDescriptor pdAnchor = TypeDescriptor.GetProperties(this.relatedControl)["Anchor"];
                pdAnchor.SetValue(this.relatedControl, value);
            }
        }

        // This method creates and populates the 
        // DesignerActionItemCollection which is used to 
        // display smart tag items.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = 
                new DesignerActionItemCollection();

            // Add a descriptive header.
            items.Add(new DesignerActionHeaderItem("Anchor Styles"));

            // Add a DesignerActionPropertyItem for the Anchor
            // property. This will be displayed in a panel using
            // the AnchorStyles UI Type Editor.
            items.Add(new DesignerActionPropertyItem(
                "Anchor", 
                "Anchor Style") );

            return items;
        }
    }
 

    #region Glyph Implementations

    // <snippet14>
    // This class implements a MarginAndPaddingGlyph, which draws 
    // borders highlighting the value of the control's Margin 
    // property and the value of the control's Padding property.
    //
    // This glyph has no mouse or keyboard interaction, so its
    // related behavior class, MarginAndPaddingBehavior, has no
    // implementation.

    public class MarginAndPaddingGlyph : Glyph
    {
        private BehaviorService behaviorService = null;
        private IComponentChangeService changeService = null;
        private ISelectionService selectionService = null;
        private IDesigner relatedDesigner = null;
        private Adorner marginAndPaddingAdorner = null;
        private Control relatedControl = null;

        public MarginAndPaddingGlyph(
            BehaviorService behaviorService,
            IComponentChangeService changeService,
            ISelectionService selectionService,
            IDesigner relatedDesigner,
            Adorner marginAndPaddingAdorner)
            : base(new MarginAndPaddingBehavior())
        {
            this.behaviorService = behaviorService;
            this.changeService = changeService;
            this.selectionService = selectionService;
            this.relatedDesigner = relatedDesigner;
            this.marginAndPaddingAdorner = marginAndPaddingAdorner;

            this.relatedControl = 
                this.relatedDesigner.Component as Control;

            this.changeService.ComponentChanged += new ComponentChangedEventHandler(changeService_ComponentChanged);
        }

        // <snippet13>
        void changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (object.ReferenceEquals(
                e.Component, 
                this.relatedControl))
            {
                if (e.Member.Name == "Margin" ||
                    e.Member.Name == "Padding" )
                {
                    this.marginAndPaddingAdorner.Invalidate();
                }
            }
        }
        // </snippet13>

        // This glyph has no mouse or keyboard interaction, so 
        // GetHitTest can return null.
        public override Cursor GetHitTest(Point p)
        {
            return null;
        }

        // This method renders the glyph as a simple focus rectangle.
        public override void Paint(PaintEventArgs e)
        {   
            ControlPaint.DrawFocusRectangle(
                    e.Graphics,
                    this.Bounds);

            ControlPaint.DrawFocusRectangle(
                    e.Graphics,
                    this.PaddingBounds);
        }

        // This glyph's Bounds property is a Rectangle defined by 
        // the value of the control's Margin property.
        public override Rectangle Bounds
        {
            get
            {
                Control c = this.relatedControl;
                Rectangle controlRect = 
                    this.behaviorService.ControlRectInAdornerWindow(this.relatedControl);

                Rectangle boundsVal = new Rectangle(
                    controlRect.Left - c.Margin.Left,
                    controlRect.Top - c.Margin.Top,
                    controlRect.Width + c.Margin.Right*2,
                    controlRect.Height + c.Margin.Bottom*2);

                return boundsVal;
            }
        }

        // The PaddingBounds property is a Rectangle defined by 
        // the value of the control's Padding property.
        public Rectangle PaddingBounds
        {
            get
            {
                Control c = this.relatedControl;
                Rectangle controlRect =
                    this.behaviorService.ControlRectInAdornerWindow(this.relatedControl);

                Rectangle boundsVal = new Rectangle(
                    controlRect.Left + c.Padding.Left,
                    controlRect.Top + c.Padding.Top,
                    controlRect.Width - c.Padding.Right * 2,
                    controlRect.Height - c.Padding.Bottom * 2);

                return boundsVal;
            }
        }

        // There are no keyboard or mouse behaviors associated with 
        // this glyph, but you could add them to this class.
        internal class MarginAndPaddingBehavior : Behavior
        {

        }
    }
    // </snippet14>

    // <snippet5>
    // This class implements an AnchorGlyph, which draws grab handles
    // that represent the value of the control's Anchor property.
    //
    // This glyph has mouse and keyboard interactions, which are
    // handled by the related behavior class, AnchorBehavior.
    // Double-clicking on an AnchorGlyph causes its value to be 
    // toggled between enabled and disable states. 
    
    public class AnchorGlyph : Glyph
    {
        // This defines the bounds of the anchor glyph.
        protected Rectangle boundsValue;

        // This defines the bounds used for hit testing.
        // These bounds are typically different than the bounds 
        // of the glyph itself.
        protected Rectangle hitBoundsValue;

        // This is the cursor returned if hit test is positive.
        protected Cursor hitTestCursor = Cursors.Hand;

        // Cache references to services that will be needed.
        private BehaviorService behaviorService = null;
        private IComponentChangeService changeService = null;
        private ISelectionService selectionService = null;

        // Keep a reference to the designer for convenience.
        private IDesigner relatedDesigner = null;

        // Keep a reference to the adorner for convenience.
        private Adorner anchorAdorner = null;

        // Keep a reference to the control being designed.
        private Control relatedControl = null;

        // This defines the AnchorStyle which this glyph represents.
        private AnchorStyles anchorStyle;

        // <snippet4>
        public AnchorGlyph(
            AnchorStyles anchorStyle,
            BehaviorService behaviorService,
            IComponentChangeService changeService,
            ISelectionService selectionService,
            IDesigner relatedDesigner,
            Adorner anchorAdorner)
            : base(new AnchorBehavior(relatedDesigner))
        {   
            // Cache references for convenience.
            this.anchorStyle = anchorStyle;
            this.behaviorService = behaviorService;
            this.changeService = changeService;
            this.selectionService = selectionService;
            this.relatedDesigner = relatedDesigner;
            this.anchorAdorner = anchorAdorner;

            // Cache a reference to the control being designed.
            this.relatedControl = 
                this.relatedDesigner.Component as Control;

            // Hook the SelectionChanged event. 
            this.selectionService.SelectionChanged += 
                new EventHandler(selectionService_SelectionChanged);

            // Hook the ComponentChanged event so the anchor glyphs
            // can correctly track the control's bounds.
            this.changeService.ComponentChanged += 
                new ComponentChangedEventHandler(changeService_ComponentChanged);
        }
        // </snippet4>

        #region Overrides

        public override Rectangle Bounds
        {
            get
            {
                return this.boundsValue;
            }
        }

        // This method renders the AnchorGlyph as a filled rectangle
        // if the glyph is enabled, or as an open rectangle if the
        // glyph is disabled.
        public override void Paint(PaintEventArgs e)
        {
            if (this.IsEnabled)
            {
                using (Brush b = new SolidBrush(Color.Tomato))
                {
                    e.Graphics.FillRectangle(b, this.Bounds);
                }
            }
            else
            {
                using (Pen p = new Pen(Color.Tomato))
                {
                    e.Graphics.DrawRectangle(p, this.Bounds);
                }
            }
        }

        // An AnchorGlyph has keyboard and mouse interaction, so it's
        // important to return a cursor when the mouse is located in 
        // the glyph's hit region. When this occurs, the 
        // AnchorBehavior becomes active.

        public override Cursor GetHitTest(Point p)
        {
            if (hitBoundsValue.Contains(p))
            {
                return hitTestCursor;
            }

            return null;
        }

        #endregion 

        #region Event Handlers

        // <snippet12>
        // The AnchorGlyph objects should mimic the resize glyphs;
        // they should only be visible when the control is the 
        // primary selection. The adorner is enabled when the 
        // control is the primary selection and disabled when 
        // it is not.

        void selectionService_SelectionChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(
                this.selectionService.PrimarySelection,
                this.relatedControl))
            {
                this.ComputeBounds();
                this.anchorAdorner.Enabled = true;
            }
            else
            {
                this.anchorAdorner.Enabled = false;
            }
        }
        // </snippet12>

        // If any of several properties change, the bounds of the 
        // AnchorGlyph must be computed again.
        void changeService_ComponentChanged(
            object sender, 
            ComponentChangedEventArgs e)
        {
            if (object.ReferenceEquals(
                e.Component,
                this.relatedControl))
            {
                if (e.Member.Name == "Anchor" ||
                    e.Member.Name == "Size" ||
                    e.Member.Name == "Height" ||
                    e.Member.Name == "Width" ||
                    e.Member.Name == "Location")
                {
                    // Compute the bounds of this glyph.
                    this.ComputeBounds();

                    // Tell the adorner to repaint itself.
                    this.anchorAdorner.Invalidate();
                }
            }
        }

        #endregion

        #region Implementation

        // This utility method computes the position and size of 
        // the AnchorGlyph in the Adorner window's coordinates.
        // It also computes the hit test bounds, which are
        // slightly larger than the glyph's bounds.
        private void ComputeBounds()
        {
            Rectangle translatedBounds = new Rectangle(
                this.behaviorService.ControlToAdornerWindow(this.relatedControl),
                this.relatedControl.Size);

            if ((this.anchorStyle & AnchorStyles.Top) == AnchorStyles.Top)
            {
                this.boundsValue = new Rectangle(
                    translatedBounds.X + (translatedBounds.Width / 2) - (glyphSize / 2),
                    translatedBounds.Y + glyphSize,
                    glyphSize,
                    glyphSize);
            }
            if ((this.anchorStyle & AnchorStyles.Bottom) == AnchorStyles.Bottom)
            {
                this.boundsValue = new Rectangle(
                    translatedBounds.X + (translatedBounds.Width / 2) - (glyphSize / 2),
                    translatedBounds.Bottom - 2*glyphSize,
                    glyphSize,
                    glyphSize);
            }
            if ((this.anchorStyle & AnchorStyles.Left) == AnchorStyles.Left)
            {
                this.boundsValue = new Rectangle(
                    translatedBounds.X + glyphSize,
                    translatedBounds.Y + (translatedBounds.Height / 2) - (glyphSize / 2),
                    glyphSize,
                    glyphSize);
            }
            if ((this.anchorStyle & AnchorStyles.Right) == AnchorStyles.Right)
            {
                this.boundsValue = new Rectangle(
                    translatedBounds.Right - 2*glyphSize,
                    translatedBounds.Y + (translatedBounds.Height / 2) - (glyphSize / 2),
                    glyphSize,
                    glyphSize);
            }

            this.hitBoundsValue = new Rectangle(
                this.Bounds.Left - hitBoundSize / 2,
                this.Bounds.Top - hitBoundSize / 2,
                hitBoundSize,
                hitBoundSize );
        }

        // This utility property determines if the AnchorGlyph is 
        // enabled, according to the value specified by the 
        // control's Anchor property.
        private bool IsEnabled
        {
            get
            {
                return 
                    ((this.anchorStyle & this.relatedControl.Anchor) == 
                    this.anchorStyle);
            }
        }

        #endregion 

        // </snippet5>



        #region Behavior Implementation

        // <snippet6>

        // This Behavior specifies mouse and keyboard handling when
        // an AnchorGlyph is active. This happens when 
        // AnchorGlyph.GetHitTest returns a non-null value.
        internal class AnchorBehavior : Behavior
        {
            private IDesigner relatedDesigner = null;
            private Control relatedControl = null;

            internal AnchorBehavior(IDesigner relatedDesigner)
            {
                this.relatedDesigner = relatedDesigner;
                this.relatedControl = relatedDesigner.Component as Control;
            }

            // <snippet10>
            // When you double-click on an AnchorGlyph, the value of 
            // the control's Anchor property is toggled.
            //
            // Note that the value of the Anchor property is not set
            // by direct assignment. Instead, the 
            // PropertyDescriptor.SetValue method is used. This 
            // enables notification of the design environment, so 
            // related events can be raised, for example, the
            // IComponentChangeService.ComponentChanged event.

            public override bool OnMouseDoubleClick(
                Glyph g, 
                MouseButtons button, 
                Point mouseLoc)
            {
                base.OnMouseDoubleClick(g, button, mouseLoc);

                if (button == MouseButtons.Left)
                {
                    AnchorGlyph ag = g as AnchorGlyph;
                    PropertyDescriptor pdAnchor = 
                        TypeDescriptor.GetProperties(ag.relatedControl)["Anchor"];

                    if (ag.IsEnabled)
                    {
                        // The glyph is enabled. 
                        // Clear the AnchorStyle flag to disable the Glyph.
                        pdAnchor.SetValue(
                            ag.relatedControl, 
                            ag.relatedControl.Anchor ^ ag.anchorStyle );
                    }
                    else
                    {
                        // The glyph is disabled. 
                        // Set the AnchorStyle flag to enable the Glyph.
                        pdAnchor.SetValue(
                            ag.relatedControl,
                            ag.relatedControl.Anchor | ag.anchorStyle);
                    }

                }

                return true;
            }
            // </snippet10>
        }

        // </snippet6>

        #endregion
    }
    #endregion
}
// </snippet1>