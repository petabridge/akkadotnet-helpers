using NUnit.Framework;

namespace AkkaHelpers.Tests
{
    [TestFixture]
    public class ActorMetadataTests
    {
        [Test]
        public void ActorMetadata_should_return_name()
        {
            var actor = ActorPaths.AuthenticatorActor;
            var expectedName = "authenticator";
            Assert.AreEqual(actor.Name, expectedName);
        }

        [Test]
        public void ActorMetadata_top_level_actor_should_return_top_level_actor_path()
        {
            var actor = ActorPaths.FormActor; // top-level actor
            var expectedPath = "/user/mainform";
            Assert.AreEqual(actor.Path, expectedPath);
        }

        [Test]
        public void ActorMetadata_nested_actor_should_return_nested_actor_path()
        {
            var actor = ActorPaths.ValidatorActor;
            var expectedPath = "/user/authenticator/validator";
            Assert.AreEqual(actor.Path, expectedPath);

            var nestedActor = ActorPaths.NestedValidatorActor;
            var expectedPath2 = "/user/authenticator/validator/childValidator";
            Assert.AreEqual(nestedActor.Path, expectedPath2);
        }

        [Test]
        public void ActorMetadata_child_actor_should_know_parent()
        {
            var actor = ActorPaths.ValidatorActor;
            var parent = ActorPaths.AuthenticatorActor;
            Assert.AreEqual(actor.Parent, parent);
        }
    }
}
