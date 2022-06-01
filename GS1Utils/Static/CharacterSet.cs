using System.Collections.Generic;

namespace Tepliakov.GS1Utils.Static
{
    internal static class CharacterSet
    {
        /// <summary>
        /// Проверяет, содержит ли строка только цифры
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <returns>true если только цифры, false если пустая строка или содержатся прочие символы</returns>
        internal static bool IsDigital(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            foreach (char c in str)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }

        /// <summary>
        /// Набор символов 82
        /// </summary>
        internal static List<char> CharacterSet82 = new List<char>
        {
            '!', '"', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '_',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        /// <summary>
        /// Проверяет соответствие строки набору символов 82
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <returns>true если соответствует набору символов 82, false если пустая строка или содержатся прочие символы</returns>
        internal static bool IsCharacterSet82(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            foreach (char c in str)
                if (!CharacterSet82.Contains(c))
                    return false;
            return true;
        }

        /// <summary>
        /// Набор символов 39
        /// </summary>
        internal static List<char> CharacterSet39 = new List<char>
        {
            '#', '-', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        /// <summary>
        /// Проверяет соответствие строки набору символов 39
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <returns>true если соответствует набору символов 39, false если пустая строка или содержатся прочие символы</returns>
        internal static bool IsCharacterSet39(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            foreach (char c in str)
                if (!CharacterSet39.Contains(c))
                    return false;
            return true;
        }
    }
}
