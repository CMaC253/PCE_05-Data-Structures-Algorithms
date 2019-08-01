using System;
using System.IO;
using NUnit.Framework;

/*
 * This file contains all the tests that will be run.
 * 
 * If you want to find out what a test does (or why it's failing), look in here
 * 
 */

namespace PCE_StarterProject
{
    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_LL_InsertAt 
    {
        LinkedList_Verifier LL;

        [SetUp]
        protected void SetUp()
        {
            LL = new LinkedList_Verifier();
        }

        [Test]
        [Category("LL InsertAt")]
        public void Add_To_Empty( [Values(0u, 2u, 10u)]uint location)
        {
            LL.InsertAt(10, location);
            int[] correct = new int[] { 10 };

            LL.TestList(correct);
        }

        [Test]
        [Category("LL InsertAt")]
        public void Add_To_Single_Item_List([Values(0u, 1u, 2u)]uint location)
        {
            int [] correct = new int[] { 5, 5 };
            int valueToInsert = 10;

            if (location >= 0 && location < correct.Length)
                correct[location] = valueToInsert;
            else if (location >= correct.Length)
                correct[correct.Length - 1] = valueToInsert;

            // put the '5' in
            LL.InsertAtFront(5);

            LL.InsertAt(valueToInsert, location);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL InsertAt")]
        public void Add_To_Double_Item_List([Values(0u, 1u, 2u, 3u)]uint location)
        {
            int valueToInsert = 10;
            int[] correct = null; 
            switch(  location)
            {
                case 0u:
                    correct = new int[] { 10, 5, 4 };
                    break;
                case 1u:
                    correct = new int[] { 5, 10, 4 };
                    break;
                case 2u:
                    goto case 3u;
                case 3u:
                    correct = new int[] { 5, 4, 10 };
                    break;
            }
            
            // put the '5, 4' in
            LL.InsertAtFront(4);
            LL.InsertAtFront(5);

            LL.InsertAt(valueToInsert, location);

            LL.TestList(correct);
       }

        [Test]
        [Category("LL InsertAt")]
        public void Add_To_MultiItem_List([Values(0u, 1u, 2u, 3u, 4u, 5u, 6u, 7u)]uint location)
        {
            int valueToInsert = 10;
            int[] correct = null;
            switch (location)
            {
                case 0u:
                    correct = new int[] {10, 1, 2, 3, 4, 5};
                    break;
                case 1u:
                    correct = new int[] { 1, 10, 2, 3, 4, 5 };
                    break;
                case 2u:
                    correct = new int[] { 1, 2, 10, 3, 4, 5 };
                    break;
                case 3u:
                    correct = new int[] { 1, 2, 3, 10, 4, 5 };
                    break;
                case 4u:
                    correct = new int[] { 1, 2, 3, 4, 10, 5 };
                    break;
                case 5u:
                    goto case 7;
                case 6u:
                    goto case 7;
                case 7u:
                    correct = new int[] { 1, 2, 3, 4, 5, 10 };
                    break;
            }

            // put the '5' in
            LL.InsertAtFront(5);
            LL.InsertAtFront(4);
            LL.InsertAtFront(3);
            LL.InsertAtFront(2);
            LL.InsertAtFront(1);

            LL.InsertAt(valueToInsert, location);

            LL.TestList(correct);
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_LL_RemoveAt
    {
        LinkedList_Verifier LL;

        [SetUp]
        protected void SetUp()
        {
            LL = new LinkedList_Verifier();
        }

        [Test]
        [Category("LL RemoveAt")]
        public void Remove_From_Empty([Values(0u, 2u, 10u)]uint location)
        {
            int[] correct = new int[0];
            LL.RemoveAt(location);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveAt")]
        public void Reomve_At_Single_Item_List([Values(0u, 1u, 2u)]uint location)
        {
            int[] correct = null;
            switch (location)
            {
                case 0u:
                    correct = new int[0];
                    break;
                case 1u:
                    goto case 2;
                case 2u:
                    correct = new int[] { 5 };
                    break;
            }

            // put the '5' in, so we can remove it.
            LL.InsertAtFront(5);

            LL.RemoveAt(location);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveAt")]
        public void Remove_From_Double_Item_List([Values(0u, 1u, 2u, 3u, 30u)]uint location)
        {
            int[] correct = null;
            switch (location)
            {
                case 0u:
                    correct = new int[] { 4, 5 };
                    break;
                case 1u:
                    correct = new int[] { 3, 5};
                    break;
                case 2u:
                    correct = new int[] { 3, 4 };
                    break;
                case 3u:
                    goto case 30;
                case 30u:
                    correct = new int[] { 3, 4, 5 };
                    break;
            }

            // put the '5, 4, 3' in
            LL.InsertAtFront(5);
            LL.InsertAtFront(4);
            LL.InsertAtFront(3);

            LL.RemoveAt(location);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveAt")]
        public void Remove_From_MultiItem_List([Values(0u, 1u, 2u, 3u, 4u, 5u, 6u, 7u)]uint location)
        {
            int[] correct = null;
            switch (location)
            {
                case 0u:
                    correct = new int[] { 2, 3, 4, 5 };
                    break;
                case 1u:
                    correct = new int[] { 1, 3, 4, 5 };
                    break;
                case 2u:
                    correct = new int[] { 1, 2, 4, 5 };
                    break;
                case 3u:
                    correct = new int[] { 1, 2, 3, 5 };
                    break;
                case 4u:
                    correct = new int[] { 1, 2, 3, 4 };
                    break;
                case 5u:
                    goto case 7;
                case 6u:
                    goto case 7;
                case 7u:
                    correct = new int[] { 1, 2, 3, 4, 5 };
                    break;
            }

            // put the '5' in
            LL.InsertAtFront(5);
            LL.InsertAtFront(4);
            LL.InsertAtFront(3);
            LL.InsertAtFront(2);
            LL.InsertAtFront(1);

            LL.RemoveAt(location);

            LL.TestList(correct);
        }
    }


    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_IGNORE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_LL_InsertInOrder
    {
        LinkedList_Verifier LL;

        [SetUp]
        protected void SetUp()
        {
            LL = new LinkedList_Verifier();
        }

        [Test]
        [Category("LL InsertInOrder")]
        public void Add_To_Empty()
        {
            int valueToAdd = 10;
            LL.InsertInOrder(valueToAdd);
            int[] correct = new int[] { valueToAdd };

            LL.TestList(correct);
        }

        [Test]
        [Category("LL InsertInOrder")]
        public void Add_To_Single_Item_List([Values(0, 2)] int valueToAdd)
        {
            int[] correct = null;
            switch (valueToAdd )
            {
                case 0:
                    correct = new int[] { 0, 1 };
                    break;
                case 2:
                    correct = new int[] { 1, 2 };
                    break;
            }

            LL.InsertAtFront(1);
            LL.InsertInOrder(valueToAdd);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL InsertInOrder")]
        public void Add_To_Two_Item_List([Values(0, 2, 4, 10)] int valueToAdd)
        {
            int[] correct = null;
            switch (valueToAdd)
            {
                case 0:
                    correct = new int[] { 0, 1, 3 };
                    break;
                case 2:
                    correct = new int[] { 1, 2, 3 };
                    break;
                case 4:
                    correct = new int[] { 1, 3, 4 };
                    break;
                case 10:
                    correct = new int[] { 1, 3, 10 };
                    break;
            }

            LL.InsertAtFront(3);
            LL.InsertAtFront(1);
            LL.InsertInOrder(valueToAdd);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL InsertInOrder")]
        public void Add_To_Multi_Item_List([Values(-10, 0, 2, 4, 6, 8, 100)] int valueToAdd)
        {
            int[] correct = null;
            switch (valueToAdd)
            {
                case -10:
                    correct = new int[] { -10, 1, 3, 5, 7 };
                    break;
                case 0:
                    correct = new int[] { 0, 1, 3, 5, 7 };
                    break;
                case 2:
                    correct = new int[] { 1, 2, 3, 5, 7 };
                    break;
                case 4:
                    correct = new int[] { 1, 3, 4, 5, 7 };
                    break;
                case 6:
                    correct = new int[] { 1, 3, 5, 6, 7 };
                    break;
                case 8:
                    correct = new int[] { 1, 3, 5, 7, 8 };
                    break;
                case 100:
                    correct = new int[] { 1, 3, 5, 7, 100 };
                    break;
            }

            LL.InsertAtFront(7);
            LL.InsertAtFront(5);
            LL.InsertAtFront(3);
            LL.InsertAtFront(1);
            LL.InsertInOrder(valueToAdd);

            LL.TestList(correct);
        }
    }

    [TestFixture]
    [Timeout(2000)] // 2 seconds default timeout
    [Description(TestHelpers.TEST_SUITE_IGNORE_DESC)] // tags this as an exercise to be graded...
    public class NUnit_Tests_LL_RemoveInOrder
    {
        LinkedList_Verifier LL;

        [SetUp]
        protected void SetUp()
        {
            LL = new LinkedList_Verifier();
        }

        [Test]
        [Category("LL RemoveByValue")]
        public void Remove_From_Empty([Values(0, 2, 10)]int valueToRemove)
        {
            int[] correct = new int[0];
            LL.RemoveByValue(valueToRemove);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveByValue")]
        public void RemoveValue_Single_Item_List([Values(0, 5, 10)]int valueToRemove)
        {
            int[] correct = null;
            switch (valueToRemove)
            {
                case 0:
                    correct = new int[] { 5 };
                    break;
                case 5:
                    correct = new int[0];
                    break;
                case 10:
                    goto case 0;
            }

            // put the '5' in, so we can remove it.
            LL.InsertAtFront(5);

            LL.RemoveByValue(valueToRemove);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveByValue")]
        public void Remove_From_Double_Item_List([Values(-20, 3, 4, 5, 10, 200)]int valueToRemove)
        {
            int[] correct = null;
            switch (valueToRemove)
            {
                case -20:
                    correct = new int[] { 4, 5 };
                    break;
                case 3:
                    goto case -20;
                case 4:
                    correct = new int[] { 5 };
                    break;
                case 5:
                    correct = new int[] { 4 };
                    break;
                case 10:
                    goto case -20;
                case 200:
                    goto case -20;
            }

            // put the '5, 4, 3' in
            LL.InsertAtFront(5);
            LL.InsertAtFront(4);

            LL.RemoveByValue(valueToRemove);

            LL.TestList(correct);
        }

        [Test]
        [Category("LL RemoveByValue")]
        public void Remove_From_MultiItem_List([Values(-30, 0, 1, 2, 3, 4, 5, 6, 7, 70)]int valueToRemove)
        {
            int[] correct = null;
            switch (valueToRemove)
            {
                case -30:
                    correct = new int[] { 1, 2, 3, 4, 5 };
                    break;
                case 0:
                    goto case -30;
                case 1:
                    correct = new int[] { 2, 3, 4, 5 };
                    break;
                case 2:
                    correct = new int[] { 1, 3, 4, 5 };
                    break;
                case 3:
                    correct = new int[] { 1, 2, 4, 5 };
                    break;
                case 4:
                    correct = new int[] { 1, 2, 3, 5 };
                    break;
                case 5:
                    correct = new int[] { 1, 2, 3, 4 };
                    break;
                case 6:
                    goto case -30;
                case 7:
                    goto case -30;
                case 70:
                    goto case -30;
            }

            // put the '5' in
            LL.InsertAtFront(5);
            LL.InsertAtFront(4);
            LL.InsertAtFront(3);
            LL.InsertAtFront(2);
            LL.InsertAtFront(1);

            LL.RemoveByValue(valueToRemove);

            LL.TestList(correct);
        }
    }

}