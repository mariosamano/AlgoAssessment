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
        private Dictionary<char, int> tracker;
        private void TrackLetterCount(char letter, int count)
        {
            if (!char.IsLetter(letter) || letter == ' ')
                return;

            if (!tracker.ContainsKey(letter))
            {
                tracker.Add(letter, count);
            }
            else
            {
                tracker[letter] = tracker[letter] + count;
            }
        }

        public bool AreAnagrams(string word1, string word2)
        {
            tracker = new Dictionary<char, int>();
            if (String.IsNullOrEmpty(word1) || String.IsNullOrEmpty(word2))
            {
                throw new ArgumentException("Invalid entry");
            }

            var maxLength = Math.Max(word1.Length, word2.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < word1.Length)
                {
                    TrackLetterCount(char.ToLower(word1[i]), 1);
                }

                if (i < word2.Length)
                {
                    TrackLetterCount(char.ToLower(word2[i]), -1);
                }
            }

            return tracker.All(x => x.Value == 0); ;
        }
    }
}
