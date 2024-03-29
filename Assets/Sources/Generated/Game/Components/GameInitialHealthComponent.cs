//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.InitialHealthComponent initialHealth { get { return (GameScene.ECS.Components.InitialHealthComponent)GetComponent(GameComponentsLookup.InitialHealth); } }
    public bool hasInitialHealth { get { return HasComponent(GameComponentsLookup.InitialHealth); } }

    public void AddInitialHealth(int newValue) {
        var index = GameComponentsLookup.InitialHealth;
        var component = CreateComponent<GameScene.ECS.Components.InitialHealthComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInitialHealth(int newValue) {
        var index = GameComponentsLookup.InitialHealth;
        var component = CreateComponent<GameScene.ECS.Components.InitialHealthComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInitialHealth() {
        RemoveComponent(GameComponentsLookup.InitialHealth);
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

    static Entitas.IMatcher<GameEntity> _matcherInitialHealth;

    public static Entitas.IMatcher<GameEntity> InitialHealth {
        get {
            if (_matcherInitialHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitialHealth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitialHealth = matcher;
            }

            return _matcherInitialHealth;
        }
    }
}
