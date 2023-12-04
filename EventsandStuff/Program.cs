using EventsandStuff;
using System.Runtime.CompilerServices;

var eventstore = new EventStoreLOL();
await AddAndReadEvents();


async Task AddAndReadEvents()
{
    await Task.Factory.StartNew(async () =>
    {
        await eventstore.AddEvent();
    });
    await Task.Factory.StartNew(async () =>
    {
        await eventstore.ReadEvent();
    }); ;
}
