﻿using SportsHub.AppService.Authentication.Models.DTOs;
using SportsHub.Domain.Models;

namespace UnitTests.MockData
{
    public class CommentMockData
    {
        public static CreateCommentDTO GetComment()
        {
            return new CreateCommentDTO()
            {
                Content = "test",
                ArticleId = 5,
                AuthorId = 3
            };
        }

        public static IEnumerable<Comment> GetForArticle()
        {
            return new List<Comment>
            {
                new Comment()
                {
                    Content = "testComment1",
                    ArticleId = 5,
                    AuthorId = 3
                },
                new Comment()
                {
                    Content = "testComment2",
                    ArticleId = 5,
                    AuthorId = 3
                },
                new Comment()
                {
                    Content = "testComment3",
                    ArticleId = 5,
                    AuthorId = 3
                },
            };
        }
    }
}
