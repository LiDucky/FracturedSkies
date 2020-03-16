using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies.NPCs.Enemies
{
    public class Pumpkor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpkor");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 4000;
            npc.damage = 100;
            npc.defense = 80;
            npc.knockBackResist = 0.5f;
            npc.width = 30;
            npc.height = 40;
            npc.aiStyle = 3;
            npc.noGravity = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            aiType = NPCID.Zombie; // overhaul AI later so it's actually scary...
            animationType = NPCID.Zombie;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            //banner = npc.type;
            //bannerItem = ItemType<PumpkorBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Corruption.Chance * 0.5f;
        }

        public override void AI()
        {
            npc.velocity.X = 3f * npc.direction; //Pretty awkward...
        }
    }
}