namespace Lab1_23520734
{
    partial class FoodMenu
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
            tabControl1 = new TabControl();
            allFood = new TabPage();
            userFood = new TabPage();
            PrevPageBtn = new Button();
            NextPageBtn = new Button();
            RandomBtn = new Button();
            AddFood = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            tabControl1.SuspendLayout();
            allFood.SuspendLayout();
            userFood.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(allFood);
            tabControl1.Controls.Add(userFood);
            tabControl1.Location = new Point(12, 29);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(495, 403);
            tabControl1.TabIndex = 0;
            // 
            // allFood
            // 
            allFood.Controls.Add(flowLayoutPanel1);
            allFood.Location = new Point(4, 24);
            allFood.Name = "allFood";
            allFood.Padding = new Padding(3);
            allFood.Size = new Size(487, 375);
            allFood.TabIndex = 0;
            allFood.Text = "All";
            allFood.UseVisualStyleBackColor = true;
            allFood.Click += allFood_Click;
            // 
            // userFood
            // 
            userFood.Controls.Add(flowLayoutPanel2);
            userFood.Location = new Point(4, 24);
            userFood.Name = "userFood";
            userFood.Padding = new Padding(3);
            userFood.Size = new Size(487, 375);
            userFood.TabIndex = 1;
            userFood.Text = "My Food";
            userFood.UseVisualStyleBackColor = true;
            userFood.Click += userFood_Click;
            // 
            // PrevPageBtn
            // 
            PrevPageBtn.Location = new Point(343, 438);
            PrevPageBtn.Name = "PrevPageBtn";
            PrevPageBtn.Size = new Size(77, 37);
            PrevPageBtn.TabIndex = 1;
            PrevPageBtn.Text = "Previous";
            PrevPageBtn.UseVisualStyleBackColor = true;
            PrevPageBtn.Click += PrevPageBtn_Click;
            // 
            // NextPageBtn
            // 
            NextPageBtn.Location = new Point(426, 438);
            NextPageBtn.Name = "NextPageBtn";
            NextPageBtn.Size = new Size(77, 37);
            NextPageBtn.TabIndex = 2;
            NextPageBtn.Text = "Next";
            NextPageBtn.UseVisualStyleBackColor = true;
            NextPageBtn.Click += NextPageBtn_Click;
            // 
            // RandomBtn
            // 
            RandomBtn.Location = new Point(16, 503);
            RandomBtn.Name = "RandomBtn";
            RandomBtn.Size = new Size(218, 94);
            RandomBtn.TabIndex = 3;
            RandomBtn.Text = "Ăn gì đây taaa";
            RandomBtn.UseVisualStyleBackColor = true;
            RandomBtn.Click += button3_Click;
            // 
            // AddFood
            // 
            AddFood.Location = new Point(289, 503);
            AddFood.Name = "AddFood";
            AddFood.Size = new Size(218, 94);
            AddFood.TabIndex = 4;
            AddFood.Text = "Thêm món";
            AddFood.UseVisualStyleBackColor = true;
            AddFood.Click += button4_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(3, 8);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(484, 368);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint_1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(487, 369);
            flowLayoutPanel2.TabIndex = 0;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // FoodMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 610);
            Controls.Add(AddFood);
            Controls.Add(RandomBtn);
            Controls.Add(NextPageBtn);
            Controls.Add(PrevPageBtn);
            Controls.Add(tabControl1);
            Name = "FoodMenu";
            Text = "Chọn món ăn";
            tabControl1.ResumeLayout(false);
            allFood.ResumeLayout(false);
            userFood.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage allFood;
        private TabPage userFood;
        private Button PrevPageBtn;
        private Button NextPageBtn;
        private Button RandomBtn;
        private Button AddFood;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}