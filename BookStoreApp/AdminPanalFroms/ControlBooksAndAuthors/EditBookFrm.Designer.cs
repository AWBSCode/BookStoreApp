namespace BookStoreApp.AdminPanalFroms.ControlBooksAndAuthors
{
    partial class EditBookFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddAuthor = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAuthor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.authorsList = new System.Windows.Forms.ListView();
            this.AuthorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.numPrice = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numCopies = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddNewBook = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Book";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.BorderRadius = 10;
            this.btnRemoveSelected.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveSelected.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveSelected.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveSelected.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveSelected.FillColor = System.Drawing.Color.LightCoral;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnRemoveSelected.ForeColor = System.Drawing.Color.White;
            this.btnRemoveSelected.Location = new System.Drawing.Point(449, 143);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(93, 35);
            this.btnRemoveSelected.TabIndex = 38;
            this.btnRemoveSelected.Text = "Remove";
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.BorderRadius = 10;
            this.btnAddAuthor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAuthor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAuthor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddAuthor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddAuthor.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddAuthor.ForeColor = System.Drawing.Color.White;
            this.btnAddAuthor.Location = new System.Drawing.Point(350, 143);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(93, 35);
            this.btnAddAuthor.TabIndex = 37;
            this.btnAddAuthor.Text = "Add";
            this.btnAddAuthor.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(272, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Author";
            // 
            // cbAuthor
            // 
            this.cbAuthor.BackColor = System.Drawing.Color.Transparent;
            this.cbAuthor.BorderRadius = 5;
            this.cbAuthor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbAuthor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbAuthor.ItemHeight = 30;
            this.cbAuthor.Location = new System.Drawing.Point(337, 101);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(205, 36);
            this.cbAuthor.TabIndex = 35;
            // 
            // authorsList
            // 
            this.authorsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AuthorName});
            this.authorsList.HideSelection = false;
            this.authorsList.Location = new System.Drawing.Point(302, 206);
            this.authorsList.Name = "authorsList";
            this.authorsList.Size = new System.Drawing.Size(284, 187);
            this.authorsList.TabIndex = 34;
            this.authorsList.UseCompatibleStateImageBehavior = false;
            this.authorsList.View = System.Windows.Forms.View.Details;
            // 
            // AuthorName
            // 
            this.AuthorName.Text = "Author";
            this.AuthorName.Width = 272;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Price";
            // 
            // numPrice
            // 
            this.numPrice.BackColor = System.Drawing.Color.Transparent;
            this.numPrice.BorderRadius = 10;
            this.numPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPrice.Location = new System.Drawing.Point(26, 305);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(200, 30);
            this.numPrice.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Quantity";
            // 
            // numCopies
            // 
            this.numCopies.BackColor = System.Drawing.Color.Transparent;
            this.numCopies.BorderRadius = 10;
            this.numCopies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numCopies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCopies.Location = new System.Drawing.Point(26, 241);
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(200, 30);
            this.numCopies.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.BorderRadius = 10;
            this.tbTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTitle.DefaultText = "";
            this.tbTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTitle.Location = new System.Drawing.Point(26, 181);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.PasswordChar = '\0';
            this.tbTitle.PlaceholderText = "";
            this.tbTitle.SelectedText = "";
            this.tbTitle.Size = new System.Drawing.Size(200, 25);
            this.tbTitle.TabIndex = 28;
            // 
            // btnAddNewBook
            // 
            this.btnAddNewBook.BorderRadius = 10;
            this.btnAddNewBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewBook.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddNewBook.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBook.Location = new System.Drawing.Point(406, 413);
            this.btnAddNewBook.Name = "btnAddNewBook";
            this.btnAddNewBook.Size = new System.Drawing.Size(180, 45);
            this.btnAddNewBook.TabIndex = 39;
            this.btnAddNewBook.Text = "Save Editing";
            this.btnAddNewBook.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(601, 486);
            this.Controls.Add(this.btnAddNewBook);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnAddAuthor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.authorsList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCopies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Name = "EditBookFrm";
            this.Text = "EditBookFrm";
            this.Load += new System.EventHandler(this.EditBookFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnRemoveSelected;
        private Guna.UI2.WinForms.Guna2Button btnAddAuthor;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cbAuthor;
        private System.Windows.Forms.ListView authorsList;
        private System.Windows.Forms.ColumnHeader AuthorName;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPrice;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2NumericUpDown numCopies;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox tbTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddNewBook;
    }
}