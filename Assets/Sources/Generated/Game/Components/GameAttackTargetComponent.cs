//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.AttackTargetComponent attackTarget { get { return (GameScene.ECS.Components.AttackTargetComponent)GetComponent(GameComponentsLookup.AttackTarget); } }
    public bool hasAttackTarget { get { return HasComponent(GameComponentsLookup.AttackTarget); } }

    public void AddAttackTarget(GameEntity newValue) {
        var index = GameComponentsLookup.AttackTarget;
        var component = CreateComponent<GameScene.ECS.Components.AttackTargetComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttackTarget(GameEntity newValue) {
        var index = GameComponentsLookup.AttackTarget;
        var component = CreateComponent<GameScene.ECS.Components.AttackTargetComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackTarget() {
        RemoveComponent(GameComponentsLookup.AttackTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherAttackTarget;

    public static Entitas.IMatcher<GameEntity> AttackTarget {
        get {
            if (_matcherAttackTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackTarget = matcher;
            }

            return _matcherAttackTarget;
        }
    }
}
