using ASPNET_QL.Data;
using ASPNET_QL.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_QL.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly RazorPageDbcontext dbcontext;
        [BindProperty]
        public EditEmployeeViewModels EditEmployeeViewModels { get; set; }
        public EditModel(RazorPageDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbcontext.Employees.Find(id);
            if(employee != null) 
            {
                EditEmployeeViewModels = new EditEmployeeViewModels()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateofBirth = employee.DateofBirth,
                    Department = employee.Department,
                };
            }
        }
        public void OnpostUpdate(Guid id)
        {
            if(EditEmployeeViewModels != null) 
            {
                var existingemploee = dbcontext.Employees.Find(EditEmployeeViewModels.Id);
                if(existingemploee != null)
                {
                    existingemploee.Id = EditEmployeeViewModels.Id;
                    existingemploee.Name = EditEmployeeViewModels.Name;
                    existingemploee.Email = EditEmployeeViewModels.Email;
                    existingemploee.Salary = EditEmployeeViewModels.Salary;
                    existingemploee.DateofBirth = EditEmployeeViewModels.DateofBirth;
                    existingemploee.Department = EditEmployeeViewModels.Department;

                    dbcontext.SaveChanges();

                    ViewData["message"] = "Employee update successfully";
                }
            }
            
        }

        public IActionResult OnpostDelete()
        {
            var existingemployee = dbcontext.Employees.Find(EditEmployeeViewModels.Id);
            if (existingemployee != null)
            {
                dbcontext.Employees.Remove(existingemployee);
                dbcontext.SaveChanges();

                return RedirectToPage("/Employees/List");
            }
            return Page();
        }
    }
}
