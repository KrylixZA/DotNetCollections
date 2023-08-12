using DotNetCollections.Models.Events;

namespace DotNetCollections;

public interface IPlayerEventProcessor
{
  void ProcessRegistrationEvent(RegistrationEvent registrationEvent);
  void ProcessLoginEvent(LoginEvent loginEvent);
  void ProcessGamePlayEvent(GamePlayEvent gamePlayEvent);
  PlayerBuffer GetPlayerBuffer(int numOfRegEvents = 1, int numOfLoginEvents = 2, int numOfGamePlayEvents = 10);
}

public class ListPlayerBufferProcessor : IPlayerEventProcessor
{
  private const int NumOfRegEventsToKeep = 1;
  private const int NumOfLoginEventsToKeep = 10;
  private const int NumOfGamePlayEventsToKeep = 50;

  // This is generally bad practice but I want to assert the correctness of the buffer from tests
  public readonly ListPlayerBuffer PlayerBuffer;

  public ListPlayerBufferProcessor()
  {
    PlayerBuffer = new ListPlayerBuffer();
  }

  public void ProcessRegistrationEvent(RegistrationEvent registrationEvent)
  {
    PlayerBuffer.Registrations.Add(registrationEvent);
    if (PlayerBuffer.Registrations.Count > NumOfRegEventsToKeep)
    {
      PlayerBuffer.Registrations.RemoveAt(0);
    }
  }

  public void ProcessLoginEvent(LoginEvent loginEvent)
  {
    PlayerBuffer.Logins.Add(loginEvent);
    if (PlayerBuffer.Logins.Count > NumOfLoginEventsToKeep)
    {
      PlayerBuffer.Logins.RemoveAt(0);
    }
  }

  public void ProcessGamePlayEvent(GamePlayEvent gamePlayEvent)
  {
    PlayerBuffer.GamePlays.Add(gamePlayEvent);
    if (PlayerBuffer.GamePlays.Count > NumOfGamePlayEventsToKeep)
    {
      PlayerBuffer.GamePlays.RemoveAt(0);
    }
  }

  public PlayerBuffer GetPlayerBuffer(int numOfRegEvents = 1, int numOfLoginEvents = 2, int numOfGamePlayEvents = 10)
  {
    return new PlayerBuffer
    {
      Registrations = PlayerBuffer.Registrations.TakeLast(numOfRegEvents),
      Logins = PlayerBuffer.Logins.TakeLast(numOfLoginEvents),
      GamePlays = PlayerBuffer.GamePlays.TakeLast(numOfGamePlayEvents)
    };
  }
}

public class QueuePlayerBufferProcessor : IPlayerEventProcessor
{
  private const int NumOfRegEventsToKeep = 1;
  private const int NumOfLoginEventsToKeep = 10;
  private const int NumOfGamePlayEventsToKeep = 50;

  // This is generally bad practice but I want to assert the correctness of the buffer from tests
  public readonly QueuePlayerBuffer PlayerBuffer;

  public QueuePlayerBufferProcessor()
  {
    PlayerBuffer = new QueuePlayerBuffer();
  }

  public void ProcessRegistrationEvent(RegistrationEvent registrationEvent)
  {
    PlayerBuffer.Registrations.Enqueue(registrationEvent);
    if (PlayerBuffer.Registrations.Count > NumOfRegEventsToKeep)
    {
      PlayerBuffer.Registrations.Dequeue();
    }
  }

  public void ProcessLoginEvent(LoginEvent loginEvent)
  {
    PlayerBuffer.Logins.Enqueue(loginEvent);
    if (PlayerBuffer.Logins.Count > NumOfLoginEventsToKeep)
    {
      PlayerBuffer.Logins.Dequeue();
    }
  }

  public void ProcessGamePlayEvent(GamePlayEvent gamePlayEvent)
  {
    PlayerBuffer.GamePlays.Enqueue(gamePlayEvent);
    if (PlayerBuffer.GamePlays.Count > NumOfGamePlayEventsToKeep)
    {
      PlayerBuffer.GamePlays.Dequeue();
    }
  }

  public PlayerBuffer GetPlayerBuffer(int numOfRegEvents = 1, int numOfLoginEvents = 2, int numOfGamePlayEvents = 10)
  {
    return new PlayerBuffer
    {
      Registrations = PlayerBuffer.Registrations.Take(numOfRegEvents),
      Logins = PlayerBuffer.Logins.Take(numOfLoginEvents),
      GamePlays = PlayerBuffer.GamePlays.Take(numOfGamePlayEvents)
    };
  }
}