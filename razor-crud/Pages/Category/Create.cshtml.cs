using asp_razor_crud_demo.Data;
using asp_razor_crud_demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_razor_crud_demo.Pages.Category;

//為此類所有屬性進行雙向綁定
//所有此類中的屬性，如果有在UI上使用到，就會自動雙綁
//有寫這個就不需要個別寫[BindProperty]
[BindProperties]

public class CreateModel : PageModel
{
    private readonly DataContext _db;
    public CreateModel( DataContext db )
    {
        _db = db;
    }

    //[BindProperty]  //個別雙向綁定 : 如果有使用BindProperties就不用寫囉~
    public CategoryModel Category { get; set; } //把這個屬性和ViewModel進行雙向綁定，就可以直接在各個handler中取用vieModel傳來的資料囉!

    //Get handler
    public void OnGet()
    {
    }

    //Post handler
    public async Task<IActionResult> OnPost()
    {
        await _db.Categories.AddAsync(Category);  //因為我們有雙向綁定Category，所以可以直接取用哦!
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");  //跳回首頁
    }

    //1.如果沒有雙向綁定的話得這樣寫
    //public async Task<IActionResult> OnPost(CategoryModel category)
    //{
    //    await _db.Categories.AddAsync(category);
    //    await _db.SaveChangesAsync();
    //    return RedirectToPage("Index");
    //}

    //2.如果需要多個Post handler的話
    //只要命名都有帶OnPost前綴即可
    //例如 : OnPostCreate
}
