using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Scp096;
using PlayerRoles;

namespace FATweaks.Handles
{
    public class Scp096
    {
        public void AddedTarget(AddingTargetEventArgs addingTargetEventArgs)
        {
            if (addingTargetEventArgs.Player == null)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("SCP096 player is null");
                return;
            }

            if (addingTargetEventArgs.Player.Role != RoleTypeId.Scp096)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("Enraged player is not SCP096 role");
                return;
            }
            if (Plugin.Instance.Config.Spotted096RageTimeIncrease > 0f)
            {
                Scp096Role scp096Role = (Scp096Role)addingTargetEventArgs.Player.Role;
                scp096Role.EnragedTimeLeft += Plugin.Instance.Config.Spotted096RageTimeIncrease;
            }
        }

        public void Enraging(EnragingEventArgs enragingEventArgs)
        {
            if (enragingEventArgs.Scp096 == null)
            {
                if (Plugin.Instance.Config.Debug)Log.Debug("SCP096 player role is null");
                return;
            }

            if (Plugin.Instance.Config.IncreasedMax096RageTime > 0f)
            {
                Scp096Role scp096Role = (Scp096Role)enragingEventArgs.Player.Role;
                scp096Role.TotalEnrageTime += Plugin.Instance.Config.IncreasedMax096RageTime;
            }
        }
    }
}