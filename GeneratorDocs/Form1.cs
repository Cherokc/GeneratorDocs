using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.XPath;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace GeneratorDocs
{
    public partial class Form1 : Form
    {
        DocGenerator DC;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DC = new DocGenerator(separatorsTextBox.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "Created Files\\"; // ������������� ���� � ����� �� ���������
            wordSetTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "russian.txt"; // ������������� ���� � ����� �� ���������
        }

        private void pathButton_Click(object sender, EventArgs e) 
        {
            if (dialog.ShowDialog() == DialogResult.OK) // �������� ��������� ����
            {
                pathTextBox.Text = dialog.SelectedPath + "\\";
            }
        }

        private void wordSetButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // �������� ��������� ����
            {
                wordSetTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (!DC.ReadWords(wordSetTextBox.Text))
            {
                MessageBox.Show("������ ������ �� �����, ��������� ��������� ����", "������!");
                return;
            }

            if (!CheckPathTextBox(pathTextBox.Text))
            {
                MessageBox.Show("��������� ������������ ����");
                return;
            }

                
            if (MessageBox.Show("�� �������?", "�������������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                generateButton.Enabled = false;
                var path = pathTextBox.Text + (pathTextBox.Text.Last() != '\\' ? "\\" : ""); // �������� �� ������, ���� ���� ������ ��� ��������� �����

                try
                {
                    Directory.CreateDirectory(path); // ������� ��������� �����
                }
                catch(Exception exception)
                {
                    MessageBox.Show("�� ������� ������� ��� ����� ��������� �����");
                    return;
                }

                int count = (int)countUpDown.Value;
                int min = (int)minUpDown.Value;
                int max = (int)maxUpDown.Value;
                GenerateDocs(path, count, min, max);

                generateButton.Enabled = true;
            }
        }

        private bool CheckPathTextBox(string path)
        {
            if (path.Length == 0) // �������� �� ������ ������
            {
                return false;
            }
            return true;
        }

        private async void GenerateDocs(string path, int docsCount, int wordCountMin, int wordCountMax)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            progressBar.Value = 0;

            Task[] tasks = new Task[docsCount];
            for (int i = 0; i < docsCount; i++)
            {
                tasks[i] = Task.Run(() => DC.CreateDocAndFill(path, wordCountMin, wordCountMax));
            }

            UpdateProgressBar(tasks, docsCount);

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            progressBar.Value = 100;
            resultLabel.Text = $"������� {docsCount - tasks.Where(s => s.IsFaulted).Count()} �� {docsCount}, ����������� �����: {stopwatch.ElapsedMilliseconds / 1000.0} �";
            resultLabel.Location = new Point((this.Width - resultLabel.Width) / 2, Height - 90);
        }

        private async void UpdateProgressBar(Task[] tasks, int docsCount)
        {
            while (!tasks.All(task => task.IsCompleted))
            {
                int completedTasks = tasks.Count(task => task.IsCompleted);
                int progressValue = (int)((double)completedTasks / docsCount * 100);

                progressBar.Value = progressValue;

                await Task.Delay(10);
            }
        }

        private void checkMinMax(object sender, EventArgs e)
        {
            if (minUpDown.Value > maxUpDown.Value)
                minUpDown.Value = maxUpDown.Value;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("   ��� ��������� ������ ���������� ������� ���� � �����, ��� ����� ����������� ���������, �� ����������, � ����� ���������� ���� � �������� ��������.\n" +
                            "   �� ��������� ������� ������� ����� ����������. ����� ������� ������ �������� ����� � ��� ���������� � ����� � �����������.\n" +
                            "   ������� ��������� ������ ������������ � ������ ����� ����������, ��� ���������� ��������� ���������� � ���������� ����� � ����������� ������.\n" +
                            "   ��� ���������� ��������� ���� ������������ ���������� DocX ��� ������ � �����������: https://github.com/xceedsoftware/DocX\n" +
                            "   � �������� ������ ������� ���� ��� ����������� ����, ��������� �� 1531464 �������: https://github.com/danakt/russian-words\n" +
                            "                                                                                                   alwaysbeearly", "� ���������...");
        }


    }
}