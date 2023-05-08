using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.XPath;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace GeneratorDocs
{
    public partial class Form1 : Form
    {
        string[] russianWords; // ������� ����� ��� �������� ����
        string marks = " .,:;'\"-?!"; // ������ ������ ����������

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "Generated Docs\\"; // ������������� ���� � ����� �� ���������
        }

        private void pathButton_Click(object sender, EventArgs e) 
        {
            if (dialog.ShowDialog() == DialogResult.OK) // �������� ��������� ����
            {
                pathTextBox.Text = dialog.SelectedPath + "\\";
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if(russianWords == null) 
            {
                try
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // �������������� ������ ����
                    FileStream MainFile = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "russian.txt", FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(MainFile, Encoding.GetEncoding(1251))) 
                    {
                        russianWords = reader.ReadToEnd().Split('\n');
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("������ ������ �� �����, ��������� ���� russian.txt � ����� � �����������", "������!");
                    return;
                }
            }

            if (pathTextBox.Text.Length == 0) // �������� �� ������ ������
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
            }
            generateButton.Enabled = true;
        }

        private void GenerateDocs(string path, int docsCount, int wordCountMin, int wordCountMax)
        {
            Random random = new Random();
            var errorCount = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < docsCount; i++)
            {
                progressBar.Value = (int)Math.Round(i*100.0 / docsCount);
                try
                {
                    DocX document = DocX.Create(path + DateTime.Now.ToString("ddMMyy_HHmmss_ffff"));
                    Paragraph paragraph = document.InsertParagraph();
                    var wordCount = random.Next(wordCountMin, wordCountMax);
                    for (int j = 0; j < wordCount; j++)
                    {
                        var wordIndex = random.Next(0, russianWords.Length - 1);
                        var markIndex = (wordIndex + j) % (marks.Length - 1);
                        paragraph.Append(russianWords[wordIndex] + (markIndex != 0 ? marks[markIndex] + " " : " "));
                    }
                    document.Save();
                }
                catch(Exception ex) 
                { 
                    errorCount++; // ���������� ����� ��������������� ��������
                    continue; 
                }
            }

            stopwatch.Stop();
            progressBar.Value = 100;
            resultLabel.Text = $"������� {docsCount - errorCount} �� {docsCount}, ����������� �����: {stopwatch.ElapsedMilliseconds/1000.0} �";
            resultLabel.Location = new Point((this.Width - resultLabel.Width)/2, resultLabel.Location.Y);
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
            MessageBox.Show("   ������ ���������� ���� ������� � ������ ��������� ������� ��� �����������.\n" +
                            "   ��� ��������� ������ ���������� ������� ���� � �����, ��� ����� ����������� ���������, �� ����������, � ����� ���������� ���� � �������� ��������.\n" +
                            "   �� ��������� ������� ������� ����� ����������. ����� ������� ������ �������� ����� � ��� ���������� � ����� � �����������.\n" +
                            "   ������� ��������� ������ ������������ � ������ ����� ����������, ��� ���������� ��������� ���������� � ���������� ����� � ����������� ������.\n" +
                            "   ��� ���������� ��������� ���� ������������ ���������� DocX ��� ������ � �����������: https://github.com/xceedsoftware/DocX\n" +
                            "   � �������� ������ ������� ���� ��� ����������� ����, ��������� �� 1531464 �������: https://github.com/danakt/russian-words\n" +
                            "                                                                                                   alwaysbeearly", "� ���������...");
        }
    }
}