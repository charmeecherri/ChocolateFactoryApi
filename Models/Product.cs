using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChocolateFactoryApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId {  get; set; }

        public string ProductName { get; set; }

        [JsonIgnore]
        public ICollection<ProductionSchedule> ProductionSchedules { get; set; }

        [JsonIgnore]
        public List<Recipe> recipes { get; set; }

    }
}
