using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using Reface.EventBus;

namespace Reface.AppStarter.UnitTestsTests.Listeners
{
    [Listener]
    public class SetOne : IEventListener<AppStartedEvent>
    {
        public void Handle(AppStartedEvent @event)
        {
            @event.App.Context["VALUE"] = 1;
        }
    }
}
