﻿using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Twitch
{
    public static class SpellDamage
    {
        public static float GetTotalDamage(AIHeroClient target)
        {
            // Auto attack
            var damage = Player.Instance.GetAutoAttackDamage(target);

            // Q
            if (SpellManager.Q.IsReady())
            {
                damage += SpellManager.Q.GetRealDamage(target);
            }

            // W
            if (SpellManager.W.IsReady())
            {
                damage += SpellManager.W.GetRealDamage(target);
            }

            // E
            if (SpellManager.E.IsReady())
            {
                damage += SpellManager.E.GetRealDamage(target);
            }

            // R
            if (SpellManager.R.IsReady())
            {
                damage += SpellManager.R.GetRealDamage(target);
            }

            return damage;
        }

        public static float GetRealDamage(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            return spell.Slot.GetRealDamage(target);
        }

        public static float GetRealDamage(this SpellSlot slot, Obj_AI_Base target)
        {
            // Helpers
            var spellLevel = Player.Instance.Spellbook.GetSpell(slot).Level;
            var stacks = SpellManager.EStacks(target);
            const DamageType damageType = DamageType.Magical;
            float damage = 0;

            // Validate spell level
            if (spellLevel == 0)
            {
                return 0;
            }
            spellLevel--;

            switch (slot)
            {
                case SpellSlot.Q:

                    damage = new float[] { 0, 0, 0, 0, 0 }[spellLevel];
                    break;

                case SpellSlot.W:

                    damage = new float[] { 0, 0, 0, 0, 0 }[spellLevel];
                    break;

                case SpellSlot.E:

                    damage = new float[] { 20, 35, 50, 65, 80 }[spellLevel] + 
                        stacks * (new int[] { 15, 20, 25, 30, 35 }[spellLevel] + 0.2f * Player.Instance.TotalMagicalDamage
                        + 0.25f * (Player.Instance.TotalAttackDamage - Player.Instance.BaseAttackDamage));
                    break;

                case SpellSlot.R:

                    damage = new float[] { 0, 0, 0 }[spellLevel];
                    break;
            }

            if (damage <= 0)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(target, damageType, damage) - 10;
        }
    }
}