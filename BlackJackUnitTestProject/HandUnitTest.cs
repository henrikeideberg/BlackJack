using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class HandUnitTest
    {
        //Define the test object
        BlackJack.Hand m_hand;

        public HandUnitTest()
        {
            //Nothing in the constructor for now
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void Setup()
        {
            int handId = 1;
            m_hand = new BlackJack.Hand(handId);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_hand = null;
        }

        [TestMethod]
        public void TestHandValue_OneAce()
        {
            //Add one ace
            m_hand.AddCardToHand(1);

            //Verify that there are two values
            Assert.AreEqual(2, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(1, m_hand.GetHandValue()[0]);
            Assert.AreEqual(11, m_hand.GetHandValue()[1]);

            //Verify HandToString
            Assert.AreEqual("A", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("1/11", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_TwoAce()
        {
            //Add cards
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);

            //Verify that there are two values
            Assert.AreEqual(2, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(2, m_hand.GetHandValue()[0]);
            Assert.AreEqual(12, m_hand.GetHandValue()[1]);

            //Verify HandToString
            Assert.AreEqual("A/A", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("2/12", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_Twenty()
        {
            //Add cards
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(9);

            //Verify that there are two values
            Assert.AreEqual(2, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(10, m_hand.GetHandValue()[0]);
            Assert.AreEqual(20, m_hand.GetHandValue()[1]);

            //Verify HandToString
            Assert.AreEqual("A/9", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("10/20", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_Twentyone()
        {
            //Add cards
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(10);

            //Verify that there are two values
            Assert.AreEqual(2, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(11, m_hand.GetHandValue()[0]);
            Assert.AreEqual(21, m_hand.GetHandValue()[1]);

            //Verify HandToString
            Assert.AreEqual("A/10", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("11/21", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_TwentytwoNoAce()
        {
            //Add cards
            m_hand.AddCardToHand(5);
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(7);

            //Verify that there is one value
            Assert.AreEqual(1, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(22, m_hand.GetHandValue()[0]);

            //Verify HandToString
            Assert.AreEqual("5/10/7", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("22", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_TwentytwoAce()
        {
            //Add cards
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(5);
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(6);

            //Verify that there is one value
            Assert.AreEqual(1, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(22, m_hand.GetHandValue()[0]);

            //Verify HandToString
            Assert.AreEqual("A/5/10/6", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("22", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestHandValue_Twelve()
        {
            //Add cards
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(10);

            //Verify that there is one value
            Assert.AreEqual(1, m_hand.GetHandValue().Count);

            //Verify values
            Assert.AreEqual(12, m_hand.GetHandValue()[0]);

            //Verify HandToString
            Assert.AreEqual("A/A/10", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("12", m_hand.HandValueToString());
        }

        [TestMethod]
        public void TestNoHand()
        {
            //Do not add any cards

            //Verify that there is one value (created in the instansiations)
            Assert.AreEqual(1, m_hand.GetHandValue().Count);

            //Verify initial value
            Assert.AreEqual(0, m_hand.GetHandValue()[0]);

            //Verify HandToString
            Assert.AreEqual("", m_hand.HandToString());

            //Very HandValueToString
            Assert.AreEqual("0", m_hand.HandValueToString());
        }
    }
}
