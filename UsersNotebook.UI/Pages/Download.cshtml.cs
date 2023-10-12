using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using UsersNotebook.UI.Models;

namespace UsersNotebook.UI.Pages;

public class DownloadModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DownloadModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnGetAsync()
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

}
