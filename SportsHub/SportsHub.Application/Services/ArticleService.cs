using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsHub.Api.Exceptions.CustomExceptionModels;
using SportsHub.AppService.Authentication.Models.DTOs;
using SportsHub.Domain.Constants;
using SportsHub.Domain.Models;
using SportsHub.Domain.Models.Constants;
using SportsHub.Domain.Models.Enumerations;
using SportsHub.Domain.UOW;
using System.Net;

namespace SportsHub.AppService.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _unitOfWork.ArticleRepository.GetAllAsync();
        }

        public async Task<Article?> GetByTitleAsync(string title)
        {
            return await _unitOfWork.ArticleRepository.GetByTitleAsync(title) ??
                   throw new NotFoundException(string.Format(ExceptionMessages.NotFound, ExceptionMessages.Article));
        }

        public async Task<string> CreateArticleAsync(CreateArticleDTO adminInput)
        {
            var articleExists = await _unitOfWork.ArticleRepository.GetByTitleAsync(adminInput.Title) != null;

            if (articleExists)
            {
                throw new BusinessLogicException(StatusCodeConstants.BadRequest, ValidationMessages.UnableToCreateArticle);
            }

            var categoryExists = GetCategoryById(adminInput.CategoryId);

            if (categoryExists == null)
            {
                throw new BusinessLogicException(StatusCodeConstants.BadRequest, ValidationMessages.UnableToCreateArticle);
            }

            var article = new Article()
            {
                Title = adminInput.Title,
                CategoryId = adminInput.CategoryId,
                StateId = (int)StateEnums.Unpublished,
                Content = adminInput.Content,
                ArticlePicture = adminInput.ArticlePicture,
                CreatedOn = DateTime.UtcNow
            };

            await _unitOfWork.ArticleRepository.AddArticleAsync(article);
            await _unitOfWork.SaveChangesAsync();

            return ValidationMessages.ArticleCreatedSuccessfully;
        }

        public async Task<bool> EditArticleAsync(CreateArticleDTO adminInput)
        {
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(adminInput.ArticleId);

            if (article == null)
            {
                return false;
            }

            var categoryExists = GetCategoryById(adminInput.CategoryId);

            if (categoryExists == null)
            {
                return false;
            }

            _mapper.Map(adminInput, article);

            _unitOfWork.ArticleRepository.UpdateArticle(article);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private async Task<Category?> GetCategoryById(int categoryId)
        {
            return await _unitOfWork.CategoryRepository.GetCategoryById(categoryId);
        }

        public async Task<List<Article>> GetListOfArticlesBySubstringAsync(string substring)
        {
            return await _unitOfWork.ArticleRepository.GetBySubstringAsync(substring);
        }

        public async Task DeleteArticleAsync(int id)
        {
            var articleForDelete = await _unitOfWork.ArticleRepository.GetByIdAsync(id);

            if (articleForDelete is null)
            {
                throw new NotFoundException(string.Format(ExceptionMessages.NotFound, ExceptionMessages.Article));
            }

            await _unitOfWork.UserRepository.DeleteArticle(articleForDelete);

            _unitOfWork.ArticleRepository.DeleteArticle(articleForDelete);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}