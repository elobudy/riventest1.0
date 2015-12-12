﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace MrMundo.States
{
    class WaveClear : StateTemplate
    {
        public override void Init()
        {

        }

        public override bool Startable()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Activate()
        {
            if (!SpellHandler.Q.IsReady() || !Program.FarmMenu["useQWC"].Cast<CheckBox>().CurrentValue) return;

            if (EntityManager.MinionsAndMonsters.EnemyMinions.OrderByDescending(a => a.MaxHealth).Any(
                    a => a.Health <= Player.Instance.GetSpellDamage(a, SpellSlot.Q) && SpellHandler.Q.Cast(a)))
            {
                return;
            }
        }
    }
}
