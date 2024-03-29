//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.CalldownComponent calldown { get { return (GameScene.ECS.Components.CalldownComponent)GetComponent(GameComponentsLookup.Calldown); } }
    public bool hasCalldown { get { return HasComponent(GameComponentsLookup.Calldown); } }

    public void AddCalldown(float newValue) {
        var index = GameComponentsLookup.Calldown;
        var component = CreateComponent<GameScene.ECS.Components.CalldownComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCalldown(float newValue) {
        var index = GameComponentsLookup.Calldown;
        var component = CreateComponent<GameScene.ECS.Components.CalldownComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCalldown() {
        RemoveComponent(GameComponentsLookup.Calldown);
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

    static Entitas.IMatcher<GameEntity> _matcherCalldown;

    public static Entitas.IMatcher<GameEntity> Calldown {
        get {
            if (_matcherCalldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Calldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCalldown = matcher;
            }

            return _matcherCalldown;
        }
    }
}
