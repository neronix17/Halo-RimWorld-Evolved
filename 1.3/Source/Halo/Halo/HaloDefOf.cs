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
    [DefOf]
    public static class HaloDefOf
    {
        static HaloDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HaloDefOf));
        }
    }
}
