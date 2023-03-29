using System;

namespace EntityFramework.DTOs.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? Comments { get; set; }
        public string? Icon { get; set; }
    }
}
