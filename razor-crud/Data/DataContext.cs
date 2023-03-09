using asp_razor_crud_demo.Model;
using Microsoft.EntityFrameworkCore;
namespace asp_razor_crud_demo.Data
{
    public class DataContext: DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        { 
        }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
