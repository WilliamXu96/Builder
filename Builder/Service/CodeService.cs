using System.Reflection;

namespace Builder.Service
{
    public class CodeService
    {
        public string Build()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(a => a.Contains("ModelTemplate.txt"));
            var stream = assembly.GetManifestResourceStream(resourceName);
            var reader = new StreamReader(stream).ReadToEnd();
            return reader;
        }
    }
}
