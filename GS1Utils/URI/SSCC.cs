using System;

namespace Tepliakov.GS1Utils.URI
{
    public class SSCC
    {
        /// <summary>
        /// SSCC
        /// </summary>
        public AI.SSCC AI_SSCC
        {
            get => _sscc;
            set
            {
                if (value is null)
                    throw new ArgumentNullException();
                _sscc = value;
            }
        }
        private AI.SSCC _sscc;

        /// <summary>
        /// SSCC extension digit
        /// </summary>
        public char Extension
        {
            get => AI_SSCC.Extension;
            set => AI_SSCC.Extension = value;
        }

        /// <summary>
        /// GS1 Company Prefix
        /// </summary>
        public string GCP
        {
            get => AI_SSCC.GCP;
            set => AI_SSCC.GCP = value;
        }

        /// <summary>
        /// Item reference
        /// </summary>
        public string Reference
        {
            get => AI_SSCC.Reference;
            set => AI_SSCC.Reference = value;
        }

        /// <summary>
        /// Создает SSCC из AI содержащего SSCC
        /// </summary>
        /// <param name="sscc">SSCC</param>
        public SSCC(AI.SSCC sscc) => AI_SSCC = sscc;

        /// <summary>
        /// Создает SSCC из URI
        /// </summary>
        /// <param name="uri">URI</param>
        public SSCC(string uri) => URI = uri;

        /// <summary>
        /// Представление в виде URI
        /// </summary>
        public string URI
        {
            get => "urn:epc:id:sscc:" + AI_SSCC.GCP + "." + AI_SSCC.Extension + AI_SSCC.Reference;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length != 34)
                    throw new ArgumentOutOfRangeException();
                if (value.Substring(0, 16) != "urn:epc:id:sscc:")
                    throw new ArgumentException("Некорректный формат строки");
                int indexofext = value.Substring(16, 0).IndexOf('.');
                if (indexofext < 0 || indexofext > 12)
                    throw new ArgumentException("Некорректный формат строки");
                AI_SSCC = new AI.SSCC(value[17 + indexofext], value.Substring(16, indexofext), value.Substring(18 + indexofext));
            }
        }
    }
}
