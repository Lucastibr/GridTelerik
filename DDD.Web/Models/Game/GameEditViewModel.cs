using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DDD.Core.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Web.Models.Game
{
    public class GameEditViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Game Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description of Game")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Gender of Game")]
        public Guid? GenderId { get; set; }

        public SelectList Genders { get; set; }

        public void BindData(IGameUnitOfWork unitOfWork)
        {
            var query = unitOfWork.Gender.All().Select(c => new { c.Id, c.Name }).OrderBy(x => x.Name);
            Genders = new SelectList(query, "Id", "Name", GenderId);
        }
    }
}
