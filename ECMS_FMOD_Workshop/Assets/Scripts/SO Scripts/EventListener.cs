using UnityEngine;
using UnityEngine.Events;



public abstract class EventListener<T> : MonoBehaviour {
    [SerializeField] EventChannel<T> eventChannel;
    [SerializeField] UnityEvent<T> unityEvent;

    protected void OnEnable() {
        eventChannel.Register(this);
    }
        
    protected void OnDisable() {
        eventChannel.Deregister(this);
    }
        
    public void Raise(T value) {
        unityEvent?.Invoke(value);
    }
        
}
public class EventListener : EventListener<Empty> {}