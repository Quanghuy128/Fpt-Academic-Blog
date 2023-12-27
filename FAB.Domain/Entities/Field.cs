using FAB.Domain.Common;
using FAB.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Field.Table)]
    public class Field : BaseEntity
    {
        [Column(EntityFieldConstant.Field.Name)]
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Account> Account { get; set; } = null!;
    }
}
