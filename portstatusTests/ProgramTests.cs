using NSubstitute;
using NUnit.Framework;
using portstatus;
using Assert = NUnit.Framework.Assert;

namespace portstatusTests
{
    [TestFixture]
    public class ProgramTests
    {


        [SetUp]
        public void Setup()
        {

           }

        [Test]
        public void GetPortStatusStringTest_NOTLISTENING()
        {
           
            var _subjectNetworking = Substitute.ForPartsOf<Networking>();
            _subjectNetworking.When(x => x.IsTcpPortConnected(Arg.Is(9999))).DoNotCallBase();
_subjectNetworking.IsTcpPortConnected(9999).Returns(false);
            _subjectNetworking.When(x => x.IsTcpPortListening(Arg.Is(9999))).DoNotCallBase();
_subjectNetworking.IsTcpPortListening(9999).Returns(false);
            //arrange
            
            

            var expected = PortStatusType.NotListening;
            //act
            var actual = _subjectNetworking.GetPortStatusString(9999);
            //assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void GetPortStatusStringTest_LISTENING()
        {
            var _subjectNetworking = Substitute.ForPartsOf<Networking>();
            _subjectNetworking.When(x => x.IsTcpPortConnected(9999)).DoNotCallBase();
            _subjectNetworking.When(x => x.IsTcpPortListening(9999)).DoNotCallBase();

            //arrange
            _subjectNetworking.IsTcpPortConnected(9999).Returns(false);
            _subjectNetworking.IsTcpPortListening(9999).Returns(true);
            var expected = PortStatusType.Listening;
            //act
            var actual = _subjectNetworking.GetPortStatusString(9999);
            //assert
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void GetPortStatusStringTest_ESTABLISHED()
        {
            var _subjectNetworking = Substitute.ForPartsOf<Networking>();
            _subjectNetworking.When(x => x.IsTcpPortConnected(9999)).DoNotCallBase();
            _subjectNetworking.When(x => x.IsTcpPortListening(9999)).DoNotCallBase();

            _subjectNetworking.IsTcpPortConnected(9999).Returns(true);
            _subjectNetworking.IsTcpPortListening(9999).Returns(false);
            var expected = PortStatusType.Established;
            //act
            var actual = _subjectNetworking.GetPortStatusString(9999);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}