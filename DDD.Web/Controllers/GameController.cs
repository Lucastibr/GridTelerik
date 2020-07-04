using System;
using DDD.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DDD.Core.Domain;
using DDD.Web.Models.Game;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace DDD.Web.Controllers
{
    public class GameController : Controller
    {
        public IGameUnitOfWork UnitOfWork { get; }

        public GameController(IGameUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new GameCreateViewModel();
            model.BindData(UnitOfWork);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GameCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BindData(UnitOfWork);
                return View(model);
            }

            var game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Gender = model.GenderId.HasValue ? UnitOfWork.Gender.Get(model.GenderId) : null
            };

            UnitOfWork.Game.Save(game);
            UnitOfWork.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(Guid? id)
        {
            var game = UnitOfWork.Game.Get(id);

            var model = new GameEditViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                GenderId = game.Gender.Id
            };

            model.BindData(UnitOfWork);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GameEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BindData(UnitOfWork);
                return View(model);
            }

            var game = UnitOfWork.Game.Get(model.Id);

            game.Name = model.Name;
            game.Description = model.Description;
            game.Price = model.Price;
            game.Gender = model.GenderId.HasValue ? UnitOfWork.Gender.Get(model.GenderId) : null;

            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            var game = UnitOfWork.Game.Get(id);
            UnitOfWork.Game.Delete(game);
            UnitOfWork.SaveChanges();

            return Json(game);
        }

        public IActionResult TelerikGrid([DataSourceRequest] DataSourceRequest request)
        {
            var result = UnitOfWork.Game.All()
                .Select(x => new GameListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    GenderName = x.Gender.Name
                })
                .ToDataSourceResult(request);

            return Json(result);
        }



    }
}

