namespace BookStoreApp.AdminPanalFroms
{
    partial class DeleteUserFrm
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
            this.btnChooseID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numUserId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUserId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseID
            // 
            this.btnChooseID.Location = new System.Drawing.Point(41, 148);
            this.btnChooseID.Name = "btnChooseID";
            this.btnChooseID.Size = new System.Drawing.Size(127, 31);
            this.btnChooseID.TabIndex = 16;
            this.btnChooseID.Text = "Ok";
            this.btnChooseID.UseVisualStyleBackColor = true;
            this.btnChooseID.Click += new System.EventHandler(this.btnChooseID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "UserID";
            // 
            // numUserId
            // 
            this.numUserId.Location = new System.Drawing.Point(41, 122);
            this.numUserId.Name = "numUserId";
            this.numUserId.Size = new System.Drawing.Size(303, 20);
            this.numUserId.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Delete User";
            // 
            // DeleteUserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUserId);
            this.Name = "DeleteUserFrm";
            this.Text = "DeleteUserFrm";
            this.Load += new System.EventHandler(this.DeleteUserFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUserId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUserId;
        private System.Windows.Forms.Label label1;
    }
}