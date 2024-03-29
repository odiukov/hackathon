//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.DistanceToTargetComponent distanceToTarget { get { return (GameScene.ECS.Components.DistanceToTargetComponent)GetComponent(GameComponentsLookup.DistanceToTarget); } }
    public bool hasDistanceToTarget { get { return HasComponent(GameComponentsLookup.DistanceToTarget); } }

    public void AddDistanceToTarget(float newValue) {
        var index = GameComponentsLookup.DistanceToTarget;
        var component = CreateComponent<GameScene.ECS.Components.DistanceToTargetComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDistanceToTarget(float newValue) {
        var index = GameComponentsLookup.DistanceToTarget;
        var component = CreateComponent<GameScene.ECS.Components.DistanceToTargetComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDistanceToTarget() {
        RemoveComponent(GameComponentsLookup.DistanceToTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherDistanceToTarget;

    public static Entitas.IMatcher<GameEntity> DistanceToTarget {
        get {
            if (_matcherDistanceToTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DistanceToTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDistanceToTarget = matcher;
            }

            return _matcherDistanceToTarget;
        }
    }
}
