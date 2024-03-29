using System;
using System.Collections.Generic;
using Core.Contexts;
using GameScene.ECS.Components;
using GameScene.Utils;
using UnityEngine;

namespace GameScene.Factories
{
    public class MonsterFactory
    {
//        *** TODO white
//        1. statue -> human(hp + walking)
//            2. human -> warrior(+attack) or worker(+build)
//        3. warrior -> healer
//        4. worker -> prist
//            *** TODO black
//        1. statue -> skeleton(hp + walking + attack)
//        2. skeleton -> zombie(-attack +disease spell) or worker(-attack +build)
//        4. worker -> lich
//            ** TODO unit balances
//        1. White



//        4. Healer: 15 HP, +2 Heal on 3 radius
//        5. Prist: 20 HP, [create soul near house](10 seconds){30 seconds cooldown}
//        2. Black

//        2. Zombie: 10 HP, [human,worker -> skeleton](need to stay around 3 seconds)
//        3. Worker: 15 HP, [build house](10 seconds){30 seconds cooldown}
//        4. Lich: 20 HP, [create skeleton near house](10 seconds){30 seconds cooldown}

        private IGameContext _context;
        private Dictionary<CreatureType, Action<Vector3Int>> map;
        
        public MonsterFactory(IGameContext context)
        {
            _context = context;
            map = new Dictionary<CreatureType, Action<Vector3Int>>()
            {
                {CreatureType.Statue, CreateStatue},
                {CreatureType.Warrior, CreateWarrior},
                {CreatureType.WhiteBuilding, CreateWhiteBuilding},
                {CreatureType.BlackBuilding, CreateBlackBuilding},
                {CreatureType.Soul, CreateSoul},
                {CreatureType.Skeleton, CreateSkeleton},
            };
        }

        public void CreateWhiteBuilding(Vector3Int transformPosition)
        {
            var statue = _context.CreateEntity();
            statue.AddInitialHealth(20);
            statue.AddHealth(20);
            statue.AddResource(ResourceNames.WhiteBuilding);
            statue.AddCell(transformPosition);
            statue.AddCreatureType(CreatureType.WhiteBuilding);
            statue.AddReputation(2);
        }


        // 1. Human: 10 HP
        public void CreateHuman( Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Human);
            entity.AddCreatureType(CreatureType.Human);
            entity.AddInitialHealth(10);
            entity.AddHealth(10);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.isPhysic = true;
            entity.AddSpeed(1);
            entity.AddReputation(1);
        }

        // 2. Warrior: 10 HP, 4 Attack
        public void CreateWarrior(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Warrior);
            entity.AddCreatureType(CreatureType.Warrior);
            entity.AddInitialHealth(10);
            entity.AddHealth(10);
            entity.isPhysic = true;
            entity.AddSpeed(1);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(2);

            entity.AddAttackPower(4);
            entity.AddCalldown(2);
            entity.AddInitialCalldown(2);

            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.Black) != 0;
            });

        }

        // 3. Worker: 15 HP, [build house](10 seconds){30 seconds cooldown}
        public void CreateWorker(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Worker);
            entity.AddCreatureType(CreatureType.Worker);
            entity.AddInitialHealth(15);
            entity.AddHealth(15);
            entity.isPhysic = true;
            entity.AddSpeed(1f);

            entity.AddCreator(CreatureType.WhiteBuilding);
            entity.AddCalldown(10);
            entity.AddInitialCalldown(10);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(3);

            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.Position) != 0;
            });
        }

        // 4. Healer: 15 HP, +2 Heal on 3 radius{5 seconds cooldown}
        public void CreateHealer(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Healer);
            entity.AddCreatureType(CreatureType.Healer);
            entity.AddInitialHealth(15);
            entity.AddHealth(15);
            entity.isPhysic = true;
            entity.AddSpeed(1.5f);

            entity.AddHealPower(2);

            entity.AddInitialCalldown(2);
            entity.AddCalldown(2);
            entity.AddDistanceToTarget(3f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(3);

            entity.AddLookNearest(possibleTarget =>
            {
                var desired = CreatureType.Human | CreatureType.Warrior | CreatureType.Worker |  CreatureType.Priest;
                return (possibleTarget.creatureType.Value & desired) != 0;
            });
        }

        // 1. Skeleton: 8 HP, 4 Attack
        public void CreateSkeleton(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Skeleton);
            entity.AddCreatureType(CreatureType.Skeleton);
            entity.AddInitialHealth(8);
            entity.AddHealth(8);
            entity.isPhysic = true;
            entity.AddSpeed(1);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);

            entity.AddAttackPower(2);
            entity.AddCalldown(2);
            entity.AddInitialCalldown(2);
            entity.AddReputation(-2);


            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.White) != 0;
            });
        }

        public void Create(CreatureType creatureType, Vector3Int position)
        {
            if (map.ContainsKey(creatureType))
            {
                map[creatureType].Invoke(position);
            }
        }

        public void CreateStatue(Vector3Int transformPosition)
        {
            var statue = _context.CreateEntity();
            statue.AddResource(ResourceNames.Statue);
            statue.AddCell(transformPosition);
            statue.AddCreatureType(CreatureType.Statue);
            statue.AddReputation(1);
        }

        public void CreateSoul(Vector3Int position)
        {
            var soul = _context.CreateEntity();
            soul.AddResource(ResourceNames.Soul);
            soul.AddCell(position);
            soul.AddCreatureType(CreatureType.Soul);
            soul.isPhysic = true;
            soul.AddSpeed(3);
            soul.isSoul = true;
            soul.AddDistanceToTarget(1f);
            soul.AddLookNearest(possibleTarget =>
            {
                var desired = CreatureType.Human |
                              CreatureType.Warrior |
                              CreatureType.Worker |
                              CreatureType.BlackStatue |
                              CreatureType.Skeleton |
                              CreatureType.BlackWorker;
                if ((((possibleTarget.creatureType.Value & desired) != 0) &&
                     possibleTarget.hasUpgradeCooldown &&
                     (possibleTarget.upgradeCooldown.Value <= 0)) ||
                    (((possibleTarget.creatureType.Value & CreatureType.Statue) != 0) ||
                     ((possibleTarget.creatureType.Value & CreatureType.BlackStatue) != 0)))
                {
                    return true;
                } else
                {
                    return false;
                }
            });
        }

        // 5. Prist: 20 HP, [create soul near house](10 seconds){30 seconds cooldown}
        public void CreatePrist(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Priest);
            entity.AddCreatureType(CreatureType.Priest);
            entity.AddInitialHealth(20);
            entity.AddHealth(20);
            entity.isPhysic = true;
            entity.AddSpeed(1.5f);

            entity.AddCreator(CreatureType.Soul);

            entity.AddCalldown(4);
            entity.AddInitialCalldown(4);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(4);

            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.WhiteBuilding) != 0;
            });
        }

        public void CreateBlackWorker(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.BlackWorker);
            entity.AddCreatureType(CreatureType.BlackWorker);
            entity.AddInitialHealth(15);
            entity.AddHealth(15);
            entity.isPhysic = true;
            entity.AddSpeed(1.5f);

            entity.AddCreator(CreatureType.BlackBuilding);

            entity.AddCalldown(20);
            entity.AddInitialCalldown(20);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(-3);

            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.Position) != 0;
            });
        }

        public void CreateZombie(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Zombie);
            entity.AddCreatureType(CreatureType.Zombie);
            entity.AddInitialHealth(10);
            entity.AddHealth(10);
            entity.isPhysic = true;
            entity.AddSpeed(1);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);

            entity.AddZombieTimer(3);
            entity.AddCalldown(3);
            entity.AddInitialCalldown(3);
            entity.AddReputation(-2);

            entity.AddLookNearest(possibleTarget =>
            {
                var desired = CreatureType.Human | CreatureType.Worker;
                return (possibleTarget.creatureType.Value & desired) != 0;
            });
        }

        public void CreateLich(Vector3Int position)
        {
            var entity = _context.CreateEntity();
            entity.AddCell(position);
            entity.AddResource(ResourceNames.Lich);
            entity.AddCreatureType(CreatureType.Lich);
            entity.AddInitialHealth(20);
            entity.AddHealth(20);
            entity.isPhysic = true;
            entity.AddSpeed(1.5f);

            entity.AddCreator(CreatureType.Skeleton);

            entity.AddCalldown(4);
            entity.AddInitialCalldown(4);
            entity.AddDistanceToTarget(1f);
            entity.AddUpgradeCooldown(Settings.DefaultUpgradeCooldownSeconds);
            entity.AddReputation(-4);

            entity.AddLookNearest(possibleTarget =>
            {
                return (possibleTarget.creatureType.Value & CreatureType.BlackBuilding) != 0;
            });
        }

        public void CreateBlackStatue(Vector3Int transformPosition)
        {
            var statue = _context.CreateEntity();
            statue.AddResource(ResourceNames.BlackStatue);
            statue.AddCell(transformPosition);
            statue.AddCreatureType(CreatureType.BlackStatue);
            statue.AddReputation(-1);
        }

        public void CreatePosition(Vector3Int transformPosition)
        {
            var statue = _context.CreateEntity();
            statue.AddResource(ResourceNames.Position);
            statue.AddCell(transformPosition);
            statue.AddCreatureType(CreatureType.Position);
        }

        public void CreateBlackBuilding(Vector3Int transformPosition)
        {
            var statue = _context.CreateEntity();

            statue.AddInitialHealth(20);
            statue.AddHealth(20);

            statue.AddResource(ResourceNames.BlackBuilding);
            statue.AddCell(transformPosition);
            statue.AddCreatureType(CreatureType.BlackBuilding);
            statue.AddReputation(-2);
        }
    }
}

[Flags]
public enum CreatureType
{
    Soul = 1,
    Statue = 1 << 1 ,
    Human = 1 << 2,
    Warrior = 1 << 3,
    Worker= 1 << 4,
    Healer= 1 << 5,
    Priest = 1 << 6,
    Skeleton = 1 << 7,
    Zombie = 1 << 8,
    EvilWorker = 1 << 9,
    Lich = 1 << 10,
    BlackStatue = 1 << 11,
    BlackWorker = 1 << 12,
    WhiteBuilding = 1 << 13,
    BlackBuilding = 1 << 14,
    Position = 1 << 15,
    White = Human | Warrior | Worker | Healer | Priest | WhiteBuilding ,
    Black = Skeleton | Lich | Zombie | BlackWorker | BlackBuilding,
    Building = Statue | BlackStatue | WhiteBuilding | BlackBuilding | Position
}
