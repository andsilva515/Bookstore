using EcommerceLivrariaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercelivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context)
        {
            _context = context;

            _context.todoProducts.Add(new Produto { ID = "1", Nome = "Book1", Preco = 24.0, Quant = 1, Categoria = "Acao", Img = "img1" });

            _context.todoProducts.Add(new Produto { ID = "2", Nome = "Book2", Preco = 30.0, Quant = 3, Categoria = "Acao", Img = "img2" });

            _context.todoProducts.Add(new Produto { ID = "3", Nome = "Book3", Preco = 4.0, Quant = 10, Categoria = "Acao", Img = "img3" });

            _context.todoProducts.Add(new Produto { ID = "4", Nome = "Book4", Preco = 94.0, Quant = 5, Categoria = "Acao", Img = "img4" });

            _context.todoProducts.Add(new Produto { ID = "5", Nome = "Book5", Preco = 24.0, Quant = 2, Categoria = "Acao", Img = "img5" });

            _context.SaveChanges();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        // Ainda falta implementar o metodo Post

        //[HttpPost]
        //public async Task<ActionResult<Produto>> PostProduct(Produto produto)
        //{
        //    _context.todoProducs.Add(produto);

        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, produto);
        //}
    }
}
