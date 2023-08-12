using BenchmarkDotNet.Attributes;
using Bogus;
using DotNetCollections.Models.Events;

namespace DotNetCollections;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
[RankColumn]
public class PlayerEventProcessorBenchmarks
{
  private readonly IEnumerable<RegistrationEvent> _regEvents;
  private readonly IEnumerable<LoginEvent> _loginEvents;
  private readonly IEnumerable<GamePlayEvent> _gamePlayEvents;
  private readonly ListPlayerBufferProcessor _listPlayerBufferProcessor;
  private readonly QueuePlayerBufferProcessor _queuePlayerBufferProcessor;

  public PlayerEventProcessorBenchmarks()
  {
    _regEvents = new Faker<RegistrationEvent>().Generate(10);
    _loginEvents = new Faker<LoginEvent>().Generate(50);
    _gamePlayEvents = new Faker<GamePlayEvent>().Generate(200);
    _listPlayerBufferProcessor = new ListPlayerBufferProcessor();
    _queuePlayerBufferProcessor = new QueuePlayerBufferProcessor();
  }

  [Benchmark]
  public void HandlePlayerEventUsingLists()
  {
    foreach(var regEvent in _regEvents)
    {
      _listPlayerBufferProcessor.ProcessRegistrationEvent(regEvent);
    }
    foreach(var loginEvent in _loginEvents)
    {
      _listPlayerBufferProcessor.ProcessLoginEvent(loginEvent);
    }
    foreach(var gamePlayEvent in _gamePlayEvents)
    {
      _listPlayerBufferProcessor.ProcessGamePlayEvent(gamePlayEvent);
    }
  }

  [Benchmark]
  public void HandlePlayerEventsUsingQueues()
  {
    foreach (var regEvent in _regEvents)
    {
      _queuePlayerBufferProcessor.ProcessRegistrationEvent(regEvent);
    }
    foreach (var loginEvent in _loginEvents)
    {
      _queuePlayerBufferProcessor.ProcessLoginEvent(loginEvent);
    }
    foreach (var gamePlayEvent in _gamePlayEvents)
    {
      _queuePlayerBufferProcessor.ProcessGamePlayEvent(gamePlayEvent);
    }
  }

  [Benchmark]
  public void GetPlayerBufferFromListsUsingTakeLast()
  {
    _listPlayerBufferProcessor.GetPlayerBuffer();
  }

  [Benchmark]
  public void GetPlayerBufferFromQueuesUsingTake()
  {
    _queuePlayerBufferProcessor.GetPlayerBuffer();
  }
}