//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.CreatureTypeComponent creatureType { get { return (GameScene.ECS.Components.CreatureTypeComponent)GetComponent(GameComponentsLookup.CreatureType); } }
    public bool hasCreatureType { get { return HasComponent(GameComponentsLookup.CreatureType); } }

    public void AddCreatureType(GameScene.ECS.Components.CreatureType newValue) {
        var index = GameComponentsLookup.CreatureType;
        var component = CreateComponent<GameScene.ECS.Components.CreatureTypeComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCreatureType(GameScene.ECS.Components.CreatureType newValue) {
        var index = GameComponentsLookup.CreatureType;
        var component = CreateComponent<GameScene.ECS.Components.CreatureTypeComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCreatureType() {
        RemoveComponent(GameComponentsLookup.CreatureType);
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

    static Entitas.IMatcher<GameEntity> _matcherCreatureType;

    public static Entitas.IMatcher<GameEntity> CreatureType {
        get {
            if (_matcherCreatureType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CreatureType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCreatureType = matcher;
            }

            return _matcherCreatureType;
        }
    }
}