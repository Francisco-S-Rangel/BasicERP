using System.ComponentModel.DataAnnotations;

namespace BasicERP.Domain
{
    public abstract class EntityBase
    {
        [Key]
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
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }
    }
}
