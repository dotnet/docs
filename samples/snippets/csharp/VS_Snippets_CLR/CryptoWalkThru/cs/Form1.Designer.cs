namespace CryptoWalkThru
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.buttonDecryptFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonEncryptFile = new System.Windows.Forms.Button();
            this._encryptOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonCreateAsmKeys = new System.Windows.Forms.Button();
            this._decryptOpeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpAsmKeys = new System.Windows.Forms.GroupBox();
            this.buttonGetPrivateKey = new System.Windows.Forms.Button();
            this.buttonImportPublicKey = new System.Windows.Forms.Button();
            this.buttonExportPublicKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.grpAsmKeys.SuspendLayout();
            this.SuspendLayout();
            //
            // CloseButton
            //
            this.CloseButton.Location = new System.Drawing.Point(139, 281);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.Close_Click);
            //
            // buttonDecryptFile
            //
            this.buttonDecryptFile.Location = new System.Drawing.Point(23, 48);
            this.buttonDecryptFile.Name = "buttonDecryptFile";
            this.buttonDecryptFile.Size = new System.Drawing.Size(110, 23);
            this.buttonDecryptFile.TabIndex = 31;
            this.buttonDecryptFile.Text = "Decrypt File";
            this.buttonDecryptFile.UseVisualStyleBackColor = true;
            this.buttonDecryptFile.Click += new System.EventHandler(this.buttonDecryptFile_Click);
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.buttonEncryptFile);
            this.groupBox3.Controls.Add(this.buttonDecryptFile);
            this.groupBox3.Location = new System.Drawing.Point(32, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 85);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption";
            //
            // buttonEncryptFile
            //
            this.buttonEncryptFile.Location = new System.Drawing.Point(23, 19);
            this.buttonEncryptFile.Name = "buttonEncryptFile";
            this.buttonEncryptFile.Size = new System.Drawing.Size(110, 23);
            this.buttonEncryptFile.TabIndex = 0;
            this.buttonEncryptFile.Text = "Encrypt File";
            this.buttonEncryptFile.UseVisualStyleBackColor = true;
            this.buttonEncryptFile.Click += new System.EventHandler(this.buttonEncryptFile_Click);
            //
            // openFileDialog1
            //
            this._encryptOpenFileDialog.Filter = "All files (*.*)|*.*";
            this._encryptOpenFileDialog.InitialDirectory = "c:\\meow";
            //
            // buttonCreateAsmKeys
            //
            this.buttonCreateAsmKeys.Location = new System.Drawing.Point(23, 19);
            this.buttonCreateAsmKeys.Name = "buttonCreateAsmKeys";
            this.buttonCreateAsmKeys.Size = new System.Drawing.Size(110, 23);
            this.buttonCreateAsmKeys.TabIndex = 37;
            this.buttonCreateAsmKeys.Text = "Create Keys";
            this.buttonCreateAsmKeys.UseVisualStyleBackColor = true;
            this.buttonCreateAsmKeys.Click += new System.EventHandler(this.buttonCreateAsmKeys_Click);
            //
            // openFileDialog2
            //
            this._decryptOpeFileDialog.Filter = "Encrypted files (*.enc) | *.enc|All files (*.*)|*.*";
            this._decryptOpeFileDialog.InitialDirectory = "c:\\encrypt";
            //
            // grpAsmKeys
            //
            this.grpAsmKeys.Controls.Add(this.buttonGetPrivateKey);
            this.grpAsmKeys.Controls.Add(this.buttonImportPublicKey);
            this.grpAsmKeys.Controls.Add(this.buttonExportPublicKey);
            this.grpAsmKeys.Controls.Add(this.buttonCreateAsmKeys);
            this.grpAsmKeys.Location = new System.Drawing.Point(31, 103);
            this.grpAsmKeys.Name = "grpAsmKeys";
            this.grpAsmKeys.Size = new System.Drawing.Size(160, 138);
            this.grpAsmKeys.TabIndex = 42;
            this.grpAsmKeys.TabStop = false;
            this.grpAsmKeys.Text = "Asymetric Keys";
            //
            // buttonGetPrivateKey
            //
            this.buttonGetPrivateKey.Location = new System.Drawing.Point(23, 107);
            this.buttonGetPrivateKey.Name = "buttonGetPrivateKey";
            this.buttonGetPrivateKey.Size = new System.Drawing.Size(110, 23);
            this.buttonGetPrivateKey.TabIndex = 40;
            this.buttonGetPrivateKey.Text = "Get Private Key";
            this.buttonGetPrivateKey.UseVisualStyleBackColor = true;
            this.buttonGetPrivateKey.Click += new System.EventHandler(this.buttonGetPrivateKey_Click);
            //
            // buttonImportPublicKey
            //
            this.buttonImportPublicKey.Location = new System.Drawing.Point(23, 78);
            this.buttonImportPublicKey.Name = "buttonImportPublicKey";
            this.buttonImportPublicKey.Size = new System.Drawing.Size(110, 23);
            this.buttonImportPublicKey.TabIndex = 39;
            this.buttonImportPublicKey.Text = "Import Public Key";
            this.buttonImportPublicKey.UseVisualStyleBackColor = true;
            this.buttonImportPublicKey.Click += new System.EventHandler(this.buttonImportPublicKey_Click);
            //
            // buttonExportPublicKey
            //
            this.buttonExportPublicKey.Location = new System.Drawing.Point(23, 48);
            this.buttonExportPublicKey.Name = "buttonExportPublicKey";
            this.buttonExportPublicKey.Size = new System.Drawing.Size(110, 23);
            this.buttonExportPublicKey.TabIndex = 38;
            this.buttonExportPublicKey.Text = "Export Public Key";
            this.buttonExportPublicKey.UseVisualStyleBackColor = true;
            this.buttonExportPublicKey.Click += new System.EventHandler(this.buttonExportPublicKey_Click);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Key not set.";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 316);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpAsmKeys);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CloseButton);
            this.Name = "Form1";
            this.Text = "CryptoWalkThru";
            this.groupBox3.ResumeLayout(false);
            this.grpAsmKeys.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button buttonDecryptFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonEncryptFile;
        private System.Windows.Forms.OpenFileDialog _encryptOpenFileDialog;
        private System.Windows.Forms.Button buttonCreateAsmKeys;
        private System.Windows.Forms.OpenFileDialog _decryptOpeFileDialog;
        private System.Windows.Forms.GroupBox grpAsmKeys;
        private System.Windows.Forms.Button buttonExportPublicKey;
        private System.Windows.Forms.Button buttonImportPublicKey;
        private System.Windows.Forms.Button buttonGetPrivateKey;
        private System.Windows.Forms.Label label1;
    }
}

