using System;

namespace CloudComputingLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteLab1();
            ExecuteLab2();
            ExecuteLab3();
        }

        static void ExecuteLab1()
        {
            var lab1 = new Lab1();
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8};

            var result = lab1.PureSum(array);

            Console.WriteLine(result); // 36
        }

        static void ExecuteLab2()
        {
            var lab2 = new Lab2();
            var array = new [] {"aaaaaaa", "bbb", "b", "b", "aaa", "ccccccccc", "aaaaaaaaaa", "qqqqqqqqqqqqqqqqq", "q"};

            var result = lab2.PureFilter(array);

            foreach (var s in result)
            {
                Console.Write($"\"{s}\", ");
            }
        }

        static void ExecuteLab3()
        {
            var eventsRepository = new EventsRepository();
            var eventBus = new EventBus();

            eventBus.Subscribe(eventsRepository, "First event",
                () => { Console.WriteLine("First event is executing."); });
            var eventActionId = eventBus.Subscribe(eventsRepository, "First event",
                () => { Console.WriteLine("Still running..."); });
            eventBus.Subscribe(eventsRepository, "Second event",
                () => { Console.WriteLine("Second event is executing."); });
            
            eventBus.ExecuteEvent(eventsRepository, "First event");
            
            eventBus.Unsubscribe(eventsRepository, "First event", eventActionId);
            
            eventBus.ExecuteAll(eventsRepository);
        }
    }
}
