namespace Trial
{
    partial class settings
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
            this.okbtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.newContextbtn = new System.Windows.Forms.Button();
            this.renameContextbtn = new System.Windows.Forms.Button();
            this.deleteContextbtn = new System.Windows.Forms.Button();
            this.contextColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contexts = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // okbtn
            // 
            this.okbtn.Location = new System.Drawing.Point(82, 226);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(75, 23);
            this.okbtn.TabIndex = 0;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = true;
            this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(188, 225);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 1;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // newContextbtn
            // 
            this.newContextbtn.Location = new System.Drawing.Point(188, 50);
            this.newContextbtn.Name = "newContextbtn";
            this.newContextbtn.Size = new System.Drawing.Size(75, 23);
            this.newContextbtn.TabIndex = 3;
            this.newContextbtn.Text = "New";
            this.newContextbtn.UseVisualStyleBackColor = true;
            this.newContextbtn.Click += new System.EventHandler(this.newContextbtn_Click);
            // 
            // renameContextbtn
            // 
            this.renameContextbtn.Location = new System.Drawing.Point(188, 79);
            this.renameContextbtn.Name = "renameContextbtn";
            this.renameContextbtn.Size = new System.Drawing.Size(75, 23);
            this.renameContextbtn.TabIndex = 4;
            this.renameContextbtn.Text = "Rename";
            this.renameContextbtn.UseVisualStyleBackColor = true;
            // 
            // deleteContextbtn
            // 
            this.deleteContextbtn.Location = new System.Drawing.Point(188, 108);
            this.deleteContextbtn.Name = "deleteContextbtn";
            this.deleteContextbtn.Size = new System.Drawing.Size(75, 23);
            this.deleteContextbtn.TabIndex = 5;
            this.deleteContextbtn.Text = "Delete";
            this.deleteContextbtn.UseVisualStyleBackColor = true;
            // 
            // contextColor
            // 
            this.contextColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.contextColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contextColor.FormattingEnabled = true;
            this.contextColor.Location = new System.Drawing.Point(188, 154);
            this.contextColor.Name = "contextColor";
            this.contextColor.Size = new System.Drawing.Size(75, 21);
            this.contextColor.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Color";
            // 
            // contexts
            // 
            this.contexts.CheckOnClick = true;
            this.contexts.FormattingEnabled = true;
            this.contexts.Location = new System.Drawing.Point(12, 50);
            this.contexts.Name = "contexts";
            this.contexts.Size = new System.Drawing.Size(145, 94);
            this.contexts.TabIndex = 8;
            this.contexts.SelectedIndexChanged += new System.EventHandler(this.contexts_SelectedIndexChanged);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.contexts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contextColor);
            this.Controls.Add(this.deleteContextbtn);
            this.Controls.Add(this.renameContextbtn);
            this.Controls.Add(this.newContextbtn);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.okbtn);
            this.Location = new System.Drawing.Point(900, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Context Settings";
            this.Load += new System.EventHandler(this.settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button newContextbtn;
        private System.Windows.Forms.Button renameContextbtn;
        private System.Windows.Forms.Button deleteContextbtn;
        private System.Windows.Forms.ComboBox contextColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox contexts;
    }
}