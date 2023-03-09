using asp_razor_crud_demo.Data;
using asp_razor_crud_demo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_razor_crud_demo.Pages.Category;

//為此類所有屬性進行雙向綁定
//所有此類中的屬性，如果有在UI上使用到，就會自動雙綁
//有寫這個就不需要個別寫[BindProperty]
[BindProperties]

public class EditModel : PageModel
{
    private readonly DataContext _db;
    public EditModel( DataContext db )
    {
        _db = db;
    }

    //[BindProperty]  //個別雙向綁定 : 如果有使用BindProperties就不用寫囉~
    public CategoryModel Category { get; set; } //把這個屬性和ViewModel進行雙向綁定，就可以直接在各個handler中取用vieModel傳來的資料囉!

    //Get handler
    public void OnGet(int id)
    {
        Category = _db.Categories.Find(id);
        //以下這些方法也可以達到同樣的效果
        //Category = _db.Categories.SingleOrDefault(c => c.Id == Id);
        //Category = _db.Categories.FirstOrDefault(c => c.Id == Id);
    }

    //Post handler
    public async Task<IActionResult> OnPost()
    {
        //客製化驗證
        if (Category.Name == Category.DisplayOrder.ToString()) 
        {
            //和MVC中的不同，必須要使用Category.Name
            ModelState.AddModelError("Category.Name", "Name和DiplayOrder不可以是相同名稱");
        }
        if (ModelState.IsValid) //使用內建的ModelState會自動把表單內有綁定的屬性作驗證
        {
                _db.Categories.Update(Category);  //Update方法沒有async唷~
                await _db.SaveChangesAsync();
                TempData["success"] = "編輯成功!";
                return RedirectToPage("Index");  //跳回首頁
        }
        return Page(); //否則停留此頁面
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
