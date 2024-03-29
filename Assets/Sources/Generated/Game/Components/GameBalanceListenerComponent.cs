//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BalanceListenerComponent balanceListener { get { return (BalanceListenerComponent)GetComponent(GameComponentsLookup.BalanceListener); } }
    public bool hasBalanceListener { get { return HasComponent(GameComponentsLookup.BalanceListener); } }

    public void AddBalanceListener(System.Collections.Generic.List<IBalanceListener> newValue) {
        var index = GameComponentsLookup.BalanceListener;
        var component = CreateComponent<BalanceListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBalanceListener(System.Collections.Generic.List<IBalanceListener> newValue) {
        var index = GameComponentsLookup.BalanceListener;
        var component = CreateComponent<BalanceListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBalanceListener() {
        RemoveComponent(GameComponentsLookup.BalanceListener);
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

    static Entitas.IMatcher<GameEntity> _matcherBalanceListener;

    public static Entitas.IMatcher<GameEntity> BalanceListener {
        get {
            if (_matcherBalanceListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BalanceListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBalanceListener = matcher;
            }

            return _matcherBalanceListener;
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

    public void AddBalanceListener(IBalanceListener value) {
        var listeners = hasBalanceListener
            ? balanceListener.value
            : new System.Collections.Generic.List<IBalanceListener>();
        listeners.Add(value);
        ReplaceBalanceListener(listeners);
    }

    public void RemoveBalanceListener(IBalanceListener value, bool removeComponentWhenEmpty = true) {
        var listeners = balanceListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveBalanceListener();
        } else {
            ReplaceBalanceListener(listeners);
        }
    }
}
