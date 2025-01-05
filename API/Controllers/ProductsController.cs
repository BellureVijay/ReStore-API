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
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
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
            return await context.Products.FindAsync(id);
        }
    }
    
}