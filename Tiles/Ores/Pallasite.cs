using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies.Tiles.Ores
{
    public class Pallasite : ModTile
    {
        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 910; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Pallasite");
			AddMapEntry(new Color(152, 171, 198), name);

			dustType = 84;
			drop = mod.ItemType("PallasiteGlobule");
            soundType = 21;
			soundStyle = 1;
			minPick = 210;
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = new Vector2(i * 16, j * 16);
                dust = Main.dust[Terraria.Dust.NewDust(position, 16, 16, 60, 0f, 0f, 181, new Color(255, 255, 255), 0.15f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = new Vector2(i * 16, j * 16);
                dust = Main.dust[Terraria.Dust.NewDust(position, 16, 16, 61, 0f, 0f, 181, new Color(255, 255, 255), 0.15f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = new Vector2(i * 16, j * 16);
                dust = Main.dust[Terraria.Dust.NewDust(position, 16, 16, 62, 0f, 0f, 181, new Color(255, 255, 255), 0.15f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = new Vector2(i * 16, j * 16);
                dust = Main.dust[Terraria.Dust.NewDust(position, 16, 16, 63, 0f, 0f, 181, new Color(255, 255, 255), 0.15f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = new Vector2(i*16, j*16);
                dust = Main.dust[Terraria.Dust.NewDust(position, 16, 16, 64, 0f, 0f, 181, new Color(255, 255, 255), 0.15f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
        }
    }
}
