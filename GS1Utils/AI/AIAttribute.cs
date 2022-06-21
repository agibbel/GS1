using System;

namespace Tepliakov.GS1Utils.AI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class AIAttribute : Attribute
    {
        /// <summary>
        /// Код AI
        /// </summary>
        public string AI
        {
            get => _ai;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length > 4)
                    throw new ArgumentOutOfRangeException();
                foreach (char c in value)
                    if (!char.IsDigit(c))
                        throw new ArgumentException();
                _ai = value;
            }
        }
        private string _ai;

        /// <summary>
        /// Человекочитаемый заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Минимальная длина
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// Максимальная длина
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Длина строки переменная
        /// </summary>
        public bool IsVariableLength => MinLength != MaxLength;

        /// <summary>
        /// Фиксированная длина
        /// </summary>
        public int FixedLength => IsVariableLength ? throw new NotImplementedException() : MinLength;

        /// <summary>
        /// Описание AI
        /// </summary>
        /// <param name="ai">AI</param>
        /// <param name="title">Человекочитаемый заголовок</param>
        /// <param name="description">Описание</param>
        /// <param name="minLength">Минимальная длина данных</param>
        /// <param name="maxLength">Максимальная длина данных</param>
        public AIAttribute(string ai, string title, string description, int minLength, int maxLength)
        {
            AI = ai;
            Title = title;
            Description = description;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        /// <summary>
        /// Описание AI
        /// </summary>
        /// <param name="ai">AI</param>
        /// <param name="title">Человекочитаемый заголовок</param>
        /// <param name="description">Описание</param>
        /// <param name="length">Длина данных</param>
        public AIAttribute(string ai, string title, string description, int length)
        {
            AI = ai;
            Title = title;
            Description = description;
            MinLength = length;
            MaxLength = length;
        }
    }
}
