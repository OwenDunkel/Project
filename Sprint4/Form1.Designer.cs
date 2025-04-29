namespace AutomaticWordComplete
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ListBox Suggestions;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearchGoogle;
        private System.Windows.Forms.Label lblWordCount;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Suggestions = new System.Windows.Forms.ListBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnSearchGoogle = new System.Windows.Forms.Button();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.White;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInput.Location = new System.Drawing.Point(283, 70);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(379, 39);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsert.Location = new System.Drawing.Point(566, 182);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(241, 60);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDelete.Location = new System.Drawing.Point(566, 248);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(241, 60);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Suggestions
            // 
            this.Suggestions.BackColor = System.Drawing.Color.Gray;
            this.Suggestions.FormattingEnabled = true;
            this.Suggestions.ItemHeight = 38;
            this.Suggestions.Location = new System.Drawing.Point(98, 146);
            this.Suggestions.Name = "Suggestions";
            this.Suggestions.Size = new System.Drawing.Size(368, 270);
            this.Suggestions.Sorted = true;
            this.Suggestions.TabIndex = 4;
            // 
            // lblInput
            // 
            this.lblInput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblInput.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInput.Location = new System.Drawing.Point(57, 69);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(220, 37);
            this.lblInput.TabIndex = 5;
            this.lblInput.Text = "Word/Prefix:";
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSearchGoogle
            // 
            this.btnSearchGoogle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSearchGoogle.Location = new System.Drawing.Point(566, 314);
            this.btnSearchGoogle.Name = "btnSearchGoogle";
            this.btnSearchGoogle.Size = new System.Drawing.Size(241, 60);
            this.btnSearchGoogle.TabIndex = 7;
            this.btnSearchGoogle.Text = "Definition";
            this.btnSearchGoogle.UseVisualStyleBackColor = false;
            this.btnSearchGoogle.Click += new System.EventHandler(this.btnSearchGoogle_Click);
            // 
            // lblWordCount
            // 
            this.lblWordCount.Font = new System.Drawing.Font("Verdana", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordCount.Location = new System.Drawing.Point(92, 428);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(432, 40);
            this.lblWordCount.TabIndex = 0;
            this.lblWordCount.Text = "Words in Dictionary: 0";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(894, 477);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.Suggestions);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearchGoogle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Word Bank";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

