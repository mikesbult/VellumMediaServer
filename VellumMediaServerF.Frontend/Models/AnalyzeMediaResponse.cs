using System;

namespace VellumMediaServerF.Frontend.Models;

public class AnalyzeMediaResponse
{
public string Title { get; set; } = "";
    public string MediaType { get; set; } = ""; 
    public string PreviewUrl { get; set; } = ""; // <--- Make sure this is exactly spelled like this
    public string ThumbnailUrl { get; set; } = "";
}