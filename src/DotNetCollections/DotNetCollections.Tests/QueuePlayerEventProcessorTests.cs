using Bogus;
using DotNetCollections.Models.Events;
using FluentAssertions;
using NUnit.Framework;

namespace DotNetCollections.Tests;

[TestFixture]
public class QueuePlayerEventProcessorTests
{
  [Test]
  public void GivenTenRegistrationEventsAndOnlyOneToKeep_WhenProcessingEvents_ThenShouldKeepLastRegistrationEvent()
  {
    // Arrange
    var regEvents = new Faker<RegistrationEvent>().Generate(10);
    var expectedRegEvent = regEvents.Last();
    var sut = new QueuePlayerBufferProcessor();

    // Act
    foreach (var regEvent in regEvents)
    {
      sut.ProcessRegistrationEvent(regEvent);
    }

    // Assert
    sut.PlayerBuffer.Registrations.Count.Should().Be(1);
    sut.PlayerBuffer.Registrations.First().Should().BeEquivalentTo(expectedRegEvent);
  }

  [Test]
  public void GivenFiftyLoginEventsAndOnlyTenToKeep_WhenProcessingEvents_ThenShouldKeepLastTenLoginEvents()
  {
    // Arrange
    var loginEvents = new Faker<LoginEvent>().Generate(50);
    var expectedLogins = loginEvents.TakeLast(10);
    var sut = new ListPlayerBufferProcessor();

    // Act
    foreach (var loginEvent in loginEvents)
    {
      sut.ProcessLoginEvent(loginEvent);
    }

    // Assert
    sut.PlayerBuffer.Logins.Count.Should().Be(10);
    sut.PlayerBuffer.Logins.Should().BeEquivalentTo(expectedLogins);
  }

  [Test]
  public void GivenTwoHundredGamePlayEventsAndOnlyFiftyToKeep_WhenProcessingEvents_ThenShouldKeepLastFiftyGamePlayEvents()
  {
    // Arrange
    var gamePlayEvents = new Faker<GamePlayEvent>().Generate(200);
    var expectedGamePlayEvents = gamePlayEvents.TakeLast(50);
    var sut = new ListPlayerBufferProcessor();

    // Act
    foreach (var gamePlayEvent in gamePlayEvents)
    {
      sut.ProcessGamePlayEvent(gamePlayEvent);
    }

    // Assert
    sut.PlayerBuffer.GamePlays.Count.Should().Be(50);
    sut.PlayerBuffer.GamePlays.Should().BeEquivalentTo(expectedGamePlayEvents);
  }
}