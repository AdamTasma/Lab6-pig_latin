using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome, to the pig latin translator");
            Console.WriteLine("Would you kindly enter a word");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (StartsAsVowel(input))
            {
                Console.WriteLine(input + "way");
            }
            else
            {
                TranslateWord(input);
            }
        }
        static bool StartsAsVowel(string input)
        {
            char[] letters = input.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vowels)
            {
                if (letters[0] == vowel)
                {
                    return true;
                }
            }
            return false;
        }
        public static string TranslateWord(string input)
        {
            char[] letters = input.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int firstVowel = 0;
            bool stop = false;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (letters[i] == vowels[j])
                    {
                        firstVowel = i;
                        Console.WriteLine("the first vowel is at index of " + i);
                        stop = true;
                    }
                }
                if (stop == true)
                {
                    break;
                }
            }
            string firstHalfOfWord = input.Substring(0, firstVowel);
            string secondHalfOfWord = input.Substring(firstVowel);

            string ordway = secondHalfOfWord + firstHalfOfWord + "ay";
            Console.WriteLine(ordway);
            return ordway;
        }
    }
}