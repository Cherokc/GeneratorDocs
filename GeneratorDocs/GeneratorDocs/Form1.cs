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
            pathTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "Created Files\\"; // устанавливаем путь к папке по умолчанию
            wordSetTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "russian.txt"; // устанавливаем путь к папке по умолчанию
        }

        private void pathButton_Click(object sender, EventArgs e) 
        {
            if (dialog.ShowDialog() == DialogResult.OK) // получаем выбранный путь
            {
                pathTextBox.Text = dialog.SelectedPath + "\\";
            }
        }

        private void wordSetButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // получаем выбранный путь
            {
                wordSetTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (!DC.ReadWords(wordSetTextBox.Text))
            {
                MessageBox.Show("Ошибка чтения из файла, проверьте указанный файл", "Ошибка!");
                return;
            }

            if (!CheckPathTextBox(pathTextBox.Text))
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

                generateButton.Enabled = true;
            }
        }

        private bool CheckPathTextBox(string path)
        {
            if (path.Length == 0) // проверка на пустую строку
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
            resultLabel.Text = $"Создано {docsCount - tasks.Where(s => s.IsFaulted).Count()} из {docsCount}, затраченное время: {stopwatch.ElapsedMilliseconds / 1000.0} с";
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
            MessageBox.Show("   Для генерации файлов необходимо указать путь к папке, где будут создаваться документы, их количество, а также количество слов в заданных пределах.\n" +
                            "   По умолчанию указана рабочая папка приложения. Можно указать просто название папки и она создасться в папке с приложением.\n" +
                            "   Процесс генерации файлов отображается в нижней части приложения, где расположен индикатор выполнения и появляется текст о выполненной работе.\n" +
                            "   Для реализации программы была использована библиотека DocX для работы с документами: https://github.com/xceedsoftware/DocX\n" +
                            "   В качестве списка русских слов был использован файл, состоящий из 1531464 записей: https://github.com/danakt/russian-words\n" +
                            "                                                                                                   alwaysbeearly", "О программе...");
        }


    }
}