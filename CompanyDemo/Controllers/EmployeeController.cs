using CompanyDemo.Filters;
using CompanyDemo.Interfaces;
using CompanyDemo.Models;
using CompanyDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompanyDemo.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepo;
    private readonly IDepartmentRepository _departmentRepo;
    
    public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository companyRepo)
    {
        _employeeRepo = employeeRepository;
        _departmentRepo = companyRepo;
    }
    
    public IActionResult Index()
    {
        var employees = _employeeRepo.GetAll();
        foreach (var employee in employees)
        {
            employee.Department = _departmentRepo.Find(employee.DepartmentId);
        }
        return View(employees);
    }
    
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _employeeRepo.Find(id.GetValueOrDefault());
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }
    [Authorize(Roles = "admin")]
    public IActionResult Create()
    {
        IEnumerable<SelectListItem> departmentList = _departmentRepo.GetAll().Select(i => new SelectListItem
        {
            Text = i.DeptName,
            Value = i.Id.ToString()
        });
        ViewBag.DepartmentList = departmentList;   
        return View();
    }
    [Authorize(Roles = "admin")]
    [HttpPost]
    [CustomActionFilter]
    public IActionResult Create([Bind("Id,FirstName,LastName,DateOfBirth,Address,Sex,Salary,DepartmentId")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            employee.Id = 1;
            _employeeRepo.Create(employee);
            return RedirectToAction(nameof(Index));
        }

        return View(employee);
    }
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        IEnumerable<SelectListItem> departmentList = _departmentRepo.GetAll().Select(i => new SelectListItem
        {
            Text = i.DeptName,
            Value = i.Id.ToString()
        });
        ViewBag.DepartmentList = departmentList;    
        var employee = _employeeRepo.Find(id.GetValueOrDefault());
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }
    [Authorize(Roles = "admin")]
    [HttpPost]
    [CustomActionFilter]
    public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Address,Sex,Salary,DepartmentId")] Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _employeeRepo.Update(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Employee not found");
            }
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        _employeeRepo.Delete(id.GetValueOrDefault());
        return RedirectToAction(nameof(Index));
    }
    
}