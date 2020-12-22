using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_2_dotnet_core.Data;
using Assignment_2_dotnet_core.Models;
using Microsoft.AspNetCore.Hosting;
using Assignment_2_dotnet_core.ViewModels;
using System.IO;
using Assignment_2_dotnet_core.Logging;

namespace Assignment_2_dotnet_core.Controllers
{
    public class EmployeesController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly ILoggerService _Nlogger;

        public EmployeesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, ILoggerService Nlogger)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _Nlogger = Nlogger;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            _Nlogger.LogDebug("Nlog Works!");
            _log4net.Debug("Hello logging world log4net!");
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            return View(emp);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,FavoriteNumber,FormatedID,MobilePhone,ProfilePicture")] EmployeeViewModel employee)
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,FavoriteNumber,FormatedID,MobilePhone,ProfilePicture")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(UploadedFile(employee));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = employee.Id;
            employeeViewModel.Name = employee.Name;
            employeeViewModel.BirthDate = employee.BirthDate;
            employeeViewModel.FavoriteNumber = employee.FavoriteNumber;
            employeeViewModel.FormatedID = employee.FormatedID;
            employeeViewModel.MobilePhone = employee.MobilePhone;
            

            return View(employeeViewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,FavoriteNumber,FormatedID,MobilePhone,ProfilePicture")] EmployeeViewModel employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _context.Employees.FindAsync(id);
                    if (emp == null)
                    {
                        return NotFound();
                    }
                    emp = UploadedFile(employee, emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        private Employee UploadedFile(EmployeeViewModel model, Employee emp = null)
        {
            string uniqueFileName = null;

            if (model.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePicture.CopyTo(fileStream);
                }
            }

            if(emp == null){
                 Employee emp_temp = new Employee {
                    Name = model.Name,
                    BirthDate = model.BirthDate,
                    FavoriteNumber = model.FavoriteNumber,
                    FormatedID = model.FormatedID,
                    MobilePhone = model.MobilePhone,
                    ProfilePicture = uniqueFileName,
                };
                return emp_temp;
            }            
            else{
                emp.Name = model.Name;

                emp.BirthDate = model.BirthDate;
                emp.FavoriteNumber = model.FavoriteNumber;
                emp.FormatedID = model.FormatedID;
                emp.MobilePhone = model.MobilePhone;
                emp.ProfilePicture = uniqueFileName;
                return emp;
            }

            
        }
    }
}
