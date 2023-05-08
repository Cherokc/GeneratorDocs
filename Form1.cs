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
        string[] russianWords; // будущее место под хранение слов
        string marks = " .,:;'\"-?!"; // массив знаков пунктуации

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "Generated Docs\\"; // устанавливаем путь к папке по умолчанию
        }

        private void pathButton_Click(object sender, EventArgs e) 
        {
            if (dialog.ShowDialog() == DialogResult.OK) // получаем выбранный путь
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
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // инициализируем массив слов
                    FileStream MainFile = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "russian.txt", FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(MainFile, Encoding.GetEncoding(1251))) 
                    {
                        russianWords = reader.ReadToEnd().Split('\n');
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка чтения из файла, проверьте файл russian.txt в папке с приложением", "Ошибка!");
                    return;
                }
            }

            if (pathTextBox.Text.Length == 0) // проверка на пустую строку
            {
                MessageBox.Show("Проверьте правильность пути");
                return;
            }
                
            if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                generateButton.Enabled = false;
                var path = pathTextBox.Text + (pathTextBox.Text.Last() != '\\' ? "\\" : ""); // проверка на случай, если путь указан без обратного слеша

                try
                {
                    Directory.CreateDirectory(path); // создаем указанную папку
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Не удалось создать или найти указанную папку");
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
                    errorCount++; // запоминаем число несовершившихся созданий
                    continue; 
                }
            }

            stopwatch.Stop();
            progressBar.Value = 100;
            resultLabel.Text = $"Создано {docsCount - errorCount} из {docsCount}, затраченное время: {stopwatch.ElapsedMilliseconds/1000.0} с";
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
            MessageBox.Show("   Данное приложение было создано в рамках тестового задания для практиканта.\n" +
                            "   Для генерации файлов необходимо указать путь к папке, где будут создаваться документы, их количество, а также количество слов в заданных пределах.\n" +
                            "   По умолчанию указана рабочая папка приложения. Можно указать просто название папки и она создасться в папке с приложением.\n" +
                            "   Процесс генерации файлов отображается в нижней части приложения, где расположен индикатор выполнения и появляется текст о выполненной работе.\n" +
                            "   Для реализации программы была использована библиотека DocX для работы с документами: https://github.com/xceedsoftware/DocX\n" +
                            "   В качестве списка русских слов был использован файл, состоящий из 1531464 записей: https://github.com/danakt/russian-words\n" +
                            "                                                                                                   alwaysbeearly", "О программе...");
        }
    }
}