using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace Halo
{
    public class Hediff_MgalekgoloBond : HediffWithComps
    {
        public Pawn bondedPawn;

        public int bondCooldown = 0;

        public override void PostMake()
        {
            base.PostMake();
        }

        public override string LabelInBrackets
        {
            get
            {
                if(bondedPawn != null)
                {
                    return "Bonded to: " + bondedPawn.Name;
                }
                else
                {
                    return "No bond.";
                }
            }
        }

        public override void Tick()
        {
            base.Tick();

            if(bondedPawn != null)
            {
                if (bondedPawn.Faction != this.pawn.Faction)
                {
                    this.pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, "BondedMgalekgoloNotColonist".Translate(this.pawn.Name.ToString(), this.bondedPawn.Name.ToString()), true, false, null, false);
                    bondCooldown = 60000;
                    bondedPawn = null;
                }
                if (bondedPawn.health.Dead)
                {
                    this.pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, "BondedMagalekgoloDied".Translate(this.pawn.Name.ToString(), this.bondedPawn.Name.ToString()), true, false, null, false);
                    bondCooldown = 120000;
                    bondedPawn = null;
                }
            }

            if(this.pawn.Map != null)
            {
                if (bondedPawn == null && bondCooldown <= 0)
                {
                    foreach (Pawn pawn in this.pawn.Map.mapPawns.AllPawns)
                    {
                        if (pawn != this.pawn && pawn.Faction == this.pawn.Faction)
                        {
                            Hediff_MgalekgoloBond worker = (Hediff_MgalekgoloBond)pawn.health.hediffSet.hediffs.ToList().Find(h => h is Hediff_MgalekgoloBond);
                            if (worker != null && worker.bondedPawn == null)
                            {
                                SetBondedPawn(pawn);
                                worker.SetBondedPawn(this.pawn);
                                break;
                            }
                        }
                    }
                    bondCooldown = 60000;
                }

                if (bondCooldown > 0)
                {
                    bondCooldown--;
                }
            }
        }

        public void SetBondedPawn(Pawn pawn)
        {
            bondedPawn = pawn;
        }
    }
}
