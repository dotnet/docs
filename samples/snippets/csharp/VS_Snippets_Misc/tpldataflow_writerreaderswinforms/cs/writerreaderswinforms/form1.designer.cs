namespace WriterReadersWinForms
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
         this.components = new System.ComponentModel.Container();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.checkBox4 = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // timer1
         // 
         this.timer1.Interval = 2500;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Enabled = false;
         this.checkBox1.Location = new System.Drawing.Point(12, 9);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(70, 17);
         this.checkBox1.TabIndex = 4;
         this.checkBox1.Text = "Reader 1";
         // 
         // checkBox2
         // 
         this.checkBox2.AutoSize = true;
         this.checkBox2.Enabled = false;
         this.checkBox2.Location = new System.Drawing.Point(12, 32);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(70, 17);
         this.checkBox2.TabIndex = 5;
         this.checkBox2.Text = "Reader 2";
         this.checkBox2.UseVisualStyleBackColor = true;
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Enabled = false;
         this.checkBox3.Location = new System.Drawing.Point(12, 55);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(70, 17);
         this.checkBox3.TabIndex = 6;
         this.checkBox3.Text = "Reader 3";
         this.checkBox3.UseVisualStyleBackColor = true;
         // 
         // checkBox4
         // 
         this.checkBox4.AutoSize = true;
         this.checkBox4.Enabled = false;
         this.checkBox4.Location = new System.Drawing.Point(12, 78);
         this.checkBox4.Name = "checkBox4";
         this.checkBox4.Size = new System.Drawing.Size(54, 17);
         this.checkBox4.TabIndex = 7;
         this.checkBox4.Text = "Writer";
         this.checkBox4.UseVisualStyleBackColor = true;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(172, 102);
         this.Controls.Add(this.checkBox4);
         this.Controls.Add(this.checkBox3);
         this.Controls.Add(this.checkBox2);
         this.Controls.Add(this.checkBox1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.CheckBox checkBox2;
      private System.Windows.Forms.CheckBox checkBox3;
      private System.Windows.Forms.CheckBox checkBox4;

   }
}

