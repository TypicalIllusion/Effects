using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Exiled.API.Extensions;

using MEC;

using CustomPlayerEffects;

using System.Collections.Generic;

using static Effects.Effects;

namespace Effects.Handlers
{
    class Player
    {
        public void OnChangingRoles(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.GetTeam() == Team.SCP)
            {
                if (Singleton.Config.NotScpEffect.Contains(RoleType.Scp173))
                    return;
                Timing.CallDelayed(1.0f, () =>
                {
                    ev.Player.EnableEffect<Scp207>(Singleton.Config.Speed);
                    ev.Player.ReferenceHub.playerEffectsController.ChangeEffectIntensity<Scp207>(Singleton.Config.Amount);
                    ev.Player.Broadcast(10, Singleton.Config.SpeedMessage);
                });
                Log.Info("Works");
            }
        }
        internal void OnHurting(HurtingEventArgs ev)
        {
            if (Singleton.Config.NotScpEffect.Contains(ev.Target.Role) && ev.DamageType == DamageTypes.Scp207)
            {
                ev.Amount = 0;
            }
        }
    }
}
