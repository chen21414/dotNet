using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new() //= new List(Item)
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return items; //return whatever we have now
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault(); //we dont wnat return a collection, so use SingleOrDefault here
        }
    }
}


// What is the purpose of readonly?
// Read-only is a file attribute which only allows a user to view a file, restricting any writing to the file. 
// Setting a file to “read-only” will still allow that file to be opened and read; 
// however, changes such as deletions, overwrites, edits or name changes cannot be made.


// Creating a List
// The List<T> is a generic collection, so you need to specify a type parameter for the type of data it can store. 
//The following example shows how to create list and add elements.

// Example: Adding elements in List
// List<int> primeNumbers = new List<int>();
// primeNumbers.Add(1); // adding elements using add() method
// primeNumbers.Add(3);
// primeNumbers.Add(5);
// primeNumbers.Add(7);


// Why do we need IEnumerable in C#?
// IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. 
// This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.