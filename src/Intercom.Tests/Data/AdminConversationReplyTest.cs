using Intercom.Clients;
using Intercom.Core;
using Intercom.Data;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Intercom.Test
{
    [TestFixture]
    public class AdminConversationReplyTest : TestBase
    {
        [Test]
        public async Task AdminConversationReply()
        {
            var mock = BuildMockClient<AdminConversationsClient, Conversation>(HttpStatusCode.OK, "Conversation.json", new Authentication(AppId, AppKey));

            var convo = await mock.Reply(new AdminConversationReply("147", "25", "comment", "We noticed you using our Product,  do you have any questions?"));

            Assert.IsNotNull(convo);
            Assert.IsTrue(convo.conversation_message.body.Contains("We noticed you using our Product"));
        }

        [Test]
        public async Task ListAdminConversations()
        {
            var mock = BuildSuccessMockClient<AdminConversationsClient, Conversation>("ConversationsList.json", new Authentication(AppId, AppKey));

            var convo = await mock.List(new Admin() { id = "394051" });

            Assert.IsNotNull(convo);
            Assert.AreEqual(1, convo.conversations.Count);
        }
    }
}