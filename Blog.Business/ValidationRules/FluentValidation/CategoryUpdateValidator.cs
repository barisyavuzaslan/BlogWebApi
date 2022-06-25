using Blog.DTO.Dtos.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("id alanı boş geçilemez");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
        }
    }
}
