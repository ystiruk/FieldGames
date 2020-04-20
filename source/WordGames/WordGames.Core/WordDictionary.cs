using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordGames.Core
{
    public class WordDictionary : IWordProvider
    {
        private readonly Dictionary<char, List<string>> _wordsByLetter;

        public List<string> Words { get; }

        public WordDictionary(string path)
        {
            Words = new List<string>();

            using (var sReader = new StreamReader(path, Encoding.UTF8))
                while (!sReader.EndOfStream)
                    Words.Add(sReader.ReadLine());
            
            Words.Sort();

            _wordsByLetter = Words
                .GroupBy(x => x[0])
                .ToDictionary(k => k.Key, v => v.OrderBy(x => x).ToList());
        }

        public bool Contains(string word)
        {
            var foundIndex = Words.BinarySearch(word);
            return (foundIndex >= 0);
        }

        public bool StartsWith(string prefix)
        {
            char firstLetter = prefix[0];

            List<string> words;
            if (!_wordsByLetter.TryGetValue(firstLetter, out words))
                return false;

            return words.Any(w => w.StartsWith(prefix));
        }
    }
}
