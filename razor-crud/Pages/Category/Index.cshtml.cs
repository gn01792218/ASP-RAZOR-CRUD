using asp_razor_crud_demo.Data;
using asp_razor_crud_demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_razor_crud_demo.Pages.Category
{
    public class IndexModel : PageModel
    {
        //依賴注入DB
        public DataContext _db { get; set; }
        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public IEnumerable<CategoryModel> Categories { get; set; }
        
        //�ϥ�Get��k��oCategory�M��
        public void OnGet()
        {
            Categories = _db.Categories;  //����C��
        }
    }
}
