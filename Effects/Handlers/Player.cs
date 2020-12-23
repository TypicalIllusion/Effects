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
                if (!Singleton.Config.WhitelistedRoles.Contains(ev.NewRole))
                    return;
                Timing.CallDelayed(1.0f, () =>
                {
                    foreach (PlayerEffects effect in Singleton.Config.TheEffects)
                    {
                        PlayerEffect(effect, ev.Player);
                    }
                    ev.Player.Broadcast(Singleton.Config.Broadcast.Duration, Singleton.Config.Broadcast.Content);
                });
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (Singleton.Config.WhitelistedRoles.Contains(ev.Target.Role) && ev.DamageType == DamageTypes.Scp207)
            {
                ev.Amount = 0f;
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
                    player.EnableEffect<Scp268>(15f);
                    break;
                case PlayerEffects.Blinded:
                    player.EnableEffect<Blinded>(Singleton.Config.BlindTime);
                    break;
                case PlayerEffects.Sinkhole:
                    player.EnableEffect<SinkHole>(Singleton.Config.SinkholeTime);
                    break;
                default:
                    break;
            }
        }
    }
}
