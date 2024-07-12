using Dashboard.Models;
using MudBlazor;
using static MudBlazor.Icons;

namespace Dashboard.Components.Pages
{
    public partial class Insert
    {
        private string searchString = "";
        Product product = new Product();
        AiUsage aiUsage = new AiUsage();
        private List<Product> ProductList = new List<Product>();
        private List<Employee> EmployeesList = new List<Employee>();
        private List<AiUsage> AiUsageList = new List<AiUsage>();

        protected override async Task OnInitializedAsync()
        {
            ProductList = await productService.GetAllProducts();
            EmployeesList = await employeeService.GetAllEmployees();
            AiUsageList = await aiUsageService.GetAllAiUsage();
            //AiUsageList = await GetAiUsage();
        }

        private async Task<List<AiUsage>> GetAiUsage()
        {
            AiUsageList = await aiUsageService.GetAllAiUsage();
            return AiUsageList;
        }

        private bool Search(AiUsage aiUsage)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (aiUsage.StateName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        private void Save()
        {
            aiUsageService.SaveAiUsage(aiUsage);
            aiUsage = new AiUsage();
            snackBar.Add("AiUsage Saved.", Severity.Success);
            GetAiUsage();
        }

        private void Edit(int id)
        {
            aiUsage = AiUsageList.FirstOrDefault(c => c.Id == id);
        }

        private void Delete(int id)
        {
            aiUsageService.DeleteAiUsage(id);
            snackBar.Add("Ai Usage Deleted.", Severity.Error);
            GetAiUsage();
        }

        private async Task OnValidSubmit()
        {
            _dataContext.AiUsages.Add(aiUsage);
            await _dataContext.SaveChangesAsync();
        }

        private async Task OnValidSubmitAi()
        {
            _dataContext.AiUsages.Add(aiUsage);
            await _dataContext.SaveChangesAsync();
        }

        // private async Task<List<Product>> GetProducts()
        // {
        //     var tempProducts = await dataContext.Products.ToList();
        //     if(tempProducts != null)
        //     {
        //         ProductList = tempProducts;
        //     }

        // }
    }
}