namespace Lab1_23520734
{
    partial class LoginPage
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
            AccountID = new Label();
            InputAccountID = new TextBox();
            Login = new Button();
            SignUp = new Button();
            SuspendLayout();
            // 
            // AccountID
            // 
            AccountID.AutoSize = true;
            AccountID.Location = new Point(66, 112);
            AccountID.Name = "AccountID";
            AccountID.Size = new Size(63, 15);
            AccountID.TabIndex = 0;
            AccountID.Text = "AccountID";
            AccountID.Click += label1_Click;
            // 
            // InputAccountID
            // 
            InputAccountID.Location = new Point(66, 153);
            InputAccountID.Name = "InputAccountID";
            InputAccountID.Size = new Size(276, 23);
            InputAccountID.TabIndex = 2;
            InputAccountID.TextChanged += textBox1_TextChanged;
            // 
            // Login
            // 
            Login.Location = new Point(143, 234);
            Login.Name = "Login";
            Login.Size = new Size(120, 40);
            Login.TabIndex = 4;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // SignUp
            // 
            SignUp.Location = new Point(143, 313);
            SignUp.Name = "SignUp";
            SignUp.Size = new Size(120, 34);
            SignUp.TabIndex = 5;
            SignUp.Text = "Sign up";
            SignUp.UseVisualStyleBackColor = true;
            SignUp.Click += SignUp_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 456);
            Controls.Add(SignUp);
            Controls.Add(Login);
            Controls.Add(InputAccountID);
            Controls.Add(AccountID);
            Name = "LoginPage";
            Text = "LoginPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AccountID;
        private TextBox InputAccountID;
        private Button Login;
        private Button SignUp;
    }
}