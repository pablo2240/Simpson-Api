namespace Simpson.Front.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int? Age { get; set; }  // Cambiar a nullable
        public string? Birthdate { get; set; }  // Cambiar a nullable
        public string? Gender { get; set; }  // Cambiar a nullable
        public string? Name { get; set; }  // Cambiar a nullable
        public string? Occupation { get; set; }  // Cambiar a nullable
        public string? PortraitPath { get; set; }  // Cambiar a nullable
        public List<string> Phrases { get; set; } = new();
        public string? Status { get; set; }  // Cambiar a nullable

        // Propiedad computada para la imagen completa
        public string ImageUrl => !string.IsNullOrEmpty(PortraitPath)
           ? $"https://cdn.thesimpsonsapi.com/500{PortraitPath}"
           : $"https://cdn.thesimpsonsapi.com/500/character/{Id}.webp";
    }
}