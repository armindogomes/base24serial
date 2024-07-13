using System.Linq;
using System;

namespace Base24Serial {

    public class Base24SerialConverter {

        /// <summary>
        /// Convert from base-16 into base-24
        /// </summary>
        /// <param name="hexValue">A string hex format (11111111112222222222333333333345)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        public static string Convert(string hexValue) {
            const int HEX_STRING_LENGTH = 32;

            if (string.IsNullOrEmpty(hexValue)) throw new ArgumentNullException(nameof(hexValue));

            if (hexValue.Count() != HEX_STRING_LENGTH) throw new ArgumentOutOfRangeException(nameof(hexValue));

            byte[] byteArray = HexStringToByteArray(hexValue);

            char[] charArray = "BCDFGHJKMPQRTVWXY2346789".ToCharArray();
            int k;
            string result = string.Empty;
            for (int i = 24; i >= 0; i--) {
                k = 0;
                for (int j = 14; j >= 0; j--) {
                    k = k * 256 ^ byteArray[j];
                    byteArray[j] = (byte)(k / 24);
                    k %= 24;
                }
                result = charArray[k] + result;
                if ((i % 5 == 0) && (i != 0))
                    result = $"-{result}";
            }
            return result;
        }

        private static byte[] HexStringToByteArray(string hexValue) {
            return Enumerable
                .Range(0, hexValue.Length / 2)
                .Select(x => System.Convert.ToByte(hexValue.Substring(x * 2, 2), 16))
                .ToArray();
        }
    }
}