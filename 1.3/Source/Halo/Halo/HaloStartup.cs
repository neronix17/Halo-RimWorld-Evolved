using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace Halo
{
    [StaticConstructorOnStartup]
    public static class HaloStartup
    {
        static HaloStartup()
        {
            HaloSettings settings = HaloMod.settings;
        }
    }
}
