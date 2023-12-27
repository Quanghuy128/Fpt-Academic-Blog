using FAB.Domain.Common;
using FAB.Domain.Constants;
using FAB.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Category.Table)]
    public class Category : BaseEntity
    {
        [Column(EntityFieldConstant.Category.Name)]
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Status)]
        [EnumDataType(typeof(CategoryStatus))]
        public CategoryStatus Status { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
