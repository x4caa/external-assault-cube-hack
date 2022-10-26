using swed32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;



namespace acmenu
{
    public partial class Form1 : Form
    {
        public swed mem;
        methods? m;
        Entity localPlayer = new Entity();
        List<Entity> entities = new List<Entity>();

        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(Keys vKey);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            m = new methods();
            if (m != null)
            {
                Thread thread = new Thread(Main) { IsBackground = true };
                thread.Start();

            }
        }




        void Main()
        {
            while(true)
            {
                localPlayer = m.ReadLocalPlayer();
                entities = m.ReadEntities(localPlayer);

                m.refillAmmo(localPlayer);

                entities = entities.OrderBy(o => o.mag).ToList();
                if (GetAsyncKeyState(Keys.RButton)<0)
                {
                    
                    if (entities.Count > 0)
                    {
                        foreach (var ent in entities)
                        {
                            if (ent.team != 2000)
                            {
                                var angles = m.CalcAngles(localPlayer, ent);
                                
                                m.Aim(localPlayer, angles.X, angles.Y);
                                break;
                            }
                        }
                    }
                }




                // Thread.Sleep(1);
            }
        }

    }
}