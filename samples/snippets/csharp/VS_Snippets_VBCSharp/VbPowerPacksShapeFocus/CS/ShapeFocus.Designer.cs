namespace VbPowerPacksShapeFocusCS
{
    partial class ShapeFocus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShape3 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape2 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShape3,
            this.ovalShape2,
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(292, 266);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // ovalShape3
            // 
            this.ovalShape3.Location = new System.Drawing.Point(100, 198);
            this.ovalShape3.Name = "ovalShape3";
            this.ovalShape3.Size = new System.Drawing.Size(161, 46);
            this.ovalShape3.Click += new System.EventHandler(this.ovalShape3_Click);
            // 
            // ovalShape2
            // 
            this.ovalShape2.Location = new System.Drawing.Point(48, 108);
            this.ovalShape2.Name = "ovalShape2";
            this.ovalShape2.Size = new System.Drawing.Size(186, 52);
            // 
            // ovalShape1
            // 
            this.ovalShape1.Location = new System.Drawing.Point(19, 18);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(163, 55);
            // 
            // ShapeFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ShapeFocus";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.ShapeFocus_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape3;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape2;
    }
}

