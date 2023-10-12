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
        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        var response = await httpClient.GetAsync($"{id}");
        if (response.IsSuccessStatusCode)
        {
            User = await response.Content.ReadFromJsonAsync<UserView>();


        }
    }
    public async Task<IActionResult> OnPostAsync()
    {


        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        var response = await httpClient.PostAsJsonAsync("update", User);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("Users"); // Redirect back to the Users page on success.
        }
        else
        {
            return Page(); 
        }
    }
}
