using Core.Contexts;
using Entitas;
using GameScene.ECS.Utils;
using GameScene.Factories;

namespace GameScene.ECS.Systems
{
    public sealed class InitSystem : IInitializeSystem
    {
        private readonly IGameContext _context;
        private readonly IPlayerFactory _playerFactory;
        private readonly IBoxFactory _boxFactory;
        private readonly RandomPositionGenerator _positionGenerator;
        
        public InitSystem(IGameContext context, IPlayerFactory playerFactory, IBoxFactory boxFactory, RandomPositionGenerator positionGenerator)
        {
            _context = context;
            _playerFactory = playerFactory;
            _boxFactory = boxFactory;
            _positionGenerator = positionGenerator;
        }
        
        public void Initialize()
        {
            _playerFactory.CreatePlayer(_context);

            for (var i = 0; i < 5; i++)
            {
                _boxFactory.CreateEntity(_context, _positionGenerator.RandomPosition());
            }
        }
    }
}