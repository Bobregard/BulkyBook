using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var productFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (productFromDb != null) 
            { 
                productFromDb.Title = product.Title;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price;
                productFromDb.Price50 = product.Price50;
                productFromDb.Price100 = product.Price100;
                productFromDb.ListPrice = product.ListPrice;
                productFromDb.Author = product.Author;
                productFromDb.ISBN = product.ISBN;
                productFromDb.CoverTypeId = product.CoverTypeId;
                productFromDb.CategoryId = product.CategoryId;
                if (productFromDb.ImageUrl != null)
                {
                    productFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
