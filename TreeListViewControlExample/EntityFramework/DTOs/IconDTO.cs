using EntityFramework.DTOs.Base;

namespace EntityFramework.DTOs
{
    public class IconDTO : BaseDTO
    {
        public string? Source { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public string? Origin { get; set; }
        public byte[]? Data { get; set; }
    }
}
