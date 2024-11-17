namespace Lab1_23520734
{
    partial class CreateAccountPage
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
            enterUserID = new Label();
            fullName = new Label();
            label3 = new Label();
            enteredID = new TextBox();
            enteredName = new TextBox();
            createAccountButton = new Button();
            userID_info = new Label();
            SuspendLayout();
            // 
            // enterUserID
            // 
            enterUserID.AutoSize = true;
            enterUserID.Location = new Point(43, 51);
            enterUserID.Name = "enterUserID";
            enterUserID.Size = new Size(74, 15);
            enterUserID.TabIndex = 0;
            enterUserID.Text = "Enter User ID";
            enterUserID.Click += label1_Click;
            // 
            // fullName
            // 
            fullName.AutoSize = true;
            fullName.Location = new Point(43, 117);
            fullName.Name = "fullName";
            fullName.Size = new Size(59, 15);
            fullName.TabIndex = 1;
            fullName.Text = "Fuil name";
            fullName.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 157);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 2;
            // 
            // enteredID
            // 
            enteredID.Location = new Point(43, 80);
            enteredID.Name = "enteredID";
            enteredID.Size = new Size(331, 23);
            enteredID.TabIndex = 3;
            // 
            // enteredName
            // 
            enteredName.Location = new Point(43, 149);
            enteredName.Name = "enteredName";
            enteredName.Size = new Size(331, 23);
            enteredName.TabIndex = 4;
            // 
            // createAccountButton
            // 
            createAccountButton.Location = new Point(115, 241);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(206, 44);
            createAccountButton.TabIndex = 5;
            createAccountButton.Text = "Create Account";
            createAccountButton.UseVisualStyleBackColor = true;
            createAccountButton.Click += button1_Click;
            // 
            // userID_info
            // 
            userID_info.AutoSize = true;
            userID_info.Location = new Point(245, 51);
            userID_info.Name = "userID_info";
            userID_info.Size = new Size(129, 15);
            userID_info.TabIndex = 6;
            userID_info.Text = "maximum 10 character";
            // 
            // CreateAccountPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 326);
            Controls.Add(userID_info);
            Controls.Add(createAccountButton);
            Controls.Add(enteredName);
            Controls.Add(enteredID);
            Controls.Add(label3);
            Controls.Add(fullName);
            Controls.Add(enterUserID);
            Name = "CreateAccountPage";
            Text = "Sign Up";
            Load += CreateAccountPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label enterUserID;
        private Label fullName;
        private Label label3;
        private TextBox enteredID;
        private TextBox enteredName;
        private Button createAccountButton;
        private Label userID_info;
    }
}