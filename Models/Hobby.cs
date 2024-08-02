namespace TeamWebAPI.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FrequencyPerWeek { get; set; }
        public string? DifficultyLevel { get; set; }  
    }
}
