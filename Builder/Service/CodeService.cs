using Builder.Dtos;
using System.Reflection;
using System.Text;

namespace Builder.Service
{
    public class CodeService
    {
        public string Build(BuildInputDto input)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(a => a.Contains("ModelTemplate.txt"));
            var file = assembly.GetManifestResourceStream(resourceName);
            var modelTemplate = new StreamReader(file).ReadToEnd();

            var attributes = new StringBuilder();
            foreach (var field in input.FieldInputDto)
            {
                attributes.Append("\r\n        /// <summary>");
                attributes.Append($"\r\n        /// " + field.DisplayName + "");
                attributes.Append("\r\n        /// </summary>");
                attributes.Append($"\r\n        public {field.DataType} {field.Name} {{ get; set; }}");
                attributes.Append("\r\n        ");
            }

            //替换模板字段
            var modelClass = modelTemplate.Replace("{Namespace}", input.Namespace)
                                           .Replace("{DisplayName}", input.DisplayName)
                                           .Replace("{EntityName}", input.EntityName)
                                           .Replace("{AttributeList}", attributes.ToString());


            var parentPath = new DirectoryInfo(Environment.CurrentDirectory).FullName;

            using (FileStream stream = File.Open($"{parentPath}/Models/{input.EntityName}.cs", FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] by = Encoding.Default.GetBytes(modelClass);
                stream.Write(by, 0, by.Length);
            }

            return "OK";
        }
    }
}
