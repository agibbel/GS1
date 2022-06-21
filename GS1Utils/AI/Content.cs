using System;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Identification of trade items contained in a logistic unit: AI (02)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A476%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C148%2C0%5D"/>
    [AI("02", "CONTEN", "Identification of trade items contained in a logistic unit: AI (02)", 14)]
    public class Content : GTIN
    {
        /// <summary>
        /// Создает объект AI (02) Content
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <param name="calcCheckDigit">true если необходимо расчитать контрольную сумму, false для проверки присутствующей в строке контрольной суммы</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public Content(string src, bool calcCheckDigit = false) : base(src, calcCheckDigit)
        {
        }

        /// <summary>
        /// Создает объект AI (02) Content
        /// </summary>
        /// <param name="extension">Extension digit</param>
        /// <param name="gcp">GCP</param>
        /// <param name="reference">Item reference</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public Content(string extension, string gcp, string reference) : base(extension, gcp, reference)
        {
        }

        /// <summary>
        /// Создает объект AI (02) Content
        /// </summary>
        /// <param name="type">Тип GTIN</param>
        /// <param name="gcp">GCP</param>
        /// <param name="reference">Item reference</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public Content(GTINType type, string gcp, string reference) : base(type, gcp, reference)
        {
        }
    }
}
