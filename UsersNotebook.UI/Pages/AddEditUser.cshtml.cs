using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
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
            ViewUser.DateOfBirth = DateTime.Today.AddYears(-40);
        }
    }
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
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
        else return Page();
    }

    public async Task<IActionResult> OnPostDeleteUser()
    {
        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        HttpResponseMessage response;

        response = await httpClient.DeleteAsync($"delete/{ViewUser.Id}");


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