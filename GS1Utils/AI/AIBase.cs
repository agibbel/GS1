using System;
using System.Linq;

namespace Tepliakov.GS1Utils.AI
{
    /// <summary>
    /// Базовый класс AI
    /// </summary>
    public abstract class AIBase
    {
        /// <summary>
        /// Создает AI
        /// </summary>
        /// <param name="src">начальное значение</param>
        /// <exception cref="ArgumentNullException">исходная строка не содержит данных</exception>
        public AIBase(string src) => Value = !string.IsNullOrEmpty(src) ? src : throw new ArgumentNullException(nameof(src));

        /// <summary>
        /// Создает AI
        /// </summary>
        public AIBase()
        {

        }

        /// <summary>
        /// Строковое представление значения
        /// </summary>
        public abstract string Value { get; set; }

        /// <summary>
        /// Определяет, равны ли два экземпляра объекта
        /// </summary>
        /// <param name="obj">объект, который требуется сравнить с текущим объектом</param>
        /// <returns>значение true, если указанный объект равен текущему объекту; в противном случае — значение false</returns>
        public override bool Equals(object obj) => GetType().Equals(obj?.GetType()) && Value == (obj as AIBase)?.Value;

        /// <summary>
        /// Хэш-функция по умолчанию
        /// </summary>
        /// <returns>хэш-код для текущего объекта</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Возвращает строку, представляющую текущий объект
        /// </summary>
        /// <returns>строка, представляющая текущий объект</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Вычисляет контрольную сумму
        /// </summary>
        /// <param name="src">строка для рассчета контрольной суммы</param>
        /// <returns>контрольная сумма</returns>
        /// <exception cref="ArgumentException">строка содержит нецифровые символы</exception>
        protected static char CalculateCheckDigit(string src) => (char)((10 - src.Reverse().Select((c, i) => (char.IsDigit(c) ? (c - '0') : throw new ArgumentException("Допустимы только цифры", src)) * (i % 2 == 0 ? 3 : 1)).Sum() % 10) % 10 + 48);
    }
}
