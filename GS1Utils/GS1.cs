using System;
using System.Collections.Generic;
using System.Text;

namespace Tepliakov.GS1Utils
{
    public class GS1
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
    }
}
