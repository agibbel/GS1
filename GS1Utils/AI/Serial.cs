using System;
using Tepliakov.GS1Utils.Static;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Serial number: AI (21)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A497%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C423%2C0%5D"/>
    [AI("21", "SERIAL", "Serial number: AI (21)", 1, 20)]
    public class Serial : AIBase
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
        /// Создает объект AI (21) Serial
        /// </summary>
        /// <param name="src"></param>
        public Serial(string src) : base(src)
        {
        }
    }
}
