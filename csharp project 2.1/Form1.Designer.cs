namespace csharp_project_2._1
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
            this.wynikButton = new System.Windows.Forms.Button();
            this.dzielnatextBox = new System.Windows.Forms.TextBox();
            this.dzielnikTextBox = new System.Windows.Forms.TextBox();
            this.wynikTextBox = new System.Windows.Forms.TextBox();
            this.znakLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wynikButton
            // 
            this.wynikButton.Location = new System.Drawing.Point(473, 182);
            this.wynikButton.Name = "wynikButton";
            this.wynikButton.Size = new System.Drawing.Size(75, 23);
            this.wynikButton.TabIndex = 0;
            this.wynikButton.Text = "=";
            this.wynikButton.UseVisualStyleBackColor = true;
            this.wynikButton.Click += new System.EventHandler(this.wynikButton_Click);
            // 
            // dzielnatextBox
            // 
            this.dzielnatextBox.Location = new System.Drawing.Point(101, 183);
            this.dzielnatextBox.Name = "dzielnatextBox";
            this.dzielnatextBox.Size = new System.Drawing.Size(100, 23);
            this.dzielnatextBox.TabIndex = 1;
            this.dzielnatextBox.TextChanged += new System.EventHandler(this.dzielnatextBox_TextChanged);
            // 
            // dzielnikTextBox
            // 
            this.dzielnikTextBox.Location = new System.Drawing.Point(305, 183);
            this.dzielnikTextBox.Name = "dzielnikTextBox";
            this.dzielnikTextBox.Size = new System.Drawing.Size(100, 23);
            this.dzielnikTextBox.TabIndex = 2;
            this.dzielnikTextBox.TextChanged += new System.EventHandler(this.dzielnikTextBox_TextChanged);
            // 
            // wynikTextBox
            // 
            this.wynikTextBox.Location = new System.Drawing.Point(613, 183);
            this.wynikTextBox.Name = "wynikTextBox";
            this.wynikTextBox.Size = new System.Drawing.Size(100, 23);
            this.wynikTextBox.TabIndex = 3;
            this.wynikTextBox.TextChanged += new System.EventHandler(this.wynikTextBox_TextChanged);
            // 
            // znakLabel
            // 
            this.znakLabel.AutoSize = true;
            this.znakLabel.Location = new System.Drawing.Point(249, 186);
            this.znakLabel.Name = "znakLabel";
            this.znakLabel.Size = new System.Drawing.Size(10, 15);
            this.znakLabel.TabIndex = 4;
            this.znakLabel.Text = ":";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.znakLabel);
            this.Controls.Add(this.wynikTextBox);
            this.Controls.Add(this.dzielnikTextBox);
            this.Controls.Add(this.dzielnatextBox);
            this.Controls.Add(this.wynikButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private Button wynikButton;
        private TextBox dzielnatextBox;
        private TextBox dzielnikTextBox;
        private TextBox wynikTextBox;
        private Label znakLabel;
    }
}