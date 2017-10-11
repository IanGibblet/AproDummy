namespace AprocoDummy
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
            this.btnShowBreakdowns = new System.Windows.Forms.Button();
            this.btnShowElements = new System.Windows.Forms.Button();
            this.txtDiagramURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBreakDownElements = new System.Windows.Forms.DataGridView();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.AproStatus = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvEA_Elements = new System.Windows.Forms.DataGridView();
            this.txtSaS_URI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiagramName = new System.Windows.Forms.TextBox();
            this.txtDiagramType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakDownElements)).BeginInit();
            this.AproStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEA_Elements)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowBreakdowns
            // 
            this.btnShowBreakdowns.Location = new System.Drawing.Point(33, 68);
            this.btnShowBreakdowns.Name = "btnShowBreakdowns";
            this.btnShowBreakdowns.Size = new System.Drawing.Size(198, 23);
            this.btnShowBreakdowns.TabIndex = 0;
            this.btnShowBreakdowns.Text = "Show all Breakdown Elements";
            this.btnShowBreakdowns.UseVisualStyleBackColor = true;
            this.btnShowBreakdowns.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowElements
            // 
            this.btnShowElements.Location = new System.Drawing.Point(33, 384);
            this.btnShowElements.Name = "btnShowElements";
            this.btnShowElements.Size = new System.Drawing.Size(283, 23);
            this.btnShowElements.TabIndex = 2;
            this.btnShowElements.Text = "Show Elements";
            this.btnShowElements.UseVisualStyleBackColor = true;
            this.btnShowElements.Click += new System.EventHandler(this.btnShowElements_Click);
            // 
            // txtDiagramURL
            // 
            this.txtDiagramURL.Location = new System.Drawing.Point(336, 387);
            this.txtDiagramURL.Name = "txtDiagramURL";
            this.txtDiagramURL.Size = new System.Drawing.Size(631, 20);
            this.txtDiagramURL.TabIndex = 3;
            this.txtDiagramURL.Text = "http://localhost:56901/RESTEA/IanTest/Dia_Thingswithtags|otDiagram|%7B49763E96-79" +
    "D0-4690-8109-EF6AE0511259%7D";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diagram URL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvBreakDownElements
            // 
            this.dgvBreakDownElements.AllowUserToAddRows = false;
            this.dgvBreakDownElements.AllowUserToDeleteRows = false;
            this.dgvBreakDownElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBreakDownElements.Location = new System.Drawing.Point(33, 97);
            this.dgvBreakDownElements.Name = "dgvBreakDownElements";
            this.dgvBreakDownElements.RowHeadersVisible = false;
            this.dgvBreakDownElements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBreakDownElements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBreakDownElements.Size = new System.Drawing.Size(934, 187);
            this.dgvBreakDownElements.TabIndex = 7;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(531, 22);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(10, 13);
            this.lblFeedback.TabIndex = 8;
            this.lblFeedback.Text = "-";
            // 
            // AproStatus
            // 
            this.AproStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStrip});
            this.AproStatus.Location = new System.Drawing.Point(0, 632);
            this.AproStatus.Name = "AproStatus";
            this.AproStatus.Size = new System.Drawing.Size(979, 22);
            this.AproStatus.TabIndex = 9;
            this.AproStatus.Text = "AproDummy";
            // 
            // statusStrip
            // 
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(76, 17);
            this.statusStrip.Text = "AproDummy";
            // 
            // dgvEA_Elements
            // 
            this.dgvEA_Elements.AllowUserToAddRows = false;
            this.dgvEA_Elements.AllowUserToDeleteRows = false;
            this.dgvEA_Elements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEA_Elements.Location = new System.Drawing.Point(33, 414);
            this.dgvEA_Elements.Name = "dgvEA_Elements";
            this.dgvEA_Elements.ReadOnly = true;
            this.dgvEA_Elements.RowHeadersVisible = false;
            this.dgvEA_Elements.Size = new System.Drawing.Size(398, 168);
            this.dgvEA_Elements.TabIndex = 10;
            // 
            // txtSaS_URI
            // 
            this.txtSaS_URI.Location = new System.Drawing.Point(237, 68);
            this.txtSaS_URI.Name = "txtSaS_URI";
            this.txtSaS_URI.Size = new System.Drawing.Size(730, 20);
            this.txtSaS_URI.TabIndex = 11;
            this.txtSaS_URI.Text = "https://sas.aprocone.cfms.org.uk/api";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "SaS URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Diagram Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Diagram Type";
            // 
            // txtDiagramName
            // 
            this.txtDiagramName.Enabled = false;
            this.txtDiagramName.Location = new System.Drawing.Point(535, 429);
            this.txtDiagramName.Name = "txtDiagramName";
            this.txtDiagramName.Size = new System.Drawing.Size(272, 20);
            this.txtDiagramName.TabIndex = 14;
            // 
            // txtDiagramType
            // 
            this.txtDiagramType.Enabled = false;
            this.txtDiagramType.Location = new System.Drawing.Point(535, 459);
            this.txtDiagramType.Name = "txtDiagramType";
            this.txtDiagramType.Size = new System.Drawing.Size(272, 20);
            this.txtDiagramType.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 654);
            this.Controls.Add(this.txtDiagramType);
            this.Controls.Add(this.txtDiagramName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSaS_URI);
            this.Controls.Add(this.dgvEA_Elements);
            this.Controls.Add(this.AproStatus);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.dgvBreakDownElements);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiagramURL);
            this.Controls.Add(this.btnShowElements);
            this.Controls.Add(this.btnShowBreakdowns);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AproDummy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakDownElements)).EndInit();
            this.AproStatus.ResumeLayout(false);
            this.AproStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEA_Elements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowBreakdowns;
        private System.Windows.Forms.Button btnShowElements;
        private System.Windows.Forms.TextBox txtDiagramURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBreakDownElements;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.StatusStrip AproStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.DataGridView dgvEA_Elements;
        private System.Windows.Forms.TextBox txtSaS_URI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiagramName;
        private System.Windows.Forms.TextBox txtDiagramType;
    }
}

