using numbersBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;


namespace numbersBlazor.State
{
    public class ShopStateProvider
    {
        public List<ShopItemData> ShoppingCart { get; private set; } = new List<ShopItemData>();
        public event Action OnChange;

        public void AddShopItem(ShopItemData shopItem)
        {
            ShopItemData item = null;
            if (ShoppingCart.Any())
            {
                item = ShoppingCart.FirstOrDefault(c => c.Id == shopItem.Id);
            }

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