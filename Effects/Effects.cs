using System;

using Exiled.API.Features;
using Exiled.API.Enums;

using PPlayer = Exiled.Events.Handlers.Player;

namespace Effects
{
    public class Effects : Plugin<Config>
    {
        private Handlers.Player player = new Handlers.Player();
        public override string Name { get; } = "Effects";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(2, 5, 2);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 19);
        public override string Prefix { get; } = "Effects";

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public static Effects Singleton;

        public void RegisterEvents()
        {
            PPlayer.ChangingRole += player.OnChangingRoles;
            PPlayer.Hurting += player.OnHurting;
            Singleton = this;
        }
        public void UnregisterEvents()
        {
            PPlayer.ChangingRole -= player.OnChangingRoles;
            PPlayer.Hurting -= player.OnHurting;
            player = null;
            Singleton = null;
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }
        public override void OnReloaded()
        {
            base.OnReloaded();
        }
    }
}
