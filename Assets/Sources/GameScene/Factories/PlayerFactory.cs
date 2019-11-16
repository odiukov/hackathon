using Core.Contexts;

namespace SpaceWars.GameScene.Factories
{
    public interface IPlayerFactory
    {
        GameEntity CreatePlayer(IGameContext context);
    }
    
    public class PlayerFactory : IPlayerFactory
    {
        public GameEntity CreatePlayer(IGameContext context)
        {
            var playerEntity = context.CreateEntity();
            playerEntity.isPlayer = true;
            playerEntity.isPhysic = true;
            playerEntity.isAnimated = true;
            //TODO: load parameter from configs
            playerEntity.AddSpeed(5f);
            //TODO: load parameter from configs
            playerEntity.AddResource("Player");
            return playerEntity;
        }
    }
}