using FAB.Domain.Common;
using FAB.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Comment.Table)]
    public class Comment : BaseEntity
    {
        [Column(EntityFieldConstant.Comment.Content)]
        [StringLength(500)]
        public string Content { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Comment.CommentorId)]
        [ForeignKey(EntityFieldConstant.Comment.FK_Commentor)]
        public Guid CommentorId { get; set; }
        public virtual Account Commentor { get; set; } = null!;

        [Column(EntityFieldConstant.Comment.ReplyTo)]
        [ForeignKey(EntityFieldConstant.Comment.FK_ReplyTo)]
        public Guid ReplyToId { get; set; }
        public virtual Comment ReplyTo { get; set; } = null!;

        public virtual Comment CommentTo { get; set; } = null!;

        public virtual Blog Blog { get; set; } = null!;

    }
}
