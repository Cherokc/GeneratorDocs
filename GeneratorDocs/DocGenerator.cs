using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace GeneratorDocs
{
    internal class DocGenerator
    {
        public string[] Words { get; set; }
        public string Separators { get; set; }

        private Random Random = new Random();

        public DocGenerator(string separators)
        {
            Separators = separators;
        }

        public DocGenerator(string[] words, string separators)
        {
            Words = words;
            Separators = separators;
        }

        public void CreateDocAndFill(string path, int wordCountMin, int wordCountMax)
        {
            var wordCount = Random.Next(wordCountMin, wordCountMax);
            StringBuilder sb = new StringBuilder();
            try
            {
                string uniquePart = Guid.NewGuid().ToString("N");
                DocX document = DocX.Create(path + DateTime.Now.ToString("ddMMyy_HHmmss_ffff") + "_" + uniquePart);
                for (int j = 0; j < wordCount; j++)
                {
                    var wordIndex = Random.Next(0, Words.Length - 1);
                    var sIndex = (wordIndex + j) % (Separators.Length - 1);
                    sb.Append(Words[wordIndex] + Separators[sIndex] + " ");
                }
                document.InsertParagraph(sb.ToString());
                document.Save();
            }
            catch(Exception ex) { }
        }

        public bool ReadWords(string path)
        {
            if (Words == null)
            {
                try
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // инициализируем массив слов
                    FileStream MainFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(MainFile, Encoding.GetEncoding(1251)))
                    {
                        Words = reader.ReadToEnd().Split('\n');
                    }
                }
                catch (Exception exception)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
