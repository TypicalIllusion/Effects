using Exiled.Events.EventArgs;
using Exiled.API.Extensions;

using EPlayer = Exiled.API.Features.Player;

using MEC;

using CustomPlayerEffects;

using static Effects.Effects;

using Effects.Enums;

namespace Effects.Handlers
{
    class Player
    {

        public void OnChangingRoles(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole.GetTeam() == Team.SCP)
            {
                if (Singleton.Config.NotScpEffect.Contains(ev.NewRole))
                    return;
                Timing.CallDelayed(1.0f, () =>
                {
                    foreach (PlayerEffects effect in Singleton.Config.PE)
                    {
                        PlayerEffect(effect, ev.Player);
                    }
                    ev.Player.Broadcast(10, Singleton.Config.SpeedMessage);
                });
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (Singleton.Config.NotScpEffect.Contains(ev.Target.Role) && ev.DamageType == DamageTypes.Scp207)
            {
                ev.Amount = 0;
            }
        }
        public void PlayerEffect(PlayerEffects effects, EPlayer player)
        {
            switch (effects)
            {
                case PlayerEffects.Scp207:
                    player.EnableEffect<Scp207>(Singleton.Config.Speed);
                    player.ReferenceHub.playerEffectsController.ChangeEffectIntensity<Scp207>(Singleton.Config.AmountOfCokes);
                    break;
                case PlayerEffects.Scp268:
                    player.EnableEffect<Scp268>(Singleton.Config.Speed);
                    player.ReferenceHub.playerEffectsController.ChangeEffectIntensity<Scp207>(15);
                    break;
                default:
                    break;
            }
        }
    }
}
