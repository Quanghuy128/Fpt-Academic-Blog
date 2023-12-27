namespace FAB.Domain.Constants
{
    public static class EntityFieldConstant
    {
        static EntityFieldConstant(){}

        public const string Status = "status";

        public static class Account
        {
            public const string Table = "account";
            public const string Gmail = "gmail";
            public const string FirstName = "first_name";
            public const string LastName = "last_name";
            public const string Role = "role";
            public const string BlogNumbers = "blogs_number";
            public const string RoleId = "role_id";
            public const string FieldId = "field_id";
            public const string AwardId = "Award";
            public const string FK_Award = "award_id";
            public const string FK_Field = "Field";
        }

        public static class BannedInfo
        {
            public const string Table = "banned_info";
            public const string AccountId = "account_id";
            public const string Message = "message";
            public const string FK_Account = "Account";
        }

        public static class Notification
        {
            public const string Table = "notification";
            public const string Message = "message";
            public const string FromAccountId = "from_account_id";
            public const string ToAccountId = "to_account_id";
            public const string Type = "type";
            public const string FK_FromAccount = "FromAccount";
            public const string FK_ToAccount = "ToAccount";
        }

        public static class Comment
        {
            public const string Table = "comment";
            public const string CommentorId = "commentor_id";
            public const string BlogId = "from_account_id";
            public const string ToAccountId = "blog_id";
            public const string Content = "content";
            public const string ReplyTo = "reply_to";
            public const string FK_Commentor = "Commentor";
            public const string FK_ReplyTo = "ReplyTo";
            public const string FK_Blog = "Blog";
        }

        public static class Blog
        {
            public const string Table = "blog";
            public const string ThumbnailUrl = "thumbnail_url";
            public const string Title = "title";
            public const string Content = "content";
            public const string Description = "description";
            public const string ReviewerId = "reviewer_id";
            public const string BlogHistoryId = "blog_history_id";
            public const string AuthorId = "author_id";
            public const string CategoryId = "category_id";
            public const string Views = "views";
            public const string FK_Reviewer = "Reviewer";
            public const string FK_Category = "Category";
            public const string FK_Author = "Author";
        }

        public static class Category
        {
            public const string Table = "category";
            public const string Name = "name";
            public const string FieldId = "field_id";
        }

        public static class Award
        {
            public const string Table = "award";
            public const string Name = "name";
            public const string IconUrl = "icon_url";
            public const string Point = "point";
        }

        public static class Field
        {
            public const string Table = "field";
            public const string Name = "name";
        }
    }
}
