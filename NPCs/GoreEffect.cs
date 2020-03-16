using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies.NPCs
{
    public class GoreEffect : ModGore
    {
        /*public int Timer;
        public float x;
        public float y;

        public override void OnSpawn(Gore gore)
        {
            for (int i = 0; i < Main.gore.Length; i++)
            {
                if (Main.gore[i].type == GoreID.MoonLordHeart1)
                {
                    Main.gore[i].velocity = new Vector2(-5, 5);
                }
            }
            x = gore.position.X;
            y = gore.position.Y;
            Update(gore);
        }

        public override bool Update(Gore gore)
        {
            Timer++;
            if (Timer > 120)
            {
                DoGoreEffect(gore);
                Timer = 0;
            }
            return true;
        }

        public void DoGoreEffect(Gore gore)
        {
            gore.position.X = x;
            gore.position.Y = y;
            Main.NewText("that worked!", 255, 255, 255);
        }*/
    }
}
