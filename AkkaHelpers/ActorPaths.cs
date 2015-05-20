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
