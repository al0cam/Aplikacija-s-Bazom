
namespace Aplikacija.Forms
{
    partial class LoginRegister
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
            this.PrijavaButton = new System.Windows.Forms.Button();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegistracijaButton = new System.Windows.Forms.Button();
            this.StatusPrijaveLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrijavaButton
            // 
            this.PrijavaButton.Location = new System.Drawing.Point(193, 173);
            this.PrijavaButton.Name = "PrijavaButton";
            this.PrijavaButton.Size = new System.Drawing.Size(75, 23);
            this.PrijavaButton.TabIndex = 0;
            this.PrijavaButton.Text = "Prijava";
            this.PrijavaButton.UseVisualStyleBackColor = true;
            this.PrijavaButton.Click += new System.EventHandler(this.PrijavaButton_Click);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(31, 68);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(237, 20);
            this.UsernameTextbox.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(28, 52);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(55, 13);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(28, 105);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(31, 121);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(237, 20);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // RegistracijaButton
            // 
            this.RegistracijaButton.Location = new System.Drawing.Point(112, 173);
            this.RegistracijaButton.Name = "RegistracijaButton";
            this.RegistracijaButton.Size = new System.Drawing.Size(75, 23);
            this.RegistracijaButton.TabIndex = 5;
            this.RegistracijaButton.Text = "Registracija";
            this.RegistracijaButton.UseVisualStyleBackColor = true;
            this.RegistracijaButton.Click += new System.EventHandler(this.RegistracijaButton_Click);
            // 
            // StatusPrijaveLabel
            // 
            this.StatusPrijaveLabel.AutoSize = true;
            this.StatusPrijaveLabel.Location = new System.Drawing.Point(107, 44);
            this.StatusPrijaveLabel.Name = "StatusPrijaveLabel";
            this.StatusPrijaveLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusPrijaveLabel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Prijava/Registracija";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // LoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusPrijaveLabel);
            this.Controls.Add(this.RegistracijaButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.PrijavaButton);
            this.Name = "LoginRegister";
            this.Text = "App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrijavaButton;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button RegistracijaButton;
        private System.Windows.Forms.Label StatusPrijaveLabel;
        private System.Windows.Forms.Label label1;
    }
}