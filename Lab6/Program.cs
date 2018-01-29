using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
//there can be 14 different types of inputs.
//word ends up having one of eleven different outputs.

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome, to the pig latin translator");
            SentenceSplit();
        }

        static void SentenceSplit()
        {
            Console.WriteLine("Would you kindly write a sentence to be translated");
            string input = Console.ReadLine();
            input = ActuallyEnteredInput(input);
            string[] seperators = { " " };
            string[] sentence = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            string word;

            for (int i = 0; i < sentence.Length; i++)
            {
                word = sentence[i];
                word = ExceptionsCase(word);
                sentence[i] = word;
            }
            Console.WriteLine(string.Concat(sentence));

            Repeat();
        }

        static string ExceptionsCase(string word)
        {
            bool isAllCaps = false;
            bool isTitleCase = false;
            char[] letters = word.ToCharArray();

            isAllCaps = IsAllCaps(letters);
            if (isAllCaps)
            {
                word = ExceptionsPunctuation(word, isAllCaps, isTitleCase);
            }
            else
            {
                if ((char.IsUpper(letters[0])) && (isAllCaps == false))
                {
                    isTitleCase = true;
                    //Console.WriteLine("input is title case");
                    //Console.WriteLine("input is not all lowercase");
                    word = ExceptionsPunctuation(word, isAllCaps, isTitleCase);
                }
                else
                {
                    word = ExceptionsPunctuation(word, isAllCaps, isTitleCase);
                }
            }
            return word;
        }

        static bool IsAllCaps(char[] letters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (char.IsLower(letters[i]))
                {
                    //Console.WriteLine("input is not all caps");
                    return false;
                }
            }
            //Console.WriteLine("input is all caps");
            return true;
        }


        static string ExceptionsPunctuation(string word, bool isAllCaps, bool isTitleCase)
        {
            //in case i can't figure out the casechecking, uncomment the below line.
            //word = word.ToLower();
            bool hasPunctuation = false;
            string punctuation;

            if ((word.EndsWith(".") || word.EndsWith(",")) || (word.EndsWith("!") || word.EndsWith("?")))
            {
                hasPunctuation = true;
                punctuation = word.Substring(word.Length - 1);
                word = word.Substring(0, word.Length - 1);
                //Console.WriteLine("hasPunctuation = " + hasPunctuation);
                //Console.WriteLine("punctuation = " + punctuation);
                //word = Exceptions(word);
                word = ExceptionsSpecialCharacters(word, hasPunctuation, isAllCaps, isTitleCase) + punctuation + "\n";
            }
            else
            {
                word = ExceptionsSpecialCharacters(word, hasPunctuation, isAllCaps, isTitleCase);
            }
            return word;
        }
        static string ExceptionsSpecialCharacters(string word, bool hasPunctuation, bool isAllCaps, bool isTitleCase)
        {
            if (Regex.IsMatch(word, "[!@#$%^&*()<>*_+1234567890]+"))
            {
                //Console.WriteLine("has special characters");
                return word;
            }
            else
            {
                word = Regulars(word, hasPunctuation, isAllCaps, isTitleCase);
            }
            return word;
        }

        static string Regulars(string word, bool hasPunctuation, bool isAllCaps, bool isTitleCase)
        {
            if (StartsAsVowel(word))
            {
                if (hasPunctuation == true)
                {
                    if (isAllCaps == true)
                    {
                        //Console.WriteLine("input starts with a vowel, ends with punctuation, doesn't have special characters, is all caps, is not titlecase");
                        return (word + "WAY");
                    }
                    else
                    {
                        //Console.WriteLine("input starts with a vowel, ends with punctuation, doesn't have special characters, is not all caps, is either titlecase or lowercase");
                        return (word + "way");
                    }
                }
                else
                {
                    if (isAllCaps == true)
                    {
                        //Console.WriteLine("input starts with a vowel, doesn't end with punctuation, doesn't have special characters, is all caps, is not titlecase");
                        return (word + "WAY ");
                    }
                    else
                    {
                        //Console.WriteLine("input starts with a vowel, doesn't end with punctuation, doesn't have special characters, is not all caps, is either titlecase or lowercase");
                        return (word + "way ");
                    }
                }
            }
            else
            {
                return TranslateWord(word, hasPunctuation, isAllCaps, isTitleCase);
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

        static string TranslateWord(string word, bool hasPunctuation, bool isAllCaps, bool isTitleCase)
        {
            char[] letters = word.ToCharArray();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int firstVowel = 0;
            bool stop = false;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < 10; j++)
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
            if (hasPunctuation == true)
            {
                if (isTitleCase == true)
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "ay";
                    word = word.ToLower();
                    word = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
                    //Console.WriteLine("input starts with a consonant, ends with punctuation, doesn't have special characters, is not all caps, is titlecase");
                    return word;

                }
                else if (isAllCaps)
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "AY";
                    //Console.WriteLine("input starts with a consonant, ends with punctuation, doesn't have special characters, is all caps, is not titlecase");
                    return word;
                }
                else
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "ay";
                    word = word.ToLower();
                    word = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
                    //Console.WriteLine("input starts with a consonant, ends with punctuation, doesn't have special characters, is not all caps, is not titlecase");
                    return word;
                }
            }
            else
            {
                if (isTitleCase == true)
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "ay ";
                    word = word.ToLower();
                    word = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
                    //Console.WriteLine("input starts with a consonant, does not end with punctuation, doesn't have special characters, is not all caps, is titlecase");
                    return word;
                }
                else if (isAllCaps)
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "AY ";
                    //Console.WriteLine("input starts with a consonant, does not end with punctuation, doesn't have special characters, is all caps, is not titlecase");
                    return word;
                }
                else
                {
                    string firstHalfOfWord = word.Substring(0, firstVowel);
                    string secondHalfOfWord = word.Substring(firstVowel);
                    word = secondHalfOfWord + firstHalfOfWord + "ay ";
                    //Console.WriteLine("input starts with a consonant, does not end with punctuation, doesn't have special characters, is not all caps, is not titlecase");
                    return word;
                }
            }

        }

        static string ActuallyEnteredInput(string input)
        {
            if (input.Length > 0)
            {
                Console.WriteLine("is translated to...");
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
    }
}
//code by Adam Tasma