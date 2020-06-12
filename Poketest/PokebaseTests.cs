using NUnit.Framework;
using Pokebase;
using System;

namespace Poketest
{
    public class PokebaseIVTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Shiftry_CP_2333_at_Level_40_for_perfect_iv()
        {
            IV iv = new IV(200, 121, 207) { };
            iv.Attack = 15;
            iv.Defense = 15;
            iv.HP = 15;
            iv.Level = 40;
            Assert.IsTrue(iv.CP == 2333);
        }
        [Test]
        public void Lickilicky_CP_2467_at_Level_40_for_perfect_iv()
        {
            IV iv = new IV(161, 181, 242) { };
            iv.Attack = 15;
            iv.Defense = 15;
            iv.HP = 15;
            iv.Level = 40;
            Assert.IsTrue(iv.CP == 2467);
        }
        [Test]
        public void Giratina_Alt_CP_2486_at_Level_26_5_for_14_7_11_iv()
        {
            IV iv = new IV(187, 225, 284) { };
            iv.Attack = 14;
            iv.Defense = 7;
            iv.HP = 11;
            iv.Level = 26.5f;
            Assert.IsTrue(iv.CP == 2486);
        }

        [Test]
        public void Azu_CP_1477_at_Level_40_for_rank_77()
        {
            IV iv = new IV(112, 152, 225) { };
            iv.Attack = 7;
            iv.Defense = 14;
            iv.HP = 13;
            iv.Level = 40;
            Assert.IsTrue(iv.CP == 1477);
        }

        [Test]
        public void Azu_CP_1496_at_Level_41_for_rank_77()
        {
            IV iv = new IV(112, 152, 225) { };
            iv.Attack = 7;
            iv.Defense = 14;
            iv.HP = 13;
            iv.Level = 41;
            Assert.IsTrue(iv.CP == 1496);
        }

        [Test]
        public void Azu_CP_1486_at_Level_40_5_for_rank_77()
        {
            IV iv = new IV(112, 152, 225) { };
            iv.Attack = 7;
            iv.Defense = 14;
            iv.HP = 13;
            iv.Level = 40.5f;
            Assert.IsTrue(iv.CP == 1486);
        }



    }
    public class PokebaseMoveTests
    {
        [Test]
        public void Snarl()
        {
            Move snarl = new Move("Snarl", PokeType.dark) { };

            snarl.Power = 8;
            snarl.Energy = 0;
            snarl.EnergyGain = 10;
            snarl.Cooldown = 1500;
            Assert.IsTrue(snarl.Name == "Snarl");
            Assert.IsTrue(snarl.ID == "SNARL");
        }
        [Test]
        public void DragonBreath()
        {
            Move db = new Move("Dragon Breath", PokeType.dragon) { };

            db.Power = 4;
            db.Energy = 0;
            db.EnergyGain = 3;
            db.Cooldown = 500;
            Assert.IsTrue(db.Name == "Dragon Breath");
            Assert.IsTrue(db.ID == "DRAGON_BREATH");
        }
        [Test]
        public void ShadowClaw()
        {
            var name = "Shadow Claw";
            Move sc = new Move(name, PokeType.ghost) { };

            sc.Power = 6;
            sc.Energy = 0;
            sc.EnergyGain = 8;
            sc.Cooldown = 1000;
            Assert.IsTrue(sc.Name == name);
            Assert.IsTrue(sc.ID == "SHADOW_CLAW");
        }
    }
    public class RegiTests
    {
        IV me;


        [SetUp]
        public void Setup()
        {
            me = new IV(143, 285, 190) { };
            me.Attack = 15;
            me.Defense = 13;
            me.HP = 15;
            me.Level = 41;
            var cp = me.CP;
            Assert.IsTrue(cp == 2470);
        }
        [Test]
        public void check_cp()
        {
            Assert.IsTrue(me.CP == 2470);
        }

        [Test]
        public void lockon_damage_test()
        {

        }
    }
        
    public class GiratinaDamageTests
    {
        IV me_giratina_a;

        [SetUp]
        public void Setup()
        {
            me_giratina_a = new IV(187, 225, 284) { };
            me_giratina_a.Attack = 14;
            me_giratina_a.Defense = 7;
            me_giratina_a.HP = 11;
            me_giratina_a.Level = 26.5f;
            var cp = me_giratina_a.CP;
            Assert.IsTrue(cp == 2486);
        }
        [Test]
        public void tina_vs_lickilicky_damage_output_In_6_Seconds()
        {
            var db_count = 12;

            var cp_me = me_giratina_a.CP;
            var atk = me_giratina_a.StatsAttack;
            var r_atk = me_giratina_a.RealAttack;
            Assert.IsTrue(cp_me == 2486);

            // dragon claw damage: vs Snorlax 42
            //                     vs lickilicky 35
            IV op_lickilicky = new IV(161, 181, 242) { };
            op_lickilicky.Attack = 15;
            op_lickilicky.Defense = 15;
            op_lickilicky.HP = 15;
            op_lickilicky.Level = 40;
            var cp_op = op_lickilicky.CP;
            var def = op_lickilicky.StatsDefense;
            var r_def = op_lickilicky.RealDefense;
            Assert.IsTrue(cp_op == 2467);

            float op_effect = (float)r_atk / r_def;
            var type_effect_bonus = 1.2f; // same type effect bonus
            var bonus_multiplier = 1.3;

            Move db = new Move("Dragon Breath", PokeType.dragon) { };
            db.Power = 4;
            db.Energy = 0;
            db.EnergyGain = 3;
            db.Cooldown = 500;
            int db_gain = db.EnergyGain * db_count;

            float effect_none = 1; // againest normal
            float effect_super = 1.25f; // againest dragon
            float effect_resist = 0.75f; // lapras
            var effect = effect_none;
            var stab = 1;

            var db_damage = ((int)Math.Floor(db.Power * stab * op_effect * type_effect_bonus * 0.5 * bonus_multiplier) + 1) * db_count;


            Move dc = new Move("Dragon Claw", PokeType.dragon) { };
            dc.Power = 50;
            dc.Energy = 35;
            dc.EnergyGain = 0;
            dc.Cooldown = 500;
            var damage = db_damage;

            IV op_snorlax = new IV(190, 169, 330) { };
            op_snorlax.Attack = 8;
            op_snorlax.Defense = 10;
            op_snorlax.HP = 14;
            op_snorlax.Level = 28.5f;
            var cp_op_s = op_snorlax.CP;
            var def_s = op_snorlax.StatsDefense;
            var r_def_s = op_snorlax.RealDefense;



            float op_effect_s = (float)r_atk / r_def_s;


            if (db_gain > dc.Energy)
            {
                var dc_damage_l = (int)Math.Floor(dc.Power * stab * op_effect * type_effect_bonus * 0.5 * bonus_multiplier) + 1;

                var dc_damage_s = (int)Math.Floor(dc.Power * stab * op_effect_s * type_effect_bonus * 0.5 * bonus_multiplier) + 1;
                damage += dc_damage_l;

                Assert.IsTrue(dc_damage_s > dc_damage_l);
                Assert.IsTrue(35 == (int)(dc_damage_l));
                Assert.IsTrue(43 == (int)(dc_damage_s));
            }

            // total damage on lickilicky
            Assert.IsTrue(damage == 35 + 3 * 12);
        }


        [Test]
        public void tina_vs_lickilick__level_30_dc_Damage_is_38()
        {
            var db_count = 12;
            var bonus_multiplier = 1.3;
            var type_effect_bonus = 1.2f; // same type effect bonus

            var r_atk = me_giratina_a.RealAttack;

            // dragon claw damage: 
            //                     vs lickilicky_l38 38 
            IV op_lickilicky = new IV(161, 181, 242) { };
            op_lickilicky.Attack = 15;
            op_lickilicky.Defense = 15;
            op_lickilicky.HP = 15;
            op_lickilicky.Level = 30;
            var cp_op = op_lickilicky.CP;
            var r_def = op_lickilicky.RealDefense;
            Assert.IsTrue(cp_op == 2114);


            Move db = new Move("Dragon Breath", PokeType.dragon) { };
            db.Power = 4;
            db.Energy = 0;
            db.EnergyGain = 3;
            db.Cooldown = 500;


            int db_gain = db.EnergyGain * db_count;

            float effect_none = 1; // againest normal
            float effect_super = 1.25f; // againest dragon
            float effect_resist = 0.75f; // lapras
            var effect = effect_none;


            Move dc = new Move("Dragon Claw", PokeType.dragon) { };
            dc.Power = 50;
            dc.Energy = 35;
            dc.EnergyGain = 0;
            dc.Cooldown = 500;

            var stab = 1;
            float op_effect = (float)r_atk / r_def;

            var db_damage = ((int)Math.Floor(db.Power * stab * op_effect * type_effect_bonus * 0.5 * bonus_multiplier) + 1);
            Assert.IsTrue(db_damage == 4);


            if (db_gain > dc.Energy)
            {
                var dc_damage_l = (int)Math.Floor(0.5 * dc.Power * stab * op_effect * bonus_multiplier * type_effect_bonus) + 1;

                Assert.IsTrue(38 == (int)(dc_damage_l));
            }

        }

    }
    public class SwampertDamageTests
    {
        private IV me_swampert;
        private int me_cp;
        private float bonus_multiplier = 1.3f;

        [SetUp]
        public void Setup()
        {
            me_swampert = new IV(208, 175, 225) { };
            me_swampert.Attack = 6;
            me_swampert.Defense = 15;
            me_swampert.HP = 9;
            me_swampert.Level = 32f;
            me_cp = me_swampert.CP;

        }
        [Test]
        public void check_swampert_cp()
        {
            Assert.IsTrue(me_cp == 2496);
        }
        [Test]
        public void check_mud_shot_damage_vs_giratina()
        {
            Move ms = new Move("Mud Shot", PokeType.ground) { };
            ms.Power = 3;
            ms.Energy = 0;
            ms.EnergyGain = 9;
            ms.Cooldown = 1000;

            var op_giratina_a = new IV(187, 225, 284) { };
            op_giratina_a.Attack = 14;
            op_giratina_a.Defense = 7;
            op_giratina_a.HP = 11;
            op_giratina_a.Level = 26.5f;
            var op_cp = op_giratina_a.CP;
            Assert.IsTrue(op_cp == 2486);

            var stab = 1;
            var r_atk = me_swampert.RealAttack;
            var r_def = op_giratina_a.RealDefense;
             
            float op_effect = (float)r_atk / r_def;
            var type_effect_bonus = 1.2;
            var ms_damage = ((int)Math.Floor(ms.Power * stab * op_effect * type_effect_bonus * 0.5 * bonus_multiplier) + 1);
            Assert.IsTrue(ms_damage == 3);

        }

        [Test]
        public void check_hydro_cannon_damage_vs_giratina()
        {
            Move ms = new Move("Mud Shot", PokeType.ground) { };
            ms.Power = 3;
            ms.Energy = 0;
            ms.EnergyGain = 9;
            ms.Cooldown = 1000;

            Move hc = new Move("Hydro Cannon", PokeType.ground) { };
            ms.Power = 90;
            ms.Energy = 40;
            ms.EnergyGain = 0;
            ms.Cooldown = 500;

            var op_giratina_a = new IV(187, 225, 284) { };
            op_giratina_a.Attack = 14;
            op_giratina_a.Defense = 7;
            op_giratina_a.HP = 11;
            op_giratina_a.Level = 26.5f;
            var op_cp = op_giratina_a.CP;
            Assert.IsTrue(op_cp == 2486);

            var stab = 1;
            var r_atk = me_swampert.RealAttack;
            var r_def = op_giratina_a.RealDefense;

            float op_effect = (float)r_atk / r_def;
            var type_effect_bonus = 1.2;
            var ms_damage = ((int)Math.Floor(ms.Power * stab * op_effect * type_effect_bonus * 0.5 * bonus_multiplier) + 1);
            Assert.IsTrue(ms_damage == 3);

        }
    }
}
