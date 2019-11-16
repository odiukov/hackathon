//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LifeTimeListenerComponent lifeTimeListener { get { return (LifeTimeListenerComponent)GetComponent(GameComponentsLookup.LifeTimeListener); } }
    public bool hasLifeTimeListener { get { return HasComponent(GameComponentsLookup.LifeTimeListener); } }

    public void AddLifeTimeListener(System.Collections.Generic.List<ILifeTimeListener> newValue) {
        var index = GameComponentsLookup.LifeTimeListener;
        var component = CreateComponent<LifeTimeListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLifeTimeListener(System.Collections.Generic.List<ILifeTimeListener> newValue) {
        var index = GameComponentsLookup.LifeTimeListener;
        var component = CreateComponent<LifeTimeListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLifeTimeListener() {
        RemoveComponent(GameComponentsLookup.LifeTimeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherLifeTimeListener;

    public static Entitas.IMatcher<GameEntity> LifeTimeListener {
        get {
            if (_matcherLifeTimeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LifeTimeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLifeTimeListener = matcher;
            }

            return _matcherLifeTimeListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddLifeTimeListener(ILifeTimeListener value) {
        var listeners = hasLifeTimeListener
            ? lifeTimeListener.value
            : new System.Collections.Generic.List<ILifeTimeListener>();
        listeners.Add(value);
        ReplaceLifeTimeListener(listeners);
    }

    public void RemoveLifeTimeListener(ILifeTimeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = lifeTimeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLifeTimeListener();
        } else {
            ReplaceLifeTimeListener(listeners);
        }
    }
}