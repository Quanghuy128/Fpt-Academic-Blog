using FAB.Domain.Common;
using FAB.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Award.Table)]
    public class Award : BaseEntity
    {
        [Column(EntityFieldConstant.Award.Name)]
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Award.IconUrl)]
        [StringLength(500)]
        public string IconUrl { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Award.Point)]
        public int Point { get; set; } = 0;

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();   
    }
}
