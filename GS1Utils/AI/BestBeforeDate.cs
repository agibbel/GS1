using System;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Best before date: AI (15)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A488%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C526%2C0%5D"/>
    [AI("15", "BEST BEFORE", "Best before date: AI (15)", 6)]
    public class BestBeforeDate : AIBaseDate
    {
        /// <summary>
        /// Создает объект AI (15) Best before date
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public BestBeforeDate(string src) : base(src)
        {
        }

        /// <summary>
        /// Создает объект AI (15) Best before date
        /// </summary>
        /// <param name="date">Дата</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public BestBeforeDate(DateTime date) : base(date)
        {
        }

        /// <summary>
        /// Создает объект AI (15) Best before date
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <param name="day">День</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public BestBeforeDate(int year, int month, int day) : base(year, month, day)
        {
        }
    }
}
