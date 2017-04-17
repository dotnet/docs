
// This sample can go in the VisualStyleElement class overview or a conceptual topic
// to give the new user a chance to view what each of the defined elements looks like. 
// This sample also gives them the ability to preview each element at three different sizes.


// <Snippet0>
using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VisualStyleElementViewer
{
    class Form1 : Form
    {
        public Form1()
        {
            ElementViewer ElementViewer1 = new ElementViewer();
            this.Controls.Add(ElementViewer1);
            this.Text = ElementViewer1.Text;
            this.Size = new Size(700, 550);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class ElementViewer : UserControl
    {
        private VisualStyleElement element;
        private VisualStyleRenderer renderer;
        private Dictionary<string, VisualStyleElement> elementDictionary =
            new Dictionary<string, VisualStyleElement>();

        private Rectangle descriptionRect;
        private Rectangle displayRect;
        private Rectangle displayRectFull;
        private Size currentTrueSize = new Size();
        private StringBuilder elementDescription = new StringBuilder();
        private Label label1 = new Label();
        private TreeView treeView1 = new TreeView();
        private DomainUpDown domainUpDown1 = new DomainUpDown();
        private bool drawElement = false;

        public ElementViewer()
            : base()
        {
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 500);
            this.Text = "VisualStyleElement Viewer";
            this.Font = SystemFonts.IconTitleFont;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.AutoSize = true;
            this.Load += new EventHandler(ElementViewer_Load);
        }

        void ElementViewer_Load(object sender, EventArgs e)
        {
            // Make sure the visual styles are enabled before 
            // going any further.
            if (!Application.RenderWithVisualStyles)
            {
                return;
            }

            label1.Location = new Point(320, 10);
            label1.Size = new Size(300, 60);
            label1.Text = "Expand the element class nodes " +
                "in the tree view to access visual style elements. " +
                "Click an element name to draw the element below. To " +
                "change the size of a resizable element, use the " +
                "spin control.";

            domainUpDown1.Location = new Point(320, 80);
            domainUpDown1.Size = new Size(70, 30);
            domainUpDown1.ReadOnly = true;
            domainUpDown1.Items.Add(elementSizes.Large);
            domainUpDown1.Items.Add(elementSizes.Medium);
            domainUpDown1.Items.Add(elementSizes.TrueSize);
            domainUpDown1.SelectedIndex = 2;
            domainUpDown1.SelectedItemChanged +=
                new EventHandler(domainUpDown1_SelectedItemChanged);
            domainUpDown1.DownButton();

            descriptionRect = new Rectangle(320, 120, 250, 50);
            displayRect = new Rectangle(320, 160, 0, 0);
            displayRectFull = new Rectangle(320, 160, 300, 200);

            // Initialize the element and renderer to known good values.
            element = VisualStyleElement.Button.PushButton.Normal;
            renderer = new VisualStyleRenderer(element);

            SetupElementCollection();
            SetupTreeView();

            this.Controls.AddRange(new Control[] { treeView1, 
                domainUpDown1, label1 });
        }

        // Use reflection to build a Dictionary of all 
        // VisualStyleElement objects exposed in the 
        // System.Windows.Forms.VisualStyles namespace.
        private void SetupElementCollection()
        {
            StringBuilder elementName = new StringBuilder();
            VisualStyleElement currentElement;
            int plusSignIndex = 0;

            // Get array of first-level nested types within 
            // VisualStyleElement; these are the element classes.
            Type[] elementClasses =
                typeof(VisualStyleElement).GetNestedTypes();

            foreach (Type elementClass in elementClasses)
            {
                // Get an array of second-level nested types within
                // VisualStyleElement; these are the element parts.
                Type[] elementParts = elementClass.GetNestedTypes();

                // Get the index of the first '+' character in 
                // the full element class name.
                plusSignIndex = elementClass.FullName.IndexOf('+');

                foreach (Type elementPart in elementParts)
                {
                    // Get an array of static property details 
                    // for  the current type. Each of these types have 
                    // properties that return VisualStyleElement objects.
                    PropertyInfo[] elementProperties =
                        elementPart.GetProperties(BindingFlags.Static |
                        BindingFlags.Public);

                    // For each property, insert the unique full element   
                    // name and the element into the collection.
                    foreach (PropertyInfo elementProperty in
                        elementProperties)
                    {
                        // Get the element.
                        currentElement =
                            (VisualStyleElement)elementProperty.
                            GetValue(null, BindingFlags.Static, null,
                            null, null);

                        // Append the full element name.
                        elementName.Append(elementClass.FullName,
                            plusSignIndex + 1,
                            elementClass.FullName.Length -
                            plusSignIndex - 1);
                        elementName.Append("." +
                            elementPart.Name.ToString() + "." +
                            elementProperty.Name);

                        // Add the element and element name to 
                        // the Dictionary.
                        elementDictionary.Add(elementName.ToString(),
                            currentElement);

                        // Clear the element name for the 
                        // next iteration.
                        elementName.Remove(0, elementName.Length);
                    }
                }
            }
        }

        // Initialize the tree view with the element names.
        private void SetupTreeView()
        {
            treeView1.Location = new Point(10, 10);
            treeView1.Size = new Size(300, 450);
            treeView1.BorderStyle = BorderStyle.FixedSingle;
            treeView1.BackColor = Color.WhiteSmoke;
            treeView1.SelectedNode = null;
            treeView1.AfterSelect +=
                new TreeViewEventHandler(treeView1_AfterSelect);

            treeView1.BeginUpdate();

            // An index into the top-level tree nodes.
            int nodeIndex = 0;

            // An index into the first '.' character in an element name.
            int firstDotIndex = 0;

            // Initialize the element class name to compare 
            // with the class name of the first element  
            // in the Dictionary, and set this name to the first 
            // top-level node.
            StringBuilder compareClassName =
                new StringBuilder("Button");
            treeView1.Nodes.Add(
                new TreeNode(compareClassName.ToString()));

            // The current element class name.
            StringBuilder currentClassName = new StringBuilder();

            // The text for each second-level node.
            StringBuilder nodeText = new StringBuilder();

            foreach (KeyValuePair<string, VisualStyleElement> entry
                in elementDictionary)
            {
                // Isolate the class name of the current element.
                firstDotIndex = entry.Key.IndexOf('.');
                currentClassName.Append(entry.Key, 0, firstDotIndex);

                // Determine whether we need to increment to the next 
                // element class.
                if (currentClassName.ToString() !=
                    compareClassName.ToString())
                {
                    // Increment the index to the next top-level node 
                    // in the tree view.
                    nodeIndex++;

                    // Get the new class name to compare with.
                    compareClassName.Remove(0, compareClassName.Length);
                    compareClassName.Append(entry.Key);
                    compareClassName.Remove(firstDotIndex,
                        compareClassName.Length - firstDotIndex);

                    // Add a new top-level node to the tree view.
                    treeView1.Nodes.Add(
                        new TreeNode(compareClassName.ToString()));
                }

                // Get the text for the new second-level node.
                nodeText.Append(entry.Key, firstDotIndex + 1,
                    entry.Key.Length - firstDotIndex - 1);

                // Create and insert the new second-level node.
                TreeNode newNode = new TreeNode(nodeText.ToString());
                newNode.Name = entry.Key;
                treeView1.Nodes[nodeIndex].Nodes.Add(newNode);

                currentClassName.Remove(0, currentClassName.Length);
                nodeText.Remove(0, nodeText.Length);
            }

            treeView1.EndUpdate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Do nothing further if visual styles are disabled.
            if (!Application.RenderWithVisualStyles)
            {
                this.Text = "Visual styles are disabled.";
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                    this.Location, this.ForeColor);
                return;
            }

            // Draw the element description.
            TextRenderer.DrawText(e.Graphics, elementDescription.ToString(),
                this.Font, descriptionRect, this.ForeColor,
                TextFormatFlags.WordBreak);

            // Draw the element, if an element is selected.
            if (drawElement)
            {
                renderer.DrawBackground(e.Graphics, this.displayRect);
            }
        }

        // Set the element to draw.
        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Clear the element description.
            elementDescription.Remove(0, elementDescription.Length);

            // If the user clicked a first-level node, disable drawing.
            if (e.Node.Nodes.Count > 0)
            {
                drawElement = false;
                elementDescription.Append("No element is selected");
                domainUpDown1.Enabled = false;
            }

            // The user clicked an element node.
            else
            {
                // Add the element name to the description.
                elementDescription.Append(e.Node.Text);

                // Get the element that corresponds to the selected  
                // node's name.
                String key = e.Node.Name;
                element = elementDictionary[key];

                // Disable resizing if the element is not defined.
                if (!VisualStyleRenderer.IsElementDefined(element))
                {
                    drawElement = false;
                    elementDescription.Append(" is not defined.");
                    domainUpDown1.Enabled = false;
                }
                else
                {
                    // Set the element to the renderer.
                    drawElement = true;
                    renderer.SetParameters(element);
                    elementDescription.Append(" is defined.");

                    // Get the system-defined size of the element.
                    Graphics g = this.CreateGraphics();
                    currentTrueSize = renderer.GetPartSize(g,
                        ThemeSizeType.True);
                    g.Dispose();
                    displayRect.Size = currentTrueSize;

                    domainUpDown1.Enabled = true;
                    domainUpDown1.SelectedIndex = 2;
                }
            }

            Invalidate();
        }

        // Resize the element display area.
        void domainUpDown1_SelectedItemChanged(object sender,
            EventArgs e)
        {
            switch ((int)domainUpDown1.SelectedItem)
            {
                case (int)elementSizes.TrueSize:
                    displayRect.Size = currentTrueSize;
                    break;
                case (int)elementSizes.Medium:
                    displayRect.Size =
                        new Size(displayRectFull.Width / 2,
                        displayRectFull.Height / 2);
                    break;
                case (int)elementSizes.Large:
                    displayRect.Size = displayRectFull.Size;
                    break;
            }

            Invalidate();
        }

        // These values represent the options in the UpDown control.
        private enum elementSizes
        {
            TrueSize,
            Medium,
            Large
        };
    }
}
// </Snippet0>