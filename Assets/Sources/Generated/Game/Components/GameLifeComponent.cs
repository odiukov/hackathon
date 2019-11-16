//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity lifeEntity { get { return GetGroup(GameMatcher.Life).GetSingleEntity(); } }
    public GameScene.ECS.Components.LifeComponent life { get { return lifeEntity.life; } }
    public bool hasLife { get { return lifeEntity != null; } }

    public GameEntity SetLife(int newValue) {
        if (hasLife) {
            throw new Entitas.EntitasException("Could not set Life!\n" + this + " already has an entity with GameScene.ECS.Components.LifeComponent!",
                "You should check if the context already has a lifeEntity before setting it or use context.ReplaceLife().");
        }
        var entity = CreateEntity();
        entity.AddLife(newValue);
        return entity;
    }

    public void ReplaceLife(int newValue) {
        var entity = lifeEntity;
        if (entity == null) {
            entity = SetLife(newValue);
        } else {
            entity.ReplaceLife(newValue);
        }
    }

    public void RemoveLife() {
        lifeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameScene.ECS.Components.LifeComponent life { get { return (GameScene.ECS.Components.LifeComponent)GetComponent(GameComponentsLookup.Life); } }
    public bool hasLife { get { return HasComponent(GameComponentsLookup.Life); } }

    public void AddLife(int newValue) {
        var index = GameComponentsLookup.Life;
        var component = CreateComponent<GameScene.ECS.Components.LifeComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLife(int newValue) {
        var index = GameComponentsLookup.Life;
        var component = CreateComponent<GameScene.ECS.Components.LifeComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLife() {
        RemoveComponent(GameComponentsLookup.Life);
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

    static Entitas.IMatcher<GameEntity> _matcherLife;

    public static Entitas.IMatcher<GameEntity> Life {
        get {
            if (_matcherLife == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Life);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLife = matcher;
            }

            return _matcherLife;
        }
    }
}