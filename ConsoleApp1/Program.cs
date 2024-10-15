// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Read a Json Document file and flatten it into a Dictionary with Keys and Values");
var filePath = "JsonDocExample1.json";
var jsonDocConent = filePath.GetFileAsJsonDocument();
var flattenJsonContent = jsonDocConent.Flatten();
Console.WriteLine("Dispaly flattened Json");
foreach (var item in flattenJsonContent)
{
    Console.Write("key:" + item.Key);
    Console.WriteLine(", value:" + item.Value);

}
Console.ReadLine();