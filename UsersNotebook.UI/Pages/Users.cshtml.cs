using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersNotebook.UI.Models;

namespace UsersNotebook.UI.Pages;
public class UsersModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    public List<UserView> UsersList;
    public bool HasApiAccessError = false;

    public UsersModel(IHttpClientFactory httpClientFactory, List<UserView> users)
    {
        _httpClientFactory = httpClientFactory;
        UsersList = users;
    }


    public async Task OnGetAsync()
    {

        try
        {
            var httpClient = _httpClientFactory.CreateClient("UsersAPI");
            var response = await httpClient.GetAsync("all");
            if (response.IsSuccessStatusCode)
            {
                var usersFromJson = await response.Content.ReadFromJsonAsync<List<UserView>>();
                if (usersFromJson != null)
                {
                    UsersList = usersFromJson;
                    HasApiAccessError = false;
                }
                else
                {
                    HasApiAccessError = true;
                }
            }
        }
        catch (Exception)
        {

            HasApiAccessError = true;
        }
    }
    public async Task<IActionResult> OnPostDownloadCsv()
    {
        var httpClient = _httpClientFactory.CreateClient("UsersAPI");
        var response = await httpClient.GetAsync("csv/download");

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadFromJsonAsync<DownloadResponseModel>(); // Deserialize the response into a custom class

            // Decode the Base64 content
            var base64Content = Convert.FromBase64String(responseData.FileContents);

            // Set the content type and file name for the response
            var contentType = responseData.ContentType;
            var fileDownloadName = responseData.FileDownloadName;

            // Return the file as a download
            return File(base64Content, contentType, fileDownloadName);
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
