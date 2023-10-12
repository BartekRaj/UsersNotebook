using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersNotebook.UI.Models;
using System.Threading.Tasks;


public class EditUserModel : PageModel
{
    [BindProperty]
    public UserView User { get; set; }

    private readonly IHttpClientFactory _httpClientFactory;

    public EditUserModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task OnGetAsync(int id)
    {
        if (id > 0)
        {
            var httpClient = _httpClientFactory.CreateClient("UsersAPI");
            var response = await httpClient.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                User = await response.Content.ReadFromJsonAsync<UserView>();
            } 
        }
        else
        {
            User = new UserView();
        }
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        HttpResponseMessage response;

        if (User.Id != 0)
        {
            response = await httpClient.PostAsJsonAsync("update", User); 
        }
        else
        {
            response = await httpClient.PostAsJsonAsync("add", User);
        }

        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Users");
        }
        else
        {
            return Page(); 
        }
    }
}
