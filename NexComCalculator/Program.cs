using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NexComCalculator
{
    class Program
    {
        //***************************** NexComCalculator ********************************
        // This is the program that evalutes any algebraic expression.
        // Developed by: Suresh Poudel
        // Date: 10/18/2021
        //*******************************************************************************


        //To support a discussion at our next meeting, we would like you to undertake a coding exercise.This is to give you the opportunity to demonstrate the quality of your programming skills.We would like you to code a simple calculator.We estimate that this would require approx. 3 hours to design, code and QA.

        //Requirements:

        //It must be able to solve an equation of Add, Subtract, Divide and Multiply.It must accept decimals.
        //For the sample of equation: “1 + 2.3 / 4 * 5 – 6” it should give a result of -2.13 rounded to 2 decimal places.
        //Do NOT use any equation solver libraries, plugins or helper of any kind. Basic code only.
        //We would like you submit this to us by Monday 18th October.  I am conscious that you are working so your time is not your own.This gives you 2 weekends to look at the project.

        // We would then like to have a second interview at 9am on the morning of Thursday 21st October for you to present your work.At that meeting we would like you to tell us about the following:-

        //The architectural pattern that you used and why you chose this pattern
        //What class structure you created and the reasoning behind that
        //What you did to ensure that the code has good readability
        //How you tested the code to ensure that it was robust and accurate
        //What steps you took to improve the re-usability of the code
        //This is not a test of your presentational skills but we would recommend creating a short summary for each point in a tool such as PowerPoint.This will give us something to use on the call to structure the conversation.


        static void Main(string[] args)
        {
            Console.WriteLine("Enter algebraic expression. Example: 1*2-3/4*5+6");
            var input = Console.ReadLine();
            var output = EvaluateExpression(input);
            Console.WriteLine($"Calculated value : {output}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

        }
        public static decimal EvaluateExpression(string expression)
        {
           
            return Operation(SanitizeExpression(expression));
        }
        /// <summary>
        ///Evalutes the algebraic expression operation
        /// </summary>
        /// <param name="expression">string:Algebraic expression</param>
        /// <returns>decimal</returns>
        public static decimal Operation(string expression)
        {
            Stack<decimal> stack = new Stack<decimal>();
            decimal number = 0;
            char sign = '+';
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    number = number * 10 + (expression[i] - '0');
                }
                else if ((expression[i]).ToString().IndexOfAny("+-*/".ToCharArray()) != 1)
                {
                    StackUpdate(sign, number, stack);
                    number = 0; sign = expression[i];
                }
            }
            StackUpdate(sign, number, stack);
            decimal sum = 0;
            foreach (var actualNumber in stack)
            {
                sum += actualNumber;
            }
            return Math.Round(sum, 2);
        }
        public static void StackUpdate(char op, decimal v, Stack<decimal> stack)
        {
            if (op == '+') stack.Push(v);
            if (op == '-') stack.Push(-v);
            if (op == '*') stack.Push(stack.Pop() * v);
            if (op == '/') stack.Push(stack.Pop() / v);
        }
        /// <summary>
        /// Refactors expression for some common issues.
        /// </summary>
        /// <param name="expresssion"></param>
        /// <returns></returns>
        public static string SanitizeExpression(string expresssion)
        {
            expresssion = expresssion.Trim();
            expresssion= expresssion.Replace(" ", string.Empty);
            return expresssion;

        }
    }
}
