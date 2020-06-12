namespace CancellationWinForms
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
         this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripProgressBar3 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripProgressBar4 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         //
         // toolStrip1
         //
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripProgressBar1,
            this.toolStripProgressBar2,
            this.toolStripProgressBar3,
            this.toolStripProgressBar4});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(579, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         //
         // toolStripButton1
         //
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(96, 22);
         this.toolStripButton1.Text = "Add Work Items";
         this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
         //
         // toolStripButton2
         //
         this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripButton2.Enabled = false;
         this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
         this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton2.Name = "toolStripButton2";
         this.toolStripButton2.Size = new System.Drawing.Size(47, 22);
         this.toolStripButton2.Text = "Cancel";
         this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
         //
         // toolStripProgressBar1
         //
         this.toolStripProgressBar1.Name = "toolStripProgressBar1";
         this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
         //
         // toolStripProgressBar2
         //
         this.toolStripProgressBar2.Name = "toolStripProgressBar2";
         this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 22);
         //
         // toolStripProgressBar3
         //
         this.toolStripProgressBar3.Name = "toolStripProgressBar3";
         this.toolStripProgressBar3.Size = new System.Drawing.Size(100, 22);
         this.toolStripProgressBar3.Step = 1;
         //
         // toolStripProgressBar4
         //
         this.toolStripProgressBar4.Name = "toolStripProgressBar4";
         this.toolStripProgressBar4.Size = new System.Drawing.Size(100, 22);
         //
         // Form1
         //
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(579, 29);
         this.Controls.Add(this.toolStrip1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.ToolStripButton toolStripButton2;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar3;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar4;
   }
}

