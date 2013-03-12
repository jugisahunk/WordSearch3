using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordSearch2
{
    internal class Puzzle
    {
        List<string> Zero, FortyFive, Ninety, OneThirtyFive, inputWords;

        internal void Process (string inputDataFilePath, StreamWriter outFile, string inputWordsFilePath){

            Zero = inputWords = ExtractDataRows(inputWordsFilePath);

            inputWords.Sort(new DescendingComparer());

            string inputData = ExtractData(inputDataFilePath);

            int rowCount, columnCount;

            columnCount = inputData.IndexOf("\r\n");
            inputData = inputData.Replace("\r\n", String.Empty);

            if (inputData.Length % columnCount != 0)
                throw new ArgumentException("Jagged array found.");

            rowCount = inputData.Length / columnCount;
        }

        List<string> GetRotatedList(List<string> list)
        {
            return null;
        }

        internal List<string> ExtractDataRows(string filePath)
        {
            List<string> inputRows = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    inputRows.Add(reader.ReadLine());
            }

            return inputRows;
        }

        internal string ExtractData(string filePath)
        {
            string input;
            using (StreamReader reader = new StreamReader(filePath))
            {
                input = reader.ReadToEnd();
            }

            return input;
        }
    }
}
