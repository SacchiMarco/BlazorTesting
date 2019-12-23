using numbersBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace numbersBlazor.State
{
    public class ShopStateProvider
    {
        public List<ShopItemData> ShoppingCart { get; private set; }
        public event Action OnChange;

        public void AddShopItem(ShopItemData shopItem)
        {
            var item = ShoppingCart.First(c => c.Id == shopItem.Id);
            if (item == null)
            {
                ShoppingCart.Add(shopItem);
            }
            else
            {
                var index = ShoppingCart.IndexOf(item);
                ShoppingCart[index] = shopItem;
            }

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}