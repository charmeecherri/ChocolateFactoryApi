using System.ComponentModel.DataAnnotations;

namespace ChocolateFactoryApi.Models
{
    public class RawMaterial
    {
        [Key]
        public int MaterialId {  get; set; }

        public string Name {  get; set; }

        public int StockQuantity {  get; set; }

        public string Unit {  get; set; }

        public DateTime ExpiryDate { get; set; }

        public int SuppilerId {  get; set; }

        public decimal CostPerUnit {  get; set; }

        public List<Ingredients> Ingredients { get; set; }

    }
}
