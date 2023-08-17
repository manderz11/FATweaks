using System;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Item = Exiled.API.Features.Items.Item;

namespace FATweaks.Handles
{
    public class SpawningItem
    {
        public void SpawningItemEvent(SpawningItemEventArgs spawningItemEvent)
        {
            if (spawningItemEvent == null)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Spawning item is null");
                return;
            }

            if (!spawningItemEvent.IsAllowed)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Item spawn is not allowed");
                return;
            }

            if (Plugin.Instance.Config.JailbirdMaxChargeAmmountChange == 0)
            {
                return;
            }
            
            if (spawningItemEvent.Pickup.Type == ItemType.Jailbird)
            {
                Jailbird jailbird;
                Pickup pickup = Pickup.Get(spawningItemEvent.Pickup.Base);
                try
                {
                    Jailbird jailbirdItem = (Jailbird)Item.Get(pickup.Base.Info.Serial);
                    jailbird = jailbirdItem;
                }
                catch (Exception e)
                {
                    if (Plugin.Instance.Config.Debug)Log.Debug("Could not get jailbird item from pickup base");
                    if (Plugin.Instance.Config.Debug)Log.Error($"Exception: {e}");
                    return;
                }
                jailbird.TotalCharges -= Plugin.Instance.Config.JailbirdMaxChargeAmmountChange;
                if (Plugin.Instance.Config.Debug)Log.Debug($"Changing jailbird charge ammount by {Plugin.Instance.Config.JailbirdMaxChargeAmmountChange} changing it to {jailbird.TotalCharges} charges");

            }
        }

        public void ItemAdded(ItemAddedEventArgs itemAddedEventArgs)
        {
            if (itemAddedEventArgs.Item.Type == ItemType.Jailbird)
            {
                Jailbird jailbird;
                try
                {
                    Jailbird jailbirdItem = (Jailbird)Item.Get(itemAddedEventArgs.Item.Base);
                    jailbird = jailbirdItem;
                }
                catch (Exception e)
                {
                    if (Plugin.Instance.Config.Debug)Log.Debug("Could not get jailbird item from pickup base");
                    if (Plugin.Instance.Config.Debug)Log.Error($"Exception: {e}");
                    return;
                }
                jailbird.TotalCharges -= Plugin.Instance.Config.JailbirdMaxChargeAmmountChange;
                if (Plugin.Instance.Config.Debug)Log.Debug($"Changing jailbird charge ammount by {Plugin.Instance.Config.JailbirdMaxChargeAmmountChange} changing it to {jailbird.TotalCharges} charges");
            }
        }
    }
}