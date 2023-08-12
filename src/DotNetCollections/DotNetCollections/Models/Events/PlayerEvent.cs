namespace DotNetCollections;

public abstract class PlayerEvent
{
  public Guid UserId { get; set; } = Guid.NewGuid();

  public DateTime EventDateTimeUtc { get; set; } = DateTime.UtcNow;

  public abstract EventType EventType { get; }
}