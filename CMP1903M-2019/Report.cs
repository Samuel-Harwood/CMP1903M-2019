using System;
using System.Collections.Generic;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

        // prints result of analysis to the console
        public void printInputStatsToConsole(List<int> values)
        {
            printAnalysisHeader();
            Console.WriteLine("stats of the input:");

            Console.WriteLine(valuesToReport(values));

            printAnalysisFooter();
        }

        // outputs the analysis of the input to a file path
        public void outputStatsToPath(List<int> values, string path)
        {
            File.WriteAllText(path, valuesToReport(values));
        }

        // writes frequency of the letters to the console
        public void outputLetterFrequencyToConsole(List<int> frequency)
        {
            printAnalysisHeader();
            Console.WriteLine("frequency of letters: ");

            Console.WriteLine(letterFrequencyToReport(frequency));

            printAnalysisFooter();
        }

        public void outputLetterFrequencyToPath(List<int> frequency, string path)
        {
            File.WriteAllText(path, letterFrequencyToReport(frequency));
        }

        // method that converts the frequency list into a humal readable analysis report
        static string letterFrequencyToReport(List<int> frequency)
        {
            var a_value = (int)'a';

            var frequency_string = new List<string>();

            for (int i = 0; i < frequency.Count; i++)
            {
                var ch = (char)(i + a_value);
                var count = frequency[i];

                frequency_string.Add(char.ToUpper(ch) + ": " + count);
            }

            return string.Join(", ", frequency_string);
        }

        // method that converts the values format into a human readable analysis report
        static string valuesToReport(List<int> values)
        {
            var values_string = new List<string>();

            values_string.Add("there are " + values[0] + " sentences");
            values_string.Add("there are " + values[1] + " vowels");
            values_string.Add("there are " + values[2] + " consonants");
            values_string.Add("there are " + values[3] + " upper case letters");
            values_string.Add("there are " + values[4] + " lower case letters");

            return string.Join('\n', values_string);
        }

        // method that will print the analysis report header
        static void printAnalysisHeader()
        {
            Console.WriteLine("Analysis report...\n");
        }

        // method that will print the analysis report footer
        static void printAnalysisFooter()
        {
            Console.WriteLine("\n... Analysis report end");
        }
    }
}
