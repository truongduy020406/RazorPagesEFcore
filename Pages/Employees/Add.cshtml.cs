using ASPNET_QL.Data;
using ASPNET_QL.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPNET_QL.Models.Domain;

namespace ASPNET_QL.Pages.Employee
{
    public class AddModel : PageModel
    {
        private readonly RazorPageDbcontext dbcontext;

        public AddModel(RazorPageDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [BindProperty]
        public AddEmployeeViewModels AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            //convert view model to domain model
            var employeeDomainModel = new Models.Domain.Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary= AddEmployeeRequest.Salary,
                DateofBirth= AddEmployeeRequest.DateofBirth,
                Department= AddEmployeeRequest.Department,
            };

            dbcontext.Employees.Add(employeeDomainModel);
            dbcontext.SaveChanges();

            ViewData["Message"] = "Employee created successfully ";
        }
    }
}
