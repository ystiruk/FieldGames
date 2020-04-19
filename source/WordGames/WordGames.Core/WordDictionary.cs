using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordGames.Core
{
    public class WordDictionary : IWordProvider
    {
        private const string _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public List<string> Words { get; }

        public WordDictionary(string path)
        {
            Words = new List<string>();

            using (var sReader = new StreamReader(path, Encoding.UTF8))
                while (!sReader.EndOfStream)
                    Words.Add(sReader.ReadLine());
        }

        public bool Contains(string word)
        {
            return Words.Contains(word);
        }

        public bool StartsWith(string prefix)
        {
            return Words.Any(w => w.StartsWith(prefix));
        }
    }
}
