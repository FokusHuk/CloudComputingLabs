using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudComputingLabs
{
    public class EventsRepository
    {
        public readonly List<Event> Events;

        public EventsRepository()
        {
            Events = new List<Event>();
        }
    }

    public class Event
    {
        public string Name { get; }
        public List<EventAction> Actions { get; }

        public Event(string name)
        {
            Name = name;
            Actions = new List<EventAction>();
        }
    }

    public class EventAction
    {
        public Guid Id { get; }
        public Action Action { get; }

        public EventAction(Guid id, Action action)
        {
            Id = id;
            Action = action;
        }
    }

    public class EventBus
    {
        public Guid Subscribe(EventsRepository repository, string eventName, Action action)
        {
            var newActionId = Guid.NewGuid();

            if (!repository.Events.Exists(e => e.Name == eventName))
                repository.Events.Add(new Event(eventName));

            repository
                .Events
                .First(e => e.Name == eventName)
                .Actions
                .Add(new EventAction(newActionId, action));

            return newActionId;
        }

        public void Unsubscribe(EventsRepository repository, string eventName, Guid actionId)
        {
            var requiredEvent = repository.Events.First(e => e.Name == eventName);
            requiredEvent.Actions.Remove(requiredEvent.Actions.First(e => e.Id == actionId));
            if (!requiredEvent.Actions.Any())
                repository.Events.Remove(requiredEvent);
        }

        public void ExecuteEvent(EventsRepository repository, string eventName)
        {
            var requiredEvent = repository.Events.First(e => e.Name == eventName);
            ShowEventExecutingMessage(requiredEvent);
            foreach (var action in requiredEvent.Actions)
            {
                action.Action();
            }
        }
        
        public void ExecuteEvent(Event @event)
        {
            ShowEventExecutingMessage(@event);
            foreach (var action in @event.Actions)
            {
                action.Action();
            }
        }

        public void ExecuteAll(EventsRepository repository)
        {
            foreach (var @event in repository.Events)
            {
                ShowEventExecutingMessage(@event);
                foreach (var action in @event.Actions)
                {
                    action.Action();
                }
            }
        }

        private void ShowEventExecutingMessage(Event @event)
        {
            Console.WriteLine($"\n[Event \"{@event.Name}\" is running.]");
        }
    }
}
