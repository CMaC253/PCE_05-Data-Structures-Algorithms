#define TESTING
using System;

/*
 * STUDENTS: Your answers (your code) goes into this file!!!!
 * 
  * NOTE: In addition to your answers, this file also contains a 'main' method, 
 *      in case you want to run a normal console application.
 * 
 * If you want to / have to put something into 'Main' for these PCEs, then put that 
 * into the Program.Main method that is located below, 
 * then select this project as startup object 
 * (Right-click on the project, then select 'Set As Startup Object'), then run it 
 * just like any other normal, console app: use the menu item Debug->Start Debugging, or 
 * Debug->Start Without Debugging
 * 
 */

namespace PCE_StarterProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
    }

    public class MyLinkedList
    {
        public class LinkedListNode
        {
            public int m_data;
            public LinkedListNode m_next;

        }

        // first item in the list, automtically given the value null
        protected LinkedListNode m_first;


        // First, in your own words, summarize the important parts of the
        // "linked list traversal" schema/plan/pattern/strategy, as discussed
        // in class:
        //
        // Linked list traversal is important to find values we can switch, remove, add
        // and anything in between to manipulate the linked list.
        //


        public void Print()
        {
           //The temp variable cur walks down the node list
           //And checks for if cur = null, so while it doesnt
           //cur will equal cur.next.

            LinkedListNode cur = m_first;
            while (null != cur)
            {
                Console.WriteLine(cur.m_data);
                cur = cur.m_next;
            }
        }

        // Try to find a given BY VALUE

        public bool Find(int target)
        {
            // While cur's data does not equal target AND while cur is not null
            // The temp variable will crawl down the list of nodes.
            // If at any point that the data for cur is equal to the target
            // the method will return true, else it will crawl until
            // cur is = to null, then it will return false.

            LinkedListNode cur = m_first;
            while (cur.m_data != target && cur !=null)
            {
                if (cur.m_data == target)
                    return true;

                cur = cur.m_next;
            }
            return false;

        }


        // Try to find a given BY VALUE
        public bool PrintAllMatching(int target)
        {
            // While looking through the list for null or the target value
            //Cur will check if the data in the node equals target
            //If it does then it prints it out and still adds one to the counter
            //and traverses cur
            //If not cur will still traverse and add one to the counter to continue the while loop.
            //If none of these are true then we return false.

            int counter = 0;
            LinkedListNode cur = m_first;
            while (cur.m_data != target && cur != null)
            {
                if(cur.m_data == target)
                {
                    Console.WriteLine($"Target value: {target} , found in node {counter}");
                    cur = cur.m_next;
                    counter++;
                }

                cur = cur.m_next;
                counter++;
            }
            return false;
        }

        // from previous ICEs:
        public void InsertAtFront(int value)
        {
            if (m_first == null)
            {
                LinkedListNode newNode = new LinkedListNode();
                newNode.m_data = value;
                m_first =  newNode;
                return;
            }
            LinkedListNode dupNode  = new LinkedListNode();
            dupNode.m_data = value;
            dupNode.m_next = m_first;
            m_first = dupNode;
        }

        //For the InsertAt method, it takes a O(n) process to find the 
        //Node ready for input, but the actualy insertion is O(1)
        public void InsertAt(int newData, uint index)
        {
            LinkedListNode ln = new LinkedListNode();
            ln.m_data = newData;
            if(m_first == null || index == 0)
            {
                ln.m_next = m_first;
                m_first = ln;
                return;
            }
            LinkedListNode cur = m_first;
            int counter = 0;
            while(cur.m_next!=null && counter < index-1 )
            {
                cur = cur.m_next;
                counter++;
            }
            ln.m_next = cur.m_next;
            cur.m_next = ln;

        }

       //Same thing with the RemoveAt method
       //It takes O(n) to find the node to delete, then
       //the delete process itself is O(1)
        public void RemoveAt(uint index)
        {
           if (m_first == null) return;

            if(index ==0)
            {
                m_first = m_first.m_next;
                return;
            }
            LinkedListNode cur = m_first;
            int counter = 0;
            while (cur.m_next != null && counter < index - 1)
            {
                cur = cur.m_next;
                counter++;
            }
            if(counter == index-1 && cur.m_next!=null)
            {
                cur.m_next = cur.m_next.m_next;
            }
            

        }

        // Add newData, so that it's in the proper sorted order (lowest to highest)
        // Note that this method assumes that the list is already properly sorted
        // (i.e., you start from an empty list,and ONLY call this method to add things
        // to the list)
        public void InsertInOrder(int newData)
        {
            LinkedListNode ln = new LinkedListNode();
            ln.m_data = newData;

            if(m_first ==null)
            {
                m_first = ln;
                return;
            }
            else if(ln.m_data<m_first.m_data)
            {
                ln.m_next = m_first;
                m_first = ln;
                return;
            }

            LinkedListNode cur = m_first;

            bool loop = false;
            while (cur.m_next != null)
            {
                if (cur.m_next.m_data > newData)
                {
                    ln.m_next = cur.m_next;
                    cur.m_next = ln;
                    loop = false;
                    break;
                }
                cur = cur.m_next;
            }
            if (!loop)
                cur.m_next = ln;
        }

        public int RemoveByValue(int value)
        {
            int counter = 0;
            if (value < 0)
                throw new ArgumentOutOfRangeException("Not in the range.");
            if (m_first == null)
                return 0;
            if (value > counter)
                value = counter - 1;

            LinkedListNode cur = m_first;
            int result=0;

            if(value ==0 )
            {
                result = cur.m_data;
                m_first = cur.m_next;
            }
            else
            {
               for(int i = 0; i<value; i++ )
                {
                    cur = cur.m_next;

                    result = cur.m_next.m_data;

                    cur.m_next = cur.m_next.m_next;
                }

            }

            return result;
        }

        public MyLinkedList Clone()
        {
            // Think about what your code does in each of
            // the three important steps of the 'list traversal' schema, 
            // in order to implement this method.
            // You are not required to write this down, but it's recommended that you
            // do so.

            // YOUR CODE GOES HERE!!!
            return null;
            throw new Exception("YOU NEED TO IMPLEMENT THIS!");
        }


        // Not really used in this week's PCE
        public void PrintAtLocation(int index)
        {
            // Remember that '0' is the very first item in the list
            // Assuming that there are any items in the list
            // YOUR CODE GOES HERE!!!
        }
    }
}