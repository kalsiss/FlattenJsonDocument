using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class JsonHelper
    {
        public static Dictionary<string, JsonElement> Flatten(this JsonElement element, string previousPath = null)
        {
            var result = new Dictionary<string, JsonElement>();

            foreach (var prop in element.EnumerateObject())
            {
                var currentPropName = previousPath != null ? previousPath + "." + prop.Name : prop.Name;
                result.Add(currentPropName, prop.Value);

                if (prop.Value.ValueKind == JsonValueKind.Object)
                {
                    var innerDictionary = prop.Value.Flatten(currentPropName);
                    foreach(var inner in innerDictionary)
                    {
                        result.Add(inner.Key, inner.Value);
                    }
                }
            }

            return result;
        }

        public static JsonElement GetFileAsJsonDocument(this string filePath)
        {
            var fileContent = File.ReadAllText(filePath);
            return JsonDocument.Parse(fileContent).RootElement;
        }
    }
}
