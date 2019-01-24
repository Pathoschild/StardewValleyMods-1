﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TehPers.CoreMod.Api.Extensions {
    public static class DeconstructorExtensions {
        /// <summary>Deconstructor for <see cref="Vector2"/>.</summary>
        /// <param name="source">The source vector.</param>
        /// <param name="x">The x-coordinate of the source vector.</param>
        /// <param name="y">The y-coordinate of the source vector.</param>
        public static void Deconstruct(this Vector2 source, out float x, out float y) {
            x = source.X;
            y = source.Y;
        }

        /// <summary>Deconstructor for <see cref="Point"/>.</summary>
        /// <param name="source">The source point.</param>
        /// <param name="x">The x-coordinate of the source point.</param>
        /// <param name="y">The y-coordinate of the source point.</param>
        public static void Deconstruct(this Point source, out int x, out int y) {
            x = source.X;
            y = source.Y;
        }

        /// <summary>Deconstructor for <see cref="KeyValuePair{TKey,TValue}"/>.</summary>
        /// <param name="source">The source point.</param>
        /// <param name="key">The x-coordinate of the source point.</param>
        /// <param name="value">The y-coordinate of the source point.</param>
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> source, out TKey key, out TValue value) {
            key = source.Key;
            value = source.Value;
        }
    }
}
