namespace DotNetCollections.Models.Events;

public class LoginEvent : PlayerEvent
{
  public override EventType EventType => EventType.Login;
}