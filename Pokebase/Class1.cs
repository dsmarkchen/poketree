using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokebase
{
    public class Poke
    {
        public string Name
        {
            get;
            set;
        }
        public Move Fast
        {
            get;
            set;
        }
        public Move[] Charges
        {
            get;
            set;
        }
        public IV IV
        {
            get;
            set;
        }

        public Type [] Types
        {
            get;
            set;
        }
    }
    public  class Type
    {
        public ENType ENType { get; set; }
    }
    public enum ENType
    {
        normal,
        grass,
        water,
        fire,
        ground,
        dragon,
        electric,
        dark,
        fairy,
        psychic,
        fighting,
        steel,
        ghost
    }
    public enum ENFastMove
    {
        snarl,
        dragon_breath,
        shadow_claw
    }
    public enum ENChargeMove
    {
        leaf_blade,
        foul_play
    }

    public class Move
    {
        public string ID { get ; private set; }

        public string Name { 
            get {
                var names = ID.Split('_');
                StringBuilder sb = new StringBuilder();
                foreach(var name in names)
                {
                    sb.Append(name.First() + name.Substring(1).ToLower());
                    sb.Append(' ');
                }
                return sb.ToString().Trim(' '); 
            } 
        }

        public ENType Type { get; private set; }

        public int Power { get; set; }
        public int Energy { get; set; }

        public int EnergyGain { get; set; }
        public int Cooldown { get; set; }

        public Move(string name, ENType type)
        {
            ID = name.ToUpper().Replace(' ', '_');            
            Type = type;
        }
    }


    public class IV
    {
        private readonly double[] _modifier = new double[]
        {
                0.094,0.135137432,0.16639787, 0.192650919,0.21573247,
                0.236572661,0.25572005,0.273530381,0.29024988,0.306057378,
                0.3210876,0.335445036,0.34921268,0.362457751,0.3752356,
                0.387592416,0.39956728,0.411193551,0.4225,0.432926409,

                0.44310755,0.453059959,0.4627984,0.472336093,0.48168495,
                0.4908558,0.49985844,0.508701765,0.51739395,0.525942511,
                0.5343543,0.542635738,0.5507927,0.558830586,0.5667545,
                0.574569133,0.5822789,0.589887907,0.5974,0.604823665,

                0.6121573,0.619404122,0.6265671,0.633649143,0.64065295,
                0.647580967,0.65443563,0.661219252,0.667934,0.674581896,
                0.6811649,0.687684904,0.69414365,0.70054287,0.7068842,
                0.713169109,0.7193991,0.725575614,0.7317,0.734741009,

                0.7377695,0.740785594,0.74378943,0.746781211,0.74976104,
                0.752729087,0.7556855,0.758630368,0.76156384,0.764486065,
                0.76739717,0.770297266,0.7731865,0.776064962,0.77893275,
                0.781790055,0.784637,0.787473608,0.7903
        };
        private float _atk;
        private float _def;
        private float _hp;

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HP { get; set; }
        public float Level { get; set; }

        public int StatsAttack { get; private set; }
        public int StatsDefense { get; private set; }
        public int StatsHP { get; private set; }

        public int CP { 
            get
            {
                return calculateCP();
            }            
        }
        

        public float RealAttack
        {
            get { return _atk; }
        }
        public float RealDefense
        {
            get { return _def; }
        }
        public float RealHP
        {
            get { return _hp; }
        }

        public IV(int statsAtk, int statsDef, int statsHp)
        {
            StatsAttack = statsAtk;
            StatsDefense = statsDef;
            StatsHP = statsHp;
            var len = _modifier.Length;
            var z = _modifier[len - 1];
            var y = _modifier[len - 2];
            var x = _modifier[len - 3];
            var w = _modifier[len - 4];
            var diff1 = z - y;
            var diff2 = y - x;
            var diff3 = x - w;
            Console.WriteLine(diff1.ToString() + " " + diff2.ToString() + " " + diff3.ToString());
        }

        private int calculateCP() {
            var cpm = getCpm(Level);
            _atk = cpm * (Attack + StatsAttack);
            _def = cpm *(Defense + StatsDefense);
            _hp = cpm *(HP + StatsHP);
            var cp = (int)Math.Floor((Attack + StatsAttack) * Math.Pow((Defense + StatsDefense), 0.5) * Math.Pow((HP + StatsHP), 0.5) * Math.Pow(cpm, 2) /10);
            if (cp < 10) cp = 10;
            return cp;
        }

        private float getCpm(float level)
        {            
            if(level <= 40)
              return (float) _modifier[(int)((level - 1) * 2)];
            else
            {
                var cfm40 = _modifier[(int)((40 - 1) * 2)];
                var cfm41 = 0.7953;
                var cfm40_5 = cfm40 + (cfm41 - cfm40) * 0.5;
                if(level == 41)
                    return (float)cfm41;
                if(level == 40.5f)
                {
                    return (float) cfm40_5;
                }
                return (float)cfm40;

            }
        }
    }
    
}
