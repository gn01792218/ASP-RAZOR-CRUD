# 問題統整
## 1.Page Model中有依賴注入Db時，似乎不能使用[BindProperties]?
問題原因 : 出在db宣告的方式
```c#
//原本這樣宣告，會導致一起被 BindProperties 雙綁
public DataContext _db {get;set;}

//要改成這樣
private readonly DataContext _db;
```
