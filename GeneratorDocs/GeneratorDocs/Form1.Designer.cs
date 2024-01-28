namespace GeneratorDocs
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateButton = new System.Windows.Forms.Button();
            this.pathButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.countUpDown = new System.Windows.Forms.NumericUpDown();
            this.wordCountLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxUpDown = new System.Windows.Forms.NumericUpDown();
            this.dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.separatorsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wordSetTextBox = new System.Windows.Forms.TextBox();
            this.wordSetButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.файлToolStripMenuItem.Text = "Приложение";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.info_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(199, 367);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(130, 30);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Сгенерировать!";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(492, 80);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(28, 28);
            this.pathButton.TabIndex = 3;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 81);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(474, 27);
            this.pathTextBox.TabIndex = 4;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(64, 45);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(407, 20);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Выберите путь к папке, где будут генерироваться файлы.";
            // 
            // countLabel
            // 
            this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(64, 236);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(316, 20);
            this.countLabel.TabIndex = 6;
            this.countLabel.Text = "Выберите количество создаваемых файлов:";
            // 
            // countUpDown
            // 
            this.countUpDown.Location = new System.Drawing.Point(386, 234);
            this.countUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countUpDown.Name = "countUpDown";
            this.countUpDown.Size = new System.Drawing.Size(85, 27);
            this.countUpDown.TabIndex = 7;
            this.countUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // wordCountLabel
            // 
            this.wordCountLabel.AutoSize = true;
            this.wordCountLabel.Location = new System.Drawing.Point(48, 288);
            this.wordCountLabel.Name = "wordCountLabel";
            this.wordCountLabel.Size = new System.Drawing.Size(444, 20);
            this.wordCountLabel.TabIndex = 8;
            this.wordCountLabel.Text = "Выберите минимальное и максимальное число слов в файле:";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(48, 327);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(37, 20);
            this.minLabel.TabIndex = 9;
            this.minLabel.Text = "Min:";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(293, 327);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(40, 20);
            this.maxLabel.TabIndex = 10;
            this.maxLabel.Text = "Max:";
            // 
            // minUpDown
            // 
            this.minUpDown.Location = new System.Drawing.Point(91, 325);
            this.minUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minUpDown.Name = "minUpDown";
            this.minUpDown.Size = new System.Drawing.Size(150, 27);
            this.minUpDown.TabIndex = 11;
            this.minUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minUpDown.ValueChanged += new System.EventHandler(this.checkMinMax);
            // 
            // maxUpDown
            // 
            this.maxUpDown.Location = new System.Drawing.Point(339, 325);
            this.maxUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxUpDown.Name = "maxUpDown";
            this.maxUpDown.Size = new System.Drawing.Size(150, 27);
            this.maxUpDown.TabIndex = 12;
            this.maxUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxUpDown.ValueChanged += new System.EventHandler(this.checkMinMax);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(48, 403);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(444, 29);
            this.progressBar.TabIndex = 13;
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(174, 379);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 20);
            this.resultLabel.TabIndex = 15;
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Разделители слов:";
            // 
            // separatorsTextBox
            // 
            this.separatorsTextBox.Location = new System.Drawing.Point(276, 196);
            this.separatorsTextBox.Name = "separatorsTextBox";
            this.separatorsTextBox.Size = new System.Drawing.Size(139, 27);
            this.separatorsTextBox.TabIndex = 17;
            this.separatorsTextBox.Text = " \",.-?!\':;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Выберите путь к файлу, содержащий набор слов.";
            // 
            // wordSetTextBox
            // 
            this.wordSetTextBox.Location = new System.Drawing.Point(12, 157);
            this.wordSetTextBox.Name = "wordSetTextBox";
            this.wordSetTextBox.Size = new System.Drawing.Size(474, 27);
            this.wordSetTextBox.TabIndex = 19;
            // 
            // wordSetButton
            // 
            this.wordSetButton.Location = new System.Drawing.Point(492, 156);
            this.wordSetButton.Name = "wordSetButton";
            this.wordSetButton.Size = new System.Drawing.Size(28, 28);
            this.wordSetButton.TabIndex = 18;
            this.wordSetButton.Text = "...";
            this.wordSetButton.UseVisualStyleBackColor = true;
            this.wordSetButton.Click += new System.EventHandler(this.wordSetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 482);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wordSetTextBox);
            this.Controls.Add(this.wordSetButton);
            this.Controls.Add(this.separatorsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.maxUpDown);
            this.Controls.Add(this.minUpDown);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.wordCountLabel);
            this.Controls.Add(this.countUpDown);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Генератор документов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.checkMinMax);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem помощьToolStripMenuItem;
        private Button generateButton;
        private Button pathButton;
        private TextBox pathTextBox;
        private Label pathLabel;
        private Label countLabel;
        private NumericUpDown countUpDown;
        private Label wordCountLabel;
        private Label minLabel;
        private Label maxLabel;
        private NumericUpDown minUpDown;
        private NumericUpDown maxUpDown;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private FolderBrowserDialog dialog;
        private ProgressBar progressBar;
        private Label resultLabel;
        private Label label1;
        private TextBox separatorsTextBox;
        private Label label2;
        private TextBox wordSetTextBox;
        private Button wordSetButton;
        private OpenFileDialog openFileDialog1;
    }
}