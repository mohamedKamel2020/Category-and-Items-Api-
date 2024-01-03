# PreRequisites
Visual studio 2022 with .net 7.0
# Technology used 
  ### Asp .net core api 7.0
  ### MS SQL Server
# Installation
 1- clone the Repository
 2- open folder CategoryAndItemApi
 3- open project with visual studio
 4- open package manager cosole to add migration for create database the first confirm the connection string with the local machine 
 and delete folder Migrations from CategoryAndItemAPI.DAL then open package manager cosole when CategoryAndItemAPI is startup project
 and select default project CategoryAndItemAPI.DAL in package manager cosole and write Add-Migration InitialCreate then Run project
 5-excute api using Postman or Swagger base url is https://localhost:7087/
   ### Categories api
    Get All Categories
    Action GET https://localhost:7087/api/Categories
    Get Categry by Id
    Action GET https://localhost:7087/api/Categories/1
    Add new Category
    Action POST https://localhost:7087/api/Categories
    Update Category
    Action PUT https://localhost:7087/api/Categories/10
    delete Category
    Action DELETE https://localhost:7087/api/Categories/10
   ### Items Api
    Get All Items
    Action GET https://localhost:7087/api/Items
    Get Item by Id
    Action GET https://localhost:7087/api/Items/1
    Add new Item
    Action POST https://localhost:7087/api/Items
    Update Item
    Action PUT https://localhost:7087/api/Items/10
    delete Item
    Action DELETE https://localhost:7087/api/Items/10
![Screenshot (189)](https://github.com/mohamedKamel2020/Category-and-Items-Api-/assets/88276377/80c367a2-ce1e-486d-99b5-c015fee61ee2)
 
    
    
Add
