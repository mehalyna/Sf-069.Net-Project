﻿using SportsHub.AppService.Authentication.Models.DTOs;
using SportsHub.Domain.Models;

namespace SportsHub.AppService.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetByTitleAsync(string title);
        Task<string> CreateArticleAsync(CreateArticleDTO adminInput);
        Task<bool> EditArticleAsync(CreateArticleDTO adminInput);
        Task<List<Article>> GetListOfArticlesBySubstringAsync(string substring);
        Task DeleteArticleAsync(int id);
    }
}
