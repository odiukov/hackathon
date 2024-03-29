using System.Collections.Generic;
using Core.Contexts;
using Entitas;
using UnityEngine;

namespace GameScene.ECS.Systems
{
    public class CheckHPSystem : ReactiveSystem<GameEntity>
    {
        private IGameContext _context;
        public CheckHPSystem(IGameContext context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Damage.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHealth && entity.hasDamage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var newHealth = entity.health.Value - entity.damage.Value;
                newHealth = (newHealth <= entity.initialHealth.Value) ? newHealth : entity.initialHealth.Value;
                entity.ReplaceHealth(newHealth);
                entity.RemoveDamage();
                if (entity.health.Value <= 0) {
                    Object.Destroy(entity.view.Value);
                    entity.isDestroy = true;
                    if (entity.isPlayer)
                    {
                        _context.isEndGame = true;
                    }
                }
            }
        }
    }
}
