namespace Trial
{
    partial class newContextForm
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
            this.newContext = new System.Windows.Forms.TextBox();
            this.saveContext = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextColors = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // newContext
            // 
            this.newContext.Location = new System.Drawing.Point(112, 5);
            this.newContext.Name = "newContext";
            this.newContext.Size = new System.Drawing.Size(147, 20);
            this.newContext.TabIndex = 0;
            // 
            // saveContext
            // 
            this.saveContext.Location = new System.Drawing.Point(57, 73);
            this.saveContext.Name = "saveContext";
            this.saveContext.Size = new System.Drawing.Size(75, 23);
            this.saveContext.TabIndex = 1;
            this.saveContext.Text = "Save";
            this.saveContext.UseVisualStyleBackColor = true;
            this.saveContext.Click += new System.EventHandler(this.saveContext_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(184, 73);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "New Context";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Color";
            // 
            // contextColors
            // 
            this.contextColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.contextColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contextColors.FormattingEnabled = true;
            this.contextColors.Location = new System.Drawing.Point(112, 36);
            this.contextColors.Name = "contextColors";
            this.contextColors.Size = new System.Drawing.Size(147, 21);
            this.contextColors.TabIndex = 5;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // newContextForm
            // 
            this.AcceptButton = this.saveContext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(292, 117);
            this.Controls.Add(this.contextColors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveContext);
            this.Controls.Add(this.newContext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(900, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newContextForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Context";
            this.Load += new System.EventHandler(this.newContextForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newContext;
        private System.Windows.Forms.Button saveContext;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox contextColors;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}