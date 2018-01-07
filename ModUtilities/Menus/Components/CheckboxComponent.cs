﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ModUtilities.Helpers;
using ModUtilities.Menus.Components.Interfaces;
using StardewValley;
using StardewValley.Menus;
using xTile.Dimensions;
using Rectangle = xTile.Dimensions.Rectangle;

namespace ModUtilities.Menus.Components {
    public class CheckboxComponent : Component, IValueComponent<bool> {
        public override bool FocusOnClick { get; } = true;

        private bool _isChecked;
        public bool IsChecked {
            get => this._isChecked;
            set {
                if (value == this._isChecked)
                    return;

                this._isChecked = value;
                this.OnValueChanged();
            }
        }

        public CheckboxComponent() {
            this.Size = new Size(OptionsCheckbox.sourceRectUnchecked.Width * Game1.pixelZoom, OptionsCheckbox.sourceRectUnchecked.Height * Game1.pixelZoom);
        }

        public CheckboxComponent(bool isChecked) : this() {
            this.IsChecked = isChecked;
        }

        protected override void OnDraw(SpriteBatch b) {
            Rectangle bounds = this.AbsoluteBounds;

            // Draw the checkbox
            Microsoft.Xna.Framework.Rectangle checkboxSource = this.IsChecked ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked;
            b.Draw(Game1.mouseCursors, bounds.ToXnaRectangle(), checkboxSource, Color.White, 0, Vector2.Zero, SpriteEffects.None, this.GetGlobalDepth(0));
        }

        protected override bool OnLeftClick(Location mousePos) {
            if (!base.OnLeftClick(mousePos))
                return false;

            this.Toggle();
            return true;
        }

        protected override bool OnKeyPressed(Keys key) {
            if (key != Keys.Space)
                return false;

            this.Toggle();
            return true;
        }

        public void Toggle() {
            this.IsChecked = !this.IsChecked;
            Game1.playSound("drumkit6");
        }

        public void SetValue(bool value) => this.IsChecked = value;

        public bool GetValue() => this.IsChecked;

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged() => this.ValueChanged?.Invoke(this, EventArgs.Empty);
    }
}
