namespace UIAITransformProvider_snip
{
    partial class ProviderForm
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
            this.btnResize = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.ResizeWidth = new System.Windows.Forms.TextBox();
            this.RotateDegrees = new System.Windows.Forms.TextBox();
            this.MoveX = new System.Windows.Forms.TextBox();
            this.MoveY = new System.Windows.Forms.TextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.ResizeHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(12, 231);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(75, 23);
            this.btnResize.TabIndex = 0;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(110, 231);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 1;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(205, 231);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // ResizeWidth
            // 
            this.ResizeWidth.Location = new System.Drawing.Point(12, 205);
            this.ResizeWidth.Name = "ResizeWidth";
            this.ResizeWidth.Size = new System.Drawing.Size(34, 20);
            this.ResizeWidth.TabIndex = 3;
            // 
            // RotateDegrees
            // 
            this.RotateDegrees.Location = new System.Drawing.Point(110, 205);
            this.RotateDegrees.Name = "RotateDegrees";
            this.RotateDegrees.Size = new System.Drawing.Size(75, 20);
            this.RotateDegrees.TabIndex = 4;
            // 
            // MoveX
            // 
            this.MoveX.Location = new System.Drawing.Point(205, 205);
            this.MoveX.Name = "MoveX";
            this.MoveX.Size = new System.Drawing.Size(34, 20);
            this.MoveX.TabIndex = 5;
            // 
            // MoveY
            // 
            this.MoveY.Location = new System.Drawing.Point(245, 205);
            this.MoveY.Name = "MoveY";
            this.MoveY.Size = new System.Drawing.Size(34, 20);
            this.MoveY.TabIndex = 6;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(205, 13);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ResizeHeight
            // 
            this.ResizeHeight.Location = new System.Drawing.Point(53, 205);
            this.ResizeHeight.Name = "ResizeHeight";
            this.ResizeHeight.Size = new System.Drawing.Size(34, 20);
            this.ResizeHeight.TabIndex = 8;
            // 
            // ProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.ResizeHeight);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MoveY);
            this.Controls.Add(this.MoveX);
            this.Controls.Add(this.RotateDegrees);
            this.Controls.Add(this.ResizeWidth);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnResize);
            this.Name = "ProviderForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox ResizeWidth;
        private System.Windows.Forms.TextBox RotateDegrees;
        private System.Windows.Forms.TextBox MoveX;
        private System.Windows.Forms.TextBox MoveY;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox ResizeHeight;
    }
}

