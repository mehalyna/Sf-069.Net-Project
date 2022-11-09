﻿using SportsHub.Domain.Models;

namespace SportsHub.AppService.Services
{
    public interface IFilterService
    {
        Task<List<Article>> GetListOfArticlesBySubstringAsync(string substring);
    }
}
