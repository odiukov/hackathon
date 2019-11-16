//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class LifeTimerEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ILifeTimerListener> _listenerBuffer;

    public LifeTimerEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ILifeTimerListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.LifeTimer)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasLifeTimer && entity.hasLifeTimerListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.lifeTimer;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.lifeTimerListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnLifeTimer(e, component.Value);
            }
        }
    }
}