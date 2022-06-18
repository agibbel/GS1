using System;
using Tepliakov.GS1Utils.Static;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Identification of a logistic unit (SSCC): AI (00)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A476%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C738%2C0%5D"/>
    [AI("00", "SSCC", "Identification of a logistic unit (SSCC): AI (00)", 18)]
    public class SSCC : AIBase
    {
        /// <summary>
        /// Строковое представление значения
        /// </summary>
        public override string Value
        {
            get => Extension + GCP + Reference + CheckDigit;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length != 18)
                    throw new ArgumentOutOfRangeException();
                if (value[17] != CalculateCheckDigit(value.Substring(0, 17)))
                    throw new ArgumentException("Неверная контрольная сумма");
                int gcplen = GCPLength.Calculate(value.Substring(1));
                if (gcplen is default(int))
                    throw new ArgumentException("GCP не соответствует стандарту GS1");
                Extension = value[0];
                GCP = value.Substring(1, gcplen);
                Reference = ((1 + gcplen) >= 17) ? string.Empty : value.Substring(1 + gcplen, value.Length - gcplen - 2);
            }
        }

        /// <summary>
        /// Extension digit
        /// </summary>
        public char Extension
        {
            get => _extension;
            set
            {
                if (char.IsDigit(value))
                    _extension = value;
                else
                    throw new ArgumentException("Допустимы только цифры");
            }
        }
        private char _extension = '0';

        /// <summary>
        /// GS1 Company Prefix
        /// </summary>
        public string GCP
        {
            get => _gcp;
            set
            {
                if (string.IsNullOrEmpty(value) || GCPLength.Calculate(value) != value.Length)
                    throw new ArgumentException("GCP не соответствует стандарту GS1");
                if (!CharacterSet.IsDigital(value))
                    throw new ArgumentException("Допустимы только цифры");
                _gcp = value;
            }
        }
        private string _gcp = "0000000";

        /// <summary>
        /// Serial reference
        /// </summary>
        public string Reference
        {
            get
            {
                int prefixlen = 1 + _gcp.Length;
                if (prefixlen < 13)
                    return _reference.Substring(prefixlen - 4);
                else
                    return string.Empty;
            }
            set
            {
                if (value.Length > 13)
                    throw new ArgumentOutOfRangeException();
                if (!CharacterSet.IsDigital(value))
                    throw new ArgumentException("Допустимы только цифры");
                _reference = "0000000000000".Substring(0, 13 - value.Length) + value;
            }
        }
        private string _reference = "0000000000000000";

        /// <summary>
        /// Контрольная сумма
        /// </summary>
        public char CheckDigit => CalculateCheckDigit(Extension + GCP + Reference);

        /// <summary>
        /// Создает объект AI (00) SSCC
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <param name="calcCheckDigit">true если необходимо расчитать контрольную сумму, false для проверки присутствующей в строке контрольной суммы</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public SSCC(string src, bool calcCheckDigit = false) : base(!string.IsNullOrEmpty(src) ? (calcCheckDigit ? (src.Substring(0, 17) + CalculateCheckDigit(src)) : src) : throw new ArgumentNullException(nameof(src)))
        {
        }

        /// <summary>
        /// Создает объект AI (00) SSCC
        /// </summary>
        /// <param name="extension">Extension digit</param>
        /// <param name="gcp">GCP</param>
        /// <param name="reference">Item reference</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public SSCC(char extension, string gcp, string reference) : base()
        {
            Extension = extension;
            GCP = gcp;
            Reference = reference;
        }
    }
}
