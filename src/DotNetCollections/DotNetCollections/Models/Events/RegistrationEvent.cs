namespace DotNetCollections.Models.Events;

public class RegistrationEvent : PlayerEvent
{
  public override EventType EventType => EventType.Registration;
}