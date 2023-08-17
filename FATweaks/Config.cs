using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace FATweaks
{
    public class Config : IConfig
    {
        [Description("Should the plugin be enabled")]
        public bool IsEnabled { get; set; } = true;
        [Description("Should effects be kept when escaping")]
        public bool KeepEscapeEffects { get; set; } = false;
        [Description("Blacklisted kept effects when escaping")]
        public List<EffectType> BlacklistedEscapeEffects { get; set; } =
            new List<EffectType>() { EffectType.Invisible, EffectType.Blinded, EffectType.Corroding, EffectType.CardiacArrest, EffectType.Traumatized, EffectType.Stained, EffectType.Flashed, EffectType.Scanned, EffectType.Deafened, EffectType.Concussed };
        [Description("Increase 096 rage time for every person that spots 096")]
        public float Spotted096RageTimeIncrease { get; set; } = 0f;
        [Description("Increase max 096 rage time by")]
        public float IncreasedMax096RageTime { get; set; } = 0f;
        [Description("Change max jailbird charge by ammount")]
        public int JailbirdMaxChargeAmmountChange { get; set; } = 0;
        [Description("Should plugin show debug information")]
        public bool Debug { get; set; } = false;
    }
}