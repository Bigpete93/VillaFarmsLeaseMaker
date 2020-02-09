namespace Villa_Farms
{
    partial class Form0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form0));
            this.leaseCreater = new System.Windows.Forms.Button();
            this.statementButt = new System.Windows.Forms.Button();
            this.ProspectusButt = new System.Windows.Forms.Button();
            this.exhibitCButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leaseCreater
            // 
            this.leaseCreater.Location = new System.Drawing.Point(13, 15);
            this.leaseCreater.Margin = new System.Windows.Forms.Padding(4);
            this.leaseCreater.Name = "leaseCreater";
            this.leaseCreater.Size = new System.Drawing.Size(189, 43);
            this.leaseCreater.TabIndex = 0;
            this.leaseCreater.Text = "Create Lease ";
            this.leaseCreater.UseVisualStyleBackColor = true;
            this.leaseCreater.Click += new System.EventHandler(this.leaseCreater_Click);
            // 
            // statementButt
            // 
            this.statementButt.Location = new System.Drawing.Point(650, 15);
            this.statementButt.Margin = new System.Windows.Forms.Padding(4);
            this.statementButt.Name = "statementButt";
            this.statementButt.Size = new System.Drawing.Size(184, 43);
            this.statementButt.TabIndex = 1;
            this.statementButt.Text = "Create Statement of Understanding";
            this.statementButt.UseVisualStyleBackColor = true;
            this.statementButt.Click += new System.EventHandler(this.statementButt_Click);
            // 
            // ProspectusButt
            // 
            this.ProspectusButt.Location = new System.Drawing.Point(209, 15);
            this.ProspectusButt.Name = "ProspectusButt";
            this.ProspectusButt.Size = new System.Drawing.Size(190, 43);
            this.ProspectusButt.TabIndex = 2;
            this.ProspectusButt.Text = "Create Prospectus";
            this.ProspectusButt.UseVisualStyleBackColor = false;
            this.ProspectusButt.Click += new System.EventHandler(this.ProspectusButt_Click);
            // 
            // exhibitCButt
            // 
            this.exhibitCButt.Location = new System.Drawing.Point(450, 15);
            this.exhibitCButt.Name = "exhibitCButt";
            this.exhibitCButt.Size = new System.Drawing.Size(189, 43);
            this.exhibitCButt.TabIndex = 3;
            this.exhibitCButt.Text = "Create Exhibit C";
            this.exhibitCButt.UseVisualStyleBackColor = false;
            this.exhibitCButt.Click += new System.EventHandler(this.exhibitCButt_Click);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 70);
            this.Controls.Add(this.exhibitCButt);
            this.Controls.Add(this.ProspectusButt);
            this.Controls.Add(this.statementButt);
            this.Controls.Add(this.leaseCreater);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form0";
            this.Text = "Lease Paper Work Creater";
            this.Load += new System.EventHandler(this.Form0_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button leaseCreater;
        private System.Windows.Forms.Button statementButt;
        private System.Windows.Forms.Button ProspectusButt;
        private System.Windows.Forms.Button exhibitCButt;
    }
}