﻿using System.ComponentModel;
using FishingOverhaul.Api;
using TehCore.Helpers.Json;

namespace FishingOverhaul.Configs {
    [JsonDescribe]
    public class FishTraits : IFishTraits {
        [Description("The difficulty of this fish.")]
        public float Difficulty { get; set; }

        [Description("The minimum size of the fish.")]
        public int MinSize { get; set; }

        [Description("The maximum size of the fish.")]
        public int MaxSize { get; set; }

        [Description("The fish's motion type. Mixed = 0, dart = 1, smooth = 2, sinker = 3, and floater = 4.")]
        public FishMotionType MotionType { get; set; }
    }
}