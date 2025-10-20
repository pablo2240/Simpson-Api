namespace Simpson.Front.Models
{
    public class ApiResponse
    {
        public int Count { get; set; }
        public string Next { get; set; } 
        public string Previous { get; set; } 
        public int Pages { get; set; }
        public List<Character> Results { get; set; } = new();
    }
}