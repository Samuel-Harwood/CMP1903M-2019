//Base code project for CMP1903M Assessment 1

using System;
using System.Collections.Generic;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            var input = new Input();

            Console.WriteLine("Please enter the text to analyse");
            // for this case, I'm just going to ask the user for the input
            input.manualTextInput();
            Console.WriteLine();


            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method
            var analyse = new Analyse();


            //Receive a list of integers back
            parameters = analyse.analyseText(input);


            //Report the results of the analysis
            var report = new Report();
            Console.WriteLine("Writing analysis results to .\\report.txt...");
            //report.outputToPath(parameters, ".\report.txt");
            Console.WriteLine();
            Console.WriteLine();
            report.outputConsole(parameters);


            //TO ADD: Get the frequency of individual letters?


        }
        
        
    
    }
}
