using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
     public class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider rngGenerator = new RNGCryptoServiceProvider();

        public static double NumberBetween(double minimumvalue, double maximumvalue)
        {

            byte[] randomNumber = new byte[1];

            rngGenerator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001);

            double range = maximumvalue - minimumvalue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (double)(minimumvalue + randomValueInRange);

        }
    }
}
