//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.HealPowerComponent healPower { get { return (GameScene.ECS.Components.HealPowerComponent)GetComponent(GameComponentsLookup.HealPower); } }
    public bool hasHealPower { get { return HasComponent(GameComponentsLookup.HealPower); } }

    public void AddHealPower(int newValue) {
        var index = GameComponentsLookup.HealPower;
        var component = CreateComponent<GameScene.ECS.Components.HealPowerComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHealPower(int newValue) {
        var index = GameComponentsLookup.HealPower;
        var component = CreateComponent<GameScene.ECS.Components.HealPowerComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHealPower() {
        RemoveComponent(GameComponentsLookup.HealPower);
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

    static Entitas.IMatcher<GameEntity> _matcherHealPower;

    public static Entitas.IMatcher<GameEntity> HealPower {
        get {
            if (_matcherHealPower == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HealPower);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealPower = matcher;
            }

            return _matcherHealPower;
        }
    }
}
