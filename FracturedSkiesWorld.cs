using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies
{
    public class FracturedSkiesWorld : ModWorld
    {
        public int _numMeteor;
        public bool _cataclysm;

        public override void Initialize()
        {
            _numMeteor = 0;
            _cataclysm = false;
        }

        public override void Load(TagCompound tag)
        {
            _numMeteor = tag.GetInt("NumMeteor");
            _cataclysm = tag.GetBool("Cataclysm");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "NumMeteor", _numMeteor},
                {"Cataclysm", _cataclysm}
            };
        }

        public override void PreUpdate() {
            if (Main.rand.Next(0, 1000) == 1 && _numMeteor < 8 && _cataclysm == true) {
                _numMeteor++;
                DropMeteor(_numMeteor);
            }
        }

        public override void PostUpdate() {
            if (NPC.downedMoonlord) {
                _cataclysm = true;
            }
        }

        public static void DropMeteor(int meteorCount)
        {
            bool flag = true;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    flag = false;
                    break;
                }
            }
            float num2 = (float)(Main.maxTilesX / 4200);
            int num3 = (int)(600f * num2);
                    float num5 = 800;
            while (!flag)
            {
                float num6 = (float)Main.maxTilesX * 0.1f;
                int num7 = Main.rand.Next(170, Main.maxTilesX - 180);
                while ((float)num7 > (float)Main.spawnTileX - num6 && (float)num7 < (float)Main.spawnTileX + num6)
                {
                    num7 = Main.rand.Next(150, Main.maxTilesX - 150);
                }
                int k = (int)(Main.worldSurface * 0.3);
                while (k < Main.maxTilesY)
                {
                    if (Main.tile[num7, k].active() && Main.tileSolid[(int)Main.tile[num7, k].type])
                    {
                        int num8 = 0;
                        int num9 = 15;
                        for (int l = num7 - num9; l < num7 + num9; l++)
                        {
                            for (int m = k - num9; m < k + num9; m++)
                            {
                                if (WorldGen.SolidTile(l, m))
                                {
                                    num8++;
                                    if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
                                    {
                                        num8 -= 100;
                                    }
                                }
                                else if (Main.tile[l, m].liquid > 0)
                                {
                                    num8--;
                                }
                            }
                        }
                        if ((float)num8 < num5)
                        {
                            num5 -= 0.5f;
                            break;
                        }
                        flag = meteor(num7, k, meteorCount);
                        if (flag)
                        {
                            break;
                        }
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }
                if (num5 < 100f)
                {
                    return;
                }
            }
        }

        public static bool meteor(int i, int j, int meteorCount)
        {
            Mod mod = ModLoader.GetMod("FracturedSkies");
            if (i < 100 || i > Main.maxTilesX - 100)
            {
                return false;
            }
            if (j < 100 || j > Main.maxTilesY - 100)
            {
                return false;
            }
            int num = 55;
            Rectangle rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
            for (int k = 0; k < 255; k++)
            {
                if (Main.player[k].active)
                {
                    Rectangle value = new Rectangle((int)(Main.player[k].position.X + (float)(Main.player[k].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[k].position.Y + (float)(Main.player[k].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                    if (rectangle.Intersects(value))
                    {
                        return false;
                    }
                }
            }
            for (int l = 0; l < 200; l++)
            {
                if (Main.npc[l].active)
                {
                    Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
                    if (rectangle.Intersects(value2))
                    {
                        return false;
                    }
                }
            }
            for (int m = i - num; m < i + num; m++)
            {
                for (int n = j - num; n < j + num; n++)
                {
                    if (Main.tile[m, n].active() && TileID.Sets.BasicChest[(int)Main.tile[m, n].type])
                    {
                        return false;
                    }
                }
            }
            //main shape
            num = WorldGen.genRand.Next(27, 39);
            for (int num2 = i - num; num2 < i + num; num2++)
            {
                for (int num3 = j - num; num3 < j + num; num3++)
                {
                    if (num3 > j + Main.rand.Next(-2, 3) - 5)
                    {
                        float num4 = (float)Math.Abs(i - num2);
                        float num5 = (float)Math.Abs(j - num3);
                        float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                        if ((double)num6 < (double)num * 0.9 + (double)Main.rand.Next(-4, 5))
                        {
                            if (!Main.tileSolid[(int)Main.tile[num2, num3].type])
                            {
                                Main.tile[num2, num3].active(false);
                            }
                            Main.tile[num2, num3].type = (ushort)mod.TileType("BlightedGrass");
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(12, 25);
            for (int num27 = i - num; num27 < i + num; num27++)
            {
                for (int num28 = j - num; num28 < j + num; num28++)
                {
                    if (num28 > j + Main.rand.Next(-2, 3) - 5)
                    {
                        float num29 = (float)Math.Abs(i - num27);
                        float num30 = (float)Math.Abs(j - num28);
                        float num31 = (float)Math.Sqrt((double)(num29 * num29 + num30 * num30));
                        if ((double)num31 < (double)num * 0.9 + (double)Main.rand.Next(-4, 5))
                        {
                            if (!Main.tileSolid[(int)Main.tile[num27, num28].type])
                            {
                                Main.tile[num27, num28].active(false);
                            }
                            Main.tile[num27, num28].type = (ushort)mod.TileType("Pallasite");
                        }
                    }
                }
            }
            //hole
            num = WorldGen.genRand.Next(8, 18);
            for (int num7 = i - num; num7 < i + num; num7++)
            {
                for (int num8 = j - num; num8 < j + num; num8++)
                {
                    if (num8 > j + Main.rand.Next(-2, 3) - 4)
                    {
                        float num9 = (float)Math.Abs(i - num7);
                        float num10 = (float)Math.Abs(j - num8);
                        float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                        if ((double)num11 < (double)num * 0.8 + (double)Main.rand.Next(-3, 4))
                        {
                            Main.tile[num7, num8].active(false);
                        }
                    }
                }
            }
            //resloper (I think.) figure this out soon.
            num = WorldGen.genRand.Next(18, 28);
            for (int num12 = i - num; num12 < i + num; num12++)
            {
                for (int num13 = j - num; num13 < j + num; num13++)
                {
                    float num14 = (float)Math.Abs(i - num12);
                    float num15 = (float)Math.Abs(j - num13);
                    float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                    if ((double)num16 < (double)num * 0.7)
                    {
                        if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
                        {
                            WorldGen.KillTile(num12, num13, false, false, false);
                        }
                        Main.tile[num12, num13].liquid = 0;//kills trees, corrupt and crimson thorns, and water. 
                    }
                    if (Main.tile[num12, num13].type == (ushort)mod.TileType("Pallasite") || Main.tile[num12, num13].type == (ushort) mod.TileType("BlightedGrass"))
                    {
                        if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                        else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                    }
                    WorldGen.SquareTileFrame(num12, num13, true);
                    WorldGen.SquareWallFrame(num12, num13, true);
                }
            }
            //Random tile spray
            num = WorldGen.genRand.Next(13, 22);
            for (int num17 = i - num; num17 < i + num; num17++)
            {
                for (int num18 = j - num; num18 < j + num; num18++)
                {
                    if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
                    {
                        float num19 = (float)Math.Abs(i - num17);
                        float num20 = (float)Math.Abs(j - num18);
                        float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
                        if ((double)num21 < (double)num * 0.8)
                        {
                            if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
                            {
                                WorldGen.KillTile(num17, num18, false, false, false);
                            }
                            Main.tile[num17, num18].type = (ushort)mod.TileType("Pallasite");
                            WorldGen.SquareTileFrame(num17, num18, true);
                        }
                    }
                }
            }
            //Far random tile spray
            num = WorldGen.genRand.Next(50, 78);
            for (int num22 = i - num; num22 < i + num; num22++)
            {
                for (int num23 = j - num; num23 < j + num; num23++)
                {
                    if (num23 > j + WorldGen.genRand.Next(-2, 3) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
                    {
                        float num24 = (float)Math.Abs(i - num22);
                        float num25 = (float)Math.Abs(j - num23);
                        float num26 = (float)Math.Sqrt((double)(num24 * num24 + num25 * num25));
                        if ((double)num26 < (double)num * 0.85)
                        {
                            if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 352)
                            {
                                WorldGen.KillTile(num22, num23, false, false, false);
                            }
                            Main.tile[num22, num23].type = (ushort)mod.TileType("BlightedGrass");
                            WorldGen.SquareTileFrame(num22, num23, true);
                        }
                    }
                }
            }
            if (Main.netMode == 0)
            {
                if (meteorCount == 1)
                {
                    Main.NewText("The earth shakes...", 255, 50, 255, false);
                } else if (meteorCount == 8)
                {
                    Main.NewText("The rapture has ended... for now.", 255, 50, 255, false);
                }
            }
            if (Main.netMode != 1)
            {
                NetMessage.SendTileSquare(-1, i, j, 40, TileChangeType.None);
            }
            return true;
        }
    }
}