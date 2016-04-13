using System;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TelevisionTests
    {
        private Device _television;
        private Remote _remote;

        public TelevisionTests()
        {
            var code = Guid.NewGuid().ToString();
            _television = new Television(code);
            _remote = new Remote(_television);
        }

        [TestMethod]
        public void should_turn_channel_up()
        {
            var currentChannel = _television.CurrentChannel;

            _remote.ChannelUp();

            Assert.AreEqual(++currentChannel, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_turn_channel_down()
        {
            _television.CurrentChannel = 100;

            var currentChannel = _television.CurrentChannel;

            _remote.ChannelDown();

            Assert.AreEqual(--currentChannel, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_not_turn_channel_down_below_0()
        {
            _television.CurrentChannel = 0;

            _remote.ChannelDown();

            Assert.AreEqual(0, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_turn_television_off_if_on()
        {
            _television.TurnedOn = true;

            _remote.Power();

            Assert.IsFalse(_television.TurnedOn);
        }

        [TestMethod]
        public void should_turn_television_on_if_off()
        {
            _television.TurnedOn = false;

            _remote.Power();

            Assert.IsTrue(_television.TurnedOn);
        }

        [TestMethod]
        public void should_go_to_specified_channel()
        {
            _television.CurrentChannel = 100;

            _remote.GoToChannel(50);

            Assert.AreEqual(50, _television.CurrentChannel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidChannelException))]
        public void should_throw_exception_if_negative_number()
        {
            _television.CurrentChannel = 100;

            _remote.GoToChannel(-100);
        }

        [TestMethod]
        public void should_not_respond_to_unknown_remote()
        {
            _television = new Television(Guid.NewGuid().ToString());

            _television.CurrentChannel = 100;

            _remote.GoToChannel(50);

            Assert.AreEqual(100, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_allow_manual_up()
        {
            _television.CurrentChannel = 100;

            (_television as Television).ManualChannelUp();

            Assert.AreEqual(101, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_allow_manual_down()
        {
            _television.CurrentChannel = 100;

            (_television as Television).ManualChannelDown();

            Assert.AreEqual(99, _television.CurrentChannel);
        }

        [TestMethod]
        public void should_allow_manual_off()
        {
            _television.TurnedOn = true;

            (_television as Television).ManualPower();

            Assert.IsFalse(_television.TurnedOn);
        }

        [TestMethod]
        public void should_allow_manual_on()
        {
            _television.TurnedOn = false;

            (_television as Television).ManualPower();

            Assert.IsTrue(_television.TurnedOn);
        }
    }
}
