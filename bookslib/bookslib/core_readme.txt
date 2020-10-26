Media queries
hamburger menu
code with harry after 1:48 hrs
flex-direction
smooth scroll
bootstrap
I.shekhar26@gmail.com
talent next asp .net procedure
0-------------------------core-------------
difference between map and mapget 
map will handle all the request and mapget will handle only the input request

kesteral server
there are two methods in the startup file -- configure() and configureservices()
the later one is used to define the dependencies which we are going to use in our application

the configure method is used to define the http service middleware
https://www.youtube.com/watch?v=gxu1fsHGvMo&list=PLaFzfwmPR7_LTXu0Vz9Zz_Y0OMMC7ArHZ&index=12&ab_channel=WebGentle

if the name of the view is equal to the name of the action method,
return (view model  obj)

if the name of the view is not equal to the name of the action method 
return (view name, view model object)

ViewEngine is a piece of code which is used to render server side code, works with views, set/get the path for the default view location, razor is a view engine, write a c# logics on 
view page. everything starts with @

@expression
@DateTime.Now
@Yourc#variable

Static files
All static files must be placed inside the wwwroot folder
Its also known as the content root folder
It must be present at the root level

In order to use the static files we need to use the middleware in the startup.cs file

app.UseStaticFiles(new StaticFileOptions() {

                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory() + "MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            }) ;

Libman.json

Razor files engine compiles only two times- it compiles when we build our solution and when we publish our solution
Install a new package to the solution
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

make some changes in the startup file - add in the 
        public void ConfigureServices(IServiceCollection services)


services.AddRazorePages().AddRazorRuntimeCompilation();

there is a 	condition in which this needs to run as it impacts the performance of the application
so that is only the development environment
--------------------------------------------------------------------------------
Layout:- RenderBody() method is used inside the layout file to provide space for the other view

we can have only one RenderBody() method inside the one layout file 		

Benifits:
less code
centralized code for the static files
No duplicate code
Easy to update
Good architecture
-----
Adding navigation bar

we will use bootstrap
-------------------------------------------
Display Model list data on the view in Asp.Net Core
@model-- when we are getting the data in the model and we need to display it on the view
----------------------------------
Render Section

RenderSection is a space with the a specific name and is used in the _Layout file
It tells the application that some other code is coming here

Section
Section is used on views
create a section we use @section directive
Each section has a unique name and we will write inside the section block that will replace the RenderSection defined in _Layout file with the same name

Situation

Header
CSS
Body
js
RenderSection
Footer

there is section which can be placed anywhere in the cshtml file and then is rendered in the layout page of the application and is placed inside the @render("section",. required: false)
and is placed at the suitable position of the UI
---------------------------------------------------------------
View start is the view which gets triggered before the view file

view imports-- common directives in this are 
@addTagHelpers
@removeTagHelpers
@tagHelperPrefix
@using
@model
@inherits
@inject
the main purpose of the view imports is to have all the directives imported at the common location
----------------------------------------------------------------------------------------------
What is the use of the view bag -- used to pass the data from the action method to the view and is the loosely binding, can pass any kind of data, uses dynamic property
viewbag.propertyname= data;

view ba g is a server side code so we need to use the razor syntax.
@view bag.property

we cannot use anonymous object in the view directly, inorder to use it we need to use the expando object and that is present in the using system.dynamic;

In case we need to send multiple data on the view then the viewBag is the easiest option

view bag works on the dynamic type hence it does not gives the compile time error

we can pass data with viewbag with or without model

The scope of view bag is to current action method to view
----------------------------------------------------------------------------------------------
View Data

loosely binding, pass any kind of data, uses dictionary type, eg: ViewData["key name"]= value; , server side code so you need to use razor syntax, we can use n number of view data on
a single view, works on ViewDataDictionary type, we need to convert the data type, is used to pass data from view to its layout view

		@{
		var bookInfo = ViewData["book"] as BookModel;
		}	
		
		then create @bookInfo.Id
----------------------------------------------------------------------------------------------
ViewData vs ViewDataAttribute

viewdata attribute is used to create attribute and then we can send the data directly from controller to view.
-----------------------------------------------------------------------------------------------
Dynamic views in asp.net core

if we pass the instance of the model in view, then also we can get the data of the model in the view.
the second is the conventional idea using the view model @viewModel

Try to avoid the dynamic view model as there is no compile time checking and in a large application it may create issues

this can be helpful in passing the ananymous data as well:

public viewResult GetBook(int id)
{
var data = new system.dynamic.expandoObject();
data.book = _bookrepository.GetBookById(id);
data.name="Abhinav";
}
-----------		
Tag helpers
These are used to render the server side code in the UI of the application.
These are used to create the controls like the image and the link etc
These provide the html friendly developemnt environment

First we need to set the scope for the Tag Helper
This scope can be set by 
@addTagHelper directive
@removeTagHelper directive

How to use the tag helper directive

@addTagHelper tagHelper, Assembly
if you need all the tag helpers then use *
addTagHelper *, Microsoft.AspNetCore.MVC.TagHelpers

ActionTag Helper**
1.Create link using ATH
2.How to pass the parameter value
3.How to pass lots of lots of query string data
4.How to pass fragment
5.How to pass the complete URL

Used to create a link using the <a></a> html elements
By default it is prefixed with asp-
asp-controller,action,area The main feature is to navigate to the specific page


<li class="nav-item">
                        <a class="nav-link" asp-controller="Book" asp-action="GetAllBooks">All Books</a>
                    </li>

How to pass parameter using the anchor tag
Attribute :- asp-route-{parameter}

asp-all-route-data
@{ 
    var parametres = new Dictionary<string, string>()
    {
        {"name","Abhinav" },
        {"company","Mphasis" },
        {"appName","bookstore" },
    };
}

asp-all-route-data="@parametres"


asp-fragment="similarBooks"  --- in getallbook
id="similarBooks"		--- in getbook			

Pass complete url using Anchor tag
Attribute
asp-protocol
asp-host
  <li class="nav-item">
                        <a class="nav-link" asp-protocol="http" asp-host="lib.com" asp-controller="Book" asp-action="GetAllBooks">New Link</a>
                    </li>

compatible with routing

asp-route in the cshtml page for the name of the route use
        [Route("book-details/{id}", Name ="bookDetailsRoute")]


  <div class="btn-group">
                                <a asp-route="bookDetailsRoute" asp-route-id="@book.Id"                               
                                   class="btn btn-sm btn-outline-secondary">View details</a>
                            </div>				
---------------------------------------------------------------------------------------------------------------
Image tag helper- what is ?what problems resolve? caching using Image tag helper?
provides additional capablilities to HTML img tag
Image tag helper provide cache busting behaviour for the static image

Attribute:: issue that the image comes with the local cache and incase the images needs to be updated then the cache needs to be cleared
asp-append-version							

But this is helpful only when u are using the own server to retrive the image files and not any third party application
----------------------------------------------------------------------------------------------------------------
Environment tag helper- used to render some content based on current environment
(Developemnt,staging,production)

there are three atrributes: name, include and exclude
----------------------------------------------------------------------------------------------------------------
Link Tag HelperS-- helps to resolve the issues related to the CDN down state
href
asp-fallback-href
asp-fallback-test-class
asp-fallback-test-property
asp-fallback-test-value
---------------------------------------------------------------------------------------------------------------
Asp.net core form
In case we create any post method in the form we get a request token

here we will use the tag helpers as 
asp=for="Title"

we have used the type as post in the form and also used the httppost attribute over the action method , based on this the model binder will bind the model in the form
-----------------------------------------------------------------------------------------------------------------
ORM
O/RM is used to manage the database data from an object oriented presperctive
Database tables => Classes
Column => Properties
To generate database tables or classes we can eitther use the database or code based first approach


How to setup DbContext class in entity framework core
We can configure db connection string:
-  by overriding OnConfiguring() method in our dbcontext class.
-  in ConfigureServices() method in Startup class

    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
        {

        }
    }
	
	keep models seperate and keep entity class seperate
	47693
	6162986

-------------------------------
 get-help entityframework

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

TOPIC
    about_EntityFrameworkCore

SHORT DESCRIPTION
    Provides information about the Entity Framework Core Package Manager Console Tools.

LONG DESCRIPTION
    This topic describes the Entity Framework Core Package Manager Console Tools. See https://docs.efproject.net for
    information on Entity Framework Core.

    The following Entity Framework Core commands are available.

        Cmdlet                      Description
        --------------------------  ---------------------------------------------------
        Add-Migration               Adds a new migration.

        Drop-Database               Drops the database.

        Get-DbContext               Gets information about a DbContext type.

        Remove-Migration            Removes the last migration.

        Scaffold-DbContext          Scaffolds a DbContext and entity types for a database.

        Script-DbContext            Generates a SQL script from the current DbContext. 

        Script-Migration            Generates a SQL script from migrations.

        Update-Database             Updates the database to a specified migration.

SEE ALSO
    Add-Migration
    Drop-Database
    Get-DbContext
    Remove-Migration
    Scaffold-DbContext
    Script-DbContext
    Script-Migration
    Update-Database	

Add-Migration init


so forst we create a migration and then we apply the migration and based on the script the tables are created
---------------------------------------------
Adding new record 
use the context class instance in the constructor


we need to resolve the dependency injection:-in the startup.cs class using
book controller

 private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
		
		
 [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel) 
        {
           int id = _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook));
            }
            return View();
        }
--- 
BookStoreContext.cs
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
        {

        }
        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
-------------
            services.AddScoped<BookRepository, BookRepository>();
			IActionResult
AutoMapper is a component that helps to copy data from one type of object to another type of object. It is more like an object-object mapper. According to the AutoMapper docs
-------------------------
Validation
Asp-validation summary(All, modelOnly, none)
bookcontroller
            ModelState.AddModelError("", "This is my custom error message");
---------------------------------
generate form field models using DataType attribute-- advantage is you can generate the firelds from the form itself
DataType.NameOfProperty
some data type attribute is still not working as of now
  [DataType(DataType.DateTime)]
        [Display(Name ="Choose date and time")]
        public string MyField { get; set; }
----------------------------------------
dropdown with text and value property
the value that you set in the property is the value in the database
    <option value="">Please choose your language</option>
            <option value="Hindi">Hindi - one of the best language</option>
            <option value="English">English-- global language</option>
            <option value="Dutch">French- my custom language</option>
----------------------------------------------
Create dropdown in asp.net core with text and value using SelectList 
passing data through the model property using the @book.id  and incase you need to pass through the controller using the viewbag

you can create groups in class and also use multi select option using the list<> type in the input
----------------------------------------------
Using enum

you need to use the enum class
change the property type to enum
Html.GetEnumSelectList<LanguageEnum>()
Localization and Globalization in Windows Store Apps
----------------------------------------
How to use the custom validation attribute
Create a helper classinherit from the validation attribute 
Apply the logic and put it on the model class

Html.GetEnumSelectList<LanguageEnum>()
---------------------------------------
Custom tah helper in 

create a cusom class for the helper tag method then mention the tag name output as   output.TagName = "a"; 
output.tagname="a";

-------------------------------------
client side validation

threee library that we need 
jquery.js
jquery.validate.js
jquery.validate.unobstrusive.js

    <environment include="Development">
        <script src="~/lib/jquery/jquery.js"></script>
        <script src="~/jquery-validate/jquery.validate.js"></script>
        <script src="~/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"></script>
    </environment>
	
	In order to diable the client side validation you need to disable in startup class
	 services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option=> {
                option.HtmlHelperOptions.ClientValidationEnabled = false;
            });
--------------------------------------------------
Ajax- what libraries are required create ajax form , loader in ajax
jquery.js
jquery.unobtrusive-ajax.js


adding loader and usig ajax

    </div>
    <div class="form-group">
        <input type="Submit" value="Add book" class="btn btn-primary" />
    </div>
    <div class="d-flex justify-content-center" id="myLoader" style="display:none">
        <div class="spinner-border" role="status"id="myLoader">
            <span class="sr-only">Loading...</span>
        </div>
    </div>


</form>
</div>

@section scripts{ 
<script>
    function myComplete(data) {
        alert("I am from complete");
    }
    function mySuccess(data) {
        alert("I am from Success");
    }
    function myFailure(data) {
        alert("I am from Failure");
    }
</script>
}


<form method="post" data-ajax="true" data-ajax-complete="myComplete" data-ajax-success="mySuccess"
      data-ajax-failure="myFailure" data-ajax-loading="#myLoader"
      asp-action="AddNewBook">	
	  ---------------------
Working with images
before storing the image files in the database we need to store in the third party tools like azure blob storage or AWS or here we are using the www root folder to store the static files

if you are dealing with the files in the form, then you must use the attribute enctype ="multipart/form-data" in the form	  

with the help of dependency injection in the dot net core
       if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    folder += Guid.NewGuid().ToString()+ "_"+ bookModel.CoverPhoto.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                   await bookModel.CoverPhoto.CopyToAsync(new FileStream( serverFolder, FileMode.Create));
                }
--------------------------------------------
save uploaded image path in the database
display image on the view

--------------------------------------------
Upload multiple images in the asp net core and create one to many relationship in the ef core		

there are three data types while uploading the multiple images:-
IFormFileCollection
<list>IFormFile
IFormFile<IEnumerable>		

Inside the book model class we have set the         public ICollection<BookGallery> BookGallery { get; set; }
and this is how we have created one to manyt relationship
------------------------------------------------------------
Upload pdf file in asp.net core
Display pdf in browser full tables
Embedd pdf in view

changes that we have till now
added a new property in the modal class
updated the view file
-----------------------------------------------
what are the partial views
how to create and how to use
how to pass data (Model) psrtial view
async partial view -- exclusive in dot net  core


Partial view is a .cshtml razor mark up file that is used to render content  html within other view file output
In general Partial view is a normal cshtml file but the way we use them over the other file makes special

Remove duplicate Razor content from the application
Break up large file into small components

when not to use the partial view
suppose you need to write the complex code or call your controller to get the data and render the razor markup.(for instance consider while using the blob structure)
Rather use the view component (this new feature is introduced in dot net core) -- earlier we were using the partial view for this
-------------
how to render partial view on another view

In asp.net core we have the Partial tag helper and in the HTML helper we have
Partial Partial Async

render Partial and Render Partial Async
--------------------------------------------
what is a view componenet ? where can we use view component ? how to create a view component? how to use a view component in a view file
 view component dont use the model binding only depend on the data provided to it
 
 view component is actually used to render view + data on a view file without actually being a part of http cycle

where csn we use View Component
Dynamic navigation menu(Role based )
Get some data for the page
Link: related post related books
Shoping cart
content visible on the side of the page 

View component has two files C# and the html file

file location  for the c# file -- anywhere in the solution

view file
views/controller name/compoent / view componenet/view name
views/shared/components/view component/view name
pages/shared/compoenent/view componenet/view name

---------------------------------
how to use a View Component on view
@await Component.InvokeAsync("Name of the view component",{Anonymous type Container Parameter})
ex-
@await Component.InvokeAync("RelatedBooks", new {bookId = 4, isSort= true})

View Component is a very important concept in the asp .net core
--------------------------------------------------
Routing
Routing is the process of mapping incoming http request to a particular resource(i.e controller and the action method)

We can define a unique url to each of the resource

in asp.net core we enable routing through middleware
UseRouting()
UseEndpoints()

Two types of routing in 
Conventional and attribute routing

The general convention for the routing is controller and the action method and the id passed 
example
{controller}/{action method name}/{id}

You can also change the pattern using the anchor tag helper like
{action }/{controller}/{id} also works 

All the routes should be with unique combination of utl+http method
we can define multiple routes for one resource
we can not define same route for multiple resource
------------------------------------------------
Attribute based routing
What is attribute routing?
How to set routes using the  attribute based routing
How to pass parameter in Attribute routing
Routing with Http verb
Controller level routing
Routing override

You can set the name order and the http verb in the route paramter

how to exchange the token value

if you place the ~ symbol at the cotroller level then we can override the route at the action level
---------------------
what is the need of constraint
what all constraint are  available in asp.net core?
how to use constraint?

routing constraint -- typw , length, alpha, regex, required

https://github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/fundamentals/routing.md

route constraint go to line 8:20
------------------------------
dependency injection

Is used to achieve IOC -- helps to achieve the code as loosely coupled

Suppose you need to change something in the service level then all the places where services will be used also needs to be changed -- without dependency injection

with dependency injection
use the interface lcasses to implement the DI- where you can use these
constructor, method or property


core has a built in support for DI-
These are registered in containers and are called IServiceProvider
Registered in Startup.ConfigureService

Services are registered in following lifetimes
Transient(AddTransient<>)- A new instance of the service will be created everytime it is requested
Scoped(AddScoped<>)- These are created as per client request
Singleton(AddSingleton<>)- Same instance for the application


Benefits of -- loosely coupling between repository and controller
does not create the instance of repository rather than the DI container itself
controller does not define the implementation of repository is used in the controller. this makes it easy to change the implementation of repo without modifying the controller class
--------------------------------------------------
Dependency injection in views
whatever services u have defined in the application you can use them directly in the view file

earlier we were used to register the service and then from the controller we were used to pass the data to the view , but in the view we can inject as 

@inject bookslib.Repository.ILanguageRepository _languageRepo
---------------------------------------------------------------------------

App settig.json file 
what is app setting.json file -- settings related to the app , you can have as many number of app.setting file
what is configuration service
how to use the configuration service
how to get the data from the appsetting.json file



we can store the connection string in the app setting .json file
these setting can be read in the program files 
IHostBuilder is used for the configuration of the files
Iconfigure is registered automatically 

the environment variable is present in the launch settings 
----
what is the need of getvalue<>-- we use to read the value from the configuration files


Bind method 


difference in between Ioption, Ioption snapshot and Ioption monitor

Ioption is singleton
snapshot is auto update
monitor is both singleton and updateable
----------------------------------
Identity core- used to provide security to any dot net application
Not only limited to sign up and sign in

Features that it provides
Common feature for all dot net application
all required tables
register
login 
change password
forgot password(reset password)
User validation
password validation
password hashing
multi factor authentication - ex 3f authentication
lockout- block user on n wrong password attempts
external identity

microsoft.aspnetcore.identity.entityframeworkcore

How to enable the authentication()

First create the model for the user 
then create the controller 
create the view

now in order to save the data -- we need to create the repository

User manager and the sign in manager -- these two are very important in the identity framework
UserManager and SignInManager in Asp.Net Core Identity
Asp.net core provides two important services.

UserManager
SignInManager
The above 2 services are used to create users, validate the user and then add it to the database.

create the custom addeded columns in the identity tablescreate a create class and inherit it into that.
---------------------------------------------
 Login in asp.net core using Identity core framework 
 Create the model class , add the action method in the account controller and add a view
 go to account repository 
 signInModel -- signIn.model, password, rememeber me , false
 
 ----------------------
 To implement the logout visibility :
 
 
 to implement the login and logout functionality, we need to create the partial view and inside that we use the signInManager 
 [Route("logout")]
 public astnc Task<IActionResult> Logout()
 {
 await _accountReposirory.signoutAsync();
 return RedirectToAction("Index","Home");
 }
 --------------------------------------
 Authorize attribute in Asp.Net Core
 [Authorize] helps to check if the user is logged in and can be used in the action level and at the controller level
 
 Redirect user to login page (custom login url) 
 services.ConfigureApplicationCookie(config=>{config.LoginPath="/login"})
 Also set the path in the loginPath in appsetting.json file
 
 use appsetting in Identity framework
 --------------------------------------
 Roles are present -- claim based
 
 roles are present in UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>: base(usermanager, rolemanager, options)
 .. override in the class and also set up in the startup file
---------------------------------------------------------
Get logged-in user id in controller and services-


create a service class for instance- 
public string userid()
{
return _httpContext.httpContext.User?.FindFirstValue(claimType.nameIdentifier)
}
-------------------------------------------------

difference in corestartup calss middleware, DI in view and in the view componenet