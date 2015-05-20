# Akka.NET Helpers
![Akka.NET Logo](akka_net_logo.png)

This repo is a library of Akka.NET helper classes and design patterns to assist with common production needs.

## Helpers & Patterns
### Shared ActorPaths
The "Shared ActorPaths" pattern is a simple way to reduce errors with `ActorSelection`s, usually due to fat-fingering `ActorPath`s.

Best practice is to store the `ActorPath`s in this public static class so that other parts of your code can reference it easily, and you don't have dangling references and hard-to-track down errors when you change an `ActorPath`. Or hardcode one in wrong.

For example, we can define the `ActorPath`s that we need to reference in one place and then use them without having to fat-finger the addresses in. This leads to **fewer errors and easier changes**:

```csharp
using Akka.Actor;

namespace AkkaHelpers
{
    /// <summary>
    /// Static helper class used to define paths to fixed-name actors
    /// (helps eliminate errors when using <see cref="ActorSelection"/>)
    /// </summary>
    public static class ActorPaths
    {
        public static readonly ActorMetaData AuthenticatorActor = new ActorMetaData("authenticator");
        public static readonly ActorMetaData FormActor = new ActorMetaData("mainform");
        public static readonly ActorMetaData ValidatorActor = new ActorMetaData("validator", AuthenticatorActor);
        public static readonly ActorMetaData NestedValidatorActor = new ActorMetaData("childValidator", ValidatorActor);
    }
}
```

...and we can then get access to the `ActorPath` we need for an `ActorSelection` like so:

```csharp
Context.ActorSelection(ActorPaths.AuthenticatorActor.Path).Tell(message);
```

#### ***This pattern should be used in conjunction with the following "Actor MetaData" pattern.***

[See the "Shared ActorPaths" example code here.](/AkkaHelpers/ActorPaths.cs)

### Actor MetaData
The "Actor MetaData" pattern is a simple way to add extra information which makes the "Shared ActorPaths" pattern much more useful. This enables you to store metadata about an actor path, letting you easily retrieve the actors name, `ActorPath`, and parent, even when you don't have a handle to an actor (e.g. don't have an `IActorRef`).

For example:

```csharp
using Akka.Actor;

namespace AkkaHelpers
{
    /// <summary>
    /// Meta-data class. Nested/child actors can build path
    /// based on their parent(s) / position in hierarchy.
    /// </summary>
    public class ActorMetaData
    {
        public ActorMetaData(string name, ActorMetaData parent = null)
        {
            Name = name;
            Parent = parent;
            // if no parent, we assume a top-level actor
            var parentPath = parent != null ? parent.Path : "/user";
            Path = string.Format("{0}/{1}", parentPath, Name);
        }

        public string Name { get; private set; }

        public ActorMetaData Parent { get; set; }

        public string Path { get; private set; }
    }
}
```

[See the "Actor MetaData" example code here.](/AkkaHelpers/ActorMetaData.cs)
<br><br>


## About Petabridge

![Petabridge logo](petabridge_logo.png)

[Petabridge](https://petabridge.com/) is a company dedicated to making it easier for .NET developers to build distributed applications.

Petabridge provides Akka.NET consulting and training, including advanced training in [Akka.Remote](https://petabridge.com/training/akka-remoting/), [Akka.Cluster](https://petabridge.com/training/akka-clustering/), and [Akka.NET Design Patterns](https://petabridge.com/training/akka-design-patterns/)!

---
Copyright 2015 Petabridge, LLC
