using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersNotebook.UI.Models;

namespace UsersNotebook.UI.Pages;

public class UsersModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<UserView> UsersList;

    public UsersModel(IHttpClientFactory httpClientFactory, List<UserView> users)
    {
        _httpClientFactory = httpClientFactory;
        UsersList = users;
    }


    public async Task OnGetAsync()
    {

        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        var response = await httpClient.GetAsync("all");
        if (response.IsSuccessStatusCode)
        {
            var usersFromJson = await response.Content.ReadFromJsonAsync<List<UserView>>();
            if (usersFromJson != null)
            {
                UsersList = usersFromJson;
            }
        }
    }
    public async Task<IActionResult> OnGetAsyncDownloadCsv()
    {
        var httpClient = _httpClientFactory.CreateClient("UsersAPI"); // Ensure you configure the client name in your startup.cs.
        var response = await httpClient.GetAsync("csv/download");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStreamAsync();
            var contentType = "text/csv";
            var fileDownloadName = "UsersData.csv";

            return File(content, contentType, fileDownloadName);
        }

        return StatusCode(500, "Failed to download CSV data.");
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
