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

        [Description("How long is the speed?")]
        public float Speed { get; set; } = 5f;
        [Description("How many cokes?")]
        public byte AmountOfCokes { get; set; } = 1;
        [Description("What is the broadcast message?")]
        public string Broadcast { get; set; } = "You have speed and invisibility!";

        [Description("What SCPs do you not want to get the effects (remove the ones you want to have the effects)?")]

        public List<RoleType> NotScpEffect { get; private set; } = new List<RoleType>()
            { RoleType.Scp173,
            RoleType.Scp049,
            RoleType.Scp106,
            RoleType.Scp93953,
            RoleType.Scp93989,
            RoleType.Scp0492,
            };
        [Description("What effects do you want?")]
        public List<PlayerEffects> TheEffects { get; private set; } = new List<PlayerEffects>()
        {
         Scp207,
         Scp268,
        };
    }
}
