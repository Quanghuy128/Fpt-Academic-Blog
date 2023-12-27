using FAB.Domain.Common;
using FAB.Domain.Constants;
using FAB.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAB.Domain.Entities
{
    [Table(EntityFieldConstant.Blog.Table)]
    public class Blog : BaseEntity
    {
        [Column(EntityFieldConstant.Blog.ThumbnailUrl)]
        [StringLength(1000)]
        public string ThumbnailUrl { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Blog.Title)]
        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Blog.Content)]
        [StringLength(1000)]
        public string Content { get; set; } = string.Empty;

        [Column(EntityFieldConstant.Blog.Views)]
        public int Views { get; set; } = 0;

        [Column(EntityFieldConstant.Status)]
        [EnumDataType(typeof(BlogStatus))]
        public BlogStatus Status { get; set; } = BlogStatus.Pending;

        [Column(EntityFieldConstant.Blog.ReviewerId)]
        [ForeignKey(EntityFieldConstant.Blog.FK_Reviewer)]
        public Guid ReviewId { get; set; }
        public virtual Account Reviewer { get; set; } = null!;

        [Column(EntityFieldConstant.Blog.AuthorId)]
        [ForeignKey(EntityFieldConstant.Blog.FK_Author)]
        public Guid AuthorId { get; set; }
        public virtual Account Author { get; set; } = null!;

        [Column(EntityFieldConstant.Blog.CategoryId)]
        [ForeignKey(EntityFieldConstant.Blog.FK_Category)]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
