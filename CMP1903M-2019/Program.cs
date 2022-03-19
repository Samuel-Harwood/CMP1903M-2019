//Base code project for CMP1903M Assessment 1

using System;
using System.Collections.Generic;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Create 'Input' object
            //Get either manually entered text, or text from a file
            var input = new Input();


            // ask for input
            input.askInputMode();

            // handle input
            input.handleInput();

            Console.WriteLine(input.text);


            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method
            var analyse = new Analyse();


            //Receive a list of integers back
            var analysis = analyse.analyseText(input);


            //Report the results of the analysis
            var report = new Report();
            Console.WriteLine();
            // also output the report to report.txt
            Console.WriteLine("Writing analysis results to .\\report.txt...");
            report.outputStatsToPath(analysis, ".\\report.txt");
            Console.WriteLine();
            Console.WriteLine();
            // print the analysis result to console
            report.printInputStatsToConsole(analysis);



            //Get the frequency of individual letters
            var frequency = analyse.letterFrequency(input);
            Console.WriteLine();
            // outputting the lettter frequency to frequency.txt
            Console.WriteLine("Writing letter frequency results to .\\frequency.txt...");
            Console.WriteLine();
            Console.WriteLine();
            // print the letter frequency to console
            report.outputLetterFrequencyToConsole(frequency);
        } 
    }
}
