using System;
using System.Collections.Generic;
using System.Linq;

namespace TGS.Challenge
{
    /*
        Devise a function that takes a string & returns the number of 
        vowels (aeiou) in that string.

        "Hi there!" = 3
        "What do you mean?"  = 6

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class VowelCount
    {
        public int Count(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid entry");
            }

            return value.Count("aeiouAEIOU".Contains); 
        }
    }
}
