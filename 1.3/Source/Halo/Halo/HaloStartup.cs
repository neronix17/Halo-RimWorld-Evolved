using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using O21Toolbox;

namespace Halo
{
    [StaticConstructorOnStartup]
    public static class HaloStartup
    {
        static HaloStartup()
        {
            OnDemandUtil.FixOnDemandDefs("O21_Halo_", HaloMod.mod.Content);
        }
    }
}
