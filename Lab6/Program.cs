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
            Console.WriteLine("Welcome, to the pig latin translator");
            SentenceSplit();
            //Console.WriteLine(Exceptions());
        }

        static void SentenceSplit()
        {
            Console.WriteLine("Would you kindly write a sentence to be translated");
            string input = Console.ReadLine();
            input = ActuallyEnteredInput(input);
            //test
            //Console.WriteLine("the input entered is " + input);
            string[] seperators = { " " };
            string[] sentence = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            string word;

            for (int i = 0; i < sentence.Length; i++)
            {
                word = sentence[i];
                word = Exceptions(word);
                //test
                //Console.WriteLine(word);
                sentence[i] = word;
                //translatedSentence = translatedSentence.Concat(sentence[i]);
            }
            //Console.WriteLine(sentence[1]);
            Console.WriteLine(string.Concat(sentence));

            Repeat();
        }

        static string Exceptions(string word)
        {
            //word = word.ToLower();
            ////bool hasPunctuation;
            string punctuation;

            if ((word.EndsWith(".") || word.EndsWith(",")) || (word.EndsWith("!") || word.EndsWith("?")))
            {
                ////hasPunctuation = true;
                punctuation = word.Substring(word.Length - 1);
                word = word.Substring(0, word.Length - 1);
                //test
                //Console.WriteLine("hasPunctuation = " + hasPunctuation);
                //Console.WriteLine("punctuation = " + punctuation);
                word = Regulars(word);
                //runs Exceptions() again in case there are other special characters as well as having punctuation
                //Exceptions(word);
            }
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
                return (word + "way ");
            }
            else
            {
                return TranslateWord(word);
            }
        }

        static bool StartsAsVowel(string word)
        {
            char[] letters = word.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char vowel in vowels)
            {
                if (letters[0] == vowel)
                {
                    return true;
                }
            }
            return false;
        }

        //static string CaseCheck(string word)
        //{
        //    bool isUpperCase;
        //    char[] letters = word.ToCharArray();
        //    if (char.IsUpper(letters[0]))
        //    {
        //        isUpperCase = true;
        //    }
        //    else
        //    {
        //        isUpperCase = false;
        //    }
        //}

        static string TranslateWord(string word)
        {
            char[] letters = word.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
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

            word = secondHalfOfWord + firstHalfOfWord + "ay ";
            return word;
        }
        //repeat
        static void Repeat()
        {
            Console.WriteLine("Would you like to continue? (y/n)");
            char repeat = char.Parse(Console.ReadLine().ToUpper());
            if (repeat.Equals(Char.Parse("Y")))
            {
                SentenceSplit();
            }
            else
            {
                //Console.WriteLine("Ok goodbye");
                //Console.ReadLine();
            }
        }

        static string ActuallyEnteredInput(string input)
        {
            if (input.Length > 0)
            {
                Console.WriteLine("Translated is...");
                return input;
            }
            else
            {
                Console.WriteLine("I didn't detect any input, would you kindly try again");
                input = Console.ReadLine();
                 input = ActuallyEnteredInput(input);
            }
            return input;
        }
    }
}