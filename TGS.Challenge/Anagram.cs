using System;
using System.Collections.Generic;
using System.Linq;

namespace TGS.Challenge
{
    /*
          Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
          one another return true, else return false

          "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
          phrase to produce a new word or phrase, using all the original letters exactly once; for example
          orchestra can be rearranged into carthorse.

          areAnagrams("horse", "shore") should return true
          areAnagrams("horse", "short") should return false

          NOTE: Punctuation, including spaces should be ignored, e.g.

          horse!! shore = true
          horse  !! shore = true
            horse? heroes = true

          There are accompanying unit tests for this exercise, ensure all tests pass & make
          sure the unit tests are correct too.
       */
    public class Anagram
    {
        public bool AreAnagrams(string word1, string word2)
        {
            if (String.IsNullOrEmpty(word1) || String.IsNullOrEmpty(word2))
            {
                throw new ArgumentException("Invalid entry");
            }

            var validation = new Dictionary<char, int>();
            foreach (var word in word1.Trim().ToLowerInvariant())
            {
                if (!char.IsLetter(word))
                {
                    continue;
                }

                if (!validation.ContainsKey(word))
                {
                    validation.Add(word, 1);
                }
                else
                {
                    validation[word] = validation[word] + 1;
                }
            }

            if (validation.Count == 0)
            {
                throw new ArgumentException("Invalid entry");
            }

            bool hasValidCharacters = false;
            foreach (var word in word2.Trim().ToLowerInvariant())
            {
                if (!char.IsLetter(word))
                {
                    continue;
                }

                hasValidCharacters = true;
                if (!validation.ContainsKey(word))
                {
                    return false;
                }
                else
                {
                    validation[word] = validation[word] - 1;
                }
            }

            if (!hasValidCharacters)
            {
                throw new ArgumentException("Invalid entry");
            }

            return validation.All(x => x.Value == 0); ;
        }
    }
}
