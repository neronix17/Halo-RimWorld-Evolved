using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace Halo
{
    public class HediffComp_DelayedBlam : HediffComp
    {
        public int timeTillBlam;

        public HediffCompProperties_DelayedBlam Props => (HediffCompProperties_DelayedBlam)this.props;

        public override void CompPostMake()
        {
            base.CompPostMake();

            this.timeTillBlam = Props.timeTillBlam;
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if(!Props.tendedPrevents || (Props.tendedPrevents && !parent.IsTended()))
            {
                if (timeTillBlam <= 0)
                {
                    this.Detonate();
                    this.parent.Severity = 0f;
                }
                else
                {
                    timeTillBlam--;
                }
            }
        }

        public void Detonate()
        {
            if (Props.explosionEffect != null)
            {
                Effecter effecter = Props.explosionEffect.Spawn();
                effecter.Trigger(new TargetInfo(this.parent.pawn.PositionHeld, this.parent.pawn.Map, false), new TargetInfo(this.parent.pawn.PositionHeld, this.parent.pawn.Map, false));
                effecter.Cleanup();
            }

            GenExplosion.DoExplosion(this.parent.pawn.PositionHeld, this.parent.pawn.Map, Props.explosiveRadius, Props.explosiveDamageType, this.parent.pawn, Props.damageAmountBase, Props.armorPenetrationBase, Props.explosionSound, null, null, null, Props.postExplosionSpawnThingDef, Props.postExplosionSpawnChance, Props.postExplosionSpawnThingCount, Props.applyDamageToExplosionCellsNeighbors, Props.preExplosionSpawnThingDef, Props.preExplosionSpawnChance, Props.preExplosionSpawnThingCount, Props.chanceToStartFire, Props.damageFalloff);
        }
    }
}
