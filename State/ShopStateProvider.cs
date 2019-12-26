using numbersBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;


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

                ShoppingCart[GetIndexOfShoppingCartItem(item)] = shopItem;
            }

            NotifyStateChanged();
        }

        public void SetOrderAmount(ShopItemData shopItem)
        {
            var item = ShoppingCart.First(c => c.Id == shopItem.Id);
            item.OrderAmount = shopItem.OrderAmount;
            ShoppingCart[GetIndexOfShoppingCartItem(item)] = item;

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        private int GetIndexOfShoppingCartItem(ShopItemData shopItem)
        {
            return ShoppingCart.IndexOf(shopItem);
        }
    }
}