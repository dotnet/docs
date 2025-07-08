namespace WFCrossThreadCS
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
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.threadExampleBtn = new System.Windows.Forms.Button();
         this.SuspendLayout();
         //
         // textBox1
         //
         this.textBox1.Location = new System.Drawing.Point(28, 36);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(459, 186);
         this.textBox1.TabIndex = 0;
         //
         // threadExampleBtn
         //
         this.threadExampleBtn.Location = new System.Drawing.Point(249, 256);
         this.threadExampleBtn.Name = "threadExampleBtn";
         this.threadExampleBtn.Size = new System.Drawing.Size(75, 23);
         this.threadExampleBtn.TabIndex = 2;
         this.threadExampleBtn.Text = "button2";
         this.threadExampleBtn.UseVisualStyleBackColor = true;
         this.threadExampleBtn.Click += new System.EventHandler(this.threadExampleBtn_Click);
         //
         // Form1
         //
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(541, 371);
         this.Controls.Add(this.threadExampleBtn);
         this.Controls.Add(this.textBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button threadExampleBtn;
   }
}

