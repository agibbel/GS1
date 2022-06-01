using System;
using Tepliakov.GS1Utils.AI;

namespace Tepliakov.GS1Utils.URI
{
    /// <summary>
    /// Serial + GTIN
    /// </summary>
    public class SGTIN
    {
        /// <summary>
        /// GTIN
        /// </summary>
        public GTIN AI_GTIN
        {
            get => _gtin;
            set
            {
                if (value is null)
                    throw new ArgumentNullException();
                _gtin = value;
            }
        }
        private GTIN _gtin;

        /// <summary>
        /// Серийный номер
        /// </summary>
        public Serial AI_Serial
        {
            get => _serial;
            set
            {
                if (value is null)
                    throw new ArgumentNullException();
                _serial = value;
            }
        }
        private Serial _serial;

        /// <summary>
        /// GTIN extension digit
        /// </summary>
        public string Extension
        {
            get => AI_GTIN.Extension;
            set => AI_GTIN.Extension = value;
        }

        /// <summary>
        /// GS1 Company Prefix
        /// </summary>
        public string GCP
        {
            get => AI_GTIN.GCP;
            set => AI_GTIN.GCP = value;
        }

        /// <summary>
        /// Item reference
        /// </summary>
        public string Reference
        {
            get => AI_GTIN.Reference;
            set => AI_GTIN.Reference = value;
        }

        /// <summary>
        /// Серийный номер
        /// </summary>
        public string Serial
        {
            get => AI_Serial.Value;
            set => AI_Serial.Value = value;
        }

        /// <summary>
        /// Создает SGTIN из AI содержащих GTIN и серийный номер
        /// </summary>
        /// <param name="gtin">GTIN</param>
        /// <param name="serial">Серийный номер</param>
        public SGTIN(GTIN gtin, Serial serial)
        {
            AI_GTIN = gtin;
            AI_Serial = serial;
        }

        /// <summary>
        /// Создает SGTIN из URI
        /// </summary>
        /// <param name="uri">URI</param>
        public SGTIN(string uri)
        {
            URI = uri;
        }

        /// <summary>
        /// Представление в виде URI
        /// </summary>
        public string URI
        {
            get => "urn:epc:id:sgtin:" + AI_GTIN.GCP + "." + AI_GTIN.Extension + AI_GTIN.Reference + "." + AI_Serial.Value;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                if (value.Length < 33 || value.Length > 52)
                    throw new ArgumentOutOfRangeException();
                if (value.Substring(0, 17) != "urn:epc:id:sgtin:")
                    throw new ArgumentException("Некорректный формат строки");
                int indexofext = value.Substring(17, 0).IndexOf('.');
                if (indexofext < 0 || indexofext > 12)
                    throw new ArgumentException("Некорректный формат строки");
                int indexofser = value.Substring(18 + indexofext).IndexOf('.');
                if ((indexofser < 0) || (indexofser + indexofext - 1) != 13)
                    throw new ArgumentException("Некорректный формат строки");
                AI_GTIN = new GTIN(value[18 + indexofext] + value.Substring(17, indexofext) + value.Substring(19 + indexofext, indexofser - 1), true);
                AI_Serial = new Serial(value.Substring(19 + indexofext + indexofser));
            }
        }
    }
}
