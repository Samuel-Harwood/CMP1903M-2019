using System;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    public enum InputMode
    {
        Manual,
        TextFile,
    }

    public class Input
    {

        // text from user, either being manual input or text file
        string _text;
        public string text { get { return _text; } }

        // "input mode" for getting text
        InputMode _inputMode;
        InputMode inputMode { get { return _inputMode; } }

        // default parameters
        public Input()
        {
            _inputMode = InputMode.Manual;
            _text = "";
        }

        //Handles the text input for Assessment 1

        // Method: manualTextInput
        // Arguments: none
        // Sets the text string inside the input class
        public void manualTextInput()
        {
            _text = Console.ReadLine();

            if (text == null)
            {
                _text = "";
            }
        }

        public void handleInput()
        {
            switch (_inputMode)
            {
                case InputMode.Manual:
                    Console.WriteLine("Please enter the text to analyse");
                    manualTextInput();
                    break;
                case InputMode.TextFile:
                    Console.WriteLine("Enter the path for the text file: ");
                    string path;

                    while (true)
                    {
                        path = Console.ReadLine();
                        if (File.Exists(path))
                        {
                            break;
                        } else
                        {
                            Console.WriteLine("File not found, try again: ");
                        }
                    }

                    fileTextInput(path);
                    break;
                default:
                    throw new Exception("Unimplented input mode");
            }
        }

        public void askInputMode()
        {
            Console.WriteLine("Please write 'm' for manual input, or 'f' for file input");
            
            while (true)
            {
                var input = Console.ReadLine();
                var input_clean = input.ToLower().Trim();

                var input_check_ok = false;

                switch (input_clean)
                {
                    case "m":
                        _inputMode = InputMode.Manual;
                        input_check_ok = true;
                        break;
                    case "f":
                        _inputMode = InputMode.TextFile;
                        input_check_ok = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input mode, please try again");
                        input_check_ok=false;
                        break;
                }

                if (input_check_ok)
                {
                    break;
                }
            }
        }

        // Method: fileTextInput
        // Arguments: string (the file path)
        // Sets the text of the input class
        // Gets text input from a .txt file
        public void fileTextInput(string fileName)
        {
            _text = File.ReadAllText(fileName);
        }
    }
}
