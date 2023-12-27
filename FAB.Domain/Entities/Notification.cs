using FAB.Domain.Common;
using FAB.Domain.Constants;
using FAB.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Notification.Table)]
    public class Notification : BaseEntity
    {
        [Column(EntityFieldConstant.Notification.Message)]
        [StringLength(500)]
        public string Message { get; set; } = String.Empty;

        [Column(EntityFieldConstant.Status)]
        [EnumDataType(typeof(NotificationStatus))]
        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

        [Column(EntityFieldConstant.Notification.Type)]
        [EnumDataType(typeof(NotificationType))]
        public NotificationType Type { get; set; } = NotificationType.Others;

        [Column(EntityFieldConstant.Notification.FromAccountId)]
        [ForeignKey(EntityFieldConstant.Notification.FromAccountId)]
        public Guid FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; } = null!;

        [Column(EntityFieldConstant.Notification.ToAccountId)]
        [ForeignKey(EntityFieldConstant.Notification.ToAccountId)]
        public Guid ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; } = null!;


    }
}
