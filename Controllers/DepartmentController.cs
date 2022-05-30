using CompanyDemo.Filters;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDemo.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepo;
    private readonly IEmployeeRepository _employeeRepo;
    public DepartmentController(IDepartmentRepository deptRepo, IEmployeeRepository employeeRepo)
    {
        _departmentRepo = deptRepo;
        _employeeRepo = employeeRepo;
    }

    // GET: Companies
    public IActionResult Index()
    {
        var departments = _departmentRepo.GetAll();
        foreach (var department in departments)
        {
            department.Employees = _employeeRepo.FindByDepartmentId(department.Id);
        }
        
        return View(departments);
    }

    // GET: Companies/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _departmentRepo.Find(id.GetValueOrDefault());
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }
    [Authorize(Roles = "admin")]
    // GET: Companies/Create
    public IActionResult Create()
    {
        return View();
    }
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    // POST: Companies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public IActionResult Create([Bind("Id,DeptName,MgrId")] Department department)
    {
        if (ModelState.IsValid)
        {
            department.Id = 1;
            _departmentRepo.Create(department);
            return RedirectToAction(nameof(Index));
        }

        return View(department);
    }
    
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    // GET: Companies/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _departmentRepo.Find(id.GetValueOrDefault());
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    // POST: Companies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public IActionResult Edit(int id, [Bind("Id,DeptName,MgrId")] Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        _departmentRepo.Update(department);

        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "admin")]
    // GET: Companies/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        _departmentRepo.Delete(id.GetValueOrDefault());
        return RedirectToAction(nameof(Index));
    }

}