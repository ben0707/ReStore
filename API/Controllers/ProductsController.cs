using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controller
{

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private StoreContext _dbcontext;

        public ProductsController(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _dbcontext.Products.ToListAsync();
        
        return Ok(products);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        
        return await _dbcontext.Products.FindAsync(id);
    }

    }

}