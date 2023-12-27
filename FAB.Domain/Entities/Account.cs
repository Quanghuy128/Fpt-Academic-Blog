using FAB.Domain.Common;
using FAB.Domain.Constants;
using FAB.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Account.Table)]
    public class Account : BaseEntity
    {
        [Column(EntityFieldConstant.Account.Gmail)]
        [Required]
        [StringLength(255)]
        public string Gmail { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Account.FirstName)]
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Account.LastName)]
        [StringLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Account.BlogNumbers)]
        public int BlogsNumber { get; set; } = 0;

        [Column(EntityFieldConstant.Status)]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus Status { get; set; } = AccountStatus.Active;

        [Column(EntityFieldConstant.Account.FieldId)]
        [ForeignKey(EntityFieldConstant.Account.FK_Field)]
        public Guid FieldId { get; set; }
        public virtual Field Field { get; set; } = null!;

        public virtual BannedInfor BannedInfor { get; set; } = null!;

        [InverseProperty(EntityFieldConstant.Notification.FK_FromAccount)]
        public virtual Notification From { get; set; } = null!;

        [InverseProperty(EntityFieldConstant.Notification.FK_ToAccount)]
        public virtual ICollection<Notification> Tos { get; set; } = new List<Notification>();

        [InverseProperty(EntityFieldConstant.Comment.FK_Commentor)]
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [InverseProperty(EntityFieldConstant.Blog.FK_Author)]
        public virtual ICollection<Blog> OwnedBlogs { get; set; } = new List<Blog>();

        [InverseProperty(EntityFieldConstant.Blog.FK_Reviewer)]
        public virtual ICollection<Blog> ReviewedBlogs { get; set; } = new List<Blog>();

        [Column(EntityFieldConstant.Account.AwardId)]
        [ForeignKey(EntityFieldConstant.Account.FK_Award)]
        public Guid AwardId { get; set; }
        public virtual ICollection<Award> Awards { get; set; } = new List<Award>();
    }
}
