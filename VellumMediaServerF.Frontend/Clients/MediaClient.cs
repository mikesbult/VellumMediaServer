using VellumMediaServerF.Frontend.Models;
namespace VellumMediaServerF.Frontend.Clients;
public class MediaClient(HttpClient httpClient)
{

    public async Task <MediaSummary[]> GetMediaAsync() 
        => await httpClient.GetFromJsonAsync<MediaSummary[]>("medias") ?? [];
        
    public async Task AddMediaAsync(MediaDetails media)
    => await httpClient.PostAsJsonAsync("medias", media);


    public async Task <MediaDetails> GetMediaAsync(Guid id)
    => await httpClient.GetFromJsonAsync<MediaDetails>($"medias/{id}")
            ?? throw new Exception ("could not find media!");


// *public async Task<MediaSummary[]> GetMediaAsync()
//{
    //var response = await httpClient.GetStringAsync("api/media");
    //Console.WriteLine($"Raw API Response: {response}"); // Look at your terminal!
   // return await httpClient.GetFromJsonAsync<MediaSummary[]>("api/media") ?? Array.Empty<MediaSummary>();
//}* //

    public async Task UpdateMediaAsync(MediaDetails updatedMedia)
    => await httpClient.PutAsJsonAsync($"medias/{updatedMedia.Id}", updatedMedia);
    

    public async Task DeleteMediaAsync(Guid id)
    => await httpClient.DeleteAsync($"medias/{id}");

   public async Task<AnalyzeMediaResponse?> AnalyzeUrlAsync(string url)
{
    var encodedUrl = Uri.EscapeDataString(url);
    return await httpClient.GetFromJsonAsync<AnalyzeMediaResponse>($"medias/analyze?url={encodedUrl}");
}

public async Task ClearHistoryAsync()
{
    await httpClient.DeleteAsync("medias/clear-history");
}

public string BuildDownloadUrl(string url, string type)
{
    if (httpClient.BaseAddress is null)
        throw new InvalidOperationException("HttpClient BaseAddress is not configured.");

    var encodedUrl = Uri.EscapeDataString(url);
    return new Uri(httpClient.BaseAddress, $"medias/download?url={encodedUrl}&type={type}").ToString();
}



}

