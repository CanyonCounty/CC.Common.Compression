namespace CC.Common.Compression.Demo
{
  partial class frmMain
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
      this.btnExtract = new System.Windows.Forms.Button();
      this.btnCleanUp = new System.Windows.Forms.Button();
      this.btnExtractAll = new System.Windows.Forms.Button();
      this.btnCreateZip = new System.Windows.Forms.Button();
      this.btnZipDir = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnExtract
      // 
      this.btnExtract.Location = new System.Drawing.Point(12, 41);
      this.btnExtract.Name = "btnExtract";
      this.btnExtract.Size = new System.Drawing.Size(152, 23);
      this.btnExtract.TabIndex = 0;
      this.btnExtract.Text = "Extract to Desktop Mask";
      this.btnExtract.UseVisualStyleBackColor = true;
      this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
      // 
      // btnCleanUp
      // 
      this.btnCleanUp.Location = new System.Drawing.Point(12, 124);
      this.btnCleanUp.Name = "btnCleanUp";
      this.btnCleanUp.Size = new System.Drawing.Size(152, 23);
      this.btnCleanUp.TabIndex = 1;
      this.btnCleanUp.Text = "Clean Up";
      this.btnCleanUp.UseVisualStyleBackColor = true;
      this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
      // 
      // btnExtractAll
      // 
      this.btnExtractAll.Location = new System.Drawing.Point(12, 12);
      this.btnExtractAll.Name = "btnExtractAll";
      this.btnExtractAll.Size = new System.Drawing.Size(152, 23);
      this.btnExtractAll.TabIndex = 2;
      this.btnExtractAll.Text = "Extract to Desktop All";
      this.btnExtractAll.UseVisualStyleBackColor = true;
      this.btnExtractAll.Click += new System.EventHandler(this.btnExtractAll_Click);
      // 
      // btnCreateZip
      // 
      this.btnCreateZip.Location = new System.Drawing.Point(13, 71);
      this.btnCreateZip.Name = "btnCreateZip";
      this.btnCreateZip.Size = new System.Drawing.Size(151, 23);
      this.btnCreateZip.TabIndex = 3;
      this.btnCreateZip.Text = "Create Zip";
      this.btnCreateZip.UseVisualStyleBackColor = true;
      this.btnCreateZip.Click += new System.EventHandler(this.btnCreateZip_Click);
      // 
      // btnZipDir
      // 
      this.btnZipDir.Location = new System.Drawing.Point(12, 227);
      this.btnZipDir.Name = "btnZipDir";
      this.btnZipDir.Size = new System.Drawing.Size(152, 23);
      this.btnZipDir.TabIndex = 4;
      this.btnZipDir.Text = "Zip C:\\Temp";
      this.btnZipDir.UseVisualStyleBackColor = true;
      this.btnZipDir.Click += new System.EventHandler(this.btnZipDir_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.btnZipDir);
      this.Controls.Add(this.btnCreateZip);
      this.Controls.Add(this.btnExtractAll);
      this.Controls.Add(this.btnCleanUp);
      this.Controls.Add(this.btnExtract);
      this.Name = "frmMain";
      this.Text = "Compression Test";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnExtract;
    private System.Windows.Forms.Button btnCleanUp;
    private System.Windows.Forms.Button btnExtractAll;
    private System.Windows.Forms.Button btnCreateZip;
    private System.Windows.Forms.Button btnZipDir;
  }
}

