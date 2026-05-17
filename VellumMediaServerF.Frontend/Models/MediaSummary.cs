
namespace VellumMediaServerF.Frontend.Models;

public class MediaSummary
{
   public Guid Id { get; set; } 

    public string Title { get; set; } = string.Empty;

    // 2. Change 'Thumbnail' to 'ThumbnailUrl' to match your HTML @item.ThumbnailUrl
    public string ThumbnailUrl { get; set; } = string.Empty;

    public string SourceUrl {get; set;} = string.Empty;
         //public   string FileUrl {get; set;} = "";


    /// <summary>
    //public string Category { get; set; } = string.Empty;
    /// </summary>
 
    //public string Description {get; set;} = "";

//public   string MediaType {get; set;} = "";

    // 3. Ensure this matches @item.SavedAt in your HTML
    public DateTime SavedAt { get; set; }
 
}


