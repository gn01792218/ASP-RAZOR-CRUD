using asp_razor_crud_demo.Data;
using asp_razor_crud_demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_razor_crud_demo.Pages.Category;

//為此類所有屬性進行雙向綁定
//所有此類中的屬性，如果有在UI上使用到，就會自動雙綁
//有寫這個就不需要個別寫[BindProperty]
[BindProperties]

public class DeleteModel : PageModel
{
    private readonly DataContext _db;
    public DeleteModel( DataContext db )
    {
        _db = db;
    }

    //[BindProperty]  //個別雙向綁定 : 如果有使用BindProperties就不用寫囉~
    public CategoryModel Category { get; set; } //把這個屬性和ViewModel進行雙向綁定，就可以直接在各個handler中取用vieModel傳來的資料囉!

    //Get handler
    public void OnGet(int Id)
    {
        Category = _db.Categories.Find(Id);
        //以下這些方法也可以達到同樣的效果
        //Category = _db.Categories.SingleOrDefault( c => c.Id == id);
        //Category = _db.Categories.FirstOrDefault(c => c.Id == id);
    }

    //Post handler
    public async Task<IActionResult> OnPost()
    {
            _db.Categories.Remove(Category);  //Remove方法沒有async唷~
            await _db.SaveChangesAsync();
            TempData["success"] = "刪除成功";
            return RedirectToPage("Index");  //跳回首頁
    }
}
