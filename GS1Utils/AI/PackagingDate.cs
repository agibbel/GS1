using System;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Packaging date: AI (13)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A485%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C236%2C0%5D"/>
    [AI("13", "PACK DATE", "Packaging date: AI (13)", 6)]
    public class PackagingDate : AIBaseDate
    {
        /// <summary>
        /// Создает объект AI (13) Packaging date
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public PackagingDate(string src) : base(src)
        {
        }

        /// <summary>
        /// Создает объект AI (13) Packaging date
        /// </summary>
        /// <param name="date">Дата</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public PackagingDate(DateTime date) : base(date)
        {
        }

        /// <summary>
        /// Создает объект AI (13) Packaging date
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <param name="day">День</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public PackagingDate(int year, int month, int day) : base(year, month, day)
        {
        }
    }
}
