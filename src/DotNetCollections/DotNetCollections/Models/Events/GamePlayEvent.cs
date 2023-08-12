namespace DotNetCollections.Models.Events;

public class GamePlayEvent : PlayerEvent
{
  public override EventType EventType => EventType.GamePlay;
}