using System.ComponentModel.DataAnnotations;

namespace VellumMediaServerF.Frontend.Models;

    public class MediaDetails
    {
    public Guid Id {get; set;}
     
     [Required]
     [StringLength(100, ErrorMessage = "The Title must be less than 100 characters!")]
    public required string Title {get; set;}

    //public string Description {get; set;} = "";

    //public  required string Category {get; set;} 

     public   string SourceUrl {get; set;} = "";

      public   string? ThumbnailUrl {get; set;} 


    public DateTime SavedAt {get; set;}



    }