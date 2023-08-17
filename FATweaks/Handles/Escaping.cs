using System.Collections.Generic;
using System.Linq;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Player = Exiled.API.Features.Player;

namespace FATweaks.Handles
{
    public class Escaping
    {
        private Dictionary<Exiled.API.Features.Player, List<StatusEffectBase>> _preEscapeEffects = new Dictionary<Player, List<StatusEffectBase>>();
        public void OnEscaping(EscapingEventArgs escapingEventArgs)
        {
            if (!Plugin.Instance.Config.KeepEscapeEffects)
            {
                return;
            }
            if (escapingEventArgs.Player == null)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Escaping player is null");
                return;
            }

            if (escapingEventArgs.Player.ActiveEffects == null)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Escaping player effects are null");
                return;
            }

            if (_preEscapeEffects.ContainsKey(escapingEventArgs.Player))
            {
                _preEscapeEffects.Remove(escapingEventArgs.Player);
                if (Plugin.Instance.Config.Debug)Log.Debug("Removing player from dictionary");
            }
            if (Plugin.Instance.Config.Debug)Log.Debug("Adding player to dictionary");
            List<StatusEffectBase> effectsList = escapingEventArgs.Player.ActiveEffects.ToList();
            _preEscapeEffects.Add(escapingEventArgs.Player,effectsList);
            if (_preEscapeEffects.TryGetValue(escapingEventArgs.Player,out List<StatusEffectBase> effe))
            {
                foreach (var VARIABLE in effe)
                {
                    Log.Debug(VARIABLE.name + VARIABLE.Duration + VARIABLE.Intensity + VARIABLE.TimeLeft);
                }
            }
        }

        public void OnSpawned(SpawnedEventArgs spawnedEventArgs)
        {
            if (!Plugin.Instance.Config.KeepEscapeEffects)
            {
                return;
            }
            if (spawnedEventArgs.Reason == SpawnReason.Escaped)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Player escaped");
                if (_preEscapeEffects.ContainsKey(spawnedEventArgs.Player))
                {
                    if (Plugin.Instance.Config.Debug)Log.Debug("Player is found in dictionary");
                    if (_preEscapeEffects.TryGetValue(spawnedEventArgs.Player, out List<StatusEffectBase> effects))
                    {
                        if (Plugin.Instance.Config.Debug)Log.Debug("Player effect values found in dictionary");
                        if (Plugin.Instance.Config.BlacklistedEscapeEffects == null)
                        {
                            foreach (var effect in effects)
                            {
                                spawnedEventArgs.Player.EnableEffect(effect,effect.TimeLeft);
                            }
                        }
                        else
                        {
                            foreach (var effect in effects)
                            {
                                if (EffectType.TryParse(effect.name,out EffectType type))
                                {
                                    if (Plugin.Instance.Config.Debug)Log.Debug($"Got effect type from escaping effects");
                                }

                                if (type != null)
                                {
                                    if (Plugin.Instance.Config.BlacklistedEscapeEffects.Contains(type))
                                    {
                                        if (Plugin.Instance.Config.Debug)Log.Debug($"Blacklisted effect {effect.name} was not given to escaping player");
                                    }
                                    else
                                    {
                                        spawnedEventArgs.Player.EnableEffect(effect,effect.TimeLeft);
                                    }
                                }
                                else
                                {
                                    if (Plugin.Instance.Config.Debug)Log.Debug($"Blacklisted effect type could not be gotten, defaulting to giving effect");
                                    spawnedEventArgs.Player.EnableEffect(effect,effect.TimeLeft);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Plugin.Instance.Config.Debug)Log.Debug("Failed to get players status effect values");
                    }
                }
                else
                {
                    if (Plugin.Instance.Config.Debug)Log.Debug("Escaping player is not found in dictionary");
                }
            }
        }
    }
}