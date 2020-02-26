using AspnetCoreWithBugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs.Data
{
    public class ProductDb
    {
        public static async Task<List<Product>> GetAllProducts(ProductContext context)
        {
            return await context.Product.ToListAsync();
        }

        public static async Task<Product> Add(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            await context.SaveChangesAsync();

            return p;
        }

        public static async Task<Product> Edit(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return p;
        }

        public static async Task Delete(Product p, ProductContext context)
        {
            await context.AddAsync(p);
            context.Entry(p).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public static async Task<Product> GetProductById(int id, ProductContext context)
        {
            return await context.Product.FindAsync(id);
        }

        private bool ProductExists(int id, ProductContext context)
        {
            return context.Product.Any(e => e.ProductId == id);
        }
    }
}
