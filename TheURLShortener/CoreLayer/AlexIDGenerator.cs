using System;
using System.Linq;

namespace TheURLShortener.CoreLayer
{
    public class AlexIDGenerator : IIDGenerator
    {
        public string Generate(int length)
        {
            var signs = new[] { "0", "1", "2", "3", "4", "5",
                "6", "7", "8", "9", "a", "b", "c", "d", "e",
                "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u",
                "v", "w", "x", "y", "z",
                "A","B","C","D","E",
                "F","G","H","I","J","K","L","M","N","O","P",
                "Q","R","S","T","U","V","W","X","Y","Z" };
            var number = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
            var result = "";

            if (number < signs.Length) return signs[number];

            long rem = 0;
            while (number > 0)
            {
                rem = number % signs.Length;
                result = signs[rem] + result;

                number /= signs.Length;
            }

            return result.Substring(0, length);
        }

    }
}

