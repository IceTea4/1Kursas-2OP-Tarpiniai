using System;

namespace Raides
{
    /** To count letters frequency
    class LettersFrequency
    {
        private const int CMax = 382;
        private int[] Frequency; // Frequency of letters
        public string line { get; set; }

        public LettersFrequency()
        {
            line = "";
            Frequency = new int[CMax];

            for (int i = 0; i < CMax; i++)
            {
                Frequency[i] = 0;
            }
        }

        public int Get(char character)
        {
            return Frequency[character];
        }

        /** Counts repetition of letters.
        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (('a' <= line[i] && line[i] <= 'z') || ('A' <= line[i] && line[i] <= 'Z') || ('Ą' <= line[i] && line[i] <= 'ž'))
                {
                    Frequency[line[i]]++;
                }
            }
        }
    }
    */
}

