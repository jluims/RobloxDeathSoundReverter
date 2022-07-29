namespace RobloxDeathSoundReverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.changeLabel = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changeLabel.Location = new System.Drawing.Point(67, 105);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(157, 21);
            this.changeLabel.TabIndex = 0;
            this.changeLabel.Text = "Change Death Sound";
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(76, 146);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(139, 44);
            this.changeButton.TabIndex = 1;
            this.changeButton.Text = "Toggle OOF";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(100, 196);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(96, 15);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status: Unknown";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 295);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.changeLabel);
            this.Name = "Form1";
            this.Text = "Roblox OOF Reverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label changeLabel;
        private Button changeButton;
        private Label statusLabel;
    }
}