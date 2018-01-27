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
            Console.WriteLine("Would you kindly enter a word");
            Console.WriteLine("I will translate it into pig latin");
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
            for (int i = 0; letters[].length; i++)
            {
                if (letters[i] == vowels[])
                int firstVowel = i;

            }
            string firstHalfOfWord = input.Substring(0,firstVowel);
            string secondHalfOfWord = input.Substring(firstVowel);

            string wordway = firstHalfOfWord + secondHalfOfWord;
            return wordway;
        }



        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Would you kindly type a word");
        //    Console.WriteLine("I will translate it into pig latin");
        //    string input = Console.ReadLine();

        //    input = input.ToLower();

        //    char[] letters = input.ToCharArray();
        //    PrintCharArray(letters);

        //    if (IsVowel(firstLetter))
        //    {
        //        input = input + "way";
        //    }
        //    else
        //    {

        //    }
            
        //}
        //public static void PrintCharArray(string letters)
        //{
        //    foreach (letter in letters)
        //    {
        //        Console.WriteLine(letter);
        //    }
        //}
        //public static bool IsVowel(char c)
        //    {
        //    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        //    foreach(char vowel in vowels)
        //    {
        //        if (c == vowels)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }
}


//convert to char array.ToLower
//check first letter is a vowel
//if yes {
// put "way" on the end of the word}
//else {
// iterate until a vowel is found}
//