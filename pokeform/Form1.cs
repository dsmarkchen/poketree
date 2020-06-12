using Pokebase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokeform
{
    public partial class Form1 : Form
    {
        private PokeContainer _jhl = new PokeContainer();
        public Form1()
        {
            InitializeComponent();
        }
        private readonly List<DGVItem> _team = new List<DGVItem>();
        private readonly List<DGVItem> _opponent = new List<DGVItem>();

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanelTop.Dock = DockStyle.Fill;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel3.Dock = DockStyle.Fill;

            string jsonFile = "gamemaster.json";
            var path = Path.Combine(System.Windows.Forms.Application.StartupPath, jsonFile);
            string text = System.IO.File.ReadAllText(path);

            _jhl.run(text);
        }

        private void buttonLoadDefault_Click(object sender, EventArgs e)
        {
            string gname = "Giratina (Altered)";
            DGVItem tinaA = new DGVItem
            {
                name = gname,
                iv_atk = 14,
                iv_def = 7,
                iv_hp = 11,
                level = 26.5f,
                fast = "Dragon Breath",
                first = "Dragon Claw",
                second = "Shadow Sneak",
           };
            tinaA.cp = _jhl.getCP(tinaA.name, tinaA.iv_atk, tinaA.iv_def, tinaA.iv_hp, tinaA.level);
            _team.Add(tinaA);


            DGVItem esc = new DGVItem
            {
                name = "Escavalier",
                iv_atk = 10,
                iv_def = 15,
                iv_hp = 15,
                level = 31.5f,
                fast = "Count",
                first = "Drill Run",
                second = "Megahorn",
            };
            esc.cp = _jhl.getCP(esc.name, esc.iv_atk, esc.iv_def, esc.iv_hp, esc.level);

            _team.Add(esc);


            DGVItem regi = new DGVItem
            {
                name = "Registeel",
                iv_atk = 15,
                iv_def = 13,
                iv_hp = 15,
                level = 41f,
                fast = "Lock On",
                first = "Flash Cannon",
                second = "Focus Blast",
            };
            regi.cp = _jhl.getCP(regi.name, regi.iv_atk, regi.iv_def, regi.iv_hp, regi.level);

            _team.Add(regi);


            dataGridView1.DataSource = _team;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gname = "Giratina (Altered)";
            DGVItem tinaA = new DGVItem
            {
                name = gname,
                iv_atk = 14,
                iv_def = 7,
                iv_hp = 11,
                level = 26.5f,
                fast = "Shadow Claw",
                first = "Dragon Claw",
                second = "Shadow Sneak",
            };
            tinaA.cp = _jhl.getCP(tinaA.name, tinaA.iv_atk, tinaA.iv_def, tinaA.iv_hp, tinaA.level);
            _opponent.Add(tinaA);
            dataGridView2.DataSource = _opponent;
        }
    }
    public class DGVItem {
        public string name
        {
            get;
            set;
        }
        public int iv_atk
        {
            get;
            set;
        }
        public int iv_def
        {
            get;
            set;
        }
        public int iv_hp
        {
            get;
            set;
        }

        public float level
        {
            get;
            set;
        }
        
        public string fast
        {
            get;
            set;
        }
        public string first
        {
            get;
            set;
        }
        public string second
        {
            get;
            set;
        }

        public int cp
        {
            get;
            set;
        }

    }
}
