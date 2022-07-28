using System.Collections;
using System.Collections.Generic;
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
        private readonly InMemItemsRepository repository;

        //constructor
        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet] //when performs GET/ items, below is the method reacting to it
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();//we created this GetItems() from Repositories
            return items;
        }
    }
}