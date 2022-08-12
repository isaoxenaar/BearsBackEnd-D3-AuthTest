using System.ComponentModel.DataAnnotations;
namespace SignalRWebpack;

public class Bear
{
    [Key]
    public int Id { get;set; }
    public int ObserverId  { get;set; }
    public DateTime Date { get; set; }
    [Required]
    [Range(typeof(float), "-180", "180")]
    public float longitude  { get; set; }
    [Required]
    [Range(typeof(float), "-90", "90")]
    public float latitude  { get; set; }
}
