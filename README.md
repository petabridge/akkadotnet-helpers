# Akka.NET Helpers
![Akka.NET Logo](akka_net_logo.png)

This repo is a library of Akka.NET helper classes and design patterns to assist with common production needs.

## Helpers & Patterns
### Shared ActorPaths
The "Shared ActorPaths" pattern is a simple way to reduce errors with `ActorSelection`s, usually due to fat-fingering `ActorPath`s.

Best practice is to store the `ActorPath`s in this public static class so that other parts of your code can reference it easily, and you don't have dangling references and hard-to-track down errors when you change an `ActorPath`. Or hardcode one in wrong.

This pattern should be used in conjunction with the following "Actor MetaData" pattern.

[See the "Shared ActorPaths" example code here.](/AkkaHelpers/ActorPaths.cs)

### Actor MetaData
The "Actor MetaData" pattern is a simple way to add extra information which makes the "Shared ActorPaths" pattern much more useful. This enables you to store metadata about an actor path, letting you easily retrieve the actors name, `ActorPath`, and parent, even when you don't have a handle to an actor (e.g. don't have an `IActorRef`).

[See the "Actor MetaData" example code here.](/AkkaHelpers/ActorMetaData.cs)




***
![Petabridge Logo](petabridge_logo.png)

Copyright 2015 Petabridge, LLC
