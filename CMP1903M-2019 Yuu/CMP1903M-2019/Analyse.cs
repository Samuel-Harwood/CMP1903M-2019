using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(Input input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters


            //Initialise all the values in the list to '0'
            List<int> values = new List<int>(new int[5]);




            // counter number of sentences
            values[0] = numberOfSentences(input.text);

            // count number of vowels
            values[1] = numberOfVowels(input.text);

            // count number of consonants
            values[2] = numberOfConsonants(input.text);

            // count number of upper case letters
            values[3] = numberOfUpperCaseLetters(input.text);

            // count number of lower case letters
            values[4] = numberOfLowerCaseLetters(input.text);

            longWords(input.text); //Runs the longwords method. Was unsure how to send it to Report :)


            return values;
        }

        int numberOfSentences(string text)
        {
            var sentences = text.Split('.').ToList();

            // remove worthless trash
            for (int i = sentences.Count - 1; i > -1; i--)
            {
                var sentence = sentences[i];

                if (string.IsNullOrWhiteSpace(sentence))
                {
                    sentences.RemoveAt(i);
                }
            }

            var sentence_count = 0;
            if (sentences != null)
            {
                sentence_count = sentences.Count();
            }

            return sentence_count;
        }

        int numberOfVowels(string text)
        {
            var vowel_count = 0;

            foreach (var ch in text.ToCharArray())
            {
                if (isAVowel(ch))
                {
                    vowel_count++;
                }
            }

            return vowel_count;
        }

        bool isAVowel(char ch)
        {
            var vowel_list = new char[] { 'a', 'i', 'u', 'e', 'o' };

            return vowel_list.Contains(char.ToLower(ch));
        }

        int numberOfConsonants(string text)
        {
            var consonants = 0;

            foreach (var ch in text.ToCharArray())
            {
                if (char.IsLetter(ch) && !isAVowel(ch))
                {
                    consonants++;
                }
            }

            return consonants;
        }

        int numberOfUpperCaseLetters(string text)
        {
            var upper_case_count = 0;

            foreach (var ch in text.ToCharArray())
            {
                if (char.IsUpper(ch))
                {
                    upper_case_count++;
                }
            }

            return upper_case_count;
        }

        int numberOfLowerCaseLetters(string text)
        {
            var lower_case_count = 0;

            foreach (var ch in text.ToCharArray())
            {
                if (char.IsLower(ch))
                {
                    lower_case_count++;
                }
            }

            return lower_case_count;
        }


        // counts and returns the frequency of each letter from the input
        public List<int> letterFrequency(Input input)
        {
            var letter_count = new List<int>(new int[26]);
            var a_value = (int)'a';

            foreach (var ch in input.text.ToCharArray())
            {
                if (char.IsWhiteSpace(ch) || !char.IsLetter(ch))
                {
                    continue;
                }

                var ch_clean = char.ToLower(ch);

                var ch_clean_value = (int)ch_clean;

                letter_count[ch_clean_value - a_value]++;
            }

            return letter_count;
        }

        // All words > 7 characters long, saved to .txt file.
        /*punctuation should be removed so only words greater than 7 characters are sent to the text file.
        e.g. Abacus? = 6 words, 7 characters 
        I however couldn't implement this the way I have done it in my code as I use a different .Net Framework
        and newer version of VS code. 
        */
        void longWords(string input) //Void as it's not sent to Report.cs
        {
            string[] longest = input.Split(new[] { " " },System.StringSplitOptions.None); //Creating a new string array of split words
            string longword = "";
            int max = 0;
            List<string> longwords = new List<string>(); //Holds all words > 7 characters.

            foreach (string seven in longest)
            {

                if (seven.Length >= 7)
                {

                    longword = seven;
                    max = seven.Length;
                    longwords.Add(longword);

                }
            }
            System.IO.File.WriteAllLines(".\\Longwords.txt", longwords); //Sends Longwords.txt to \bin\Debug\netcoreapp3.1
        }

    }
}

