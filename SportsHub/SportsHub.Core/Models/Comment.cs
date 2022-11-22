﻿namespace SportsHub.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime PostedOn { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
