using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sandbox
{
    class WordDictionary
    {
        private const string _alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        //private readonly WordsBoundaries[] searchBoundaries;

        public List<string> Words { get; }

        public WordDictionary(string path)
        {
            Words = new List<string>();

            using (var sReader = new StreamReader(path, Encoding.UTF8))
                while (!sReader.EndOfStream)
                    Words.Add(sReader.ReadLine());

            //int[] positions = Enumerable.Repeat(-1, _alphabet.Length).ToArray();
            //for (int i = 0; i < _alphabet.Length; i++)
            //{
            //    for (int j = 0; j < Words.Count; j++)
            //    {
            //        var firstLetter = Words[j][0];
            //        if (firstLetter == _alphabet[i])
            //        {
            //            positions[i] = j;
            //            break;
            //        }
            //    }
            //}

            //searchBoundaries = new WordsBoundaries[_alphabet.Length];
        }
    }

    //struct WordsBoundaries
    //{
    //    public char Letter { get; }
    //    public int StartIndex { get; }
    //    public int EndIndex { get; }

    //    public WordsBoundaries(char letter, int start, int end)
    //    {
    //        if (start >= end)
    //            throw new ArgumentException($"Start position cannot be greater that End position.");

    //        Letter = letter;
    //        StartIndex = start;
    //        EndIndex = end;
    //    }
    //}
}
