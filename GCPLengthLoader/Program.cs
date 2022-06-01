// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Xml.Linq;

string url = "https://www.gs1.org/docs/gcp_length/gcpprefixformatlist.xml";
string path = Path.GetFullPath("..\\..\\..\\..\\GS1Utils\\Static\\GCPLength.cs", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
Console.WriteLine("Загрузка данных " + url +" ...");
Dictionary<string, int> entries = new();
using(HttpClient client = new())
{
    try
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        XElement root = XElement.Parse(await response.Content.ReadAsStringAsync());
        foreach(XElement element in root.Descendants("entry"))
#pragma warning disable CS8602
            entries.Add(element.Attribute("prefix").Value, int.Parse(element.Attribute("gcpLength").Value));
#pragma warning restore CS8602
    }
    catch (Exception e)
    {
        Console.WriteLine("\nОшибка загрузки");
        Console.WriteLine(e.Message);
        Console.Beep();
        Console.ReadKey();
        return;
    }
}
Console.WriteLine("Загрузка завершена");
Console.WriteLine("Сохранение файла " + path + " ...");
try
{
    using (FileStream file = File.Create(path))
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(@"using Tepliakov.GS1Utils.Collections;

namespace Tepliakov.GS1Utils.Static
{
    /// <summary>
    /// Длина GCP в строке (SSCC, GTIN и тд)
    /// </summary>
    internal static class GCPLength
    {
        /// <summary>
        /// Таблица длин GCP
        /// </summary>
        private static readonly DigitTreeCollection<int> Table = new DigitTreeCollection<int>
        {");
            foreach (KeyValuePair<string, int> entry in entries)
                writer.WriteLine("            [\"" + entry.Key + "\"] = " + entry.Value + ",");
            writer.WriteLine(@"        };

        /// <summary>
        /// Вычисляет длину GCP
        /// </summary>
        /// <param name=""str"">исходная строка</param>
        /// <returns>длина GCP, 0 если не определена</returns>
        internal static int Calculate(string str) => Table[str];
    }
}
");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("\nОшибка сохранения");
    Console.WriteLine(e.Message);
    Console.Beep();
    Console.ReadKey();
    return;
}
Console.WriteLine("Файл успешно сохранен");
Console.Beep();
Console.ReadKey();
