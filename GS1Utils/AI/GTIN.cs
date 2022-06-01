using System;
using Tepliakov.GS1Utils.Static;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Identification of a trade item (GTIN): AI (01)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A476%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C440%2C0%5D"/>
    [AI("01", "GTIN", "Identification of a trade item (GTIN): AI (01)", 14)]
    public class GTIN : AIBase
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
                if (value.Length != 14)
                    throw new ArgumentOutOfRangeException();
                if (value[13] != CalculateCheckDigit(value.Substring(0, 13)))
                    throw new ArgumentException("Неверная контрольная сумма");
                int extsize = (value.Substring(0, 6) == "000000") ? 6 : ((value.Substring(0, 2) == "00") ? 2 : ((value[0] == '0') ? 1 : 0));
                int gcplen = GCPLength.Calculate(value.Substring(extsize));
                if (gcplen is default(int))
                    throw new ArgumentException("GCP не соответствует стандарту GS1");
                Extension = (extsize > 0) ? value.Substring(0, extsize) : string.Empty;
                GCP = value.Substring(extsize, gcplen);
                Reference = ((extsize + gcplen) >= 13) ? string.Empty : value.Substring(extsize + gcplen, value.Length - extsize - gcplen -1);
            }
        }

        /// <summary>
        /// Extension digit
        /// </summary>
        public string Extension
        {
            get => _extension;
            set
            {
                if (value.Length != 0 && value.Length != 1 && value.Length != 2 && value.Length != 6)
                    throw new ArgumentOutOfRangeException();
                foreach (char c in value)
                    if (c != '0')
                        throw new ArgumentException("Допустимы только цифры '0'");
                _extension = value;
            }
        }
        private string _extension = "0";

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
        /// Item reference
        /// </summary>
        public string Reference
        {
            get
            {
                int prefixlen = _extension.Length + _gcp.Length;
                if (prefixlen < 13)
                    return _reference.Substring(10 - (13 - prefixlen));
                else
                    return string.Empty;
            }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentOutOfRangeException();
                if (!CharacterSet.IsDigital(value))
                    throw new ArgumentException("Допустимы только цифры");
                _reference = "0000000000".Substring(0, 10 - value.Length) + value;
            }
        }
        private string _reference = "0000000000000";

        /// <summary>
        /// Контрольная сумма
        /// </summary>
        public char CheckDigit => CalculateCheckDigit(Extension + GCP + Reference);

        /// <summary>
        /// Тип GTIN
        /// </summary>
        public enum GTINType
        {
            GTIN8,
            GTIN12,
            GTIN13,
            GTIN14
        }

        /// <summary>
        /// Тип GTIN
        /// </summary>
        public GTINType Type
        {
            get
            {
                switch(Extension)
                {
                    case "0":
                        return GTINType.GTIN13;
                    case "00":
                        return GTINType.GTIN12;
                    case "000000":
                        return GTINType.GTIN8;
                    default:
                        return GTINType.GTIN14;
                }
            }
            set
            {
                switch(value)
                {
                    case GTINType.GTIN8:
                        Extension = "000000";
                        break;
                    case GTINType.GTIN12:
                        Extension = "00";
                        break;
                    case GTINType.GTIN13:
                        Extension = "0";
                        break;
                    default:
                        Extension = string.Empty;
                        break;
                }
            }
        }

        /// <summary>
        /// Создает объект AI (01) GTIN
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <param name="calcCheckDigit">true если необходимо расчитать контрольную сумму, false для проверки присутствующей в строке контрольной суммы</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public GTIN(string src, bool calcCheckDigit = false) : base(!string.IsNullOrEmpty(src) ? (calcCheckDigit ? (src.Substring(0, 13) + CalculateCheckDigit(src)) : src) : throw new ArgumentNullException(nameof(src)))
        {
        }

        /// <summary>
        /// Создает объект AI (01) GTIN
        /// </summary>
        /// <param name="extension">Extension digit</param>
        /// <param name="gcp">GCP</param>
        /// <param name="reference">Item reference</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public GTIN(string extension, string gcp, string reference) : base()
        {
            Extension = extension;
            GCP = gcp;
            Reference = reference;
        }

        /// <summary>
        /// Создает объект AI (01) GTIN
        /// </summary>
        /// <param name="extension">Тип GTIN</param>
        /// <param name="gcp">GCP</param>
        /// <param name="reference">Item reference</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public GTIN(GTINType type, string gcp, string reference) : base()
        {
            Type = type;
            GCP = gcp;
            Reference = reference;
        }
    }
}
