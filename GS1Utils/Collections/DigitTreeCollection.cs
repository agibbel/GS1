using System;

namespace Tepliakov.GS1Utils.Collections
{
    /// <summary>
    /// Древовидная коллекция с цифровыми индексами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DigitTreeCollection<T>
    {
        /// <summary>
        /// Содержимое текущей ветки
        /// </summary>
        private readonly DigitTreeCollection<T>[] Items = { default, default, default, default, default, default, default, default, default, default };

        /// <summary>
        /// Значение текущего элемента
        /// </summary>
        private T Value = default;

        /// <summary>
        /// Элемент коллекции соответствующий индексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns>значение элемента коллекции</returns>
        /// <exception cref="IndexOutOfRangeException">индекс содержит нецифровые символы</exception>
        internal T this[string index]
        {
            get
            {
                if (string.IsNullOrEmpty(index))
                    return Value;
                char c = index[0];
                if (!char.IsDigit(c))
                    throw new IndexOutOfRangeException("Значение " + index + " недопустимо для индекса");
                int i = c - '0';
                if (Items[i] is DigitTreeCollection<T> item)
                    return item[index.Substring(1)];
                return Value;
            }
            set
            {
                if (string.IsNullOrEmpty(index))
                    Value = value;
                else
                {
                    char c = index[0];
                    if (!char.IsDigit(c))
                        throw new IndexOutOfRangeException("Значение " + index + " недопустимо для индекса");
                    int i = c - '0';
                    if (Items[i] is default(DigitTreeCollection<T>))
                        Items[i] = new DigitTreeCollection<T>();
                    Items[i][index.Substring(1)] = value;
                }
            }
        }
    }
}
