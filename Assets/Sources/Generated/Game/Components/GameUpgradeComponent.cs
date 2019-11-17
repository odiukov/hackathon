//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.UpgradeComponent upgrade { get { return (GameScene.ECS.Components.UpgradeComponent)GetComponent(GameComponentsLookup.Upgrade); } }
    public bool hasUpgrade { get { return HasComponent(GameComponentsLookup.Upgrade); } }

    public void AddUpgrade(GameEntity newEntity) {
        var index = GameComponentsLookup.Upgrade;
        var component = CreateComponent<GameScene.ECS.Components.UpgradeComponent>(index);
        component.Entity = newEntity;
        AddComponent(index, component);
    }

    public void ReplaceUpgrade(GameEntity newEntity) {
        var index = GameComponentsLookup.Upgrade;
        var component = CreateComponent<GameScene.ECS.Components.UpgradeComponent>(index);
        component.Entity = newEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveUpgrade() {
        RemoveComponent(GameComponentsLookup.Upgrade);
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

    static Entitas.IMatcher<GameEntity> _matcherUpgrade;

    public static Entitas.IMatcher<GameEntity> Upgrade {
        get {
            if (_matcherUpgrade == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Upgrade);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUpgrade = matcher;
            }

            return _matcherUpgrade;
        }
    }
}