using System;
using Xunit;

namespace TGS.Challenge.Tests
{
    public class VowelCountTests
    {
        private readonly VowelCount _vowelCount;

        public VowelCountTests()
        {
            this._vowelCount = new VowelCount();
        }

        [Fact]
        public void Value_IsRequired()
        {
            Assert.Throws<ArgumentException>(() => _vowelCount.Count(string.Empty));
        }


        [Fact]
        public void ValueIsNull_IsRequired()
        {
            Assert.Throws<ArgumentException>(() => _vowelCount.Count(null));
        }

        [Fact]
        public void AEIOU_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("AEIOU");

            //expeceted result is incorrect should be 5 not 6
            Assert.Equal(count, 5);
        }

        [Fact]
        public void lmnpqr_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("lmnpqr");

            Assert.Equal(count, 0);
        }

        [Fact]
        public void abcdefghijklmnopqrstuvwxyz_Returns_Correct_Count()
        {
            //incorrect value should be abcdefghijklmnopqrstuvwxyz not lmnpqr
            var count = _vowelCount.Count("abcdefghijklmnopqrstuvwxyz");

            Assert.Equal(count, 5);
        }

        [Fact]
        public void Howmanycanyoufind_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("How many can you find");

            Assert.Equal(count, 6);
        }

        [Fact]
        public void AaEeIiOoUu_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("AaEeIiOoUu");

            Assert.Equal(count, 10);
        }

        [Fact]
        public void symbols_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("&/(&(&%·(()//&%$··$$·%$");

            Assert.Equal(count, 0);
        }

        [Fact]
        public void bigstring_Returns_Correct_Count()
        {
            var count = _vowelCount.Count("Childhood Cancer Society (CCS) began with the vision of a 16-year-old high school student who realized that having family around him while he was being evaluated for childhood leukemia created the support that he needed to cope. There is nothing more powerful than the miracles that result from the love of family, and it is the mission of CCS to see to it that children diagnosed with cancer have the opportunity to experience the benefits that come from this vital support system. A true miracle happens when a child looks up from a hospital bed and feels the comfort of loved ones at");

            Assert.Equal(count, 180);
        }
       
    }
}