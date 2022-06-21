using System;
using Tepliakov.GS1Utils.Collections;

namespace Tepliakov.GS1Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class GS1Utlis
    {
        /// <summary>
        /// Производит инициализацию статических полей путем обращения к ним.
        /// </summary>
        public static void Init()
        {
            Static.GCPLength.Calculate(string.Empty);
            Static.CharacterSet.IsCharacterSet82("0");
            Static.CharacterSet.IsCharacterSet39("0");
        }

        /// <summary>
        /// Разбирает строку формата GS1 в коллекцию значений
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static AICollection ParseGS1(string str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Собирает коллекцию значений в строку в формате GS1
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string MergeGS1(AICollection src)
        {
            throw new NotImplementedException();
        }
    }
}
