using System.Collections.Generic;
using System.Resources;

namespace FileToResx
{
    public class ResxBuilder
    {
        public void BuildResx(Dictionary<string, string> languageDictionary, string newFilePath)
        {
            using (var resx = new ResXResourceWriter(newFilePath))
            {
                foreach (var kvp in languageDictionary)
                {
                    resx.AddResource(kvp.Key, kvp.Value);
                }

                resx.Generate();
            }
        }
    }
}