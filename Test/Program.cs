// See https://aka.ms/new-console-template for more information
using Tepliakov.GS1Utils;
using Tepliakov.GS1Utils.AI;
using Tepliakov.GS1Utils.URI;

GS1.Init();
while (true)
{
    try
    {
        Console.Write("\nВедите GTIN : ");
        GTIN gtin = new(Console.ReadLine());
        Console.Write("Введите серийный номер : ");
        Serial serial = new(Console.ReadLine());
        SGTIN sgtin = new(gtin, serial);
        Console.WriteLine("SGTIN : " + sgtin.URI);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка : " + ex.Message);
    }
}