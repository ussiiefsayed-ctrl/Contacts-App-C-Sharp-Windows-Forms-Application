namespace ContactsConsoleApp_PresentationLayer
{
    partial class FrmListContacts
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
            this.DgvAllContacts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAddContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAllContacts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAllContacts
            // 
            this.DgvAllContacts.BackgroundColor = System.Drawing.Color.Silver;
            this.DgvAllContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAllContacts.ContextMenuStrip = this.contextMenuStrip1;
            this.DgvAllContacts.Location = new System.Drawing.Point(0, 1);
            this.DgvAllContacts.Name = "DgvAllContacts";
            this.DgvAllContacts.Size = new System.Drawing.Size(927, 288);
            this.DgvAllContacts.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Edit";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // BtnAddContact
            // 
            this.BtnAddContact.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddContact.FlatAppearance.BorderSize = 0;
            this.BtnAddContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.BtnAddContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.BtnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddContact.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddContact.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnAddContact.Location = new System.Drawing.Point(383, 339);
            this.BtnAddContact.Name = "BtnAddContact";
            this.BtnAddContact.Size = new System.Drawing.Size(169, 71);
            this.BtnAddContact.TabIndex = 1;
            this.BtnAddContact.Text = "Add Contact";
            this.BtnAddContact.UseVisualStyleBackColor = false;
            this.BtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // FrmListContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(926, 450);
            this.Controls.Add(this.BtnAddContact);
            this.Controls.Add(this.DgvAllContacts);
            this.DoubleBuffered = true;
            this.Name = "FrmListContacts";
            this.Text = "FrmListContacts";
            this.Load += new System.EventHandler(this.FrmListContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAllContacts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAllContacts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Button BtnAddContact;
    }
}