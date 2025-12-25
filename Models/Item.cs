using System.Text.Json.Serialization;

namespace WebAPI_Repo__UOW_.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
