namespace TeamWebAPI.Models
{
public class FavoriteBook
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public DateTime PublishedDate { get; set; }
}
}