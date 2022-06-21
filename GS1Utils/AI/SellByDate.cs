using System;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Sell by date: AI (16)
    /// </summary>
    /// <see cref="https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf#%5B%7B%22num%22%3A491%2C%22gen%22%3A0%7D%2C%7B%22name%22%3A%22XYZ%22%7D%2C50%2C732%2C0%5D"/>
    [AI("16", "SELL BY", "Sell by date: AI (16)", 6)]
    public class SellByDate : AIBaseDate
    {
        /// <summary>
        /// Создает объект AI (16) Sell by date
        /// </summary>
        /// <param name="src">исходное значение</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        /// <exception cref="ArgumentOutOfRangeException">размер исходной строки не соответствует поддерживаемому</exception>
        /// <exception cref="ArgumentException">содержимое исходной строки некорректно</exception>
        public SellByDate(string src) : base(src)
        {
        }

        /// <summary>
        /// Создает объект AI (16) Sell by date
        /// </summary>
        /// <param name="date">Дата</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public SellByDate(DateTime date) : base(date)
        {
        }

        /// <summary>
        /// Создает объект AI (16) Sell by date
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <param name="day">День</param>
        /// <exception cref="ArgumentOutOfRangeException">значение даты выходит за допустимый диапазон</exception>
        public SellByDate(int year, int month, int day) : base(year, month, day)
        {
        }
    }
}
