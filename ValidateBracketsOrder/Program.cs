﻿/**
* Given a string containing a combination of parentheses and brackets, determine if they open/close in the correct order.
* []{}()<> are all valid.
* ie: "{()}" should return true, but "{(})" should return false
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBracketsOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("Enter an expression containing brackets\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    Console.WriteLine($"\nThe order is {(ValidateBrackets(input) ? "correct" : "incorrect.")}");
                    Console.Write("\nPress Enter to try another string...");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        static bool ValidateBrackets(string input)
        {
            string fliteredInput = "";
            foreach(var ch in input)
            {
                if (ch == '(' || ch == '<' || ch == '{' || ch == '[' || ch == ')' || ch == '>' || ch == '}' || ch == ']')
                    fliteredInput += ch;
            }
            Stack<char> myStack = new Stack<char>();
            bool keepLooping = true;
            bool isValid = false;
            do
            {
                foreach (var ch in fliteredInput)
                {
                    // adds the opening bracket to the Stack
                    if (ch == '(' || ch == '<' || ch == '{' || ch == '[')
                    {
                        myStack.Push(ch);
                    }
                    // compares the closing brackets with with the last opening bracket on Stack and pops it if they match
                    else if ((ch == ')' || ch == '>' || ch == '}' || ch == ']') && myStack.Count() != 0)
                    {
                        if (myStack.Peek() + 1 == ch || myStack.Peek() + 2 == ch)
                        {
                            myStack.Pop();
                        }
                        else
                        {
                            return isValid;
                        }
                    }
                    //checks for unmatched closing brackets
                    else if ((ch == ')' || ch == '>' || ch == '}' || ch == ']') && myStack.Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        keepLooping = false;
                        throw new Exception("\nInvalid Entry!");
                    }
                }
                // Checks for unmatched opening brackets
                if (myStack.Count() == 0)
                {
                    isValid = true;
                }
                keepLooping = false;
            } while (keepLooping);
            return isValid;
        }
    }
}
