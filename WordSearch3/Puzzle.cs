using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordSearch2
{
    internal class Puzzle
    {
        int RowCount, ColumnCount;
        List<string> Zero, FortyFive, Ninety, OneThirtyFive, inputWords;

        internal void Process (string inputDataFilePath, StreamWriter outFile, string inputWordsFilePath){

            inputWords = ExtractDataRows(inputWordsFilePath);
            Zero = ExtractDataRows(inputDataFilePath);

            inputWords.Sort(new DescendingComparer());

            ColumnCount = Zero[0].Length;
            RowCount = Zero.Count();

            Zero = ExtractDataRows(inputDataFilePath);
            FortyFive = GetFortyFive(Zero);
            Ninety = GetNinety(Zero);
            OneThirtyFive = GetOneThirtyFive(Zero);
        }

        List<string> GetFortyFive(List<string> list)
        {
            int x, y;
            List<string> fortyFive = new List<string>();
            
            for (int i = 0; i < ColumnCount; i++)
            {
                x = 0; y = i;

                char[] rowChars = new Char[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    rowChars[j] = Zero[x][y];
                    x++; y--;
                }
                fortyFive.Add(new String(rowChars));
            }

            for (int i = 1; i < RowCount; i++)
            {
                x = ColumnCount - 1; y = i;
                
                char[] rowChars = new Char[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    rowChars[j] = Zero[x][y];
                    x--; y++;
                }

                fortyFive.Add(new String(rowChars));
            }

            return fortyFive;
        }

        internal List<string> GetNinety(List<string> list)
        {
            List<string> ninety = new List<string>();

            for (int i = 0; i < ColumnCount; i++)
            {
                char[] verticalRow = new char[RowCount];
                for (int j = 0; j < RowCount; j++)
                    verticalRow[j] = list[i][j];

                ninety.Add(new String(verticalRow));
            }

            return ninety;
        }

        internal List<string> GetOneThirtyFive(List<string> list)
        {
            int x, y;
            List<string> oneThirtyFive = new List<string>();

            for (int i = 0; i < ColumnCount; i++)
            {
                x = i; y = ColumnCount - 1;

                char[] rowChars = new Char[x + 1];
                for (int j = 0; j <= i; j++)
                {
                    rowChars[j] = Zero[x][y];
                    x--; y--;
                }
                oneThirtyFive.Add(new String(rowChars));
            }

            for (int i = 1; i < RowCount; i++)
            {
                x = ColumnCount - 1; y = RowCount - 1 - i;

                char[] rowChars = new Char[y + 1];
                for (int j = 0; j <= i; j++)
                {
                    rowChars[j] = Zero[x][y];
                    x--; y--;
                }

                oneThirtyFive.Add(new String(rowChars));
            }

            return oneThirtyFive;
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
