//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly GameScene.ECS.Components.CreateSoulComponent createSoulComponent = new GameScene.ECS.Components.CreateSoulComponent();

    public bool isCreateSoul {
        get { return HasComponent(GameComponentsLookup.CreateSoul); }
        set {
            if (value != isCreateSoul) {
                var index = GameComponentsLookup.CreateSoul;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : createSoulComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherCreateSoul;

    public static Entitas.IMatcher<GameEntity> CreateSoul {
        get {
            if (_matcherCreateSoul == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CreateSoul);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCreateSoul = matcher;
            }

            return _matcherCreateSoul;
        }
    }
}
