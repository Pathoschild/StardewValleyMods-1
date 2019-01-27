﻿using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using TehPers.CoreMod.Api;
using TehPers.CoreMod.Api.Drawing.Sprites;
using TehPers.CoreMod.Api.Items;
using TehPers.CoreMod.Api.Items.ItemProviders;

namespace TehPers.CoreMod.Items.ItemProviders {
    internal abstract class ItemRegistry<TManager> : IItemRegistry<TManager> where TManager : IModItem {
        protected IApiHelper ApiHelper { get; }
        protected IItemDelegator ItemDelegator { get; }
        protected Dictionary<ItemKey, TManager> Managers { get; } = new Dictionary<ItemKey, TManager>();

        protected ItemRegistry(IApiHelper apiHelper, IItemDelegator itemDelegator) {
            this.ApiHelper = apiHelper;
            this.ItemDelegator = itemDelegator;
        }

        public ItemKey Register(string localKey, TManager manager) {
            // Create a new key
            ItemKey key = new ItemKey(this.ApiHelper.Owner, localKey);

            // Call the other overload to register the key
            this.Register(key, manager);

            return key;
        }

        public void Register(ItemKey key, TManager manager) {
            // Try to register this key with the item delegator
            if (!this.ItemDelegator.TryRegisterKey(key)) {
                throw new ArgumentException($"Key already registered: {key}", nameof(key));
            }

            // Override its drawing
            this.ItemDelegator.OverrideSprite(key, this.GetSpriteSheet(key, manager), manager.OverrideDraw);

            // Track this key for later
            this.Managers.Add(key, manager);
        }

        public bool TryCreate(ItemKey key, out Item item) {
            // Try to get the index for the given key
            if (this.ItemDelegator.TryGetIndex(key, out int index)) {
                item = this.CreateSingleItem(key, index);
                return true;
            }

            // Failed
            item = default;
            return false;
        }

        public abstract bool IsInstanceOf(ItemKey key, Item item);
        public abstract void InvalidateAssets();
        protected abstract ISpriteSheet GetSpriteSheet(ItemKey key, TManager manager);
        protected abstract Item CreateSingleItem(ItemKey key, int index);
    }
}