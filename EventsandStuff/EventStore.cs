using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace EventsandStuff
{
    internal class EventStoreLOL
    {
        EventStoreClient Client { get; set; }
        List<EventData> Events { get; set; }   
        

        public EventStoreLOL()
        {
            Events = new List<EventData>(); 
            InitConnection();
        }

        public async Task AddEvent()
        {
            var userEvent = new UserRegisteredEvent(0, "Bjarne", true);
            var datastring = JsonSerializer.Serialize(userEvent);
            var data = Encoding.UTF8.GetBytes(datastring);

            var evt = new EventData(Uuid.NewUuid(), "testEvent",data);
            Events.Add(evt);

            var res = await Client.AppendToStreamAsync("test-stream", StreamState.Any, Events,null,TimeSpan.MaxValue);
        }

        public async Task ReadEvent()
        {
            var streamEvents = Client.ReadStreamAsync(Direction.Forwards, "test-stream", StreamPosition.Start);
            var returnedEvent = await streamEvents.ToListAsync();



            Console.WriteLine(
                
            );
        }

        public void InitConnection()
        {
            
            var settings = EventStoreClientSettings.Create("esdb://admin:changeit@localhost:1113");
            settings.DefaultDeadline = TimeSpan.MaxValue;
            Client = new EventStoreClient(settings);
           
        }
    }
}
