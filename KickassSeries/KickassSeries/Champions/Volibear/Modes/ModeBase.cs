﻿using EloBuddy.SDK;

namespace KickassSeries.Champions.Volibear.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Active Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.Targeted W
        {
            get { return SpellManager.W; }
        }
        protected Spell.Active E
        {
            get { return SpellManager.E; }
        }
        protected Spell.Active R
        {
            get { return SpellManager.R; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
