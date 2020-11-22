using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNETUG
{
    public class BlogPost
    {
        
        public string Title { get; set; }

        
        [StringLength(16, ErrorMessage = "Slug is too long (16 character limit).")]
        public string Slug { get; set; }

        
        public string Content { get; set; }
    }

    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Slug).NotEmpty().Length(3, 16);
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
