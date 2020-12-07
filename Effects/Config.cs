using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Interfaces;

using static Effects.Enums.PlayerEffects;
using Effects.Enums;

namespace Effects
{
    public class Config : IConfig
    {

        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How long speed?")]
        public float Speed { get; set; } = 5f;
        [Description("How many cokes?")]
        public byte AmountCokes { get; set; } = 1;
        [Description("What should the speed message be?")]
        public string SpeedMessage { get; set; } = "You have speed";

        [Description("What SCPs do you not want to get the effects?")]
        public List<RoleType> NotScpEffect { get; private set; } = new List<RoleType>()
            { RoleType.Scp173,
            RoleType.Scp049,
            RoleType.Scp106,
            RoleType.Scp93953,
            RoleType.Scp93989,
            RoleType.Scp0492,
            };
        [Description("What effects do you want?")]
        public PlayerEffects EffectApplied { get; set; } = Scp207;
    }
}
