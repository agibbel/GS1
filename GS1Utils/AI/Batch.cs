using System;
using Tepliakov.GS1Utils.Static;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Batch or lot number: AI (10)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A482%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C738%2C0%5D"/>
    [AI("10", "BATCH/LOT", "Batch or lot number: AI (10)", 1, 20)]
    public class Batch : AIBase
    {
        /// <summary>
        /// Строковое представление значения
        /// </summary>
        public override string Value
        {
            get => _value;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length > 20)
                    throw new ArgumentOutOfRangeException();
                if (!CharacterSet.IsCharacterSet82(value))
                    throw new ArgumentException("Строка содержит недопустимые символы");
                _value = value;
            }
        }
        private string _value = "0";

        /// <summary>
        /// Создает объект AI (10) Batch/Lot
        /// </summary>
        /// <param name="src"></param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public Batch(string src) : base(src)
        {
        }
    }
}
