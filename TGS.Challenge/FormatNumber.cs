using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TGS.Challenge
{
    /*
        Devise a function that takes an input 'n' (integer) and returns a string that is the
        decimal representation of that number grouped by commas after every 3 digits. 
        
        NOTES: You cannot use any built-in formatting functions to complete this task.

        Assume: 0 <= n < 1000000000

        1 -> "1"
        10 -> "10"
        100 -> "100"
        1000 -> "1,000"
        10000 -> "10,000"
        100000 -> "100,000"
        1000000 -> "1,000,000"
        35235235 -> "35,235,235"

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */



    public class FormatNumber
    {
        public string Format(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid entry: entry should be major than 0");
            }

            if (value > 1000000000)
            {
                throw new ArgumentOutOfRangeException("Invalid entry: entry should be under than 1000000000");
            }

            var valueString = value.ToString();
            var result = String.Empty;
            var symbol = ",";
            var length = 3;
            for (int i = 1; i <= (valueString.Length / 3) + 1; i++)
            {
                var index = valueString.Length - (i * 3);
                //First digits step ie 1 from 1000
                if (index <= 0)
                {
                    length = index + 3;
                    index = 0;
                    symbol = String.Empty;
                }

                result = $"{symbol}{valueString.Substring(index, length)}{result}";
            }

            return result;
        }
    }
}
