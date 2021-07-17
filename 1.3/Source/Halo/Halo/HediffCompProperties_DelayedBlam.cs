using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace Halo
{
    public class HediffCompProperties_DelayedBlam : HediffCompProperties
    {
        public HediffCompProperties_DelayedBlam()
        {
            this.compClass = typeof(HediffComp_DelayedBlam);
        }

        public bool tendedPrevents = false;

        public int timeTillBlam = 600;

        public EffecterDef explosionEffect = null;

        public int damageAmountBase = -1;

        public DamageDef explosiveDamageType;
        public SoundDef explosionSound = null;
        public ThingDef preExplosionSpawnThingDef = null;
        public ThingDef postExplosionSpawnThingDef = null;
        public int preExplosionSpawnThingCount = 1;
        public int postExplosionSpawnThingCount = 1;
        public float explosiveRadius = 1.9f;
        public float armorPenetrationBase = -1;
        public float preExplosionSpawnChance = 0;
        public float postExplosionSpawnChance = 1;
        public float chanceToStartFire = 0;
        public bool applyDamageToExplosionCellsNeighbors = false;
        public bool damageFalloff = false;
    }
}
