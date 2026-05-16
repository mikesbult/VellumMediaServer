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
    string encodedUrl = Uri.EscapeDataString(url);

#if DEBUG
    // 1. This block ONLY runs when you press play on your local computer (Debug mode)
    return await httpClient.GetFromJsonAsync<AnalyzeMediaResponse>($"medias/analyze?url={encodedUrl}");
#else
    // 2. This block ONLY runs when Render compiles it for production (Release mode)
    string defaultType = "VIDEO";
    return await httpClient.GetFromJsonAsync<AnalyzeMediaResponse>($"download?url={encodedUrl}&type={defaultType}");
#endif
}

public async Task ClearHistoryAsync()
{
    await httpClient.DeleteAsync("medias/clear-history");
}


}

