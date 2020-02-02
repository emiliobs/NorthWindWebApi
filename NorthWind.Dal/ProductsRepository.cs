using Northwind.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Dal
{
    public class ProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll() => _context.Products.ToList();
        public Product GetById(int id) => _context.Products.Where(p => p.Id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return product;
        }

        public void Delete(int id)
        {
            _context.Remove(new Product { Id = id});
            _context.SaveChanges();
        }
     
    }
}
