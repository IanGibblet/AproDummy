namespace AprocoDummy
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
            this.btnShowBreakdowns = new System.Windows.Forms.Button();
            this.txtBreakdowns = new System.Windows.Forms.TextBox();
            this.btnShowElements = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowBreakdowns
            // 
            this.btnShowBreakdowns.Location = new System.Drawing.Point(33, 57);
            this.btnShowBreakdowns.Name = "btnShowBreakdowns";
            this.btnShowBreakdowns.Size = new System.Drawing.Size(198, 23);
            this.btnShowBreakdowns.TabIndex = 0;
            this.btnShowBreakdowns.Text = "Show all Breakdown Elements";
            this.btnShowBreakdowns.UseVisualStyleBackColor = true;
            this.btnShowBreakdowns.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBreakdowns
            // 
            this.txtBreakdowns.Location = new System.Drawing.Point(33, 86);
            this.txtBreakdowns.Multiline = true;
            this.txtBreakdowns.Name = "txtBreakdowns";
            this.txtBreakdowns.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBreakdowns.Size = new System.Drawing.Size(198, 266);
            this.txtBreakdowns.TabIndex = 1;
            this.txtBreakdowns.Text = "l";
            // 
            // btnShowElements
            // 
            this.btnShowElements.Location = new System.Drawing.Point(533, 57);
            this.btnShowElements.Name = "btnShowElements";
            this.btnShowElements.Size = new System.Drawing.Size(283, 23);
            this.btnShowElements.TabIndex = 2;
            this.btnShowElements.Text = "Show Elements";
            this.btnShowElements.UseVisualStyleBackColor = true;
            this.btnShowElements.Click += new System.EventHandler(this.btnShowElements_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(533, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diagram URL";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(534, 183);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 212);
            this.listBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Elements";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnShowElements);
            this.Controls.Add(this.txtBreakdowns);
            this.Controls.Add(this.btnShowBreakdowns);
            this.Name = "Form1";
            this.Text = "ll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowBreakdowns;
        private System.Windows.Forms.TextBox txtBreakdowns;
        private System.Windows.Forms.Button btnShowElements;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
    }
}

