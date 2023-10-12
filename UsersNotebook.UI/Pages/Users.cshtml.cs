using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersNotebook.UI.Models;

public class UsersModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<UserView> _users;

    public UsersModel(IHttpClientFactory httpClientFactory, List<UserView> users)
    {
        _httpClientFactory = httpClientFactory;
        _users = users;
    }


    public async Task OnGetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync("https://localhost:7261/users/all");
        if (response.IsSuccessStatusCode)
        {
             _users = await response.Content.ReadFromJsonAsync<List<UserView>>();
        }
    }

    public string GetGender(GenderView gender)
    {
        if (gender == 0)
        {
            return "Male";
        }
        else return "Female";
    }


}
