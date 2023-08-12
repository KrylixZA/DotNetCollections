// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using BenchmarkDotNet.Running;
using Bogus;
using DotNetCollections;
using DotNetCollections.Models.Events;

var regEvents = new Faker<RegistrationEvent>().Generate(10);
var loginEvents = new Faker<LoginEvent>().Generate(50);
var gamePlayEvents = new Faker<GamePlayEvent>().Generate(200);

// List processor
//var listPlayerBufferProcessor = new ListPlayerBufferProcessor();
//foreach(var registrationEvent in regEvents)
//{
//  listPlayerBufferProcessor.ProcessRegistrationEvent(registrationEvent);
//}
//foreach(var loginEvent in loginEvents)
//{
//  listPlayerBufferProcessor.ProcessLoginEvent(loginEvent);
//}
//foreach(var gamePlayEvent in gamePlayEvents)
//{
//  listPlayerBufferProcessor.ProcessGamePlayEvent(gamePlayEvent);
//}
//var listBuffer = listPlayerBufferProcessor.GetPlayerBuffer();
//Console.WriteLine(JsonSerializer.Serialize(listBuffer));

//// Queue processor
//var queuePlayerBufferProcess = new QueuePlayerBufferProcessor();
//foreach (var registrationEvent in regEvents)
//{
//  queuePlayerBufferProcess.ProcessRegistrationEvent(registrationEvent);
//}
//foreach (var loginEvent in loginEvents)
//{
//  queuePlayerBufferProcess.ProcessLoginEvent(loginEvent);
//}
//foreach (var gamePlayEvent in gamePlayEvents)
//{
//  queuePlayerBufferProcess.ProcessGamePlayEvent(gamePlayEvent);
//}
//var queueBuffer = queuePlayerBufferProcess.GetPlayerBuffer();
//Console.WriteLine(JsonSerializer.Serialize(queueBuffer));

BenchmarkRunner.Run<PlayerEventProcessorBenchmarks>();


/* TODO: Write benchmark tests for the following scenario
** 1. Use queue over list with takelast
** 2. Use foreach and dequeue 
*/