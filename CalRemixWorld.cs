using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using System.IO;
using CalamityMod.World;
using System;
using CalRemix.Tiles;
using CalamityMod.Tiles.Astral;
using CalamityMod.Tiles.AstralDesert;
using CalamityMod.Tiles.AstralSnow;
using CalamityMod.Tiles.FurnitureMonolith;
using CalRemix.Items.Placeables;
using CalamityMod.Walls;
using CalamityMod;
using Microsoft.Xna.Framework;
using CalamityMod.NPCs.Cryogen;
using CalRemix.UI;
using CalamityMod.Tiles.Ores;
using CalRemix.Backgrounds.Plague;
using CalRemix.Tiles.PlaguedJungle;
using CalRemix.Projectiles.TileTypeless;
using CalamityMod.Tiles.Plates;
using CalamityMod.NPCs;
using CalRemix.Projectiles.Weapons;
using CalRemix.Items.Weapons;
using CalRemix.NPCs;
using CalamityMod.Tiles;
using CalamityMod.Tiles.SunkenSea;
using System.Threading;
using Terraria.GameContent.ItemDropRules;
using CalamityMod.NPCs.Abyss;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Fishing.SulphurCatches;
using CalamityMod.NPCs.DevourerofGods;
using CalamityMod.Tiles.DraedonStructures;
using Terraria.WorldBuilding;
using log4net.Repository.Hierarchy;
using log4net.Core;
using CalamityMod.Tiles.FurnitureVoid;
using CalamityMod.Items.SummonItems;
using CalRemix.Items;
using CalamityMod.NPCs.DesertScourge;
using CalamityMod.Items.TreasureBags;
using CalamityMod.NPCs.Bumblebirb;
using CalamityMod.NPCs.GreatSandShark;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.NPCs.PrimordialWyrm;
using Terraria.UI;

namespace CalRemix
{
    public class CalRemixWorld : ModSystem
    {
        public static bool downedEarth = false;
        public static bool downedExcavator = false;
        public static bool downedDerellect = false;

        public static bool downedLifeSlime = false;
        public static bool downedClamitas = false;
        public static bool downedCyberDraedon = false;
        public static bool downedOnyxKinsman = false;
        public static bool downedYggdrasilEnt = false;
        public static bool downedPlagueEmperor = false;
        public static bool downedLaRuga = false;
        public static bool downedKingMinnowsPrime = false;

        public static int lifeTiles;
        public static int PlagueTiles;
        public static int PlagueDesertTiles;
        public static int MeldTiles;
        public static int ShrineTimer = -20;
        public static bool loadedRecipeInjections = false;

        public static bool guideHasExisted = false;
        public static bool deusDeadInSnow = false;
        public static bool generatedCosmiliteSlag = false;
        public static bool generatedPlague = false;
        public static bool generatedStrain = false;
        public static bool grime = false;

        public static int transmogrifyingItem = -1;
        public static int transmogrifyingItemAmt = 0;
        public static int transmogrifyTimeLeft = 0;
        public static List<(int, int)> plagueBiomeArray = new List<(int, int)>();
        public static int meldCountdown = 72000;

        public static bool alloyBars = true;
        public static bool essenceBars = true;
        public static bool yharimBars = true;
        public static bool shimmerEssences = true;
        public static bool meldGunk = true;
        public static bool cosmislag = true;
        public static bool reargar = true;
        public static bool sidegar = true;
        public static bool frontgar = true;
        public static bool crocodile = true;
        public static bool permanenthealth = true;
        public static bool starbuster = true;
        public static bool plaguetoggle = true;
        public static bool shrinetoggle = true;
        public static bool lifeoretoggle = true;
        public static bool resprites = true;
        public static bool renames = true;
        public static bool bossdialogue = true;
        public static bool grimesandToggle = true;
        public static bool clowns = true;
        public static bool aspids = true;
        public static bool clamitas = true;
        public static bool wolfvenom = true;
        public static bool fearmonger = true;
        public static bool seafood = true;
        public static bool laruga = true;

        public List<int> DungeonWalls = new List<int>
        {
            WallID.BlueDungeonUnsafe,
            WallID.BlueDungeonSlabUnsafe,
            WallID.BlueDungeonTileUnsafe,
            WallID.GreenDungeonUnsafe,
            WallID.GreenDungeonSlabUnsafe,
            WallID.GreenDungeonTileUnsafe,
            WallID.PinkDungeonUnsafe,
            WallID.PinkDungeonSlabUnsafe,
            WallID.PinkDungeonTileUnsafe
        };
        public static void UpdateWorldBool()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
        public override void OnWorldLoad()
        {
            downedDerellect = false;
            downedExcavator = false;
            downedEarth = false;

            downedLifeSlime = false;
            downedClamitas = false;
            downedCyberDraedon = false;
            downedOnyxKinsman = false;
            downedYggdrasilEnt = false;
            downedPlagueEmperor = false;
            downedLaRuga = false;
            downedKingMinnowsPrime = false;

            guideHasExisted = false;
            deusDeadInSnow = false;
            generatedCosmiliteSlag = false;
            generatedPlague = false;
            generatedStrain = false;
            grime = false;

            alloyBars = true;
            essenceBars = true;
            yharimBars = true;
            shimmerEssences = true;
            meldGunk = true;
            cosmislag = true;
            reargar = true;
            sidegar = true;
            frontgar = true;
            crocodile = true;
            permanenthealth = true;
            starbuster = true;
            plaguetoggle = true;
            shrinetoggle = true;
            lifeoretoggle = true;
            resprites = true;
            renames = true;
            bossdialogue = true;
            grimesandToggle = true;
            clowns = true;
            aspids = true;
            clamitas = true;
            wolfvenom = true;
            fearmonger = true;
            seafood = true;
            laruga = true;

            loadedRecipeInjections = false;

            transmogrifyingItem = -1;
            transmogrifyingItemAmt = 0;
            transmogrifyTimeLeft = 0;
            meldCountdown = 72000;
        }
        public override void OnWorldUnload()
        {
            downedDerellect = false;
            downedExcavator = false;
            downedEarth = false;

            downedLifeSlime = false;
            downedClamitas = false;
            downedCyberDraedon = false;
            downedOnyxKinsman = false;
            downedYggdrasilEnt = false;
            downedPlagueEmperor = false;
            downedLaRuga = false;
            downedKingMinnowsPrime = false;

            guideHasExisted = false;
            deusDeadInSnow = false;
            generatedCosmiliteSlag = false;
            generatedPlague = false;
            generatedStrain = false;

            alloyBars = true;
            essenceBars = true;
            yharimBars = true;

            alloyBars = true;
            essenceBars = true;
            yharimBars = true;
            shimmerEssences = true;
            meldGunk = true;
            cosmislag = true;
            reargar = true;
            sidegar = true;
            frontgar = true;
            crocodile = true;
            permanenthealth = true;
            starbuster = true;
            plaguetoggle = true;
            shrinetoggle = true;
            lifeoretoggle = true;
            resprites = true;
            renames = true;
            bossdialogue = true;
            grimesandToggle = true;
            clowns = true;
            aspids = true;
            clamitas = true;
            wolfvenom = true;
            fearmonger = true;
            seafood = true;
            laruga = true;

            loadedRecipeInjections = false;

            transmogrifyingItem = -1;
            transmogrifyingItemAmt = 0;
            transmogrifyTimeLeft = 0;
            meldCountdown = 72000;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            tag["downedDerellect"] = downedDerellect;
            tag["downedExcavator"] = downedExcavator;
            tag["downedEarth"] = downedEarth;

            tag["downedLifeSlime"] = downedLifeSlime;
            tag["downedClamitas"] = downedClamitas;
            tag["downedCyberDraedon"] = downedCyberDraedon;
            tag["downedOnyxKinsman"] = downedOnyxKinsman;
            tag["downedYggdrasilEnt"] = downedYggdrasilEnt;
            tag["downedPlagueEmperor"] = downedPlagueEmperor;
            tag["downedLaRuga"] = downedLaRuga;
            tag["downedKingMinnowsPrime"] = downedKingMinnowsPrime;

            tag["guideHasExisted"] = guideHasExisted;
            tag["deusDeadInSnow"] = deusDeadInSnow;
            tag["genSlag"] = generatedCosmiliteSlag;
            tag["plague"] = generatedPlague;
            tag["astrain"] = generatedStrain;
            tag["grime"] = grime;

            tag["109alloybar"] = alloyBars;
            tag["109essencebar"] = essenceBars;
            tag["109yharimbar"] = yharimBars;
            tag["109essenceshimmer"] = shimmerEssences;
            tag["109meldgunk"] = meldGunk;
            tag["109cosmilite"] = cosmislag;
            tag["109reargar"] = reargar;
            tag["109sidegar"] = sidegar;
            tag["109frontgar"] = frontgar;
            tag["109crocodile"] = crocodile;
            tag["109permanenthealth"] = permanenthealth;
            tag["109starbuster"] = starbuster;
            tag["109plague"] = plaguetoggle;
            tag["109shrine"] = shrinetoggle;
            tag["109lifeore"] = lifeoretoggle;
            tag["109resprites"] = resprites;
            tag["109renames"] = renames;
            tag["109dialogue"] = bossdialogue;
            tag["109grime"] = grimesandToggle;
            tag["109clowns"] = clowns;
            tag["109aspids"] = aspids;
            tag["109clamitas"] = clamitas;
            tag["109coyotevenom"] = wolfvenom;
            tag["109fearmonger"] = fearmonger;
            tag["109seafood"] = seafood;
            tag["109laruga"] = laruga;
            tag["109fanny"] = FannyManager.fannyEnabled;
            tag["109fannyfreeze"] = FannyManager.fannyTimesFrozen;

            tag["transmogrifyingItem"] = transmogrifyingItem;
            tag["transmogrifyingItemAmt"] = transmogrifyingItemAmt;
            tag["transmogrifyTimeLeft"] = transmogrifyTimeLeft;
            tag["meld"] = meldCountdown;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedDerellect = tag.Get<bool>("downedDerellect");
            downedExcavator = tag.Get<bool>("downedExcavator");
            downedEarth = tag.Get<bool>("downedEarth");



            downedLifeSlime = tag.Get<bool>("downedLifeSlime");
            downedClamitas = tag.Get<bool>("downedClamitas");
            downedCyberDraedon = tag.Get<bool>("downedCyberDraedon");
            downedOnyxKinsman = tag.Get<bool>("downedOnyxKinsman");
            downedYggdrasilEnt = tag.Get<bool>("downedYggdrasilEnt");
            downedPlagueEmperor = tag.Get<bool>("downedPlagueEmperor");
            downedLaRuga = tag.Get<bool>("downedLaRuga");
            downedKingMinnowsPrime = tag.Get<bool>("downedKingMinnowsPrime");


            guideHasExisted = tag.Get<bool>("guideHasExisted");
            deusDeadInSnow = tag.Get<bool>("deusDeadInSnow");
            generatedCosmiliteSlag = tag.Get<bool>("genSlag");
            generatedPlague = tag.Get<bool>("plague");
            generatedStrain = tag.Get<bool>("astrain");
            grime = tag.Get<bool>("grime");

            alloyBars = tag.Get<bool>("109alloybar");
            essenceBars = tag.Get<bool>("109essencebar");
            yharimBars = tag.Get<bool>("109yharimbar");
            shimmerEssences = tag.Get<bool>("109essenceshimmer");// = shimmerEssences;
            meldGunk = tag.Get<bool>("109meldgunk");// = meldGunk;
            cosmislag = tag.Get<bool>("109cosmilite");// = cosmislag;
            reargar = tag.Get<bool>("109reargar");// = reargar;
            sidegar = tag.Get<bool>("109sidegar");// = sidegar;
            frontgar = tag.Get<bool>("109frontgar");// = frontgar;
            crocodile = tag.Get<bool>("109crocodile");// = crocodile;
            permanenthealth= tag.Get<bool>("109permanenthealth");// = permanenthealth;
            starbuster= tag.Get<bool>("109starbuster");// = starbuster;
            plaguetoggle= tag.Get<bool>("109plague");// = plaguetoggle;
            shrinetoggle= tag.Get<bool>("109shrine");// = shrinetoggle;
            lifeoretoggle= tag.Get<bool>("109lifeore");// = lifeoretoggle;
            resprites= tag.Get<bool>("109resprites");// = resprites;
            renames = tag.Get<bool>("109resprites");// = renames;
            bossdialogue = tag.Get<bool>("109dialogue");// = bossdialogue;
            grimesandToggle= tag.Get<bool>("109grime");// = grimesand;
            clowns= tag.Get<bool>("109clowns");// = clowns;
            aspids= tag.Get<bool>("109aspids");// = aspids;
            clamitas= tag.Get<bool>("109clamitas");// = clamitas;
            wolfvenom= tag.Get<bool>("109coyotevenom");// = wolfvenom;
            fearmonger= tag.Get<bool>("109fearmonger");// = fearmonger;
            seafood= tag.Get<bool>("109seafood");// = seafood;
            laruga= tag.Get<bool>("109laruga");// = laruga;
            FannyManager.fannyEnabled = tag.Get<bool>("109fanny");

            transmogrifyingItem = tag.Get<int>("transmogrifyingItem");
            transmogrifyingItem = tag.Get<int>("transmogrifyingItemAmt");
            transmogrifyTimeLeft = tag.Get<int>("transmogrifyTimeLeft");
            meldCountdown = tag.Get<int>("meld");
            FannyManager.fannyTimesFrozen = tag.Get<int>("109fannyfreeze");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(downedDerellect);
            writer.Write(downedExcavator);
            writer.Write(downedEarth);
            writer.Write(guideHasExisted);
            writer.Write(deusDeadInSnow);
            writer.Write(generatedCosmiliteSlag);
            writer.Write(generatedPlague);
            writer.Write(generatedStrain);
            writer.Write(grime);

            writer.Write(alloyBars);
            writer.Write(essenceBars);
            writer.Write(yharimBars);
            writer.Write(shimmerEssences );//tag.Get<bool>("109essenceshimmer");;// );//shimmerEssences;
            writer.Write(meldGunk );//tag.Get<bool>("109meldgunk");;// );//meldGunk;
            writer.Write(cosmislag );//tag.Get<bool>("109cosmilite");;// );//cosmislag;
            writer.Write(reargar );//tag.Get<bool>("109reargar");;// );//reargar;
            writer.Write(sidegar );//tag.Get<bool>("109sidegar");;// );//sidegar;
            writer.Write(frontgar );//tag.Get<bool>("109frontgar");;// );//frontgar;
            writer.Write(crocodile );//tag.Get<bool>("109crocodile");;// );//crocodile;
            writer.Write(permanenthealth );//tag.Get<bool>("109permanenthealth");;// );//permanenthealth;
            writer.Write(starbuster );//tag.Get<bool>("109starbuster");;// );//starbuster;
            writer.Write(plaguetoggle );//tag.Get<bool>("109plague");;// );//plaguetoggle;
            writer.Write(shrinetoggle );//tag.Get<bool>("109shrine");;// );//shrinetoggle;
            writer.Write(lifeoretoggle );//tag.Get<bool>("109lifeore");;// );//lifeoretoggle;
            writer.Write(resprites );//tag.Get<bool>("109resprites");;// );//resprites;
            writer.Write(renames);//tag.Get<bool>("109renames");;// );//renames;
            writer.Write(bossdialogue );//tag.Get<bool>("109dialogue");;// );//bossdialogue;
            writer.Write(grimesandToggle );//tag.Get<bool>("109grime");;// );//grimesand;
            writer.Write(clowns );//tag.Get<bool>("109clowns");;// );//clowns;
            writer.Write(aspids );//tag.Get<bool>("109aspids");;// );//aspids;
            writer.Write(clamitas );//tag.Get<bool>("109clamitas");;// );//clamitas;
            writer.Write(wolfvenom );//tag.Get<bool>("109coyotevenom");;// );//wolfvenom;
            writer.Write(fearmonger );//tag.Get<bool>("109fearmonger");;// );//fearmonger;
            writer.Write(seafood );//tag.Get<bool>("109seafood");;// );//seafood;
            writer.Write(laruga );//tag.Get<bool>("109laruga");;// );//laruga;
            writer.Write(FannyManager.fannyEnabled);
            writer.Write(FannyManager.fannyTimesFrozen);
            writer.Write(Anomaly109Manager.helpUnlocked);

            writer.Write(transmogrifyingItem);
            writer.Write(transmogrifyingItemAmt);
            writer.Write(transmogrifyTimeLeft);
            writer.Write(meldCountdown);
        }

        public override void NetReceive(BinaryReader reader)
        {
            downedDerellect = reader.ReadBoolean();
            downedExcavator = reader.ReadBoolean();
            downedEarth = reader.ReadBoolean();

            downedLifeSlime = reader.ReadBoolean();
            downedClamitas = reader.ReadBoolean();
            downedCyberDraedon = reader.ReadBoolean();
            downedOnyxKinsman = reader.ReadBoolean();
            downedYggdrasilEnt = reader.ReadBoolean();
            downedPlagueEmperor = reader.ReadBoolean();
            downedLaRuga = reader.ReadBoolean();
            downedKingMinnowsPrime = reader.ReadBoolean();

            guideHasExisted = reader.ReadBoolean();
            deusDeadInSnow = reader.ReadBoolean();
            generatedCosmiliteSlag = reader.ReadBoolean();
            generatedPlague = reader.ReadBoolean();
            generatedStrain = reader.ReadBoolean();
            grime = reader.ReadBoolean();

            alloyBars = reader.ReadBoolean();
            essenceBars = reader.ReadBoolean();
            yharimBars = reader.ReadBoolean();
            shimmerEssences = reader.ReadBoolean();//.Get<bool>("109essenceshimmer");// = shimmerEssences;
            meldGunk = reader.ReadBoolean();//.Get<bool>("109meldgunk");// = meldGunk;
            cosmislag = reader.ReadBoolean();//.Get<bool>("109cosmilite");// = cosmislag;
            reargar = reader.ReadBoolean();//.Get<bool>("109reargar");// = reargar;
            sidegar = reader.ReadBoolean();//.Get<bool>("109sidegar");// = sidegar;
            frontgar = reader.ReadBoolean();//.Get<bool>("109frontgar");// = frontgar;
            crocodile = reader.ReadBoolean();//.Get<bool>("109crocodile");// = crocodile;
            permanenthealth = reader.ReadBoolean();//.Get<bool>("109permanenthealth");// = permanenthealth;
            starbuster = reader.ReadBoolean();//.Get<bool>("109starbuster");// = starbuster;
            plaguetoggle = reader.ReadBoolean();//.Get<bool>("109plague");// = plaguetoggle;
            shrinetoggle = reader.ReadBoolean();//.Get<bool>("109shrine");// = shrinetoggle;
            lifeoretoggle = reader.ReadBoolean();//.Get<bool>("109lifeore");// = lifeoretoggle;
            resprites = reader.ReadBoolean();//.Get<bool>("109resprites");// = resprites;
            renames = reader.ReadBoolean();//.Get<bool>("109renames");// = renames;
            bossdialogue = reader.ReadBoolean();//.Get<bool>("109dialogue");// = bossdialogue;
            grimesandToggle = reader.ReadBoolean();//.Get<bool>("109grime");// = grimesand;
            clowns = reader.ReadBoolean();//.Get<bool>("109clowns");// = clowns;
            aspids = reader.ReadBoolean();//.Get<bool>("109aspids");// = aspids;
            clamitas = reader.ReadBoolean();//.Get<bool>("109clamitas");// = clamitas;
            wolfvenom = reader.ReadBoolean();//.Get<bool>("109coyotevenom");// = wolfvenom;
            fearmonger = reader.ReadBoolean();//.Get<bool>("109fearmonger");// = fearmonger;
            seafood = reader.ReadBoolean();//.Get<bool>("109seafood");// = seafood;
            laruga = reader.ReadBoolean();//.Get<bool>("109laruga");// = laruga;
            FannyManager.fannyEnabled = reader.ReadBoolean();
            FannyManager.fannyTimesFrozen = reader.ReadInt32();
            Anomaly109Manager.helpUnlocked = reader.ReadBoolean();

            transmogrifyingItem = reader.ReadInt32();
            transmogrifyingItemAmt = reader.ReadInt32();
            transmogrifyTimeLeft = reader.ReadInt32();
            meldCountdown = reader.ReadInt32();
        }

        public static List<int> hallowlist = new List<int>
        {
            TileID.Pearlstone,
            TileID.HallowedIce,
            TileID.HallowHardenedSand,
            TileID.HallowSandstone
        };
        public static List<int> astrallist = new List<int>
        {
            ModContent.TileType<AstralStone>(),
            ModContent.TileType<AstralSandstone>(),
            ModContent.TileType<HardenedAstralSand>(),
            ModContent.TileType<CelestialRemains>(),
            ModContent.TileType<NovaeSlag>(),
            ModContent.TileType<AstralDirt>(),
            ModContent.TileType<AstralIce>(),
            ModContent.TileType<AstralSnow>(),
            ModContent.TileType<AstralGrass>(),
            TileType<AstralClay>(),
            TileType<AstralSand>(),
            TileType<AstralMonolith>(),
        };
        public override void PreUpdateWorld()
        {
            if (!loadedRecipeInjections)
            {
                if (reargar)
                {
                    RemoveLoot(ItemID.JungleFishingCrate, ItemType<CalamityMod.Items.Placeables.Ores.UelibloomOre>());
                    RemoveLoot(ItemID.JungleFishingCrate, ItemType<CalamityMod.Items.Materials.UelibloomBar>());
                    RemoveLoot(ItemID.JungleFishingCrateHard, ItemType<CalamityMod.Items.Placeables.Ores.UelibloomOre>());
                    RemoveLoot(ItemID.JungleFishingCrateHard, ItemType<CalamityMod.Items.Materials.UelibloomBar>());
                }
                if (frontgar)
                {
                    RemoveLoot(ItemType<SulphurousCrate>(), ItemType<ReaperTooth>());
                    RemoveLoot(NPCType<ReaperShark>(), ItemType<ReaperTooth>(), true);
                }
                if (cosmislag)
                {
                    RemoveLoot(NPCType<DevourerofGodsHead>(), ItemType<CosmiliteBar>(), true);
                }
                RemoveLoot(NPCType<DesertScourgeHead>(), ItemType<PearlShard>(), true);
                RemoveLoot(NPCType<Bumblefuck>(), ItemType<EffulgentFeather>(), true);
                Recipes.MassModifyIngredient(!yharimBars, Recipes.yharimBarCrafts);
                Recipes.MassModifyIngredient(!alloyBars, Recipes.alloyBarCrafts);
                Recipes.MassModifyIngredient(!essenceBars, Recipes.essenceBarCrafts);
                Recipes.MassModifyIngredient(!crocodile, Recipes.crocodileCrafts);
                Recipes.MassModifyIngredient(!wolfvenom, Recipes.venomCrafts);
                loadedRecipeInjections = true;
                //RemoveLoot(NPCType<DevourerofGodsHead>(), ItemType<PearlShard>(), true);
            }
        }
        public override void PostUpdateWorld()
        {
            if (meldCountdown > 0)
            {
                meldCountdown--;
            }
            if (aspids)
            {
                if (CalRemixGlobalNPC.aspidCount >= 20 && !DownedBossSystem.downedCryogen)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        NPC.SpawnOnPlayer(Main.myPlayer, NPCType<Cryogen>());
                    }
                    CalRemixGlobalNPC.aspidCount = 0;
                }
            }
            if (CalamityMod.World.CalamityWorld.spawnedCirrus)
            {
                CalamityMod.World.CalamityWorld.spawnedCirrus = false;
            }
            if (NPC.AnyNPCs(NPCID.Guide)) guideHasExisted = true;
            if (shrinetoggle)
            {
                if (ShrineTimer == 0)
                {
                    HMChest(TileID.CrystalBlock, TileID.CrystalBlock, WallID.Crystal, ModContent.ItemType<HallowEffigy>(), hallowlist, 21);
                    HMChest(ModContent.TileType<AstralMonolith>(), ModContent.TileType<AstralMonolith>(), ModContent.WallType<AstralMonolithWall>(), ModContent.ItemType<AstralEffigy>(), astrallist, 46);

                    Color messageColor = Color.Magenta;
                    CalamityUtils.DisplayLocalizedText("Shrines appear within the newly spread infections!", messageColor);
                }
            }
            if (ShrineTimer > -20)
            {
                ShrineTimer--;
            }
            if (cosmislag)
            {
                if (!generatedCosmiliteSlag)
                {
                    if (NPC.downedMoonlord)
                    {
                        if (CalamityWorld.HasGeneratedLuminitePlanetoids)
                        {
                            //ThreadPool.QueueUserWorkItem(_ => GenerateCosmiliteSlag());
                            GenerateCosmiliteSlag();
                        }
                    }
                }
            }
            if (plaguetoggle)
            {
                if (!generatedPlague && NPC.downedGolemBoss)
                {
                    ThreadPool.QueueUserWorkItem(_ => GeneratePlague(), this);
                }
            }
            //if (Main.LocalPlayer.HeldItem.type == ItemID.CopperAxe && Main.LocalPlayer.controlUseItem)
            if (meldGunk)
            {
                if (!generatedStrain && Main.hardMode)
                {
                    GenerateCavernStrain();
                    generatedStrain = true;
                    UpdateWorldBool();
                }
            }
            if (transmogrifyTimeLeft > 0) transmogrifyTimeLeft--;
            if (transmogrifyTimeLeft > 200) transmogrifyTimeLeft = 200;
        }

        public static void AddLootDynamically(int npcType, bool npc = false)
        {
            if (npc)
            {
                if (npcType == NPCType<ReaperShark>())
                {
                    var postPolter = new LeadingConditionRule(DropHelper.PostPolter());
                    postPolter.Add(ItemType<ReaperTooth>(), 1, 3, 4);
                    Terraria.Main.ItemDropsDB.RegisterToNPC(npcType, postPolter);
                }
            }
            else
            {
                if (npcType == ItemType<SulphurousCrate>())
                {
                    // dude i fucking FUCKING LOATHE drop code
                    var postDuke = new LeadingConditionRule(DropHelper.PostOD());
                    postDuke.Add(ItemType<ReaperTooth>(), 10, 1, 5);
                    var postPolter = new LeadingConditionRule(DropHelper.PostPolter()).OnSuccess(postDuke);
                    Terraria.Main.ItemDropsDB.RegisterToItem(npcType, postPolter);
                }
                if (npcType == ItemID.JungleFishingCrate)
                {
                    var postDuke = new LeadingConditionRule(DropHelper.PostProv());
                    postDuke.Add(ItemType<CalamityMod.Items.Placeables.Ores.UelibloomOre>(), 5, 16, 28);
                    postDuke.Add(ItemType<CalamityMod.Items.Materials.UelibloomBar>(), new Fraction(15, 100), 4, 7);
                    Terraria.Main.ItemDropsDB.RegisterToItem(npcType, postDuke);
                    Terraria.Main.ItemDropsDB.RegisterToItem(ItemID.JungleFishingCrateHard, postDuke);
                }
            }
        }
        public static void RemoveLoot(int bagType, int itemToRemove, bool npc = false)
        {
            List<IItemDropRule> JungleCrateDrops = npc ? Terraria.Main.ItemDropsDB.GetRulesForNPCID(bagType) : Terraria.Main.ItemDropsDB.GetRulesForItemID(bagType);
            for (int i = 0; i < JungleCrateDrops.Count; i++)
            {
                if (JungleCrateDrops[i] is LeadingConditionRule lead)
                {
                    for (int j = 0; j < lead.ChainedRules.Count; j++)
                    {
                        if (lead.ChainedRules[j] is Chains.TryIfSucceeded c)
                        {
                            if (c.RuleToChain is CommonDrop fuck)
                            {
                                if (fuck.itemId == itemToRemove)
                                {
                                    lead.ChainedRules.RemoveAt(j);
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void ResetNearbyTileEffects()
        {
            lifeTiles = 0;
            PlagueTiles = 0;
            PlagueDesertTiles = 0;
            MeldTiles = 0;
        }
        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            // Life Ore tiles
            lifeTiles = tileCounts[TileType<LifeOreTile>()];
            PlagueTiles = tileCounts[TileType<PlaguedGrass>()] +
            tileCounts[TileType<PlaguedMud>()] +
            tileCounts[TileType<PlaguedStone>()] +
            tileCounts[TileType<PlaguedClay>()] +
            tileCounts[TileType<OvergrownPlaguedStone>()] +
            tileCounts[TileType<PlaguedSilt>()] +
            tileCounts[TileType<Sporezol>()];
            PlagueDesertTiles = tileCounts[TileType<PlaguedSand>()];
            MeldTiles = tileCounts[TileType<MeldGunkPlaced>()];
            Main.SceneMetrics.JungleTileCount += PlagueTiles;
            Main.SceneMetrics.SandTileCount += PlagueDesertTiles;
        }
        public override void PostWorldGen()
        {
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    if (Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36 && DungeonWalls.Contains(Main.tile[chest.x, chest.y].WallType))
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.None)
                            {
                                if (Main.rand.NextBool(4))
                                {
                                    chest.item[inventoryIndex].SetDefaults(ItemType<BundleBones>());
                                    chest.item[inventoryIndex].stack = Main.rand.Next(10, 26);
                                }
                                break;
                            }
                        }
                    }
                    if (Main.tile[chest.x, chest.y].TileType == TileType<VoidChest>())
                    {
                        if (chest.item[0].type == ItemType<Terminus>())
                        {
                            chest.item[0].SetDefaults(ItemType<CalamityMod.Items.Placeables.Ores.ScoriaOre>());
                        }
                    }
                }
            }
        }

        public static void HMChest(int block1, int block2, int wall, int loot, List<int> anchor, int chest)
        {
            int x = Main.maxTilesX;
            int y = Main.maxTilesY;
            for (int k = 0; k < (int)(x * y * 100E-05); k++)
            {
                int tilesX = WorldGen.genRand.Next(0, x);
                int tilesY = WorldGen.genRand.Next((int)(y * 0.35f), (int)(y * 0.8f));

                if (anchor.Contains(Main.tile[tilesX, tilesY].TileType))
                {
                    UndergroundShrines.SpecialHut((ushort)block1, (ushort)Main.tile[tilesX, tilesY].TileType, (ushort)wall, UndergroundShrines.UndergroundShrineType.Surface, tilesX, tilesY);
                    for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
                    {
                        Chest cheste = Main.chest[chestIndex];
                        if (cheste != null && Main.tile[cheste.x, cheste.y].TileType == TileID.Containers && Main.tile[cheste.x, cheste.y + 2].TileType == block1)
                        {
                            if (block1 == TileID.CrystalBlock)
                            {
                                Main.tile[cheste.x, cheste.y].TileType = TileID.Containers2;
                                Main.tile[cheste.x + 1, cheste.y].TileType = TileID.Containers2;
                                Main.tile[cheste.x, cheste.y + 1].TileType = TileID.Containers2;
                                Main.tile[cheste.x + 1, cheste.y + 1].TileType = TileID.Containers2;
                            }
                            if (block1 == ModContent.TileType<AstralMonolith>())
                            {
                                Main.tile[cheste.x, cheste.y].TileType = (ushort)ModContent.TileType<MonolithChest>();
                                Main.tile[cheste.x + 1, cheste.y].TileType = (ushort)ModContent.TileType<MonolithChest>();
                                Main.tile[cheste.x, cheste.y + 1].TileType = (ushort)ModContent.TileType<MonolithChest>();
                                Main.tile[cheste.x + 1, cheste.y + 1].TileType = (ushort)ModContent.TileType<MonolithChest>();
                            }
                            cheste.item[0].SetDefaults(loot);
                        }
                    }
                    break;
                }
            }
        }


        public static void GenerateCosmiliteSlag()
        {
            CalamityMod.World.Planets.LuminitePlanet.GenerateLuminitePlanetoids(); // MORE
            int minCloud = 0;
            bool planetsexist = false;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = (int)(Main.maxTilesY * 0.6f); j > 0; j--)
                {
                    if (Main.tile[i, j].TileType == TileType<ExodiumOre>())
                    {
                        planetsexist = true;
                        minCloud = j;
                        break;
                    }
                    if (minCloud != 0)
                        break;
                }
            }
            bool cutitNOW = false;
            for (int loo = 0; loo < 200; loo++)
            {
                if (cutitNOW)
                {
                    break;
                }

                if (planetsexist)
                {
                    for (int i = 0; i < Main.maxTilesX; i++)
                    {
                        for (int j = 0; j < minCloud; j++)
                        {
                            if (Main.rand.NextBool(75))
                            {
                                if (Main.tile[i, j].TileType == TileID.LunarOre || Main.tile[i, j].TileType == TileType<ExodiumOre>())
                                {
                                    int planetradius = Main.rand.Next(4, 7);
                                    for (int p = i - planetradius; p < i + planetradius; p++)
                                    {
                                        for (int q = j - planetradius; q < j + planetradius; q++)
                                        {
                                            int dist = (p - i) * (p - i) + (q - j) * (q - j);
                                            if (dist > planetradius * planetradius)
                                                continue;

                                            if (WorldGen.InWorld(p, q, 1) && Main.tile[p, q].HasTile)
                                            {
                                                if (Main.tile[p, q].TileType == TileID.LunarOre || Main.tile[p, q].TileType == TileType<ExodiumOre>())
                                                {
                                                    Main.tile[p, q].TileType = (ushort)TileType<CosmiliteSlagPlaced>();

                                                    WorldGen.SquareTileFrame(p, q, true);
                                                    NetMessage.SendTileSquare(-1, p, q, 1);
                                                    cutitNOW = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (Main.rand.NextBool(222))
                            {
                                int planetradius = Main.rand.Next(2, 5);
                                if (Main.tile[i, j].TileType == TileID.Dirt || Main.tile[i, j].TileType == TileID.Stone || Main.tile[i, j].TileType == TileID.Grass || Terraria.ID.TileID.Sets.Ore[Main.tile[i, j].TileType])
                                {
                                    for (int p = i - planetradius; p < i + planetradius; p++)
                                    {
                                        for (int q = j - planetradius; q < j + planetradius; q++)
                                        {
                                            int dist = (p - i) * (p - i) + (q - j) * (q - j);
                                            if (dist > planetradius * planetradius)
                                                continue;

                                            if (WorldGen.InWorld(p, q, 1) && Main.tile[p, q].HasTile)
                                                if (Main.tile[p, q].TileType == TileID.Dirt || Main.tile[p, q].TileType == TileID.Stone || Main.tile[p, q].TileType == TileID.Grass || Terraria.ID.TileID.Sets.Ore[Main.tile[p, q].TileType])
                                                {
                                                    Main.tile[p, q].TileType = (ushort)ModContent.TileType<CosmiliteSlagPlaced>();

                                                    WorldGen.SquareTileFrame(p, q, true);
                                                    NetMessage.SendTileSquare(-1, p, q, 1);
                                                    cutitNOW = true;
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Color messageColor = Color.Magenta;
                    CalamityUtils.DisplayLocalizedText("Rifts materialize in the upper atmosphere...", messageColor);
                    generatedCosmiliteSlag = true;
                    UpdateWorldBool();
                }
            }
        }

        public static void GeneratePlague()
        {
            bool gennedplague = false;
            int plagueX = 0;
            int plagueY = 0;
            int plagueY2 = 0;
            if (CalamityWorld.JungleLabCenter != Vector2.Zero)
            {
                PlaguedSpray.Convert((int)(CalamityWorld.JungleLabCenter.X / 16), (int)(CalamityWorld.JungleLabCenter.Y / 16), 222 * (WorldGen.GetWorldSize() + 1));
                plagueX = (int)(CalamityWorld.JungleLabCenter.X / 16);
                plagueY = (int)(CalamityWorld.JungleLabCenter.Y / 16);
                gennedplague = true;
            }
            if (!gennedplague)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        if (Main.tile[i, j].TileType == TileID.Mud && Main.rand.NextBool(2222))
                        {
                            PlaguedSpray.Convert(i, j, 222 * (WorldGen.GetWorldSize() + 1));
                            plagueX = i;
                            plagueY = j;
                            gennedplague = true;
                            break;
                        }
                        if (gennedplague)
                        {
                            break;
                        }
                    }
                    if (gennedplague)
                    {
                        break;
                    }
                }
            }
            if (gennedplague)
            {
                for (int j = 100; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[plagueX, j].HasTile && !Main.tile[plagueX, j - 1].HasTile)
                    {
                        PlaguedSpray.Convert(plagueX, j, 111 * (WorldGen.GetWorldSize() + 1));
                        plagueY2 = j;
                        break;
                    }
                }
                for (int i = plagueX - 33 * (WorldGen.GetWorldSize() + 1); i < 33 * (WorldGen.GetWorldSize() + 1) + plagueX; i++)
                {
                    for (int j = plagueY2; j < plagueY; j++)
                    {
                        PlaguedSpray.Convert(i, j, 2);
                    }
                }
                generatedPlague = true;
            }
        }

        public static void GenerateCavernStrain()
        {
            int widthdiv2 = 16;
            int heightdiv2 = 22;
            bool gennedMeld = false;
            Vector2 meldCoords = Vector2.Zero;
            int ymin = Main.remixWorld ? (int)(Main.maxTilesY * 0.4f) : (int)(Main.maxTilesY * 0.6f);
            int ymax = Main.remixWorld ? (int)(Main.maxTilesY * 0.6f) : Main.UnderworldLayer - 100;
            for (int loop = 0; loop < 200; loop++)
            {
                if (gennedMeld)
                    break;
                for (int x = (int)(Main.maxTilesX * 0.2f); x < (Main.maxTilesX * 0.8f); x++)
                {
                    if (gennedMeld)
                        break;
                    if (x > Main.maxTilesX * 0.4f && x < Main.maxTilesX * 0.6f)
                        continue;
                    for (int y = ymin; y < ymax; y++)
                    {
                        if (gennedMeld)
                            break;
                        if (Main.rand.NextBool(2222222))
                        {
                            if (widthdiv2 * 2 > Main.maxTilesX - 100 || heightdiv2 * 2 > Main.maxTilesY - 100)
                                continue;
                            if (x - widthdiv2 < 100 || y - heightdiv2 < 100)
                                continue;
                            bool canGen = true;
                            for (int m = x - 100; m < x + 100; m++)
                            {
                                if (!canGen)
                                    break;
                                for (int n = y - 100; n < y + 100; n++)
                                {
                                    if (!canGen)
                                        break;
                                    Tile t = Main.tile[m, n];
                                    if (WorldGen.InWorld(m, n, 1))
                                    {
                                        if (t.TileType == TileID.StoneSlab || t.TileType == TileType<LaboratoryPlating>() || t.TileType == TileType<LaboratoryPanels>() || t.TileType == TileType<RustedPipes>() || TileID.Sets.IsAContainer[t.TileType] || TileID.Sets.AvoidedByMeteorLanding[t.TileType] || t.TileType == TileID.LihzahrdBrick || Terraria.Main.tileDungeon[t.TileType] || t.TileType == TileType<Navystone>() || t.TileType == TileID.JungleGrass)
                                        {
                                            canGen = false;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (canGen)
                            {
                                if (WorldGen.InWorld(x, y, 1))
                                {
                                    PlaceMeldHeart(x, y, 16, 22);
                                    meldCoords = new Vector2(x, y);
                                    gennedMeld = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (meldCoords != Vector2.Zero)
            {
                ThreadPool.QueueUserWorkItem(_ => AstralMeld(meldCoords));
                //AstralMeld(meldCoords);
            }

        }

        public static void AstralMeld(Vector2 meldCoords)
        {
            int planetradius = 56;
            for (int p = (int)meldCoords.X - planetradius; p < (int)meldCoords.X + planetradius; p++)
            {
                for (int q = (int)meldCoords.Y - planetradius; q < (int)meldCoords.Y + planetradius; q++)
                {
                    int dist = (p - (int)meldCoords.X) * (p - (int)meldCoords.X) + (q - (int)meldCoords.Y) * (q - (int)meldCoords.Y);
                    if (dist > planetradius * planetradius)
                        continue;

                    if (WorldGen.InWorld(p, q, 1) && Main.tile[p, q].HasTile)
                    {
                        AstralBiome.ConvertToAstral(p, q, true);
                    }
                }
            }
        }

        public static void PlaceMeldHeart(int x, int y, int width, int height)
        {
            // cut off at the top octagon
            for (int i = x - width; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (WorldGen.InWorld(i, j, 1) && Math.Abs(i - x) + Math.Abs(j - y) < Math.Sqrt(width * width + height * height))
                    {
                        if (WorldGen.CheckTileBreakability(i, j) == 0)
                        {
                            if (Main.tile[i, j].HasTile)
                            {
                                Main.tile[i, j].TileType = (ushort)TileType<MeldGunkPlaced>();
                                Main.tile[i, j].Get<TileWallWireStateData>().Slope = SlopeType.Solid;
                                Main.tile[i, j].Get<TileWallWireStateData>().IsHalfBlock = false;
                                Main.tile[i, j].ClearBlockPaintAndCoating();
                                Main.tile[i, j].LiquidAmount = 0;
                                WorldGen.SquareTileFrame(i, j, true);
                                NetMessage.SendTileSquare(-1, i, j, 1);
                            }
                            else
                            {
                                WorldGen.PlaceTile(i, j, TileType<MeldGunkPlaced>(), true, true);
                                WorldGen.SquareTileFrame(i, j, true);
                                NetMessage.SendTileSquare(-1, i, j, 1);
                            }
                        }
                    }
                }
            }
            RightTriangleGen(TileType<MeldGunkPlaced>(), x - width, y, (int)(width * 0.7f) * 2, (int)(height * 1.0f));
            RightTriangleGen(TileType<MeldGunkPlaced>(), x, y + (int)(height * 0.22f), (int)(width * 0.5f) * 2, (int)(height * 0.7f));
        }

        // at the moment this only supports a /| angled triangle
        public static void RightTriangleGen(int blockType, int x, int y, int width, int height)
        {
            float slope = -(float)height / (float)width;
            float b = y - slope * x;
            for (int i = x; i < x + width; i++)
            {
                for (int j = y - height; j < y; j++)
                {
                    if (j >= slope * i + b)
                    {
                        if (WorldGen.CheckTileBreakability(i, j) == 0)
                        {
                            if (Main.tile[i, j].HasTile)
                            {
                                Main.tile[i, j].TileType = (ushort)blockType;
                                Main.tile[i, j].Get<TileWallWireStateData>().Slope = SlopeType.Solid;
                                Main.tile[i, j].Get<TileWallWireStateData>().IsHalfBlock = false;
                                Main.tile[i, j].ClearBlockPaintAndCoating();
                                Main.tile[i, j].LiquidAmount = 0;
                                WorldGen.SquareTileFrame(i, j, true);
                                NetMessage.SendTileSquare(-1, i, j, 1);
                            }
                            else
                            {
                                WorldGen.PlaceTile(i, j, blockType, true, true);
                                WorldGen.SquareTileFrame(i, j, true);
                                NetMessage.SendTileSquare(-1, i, j, 1);
                            }
                        }
                    }
                }
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            if (Main.gameMenu)
            {
                return;
            }
            var player = Main.LocalPlayer;
            var pPlayer = player.GetModPlayer<CalRemixPlayer>();
            if (pPlayer.ZonePlague || pPlayer.ZonePlagueDesert)
            {
                float amount = 0.2f;
                if (PlagueSky.Intensity < 1f)
                {
                    float r = backgroundColor.R / 255f;
                    float g = backgroundColor.G / 255f;
                    float b = backgroundColor.B / 255f;
                    r = MathHelper.Lerp(r, amount, PlagueSky.Intensity);
                    g = MathHelper.Lerp(g, amount, PlagueSky.Intensity);
                    b = MathHelper.Lerp(b, amount, PlagueSky.Intensity);
                    backgroundColor.R = (byte)(int)(r * 255f);
                    backgroundColor.G = (byte)(int)(g * 255f);
                    backgroundColor.B = (byte)(int)(b * 255f);
                }
                else
                {
                    byte a = (byte)(int)(amount * 255f);
                    backgroundColor.R = 40;
                    backgroundColor.G = 40;
                    backgroundColor.B = 40;
                }
            }
        }
        public static bool IsTileFullySolid(int i, int j)
        {
            return IsTileFullySolid(Framing.GetTileSafely(i, j));
        }

        public static bool IsTileFullySolid(Tile tile)
        {
            return Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType];
        }
    }
}