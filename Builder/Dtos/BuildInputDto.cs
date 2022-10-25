namespace Builder.Dtos
{
    public class BuildInputDto
    {
        public string Namespace { get; set; }

        public string EntityName { get; set; }

        public string DisplayName { get; set; }

        public List<FieldInputDto> FieldInputDto { get; set; }
    }

    public class FieldInputDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }
    }
}
