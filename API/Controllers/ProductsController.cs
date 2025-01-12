using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class ProductsController:BaseApiController
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Products>>> getProducts(){
           return await context.Products.ToListAsync();
             
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Products>> getProduct(int id){
            var res= await context.Products.FindAsync(id);

            if (res == null) return NotFound();

            return res;
        }
    }
    
}