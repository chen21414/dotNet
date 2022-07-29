using System;
using System.Collections.Generic;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IItemsRepository //used to be public class InMemItemsRepository{}
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}