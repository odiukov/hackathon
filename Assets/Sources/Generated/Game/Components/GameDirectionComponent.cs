//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.DirectionComponent direction { get { return (GameScene.ECS.Components.DirectionComponent)GetComponent(GameComponentsLookup.Direction); } }
    public bool hasDirection { get { return HasComponent(GameComponentsLookup.Direction); } }

    public void AddDirection(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = CreateComponent<GameScene.ECS.Components.DirectionComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDirection(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = CreateComponent<GameScene.ECS.Components.DirectionComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDirection() {
        RemoveComponent(GameComponentsLookup.Direction);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDirection;

    public static Entitas.IMatcher<GameEntity> Direction {
        get {
            if (_matcherDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Direction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDirection = matcher;
            }

            return _matcherDirection;
        }
    }
}
