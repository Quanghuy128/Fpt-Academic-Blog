using FAB.Domain.Common;
using FAB.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.BannedInfo.Table)]
    public class BannedInfor : BaseEntity
    {
        [Column(EntityFieldConstant.BannedInfo.AccountId)]
        [ForeignKey(EntityFieldConstant.BannedInfo.FK_Account)]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; } = null!;

        [Column(EntityFieldConstant.BannedInfo.Message)]
        [StringLength(500)]
        public string Message { get; set; } = string.Empty;
    }
}
