using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EcommerceLivrariaAPI.Models
{
    public class ToDoContext : DbContext 
    {
        internal object todoProducs;

        public ToDoContext(DbContextOptions<ToDoContext> option) : base(option)
        {

        }
        public DbSet<Produto> todoProducts { get; set; }

    }


}
