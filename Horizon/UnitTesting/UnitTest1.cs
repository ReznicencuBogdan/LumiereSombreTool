using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var LumiereSomForm = new LumiereServer.LumiereServer();
            LumiereSomForm.debugMessage("Welcome", 2);
        }

        public void DatabaseTest() {
            var database = new LumiereServer.DatabaseUsers();
            var clientInstance = new LumiereServer.ClientInstance(null);
            clientInstance.ip = "127.0.0.1";
            clientInstance.usrdescriptor = new LumiereServer.MPacketUserDescriptor.userdescriptor();
            clientInstance.usrdescriptor.user_name = "testing_name";

            database.registerNewUser(clientInstance);

            Debug.Assert(database.isUserRegistered(clientInstance.ip));

            database.blackListUser(clientInstance.ip);

            Debug.Assert(database.isUserBlacklisted(clientInstance.ip));

            database.removeFromBlacklist(clientInstance.ip);

            Debug.Assert(!database.isUserBlacklisted(clientInstance.ip));
        }

    }
}
