using System.ComponentModel.DataAnnotations.Schema;

namespace numbersBlazor.Model
{
    public class ShopItemData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int InStock { get; set; }

        public string Description { get; set; }

        [NotMapped] public int OrderAmount { get; set; } = 1;
    }
}