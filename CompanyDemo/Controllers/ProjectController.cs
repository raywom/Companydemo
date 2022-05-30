// using CompanyDemo.Filters;
// using CompanyDemo.Interfaces;
// using CompanyDemo.Models;
// using CompanyDemo.Repository;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace CompanyDemo.Controllers;
//
// public class ProjectController : Controller
// {
//     private readonly IProjectRepository _projectRepo;
//     private readonly IEmployeeRepository _employeeRepo;
//
//     public ProjectController(IProjectRepository deptRepo, IEmployeeRepository employeeRepo)
//     {
//         _projectRepo = deptRepo;
//         _employeeRepo = employeeRepo;
//     }
//
//     // GET: Companies
//     public IActionResult Index()
//     {
//         var employees = _employeeRepo.GetAll();
//         foreach (var employee in employees)
//         {
//             employee.Id = _employeeRepo.(employee.Id);
//         }
//
//         return View(departments);
//     }
//
//     // GET: Companies/Details/5
//     public IActionResult Details(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var department = _projectRepo.Find(id.GetValueOrDefault());
//         if (department == null)
//         {
//             return NotFound();
//         }
//
//         return View(department);
//     }
//
//     [Authorize(Roles = "Admin")]
//     // GET: Companies/Create
//     public IActionResult Create()
//     {
//         return View();
//     }
//
//     [Authorize(Roles = "Admin")]
//     [CustomActionFilter]
//     // POST: Companies/Create
//     // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//     // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//     [HttpPost]
//     public IActionResult Create([Bind("Id,DeptName,MgrId")] Department department)
//     {
//         if (ModelState.IsValid)
//         {
//             department.Id = 1;
//             _projectRepo.Create(department);
//             return RedirectToAction(nameof(Index));
//         }
//
//         return View(department);
//     }
//
//     [Authorize(Roles = "Admin")]
//     [CustomActionFilter]
//     // GET: Companies/Edit/5
//     public IActionResult Edit(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         var department = _projectRepo.Find(id.GetValueOrDefault());
//         if (department == null)
//         {
//             return NotFound();
//         }
//
//         return View(department);
//     }
//
//     [Authorize(Roles = "Admin")]
//     [CustomActionFilter]
//     // POST: Companies/Edit/5
//     // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//     // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//     [HttpPost]
//     public IActionResult Edit(int id, [Bind("Id,DeptName,MgrId")] Department department)
//     {
//         if (id != department.Id)
//         {
//             return NotFound();
//         }
//
//         _projectRepo.Update(department);
//
//         return RedirectToAction(nameof(Index));
//     }
//
//     [Authorize(Roles = "Admin")]
//     // GET: Companies/Delete/5
//     public IActionResult Delete(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }
//
//         _projectRepo.Delete(id.GetValueOrDefault());
//     }
//
// }