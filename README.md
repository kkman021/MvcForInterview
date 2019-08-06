# 面試用的專案

## 專案背景說明

 - 採用 .NET MVC 作為開發框架
 - 採用 SB.Admin2 作為版型，SB.Admin2 版型參考來源：https://github.com/lvasquez/sb-admin-2-bootstrap-template-asp-mvc
 - 主要撰寫一個 員工資料的 CRUD 功能
 - 資料庫技術採用 Entity Framework Db First 開發模式，會使用  [EntityFramework Reverse POCO Generator]("https://github.com/sjh37/EntityFramework-Reverse-POCO-Code-First-Generator") 進行操作
 - 資料庫部分會採用 Autofac 作為 DI 工具，此部分會將資料庫作為演示目標
 - 前端部分採用 Razor 搭配 jQuery ， 其中會用到幾個套件：
     - [DataTable]("https://datatables.net/")