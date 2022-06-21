using System;
using System.Globalization;
using Tepliakov.GS1Utils.Static;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Базовый класс AI содержащего дату
    /// </summary>
    /// <remarks>
    /// Поскольку с 1 января 2025 года стандарт запрещает использовать 00 в качестве дня для фармацевтической
    /// продукции, возможность генерации такого значения не реализована.
    /// </remarks>
    public abstract class AIBaseDate : AIBase
    {
        /// <summary>
        /// Строковое представление значения
        /// </summary>
        public override string Value
        {
            get => _value.ToString("yyMMdd", CultureInfo.InvariantCulture);
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length != 6)
                    throw new ArgumentOutOfRangeException();
                if (!CharacterSet.IsDigital(value))
                    throw new ArgumentException("Строка содержит недопустимые символы");
                if (value.Substring(4, 2) == "00")
                {
                    DateTime val = DateTime.ParseExact(value.Substring(0, 4) + "01", "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    _value = new DateTime(val.Year, val.Month, DateTime.DaysInMonth(val.Year, val.Month));
                }
                else
                    _value = DateTime.ParseExact(value, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                if ((DateTime.Now.Year - _value.Year) > 49)
                    _value.AddYears(100);
                else if ((_value.Year - DateTime.Now.Year) > 50)
                    _value.AddYears(-100);
            }
        }
        private DateTime _value = DateTime.UtcNow;

        /// <summary>
        /// Значение даты
        /// </summary>
        public DateTime Date
        {
            get => _value;
            set
            {
                if ((DateTime.Now.Year - value.Year) > 49 || (value.Year - DateTime.Now.Year) > 50)
                    throw new ArgumentOutOfRangeException();
                _value = value;
            }
        }

        /// <summary>
        /// Создает AI содержащий дату
        /// </summary>
        /// <param name="src">Исходная строка</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public AIBaseDate(string src) : base(src)
        {
        }

        /// <summary>
        /// Создает AI содержащий дату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public AIBaseDate(DateTime date) : base() => Date = date;

        /// <summary>
        /// Создает AI содержащий дату
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <param name="day">День</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public AIBaseDate(int year, int month, int day) : base() => Date = new DateTime(year, month, day);
    }
}
