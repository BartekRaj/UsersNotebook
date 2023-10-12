using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersNotebook.UI.Models;

namespace UsersNotebook.UI.Pages;

public class EditUserModel : PageModel
{
    [BindProperty]
    public UserView? ViewUser { get; set; }

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
                ViewUser = await response.Content.ReadFromJsonAsync<UserView>();
            }
        }
        else
        {
            ViewUser = new UserView();
        }
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        HttpResponseMessage response;

        if (ViewUser?.Id != 0)
        {
            response = await httpClient.PostAsJsonAsync("update", ViewUser);
        }
        else
        {
            response = await httpClient.PostAsJsonAsync("add", ViewUser);
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