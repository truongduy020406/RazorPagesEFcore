using ASPNET_QL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET_QL.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly RazorPageDbcontext dbcontext;

        public List<Models.Domain.Employee> Employees{ get; set; }
        public ListModel(RazorPageDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void OnGet()
        {
           Employees = dbcontext.Employees.ToList();
        }
    }
}
