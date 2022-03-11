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

        public void outputConsole(List<int> values)
        {
            printAnalysisHeader();

            Console.WriteLine(valuesToReport(values));

            printAnalysisFooter();
        }

        public void outputToPath(List<int> values, string path)
        {
            File.WriteAllText(path, valuesToReport(values));
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
