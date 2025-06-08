using System.ComponentModel.DataAnnotations;

namespace BasicERP.Services.DTO
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime ModificationDate { get; set; }

        public string? ImageUrl { get; set; }

        public void GenerateNewEntity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }
    }
}
