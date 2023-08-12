using DotNetCollections.Models.Events;

namespace DotNetCollections;

public class PlayerBuffer
{
  public IEnumerable<RegistrationEvent> Registrations { get; set; } = Enumerable.Empty<RegistrationEvent>();
  public IEnumerable<LoginEvent> Logins { get; set; } = Enumerable.Empty<LoginEvent>();
  public IEnumerable<GamePlayEvent> GamePlays { get; set; } = Enumerable.Empty<GamePlayEvent>();
}

public class ListPlayerBuffer
{
  public List<RegistrationEvent> Registrations { get; set; } = new List<RegistrationEvent>();
  public List<LoginEvent> Logins { get; set; } = new List<LoginEvent>();
  public List<GamePlayEvent> GamePlays { get; set; } = new List<GamePlayEvent>();
}

public class QueuePlayerBuffer
{
  public Queue<RegistrationEvent> Registrations { get; set; } = new Queue<RegistrationEvent>();
  public Queue<LoginEvent> Logins { get; set; } = new Queue<LoginEvent>();
  public Queue<GamePlayEvent> GamePlays { get; set; } = new Queue<GamePlayEvent>();
}