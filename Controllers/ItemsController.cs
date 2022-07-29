using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    //url: GET/ items

    [ApiController] //mark this class API controller; make life easier
    [Route("[items]")]//whatever name of the controller is, that's going to be the route
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        //constructor
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] //when performs GET/ items, below is the method reacting to it
        public IEnumerable<ItemDto> GetItems()
        {
            //was: var items = repository.GetItems();
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;


            //this used to be below, we used extensions instead
            // var items = repository.GetItems().Select(item => new ItemDto {
            //     Id = item.Id,
            //     Name = item.Name,
            //     Price = item.Price,
            //     CreatedDate = item.CreatedDate
            // });
        }
        //we created this GetItems() from Repositories

        //get one specific item
        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id) //actionResult allows us to return more than one type (for notFound)
        {
            var item = repository.GetItem(id);

            //if can't find the item
            if (item is null)
            {
                return NotFound();//404
            }

            return item.AsDto();
        }

    }
}