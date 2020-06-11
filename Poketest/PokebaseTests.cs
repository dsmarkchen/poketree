using NUnit.Framework;
using Pokebase;

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
            IV iv = new IV(200,121,207) { };
            iv.Attack = 15;
            iv.Defense = 15;
            iv.HP = 15;
            iv.Level = 40;            
            Assert.IsTrue(iv.CP == 2333);
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
            Move snarl = new Move("Snarl", ENType.dark) { };
            
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
            Move db = new Move("Dragon Breath", ENType.dragon) { };

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
            Move sc = new Move(name, ENType.ghost) { };

            sc.Power = 6;
            sc.Energy = 0;
            sc.EnergyGain = 8;
            sc.Cooldown = 1000;
            Assert.IsTrue(sc.Name == name);
            Assert.IsTrue(sc.ID == "SHADOW_CLAW");
        }

        [Test]
        public void CountMoves_In_7_Seconds()
        {
            var db_count = 12;
            Move db = new Move("Dragon Breath", ENType.dragon) { };
            db.Power = 4;
            db.Energy = 0;
            db.EnergyGain = 3;
            db.Cooldown = 500;            
            int db_gain = db.EnergyGain * db_count;

            float effect_normal = 1; // againest normal
            float effect_dragon = 1.25f; // againest dragon
            float effect_ice = 0.75f; // lapras
            var effect = effect_ice;
            var db_damage = effect * db.Power * db_count;


            Move dc = new Move("Dragon Claw", ENType.dragon) { };
            dc.Power = 500;
            dc.Energy = 35;
            dc.EnergyGain = 0;
            dc.Cooldown = 500;
            var damage = db_damage ;
            if (db_gain > dc.Energy)
            {
                damage += dc.Power * effect;
            }
            Assert.IsTrue(damage == 37 + 3 * 12);
        }

    }

}