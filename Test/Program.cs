// See https://aka.ms/new-console-template for more information
using Tepliakov.GS1Utils;
using AI = Tepliakov.GS1Utils.AI;
using URI = Tepliakov.GS1Utils.URI;

GS1Utlis.Init();
while (true)
{
    try
    {
        Console.Write("\nВведите SSCC : ");
        AI.SSCC sscc = new(Console.ReadLine());
        URI.SSCC urisscc = new(sscc);
        Console.WriteLine("SSCC uri : " + urisscc.URI);
        //Console.Write("\nВедите GTIN : ");
        //GTIN gtin = new(Console.ReadLine());
        //Console.Write("Введите серийный номер : ");
        //Serial serial = new(Console.ReadLine());
        //SGTIN sgtin = new(gtin, serial);
        //Console.WriteLine("SGTIN : " + sgtin.URI);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка : " + ex.Message);
    }
}