using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        void Create(Item item);
        void Update(Item item);
        void Delete(int id);
    }
}
