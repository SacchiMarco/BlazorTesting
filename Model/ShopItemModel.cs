using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace numbersBlazor.Model
{
    public class ShopItemModel
    {
        public IEnumerable<ShopItemData> ShopItemsList { get; set; }

        public ShopItemModel(IEnumerable<ShopItemData> shopItemList)
        {
            this.ShopItemsList = shopItemList;
        }

        public string GetDescriptionShort(int shopItemId)
        {
            var shopItem = ShopItemsList.First(s => s.Id == shopItemId);

            if (shopItem.Description.Equals("")) return Empty;

            var shortString = shopItem.Description.Split().Take(10);

            var end = shortString.Aggregate(Empty, (current, s) => current + (" " + s));

            var trim = end.Trim();
            return trim += "...";
        }
    }
}