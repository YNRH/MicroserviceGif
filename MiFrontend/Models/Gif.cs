namespace MiFrontend.Models
{
    public class Gif
    {
        public string Id { get; set; }
        public List<Media> Media { get; set; } // Aquí se debe definir la propiedad Media
    }

    public class Media
    {
        public Webm Webm { get; set; }
    }

    public class Webm
    {
        public string Preview { get; set; }
    }
}
