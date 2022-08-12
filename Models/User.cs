using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace SignalRWebpack;

public class User {
    [Key]
    public int Id {get;set;}
    [Required]
    [MaxLength(20, ErrorMessage="max 20 character allowed")]
    public string? Name  { get; set;}
    public string? Email {get;set;}
    // [JsonIgnore]
    public string? Password {get;set;}
    public string? Color {get;set;}
    public List<Bear>? Bears  { get; set; }
}