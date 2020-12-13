using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Interfaces;
using BBroadcast = Exiled.API.Features.Broadcast;

using static Effects.Enums.PlayerEffects;
using Effects.Enums;

namespace Effects
{
    public class Config : IConfig
    {

        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// Gets speed
        /// </summary>
        [Description("How long is the speed?")]
        public float Speed { get; set; } = 5f;
        [Description("How long is the speed?")]
        /// <summary>
        /// Gets coke ammount
        /// </summary>
        public byte AmountOfCokes { get; set; } = 1;
        [Description("How long are they blinded for?")]
        /// <summary>
        /// Blinded Effect
        /// </summary>
        public int BlindTime { get; set; } = 5;
        [Description("How long will they have sinkhole for?")]
        /// <summary>
        /// Sinkhole Effect
        /// </summary>
        public int SinkholeTime { get; set; } = 5;
        [Description("What is the broadcast message?")]
        /// <summary>
        /// Gets broadcasts
        /// </summary>
        public BBroadcast Broadcast { get; set; } = new BBroadcast($"You have speed, invisibility, blindness, and sinkhole.", 7);

        [Description("What SCPs do you not want to get the effects? (add the ones you want to have the effects)")]
        /// <summary>
        /// Scps that dont get effects
        /// </summary>
        public List<RoleType> WhitelistedRoles { get; private set; } = new List<RoleType>()
            { RoleType.Scp173,
            RoleType.Scp049,
            RoleType.Scp106,
            RoleType.Scp93953,
            RoleType.Scp93989,
            RoleType.Scp0492,
            RoleType.ClassD,
            };
        [Description("What effects do you want?")]
        /// <summary>
        /// Gets effects
        /// </summary>
        public List<PlayerEffects> TheEffects { get; private set; } = new List<PlayerEffects>()
        {
        Scp207,
        Scp268,
        Blinded,
        Sinkhole,
        };
    }
}
