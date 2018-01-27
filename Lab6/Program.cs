using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            bool hasPunctuation;
            string punctuation;

            Console.WriteLine("Welcome, to the pig latin translator");
            Console.WriteLine(Exceptions());

        }

        static string Exceptions()
        {
            Console.WriteLine("Would you kindly enter a word");
            string word = Console.ReadLine();
            //word = word.ToLower();
            bool hasPunctuation;
            string punctuation;

            if ((word.EndsWith(".") || word.EndsWith(",")) || (word.EndsWith("!") || word.EndsWith("?")))
            {
                hasPunctuation = true;
                punctuation = word.Substring(word.Length - 1);
                word = word.Substring(0, word.Length - 1);
                //Console.WriteLine("hasPunctuation = " + hasPunctuation);
                //Console.WriteLine("punctuation = " + punctuation);
                word = Regulars(word);
                //runs Exceptions() again in case there are other special characters as well as having punctuation
                //Exceptions(word);
            }
            //else if ((Regex.IsMatch(word, "[a-zA-Z ]\d{word.Length}+")))
            else if (Regex.IsMatch(word, "[!@#$%^&*()<>*_+1234567890]+"))
            {
                Console.WriteLine("has special characters");
                return word;
            }
            else 
            {
                word = Regulars(word);
            }
            return word;
        }

        static string Regulars(string word)
        {
            if (StartsAsVowel(word))
            {
                //Console.WriteLine(word + "way");
                return (word + "way");
            }
            else
            {
                return TranslateWord(word);
            }
        }

        static bool StartsAsVowel(string word)
        {
            char[] letters = word.ToCharArray();
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

        public static string TranslateWord(string word)
        {
            char[] letters = word.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int firstVowel = 0;
            bool stop = false;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (letters[i] == vowels[j])
                    {
                        firstVowel = i;
                        //Console.WriteLine("the first vowel is at index of " + i);
                        stop = true;
                    }
                }
                if (stop == true)
                {
                    break;
                }
            }
            string firstHalfOfWord = word.Substring(0, firstVowel);
            string secondHalfOfWord = word.Substring(firstVowel);

            word = secondHalfOfWord + firstHalfOfWord + "ay";
            return word;
        }
    }
}