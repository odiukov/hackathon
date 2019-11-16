using System.Collections.Generic;
using Core.Contexts;
using GameScene.ECS.Components;
using GameScene.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.View
{
    public class SoulView : MonoBehaviour, IView
    {
        private IGameContext _context;
        private GameEntity _entity;

        class CreatureInfo
        {
            public CreatureType CreatureType;
            public string CreatureName;

            public CreatureInfo(CreatureType creatureType, string creatureName)
            {
                CreatureType = creatureType;
                CreatureName = creatureName;
            }
        }
        
        private List<CreatureInfo> soulPlusStatue = new List<CreatureInfo>()
        {
            new CreatureInfo(CreatureType.Human, ResourceNames.Human),
            new CreatureInfo(CreatureType.Skeleton,ResourceNames.Skeleton),
            new CreatureInfo(CreatureType.Zombie,ResourceNames.Zombie)
        };
        public void Link(IGameContext context, GameEntity entity)
        {
            _context = context;
            _entity = entity;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Statue")) return;

            var statueEntity = other.gameObject.GetComponent<StatueView>();
            Clear(statueEntity);

            var rndIndex = Random.Range(0, soulPlusStatue.Count);
            
            CreateMob(other.transform.position, soulPlusStatue[rndIndex]);
        }

        private void CreateMob(Vector2 position, CreatureInfo creatureInfo)
        {
            var entity = _context.CreateEntity();
            entity.AddInitialPosition(position);
            entity.AddResource(creatureInfo.CreatureName);
            entity.AddCreatureType(creatureInfo.CreatureType);
            entity.AddHealth(10);
        }

        private void Clear(StatueView statueEntity)
        {
            statueEntity.Entity.isDestroy = true;
            _entity.isDestroy = true;
            Destroy(statueEntity.gameObject);
            Destroy(gameObject);
        }
    }
}